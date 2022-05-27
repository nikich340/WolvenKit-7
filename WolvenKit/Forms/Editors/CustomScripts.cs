using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using WolvenKit.App;
using WolvenKit.App.Model;
using WolvenKit.Common.Model;
using WolvenKit.Common.Services;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Types;

namespace WolvenKit.Forms
{
    public class CustomScripts
    {
        private CR2WFile cr2w, fcd;
        public bool LogAll; // 0 - critical, 1 - all
        private /*readonly*/ LoggerService Logger;
        public CustomScripts(bool _LogAll = false)
        {
            Logger = MainController.Get().Logger;
            LogAll = _LogAll;
            cr2w = null;
            fcd = null;
        }
        public EFileReadErrorCodes LoadCR2W(String fullpath)
        {
            using (var fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                // read main cr2w
                cr2w = new CR2WFile();
                EFileReadErrorCodes ret, ret2;
                ret = cr2w.Read(reader);
                ret2 = EFileReadErrorCodes.NoError;

                // try read FCD
                if (ret == EFileReadErrorCodes.NoError && cr2w.chunks[0].REDType == "CEntityTemplate")
                {
                    CByteArray fcdBytes = ((CEntityTemplate)cr2w.chunks[0].data).FlatCompiledData;
                    fcd = new CR2WFile();
                    ret2 = fcd.Read(fcdBytes.GetBytes());
                }
                else
                {
                    fcd = null;
                }
                if (ret2 != EFileReadErrorCodes.NoError)
                {
                    return ret2;
                }
                return ret;
            }
        }

        public void ArdStableHWScript(bool insideFCD = false)
        {
            CR2WFile current_cr2w;
            string dangleName, furName;
            if (insideFCD)
            {
                current_cr2w = fcd;
                dangleName = "CAnimDangleComponent #1";
                furName = "CFurComponent #2";
            } else
            {
                current_cr2w = cr2w;
                dangleName = "CAnimDangleComponent #2";
                furName = "CFurComponent #3";
            }
            var mapChunks = current_cr2w.GetChunksMapByPrefix("");

            /*foreach (var key_value in mapChunks)
            {
                Logger.LogString($"CHUNK: {key_value.Key}");
            }*/

            if (mapChunks.ContainsKey(dangleName) && mapChunks.ContainsKey(furName))
            {
                var dangleChunk = mapChunks[dangleName];
                var dangleVar = (CAnimDangleComponent)dangleChunk.data;

                var furChunk = mapChunks[furName];
                var furVar = (CFurComponent)furChunk.data;

                // create CMeshSkinningAttachment #4 chunk as children of CAnimDangleComponent #2
                var skinChunk = current_cr2w.CreateChunk("CMeshSkinningAttachment", current_cr2w.chunks.Count, dangleChunk);
                var skinVar = (CMeshSkinningAttachment)skinChunk.data;

                // create CAnimDangleConstraint_Dyng #5 chunk as children of CAnimDangleComponent #2
                /* Ding dyng ding ... */
                var dyngChunk = current_cr2w.CreateChunk("CAnimDangleConstraint_Dyng", current_cr2w.chunks.Count, dangleChunk);
                var dyngVar = (CAnimDangleConstraint_Dyng)dyngChunk.data;

                // add a AttachmentsChild handle CMeshSkinningAttachment #4 in CAnimDangleComponent #2
                /* "0" is a "name", doesn't matter for arrays */
                var dangleHandle = new CHandle<IAttachment>(current_cr2w, dangleVar.AttachmentsChild, "0");
                dangleHandle.SetValue(skinChunk);
                dangleVar.AttachmentsChild.Add(dangleHandle);

                // add variable parent = CAnimDangleComponent #2 in CMeshSkinningAttachment #4
                /* here var name matters! */
                skinVar.Parent = new CPtr<CNode>(current_cr2w, skinVar, "parent");
                skinVar.Parent.SetValue(dangleChunk);

                // add variable child = CFurComponent #3 in CMeshSkinningAttachment #4
                skinVar.Child = new CPtr<CNode>(current_cr2w, furVar, "child");
                skinVar.Child.SetValue(furChunk);

                // add variable transformParent = CMeshSkinningAttachment #4 in CFurComponent #3
                furVar.TransformParent = new CPtr<CHardAttachment>(current_cr2w, furVar, "transformParent");
                furVar.TransformParent.SetValue(skinChunk);

                // add a AttachmentsReference handle CMeshSkinningAttachment #4 in CFurComponent #3
                var furHandle = new CHandle<IAttachment>(current_cr2w, furVar.AttachmentsReference, "0");
                furHandle.SetValue(skinChunk);
                furVar.AttachmentsReference.Add(furHandle);

                // add variable constraint = CAnimDangleConstraint_Dyng #5 in CAnimDangleComponent #2
                dangleVar.Constraint = new CPtr<IAnimDangleConstraint>(current_cr2w, dangleVar, "constraint");
                dangleVar.Constraint.SetValue(dyngChunk);

                // add variable dyng = [CDyngResource:path] in CAnimDangleConstraint_Dyng #5
                dyngVar.Dyng = new CHandle<CDyngResource>(current_cr2w, dyngVar, "dyng");
                dyngVar.Dyng.SetValue("CDyngResource:characters\\models\\animals\\horse\\draft\\model\\dyng_h_02_hd__simple.w3dyng");
            }

            if (!insideFCD && mapChunks.ContainsKey("CEntityTemplate #0"))
            {
                // process FCD
                ArdStableHWScript(true);
            }
        }
		
        public int RemoveFurScript(bool insideFCD = false)
        {
            CR2WFile current_cr2w;
            int ret = 0;
            if (insideFCD)
            {
                current_cr2w = fcd;
            }
            else
            {
                current_cr2w = cr2w;
            }
            var mapChunks = current_cr2w.GetChunksMapByPrefix("");

            foreach (var name_chunk in mapChunks)
            {
                //Logger.LogString($"CHUNK: {name_chunk.Key}");
                if (name_chunk.Value.REDType == "CFurComponent")
                {
                    var furVar = (CFurComponent)name_chunk.Value.data;
                    if (furVar.FurMesh != null && !string.IsNullOrEmpty(furVar.FurMesh.DepotPath))
                    {
                        furVar.FurMesh.SetValue("CFurMeshResource:removed.w3fur");
                        ret += 1;

                        if (LogAll)
                            Logger.LogString($"RemoveFurScript: {current_cr2w.FileName}");
                    }
                }
            }

            if (!insideFCD && mapChunks.ContainsKey("CEntityTemplate #0"))
            {
                // process FCD
                ret = ret + RemoveFurScript(true);
            }
			return ret;
		}
			
        public int ExportApx(string savePath, bool scalePoses)
        {
            int ret = 0;
            var mapChunks = cr2w.GetChunksMapByPrefix("CFurMeshResource");
            var kwargs = new Dictionary<string, string>();

            // try set correct precision
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberDecimalDigits = 7;
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            foreach (var name_chunk in mapChunks)
            {
                ++ret;
                var furVar = (CFurMeshResource)name_chunk.Value.data;

                kwargs["splines"] = furVar.SplineMultiplier != null ? furVar.SplineMultiplier.REDValue : "4";
                // vertices
                kwargs["totalVerts"] = furVar.Positions != null ? furVar.Positions.Elements.Count.ToString() : "0";
                if (kwargs["totalVerts"] != "0")
                {
                    List<string> vertices = new List<string>();
                    foreach (Vector v in furVar.Positions.Elements)
                    {
                        vertices.Add($"{v.X.val * 100.0f:N7} {v.Y.val * 100.0f:N7} {v.Z.val * 100.0f:N7}");
                    }
                    kwargs["hair_verts"] = String.Join(", ", vertices);
                } else
                {
                    kwargs["hair_verts"] = "";
                }

                // UVs
                kwargs["n_UVs"] = furVar.Uvs != null ? furVar.Uvs.Elements.Count.ToString() : "0";
                if (kwargs["n_UVs"] != "0")
                {
                    List<string> uvs = new List<string>();
                    foreach (Vector2 v in furVar.Uvs.Elements)
                    {
                        uvs.Add($"{v.X.val:N7} {v.Y.val:N7}");
                    }
                    kwargs["UVs"] = String.Join(", ", uvs);
                }
                else
                {
                    kwargs["UVs"] = "";
                }

                // End Indices
                kwargs["numHairs"] = furVar.EndIndices != null ? furVar.EndIndices.Elements.Count.ToString() : "0";
                if (kwargs["numHairs"] != "0")
                {
                    List<string> endIndices = new List<string>();
                    foreach (CUInt32 v in furVar.EndIndices.Elements)
                    {
                        endIndices.Add($"{v.val}");
                    }
                    kwargs["endIndices"] = String.Join(" ", endIndices);
                }
                else
                {
                    kwargs["endIndices"] = "";
                }

                // Face Indices
                kwargs["n_faceIndices"] = furVar.FaceIndices != null ? furVar.FaceIndices.Elements.Count.ToString() : "0";
                kwargs["numFaces"] = furVar.FaceIndices != null ? (furVar.FaceIndices.Elements.Count / 3).ToString() : "0";
                if (kwargs["n_faceIndices"] != "0")
                {
                    List<string> faceIndices = new List<string>();
                    foreach (CUInt32 v in furVar.FaceIndices.Elements)
                    {
                        faceIndices.Add($"{v.val}");
                    }
                    kwargs["faceIndices"] = String.Join(" ", faceIndices);
                }
                else
                {
                    kwargs["faceIndices"] = "";
                }

                // Bone Indices
                if (kwargs["numHairs"] != "0" && furVar.BoneIndices != null)
                {
                    List<string> boneIndices = new List<string>();
                    foreach (Vector v in furVar.BoneIndices)
                    {
                        boneIndices.Add($"{(int)v.X.val} {(int)v.Y.val} {(int)v.Z.val} {(int)v.W.val}");
                    }
                    kwargs["boneIndices"] = String.Join(", ", boneIndices);
                }
                else
                {
                    kwargs["boneIndices"] = "";
                }

                // Bone Weights
                if (kwargs["numHairs"] != "0" && furVar.BoneWeights != null)
                {
                    List<string> boneWeights = new List<string>();
                    foreach (Vector v in furVar.BoneWeights)
                    {
                        boneWeights.Add($"{v.X.val:N7} {v.Y.val:N7} {v.Z.val:N7} {v.W.val:N7}");
                    }
                    kwargs["boneWeights"] = String.Join(", ", boneWeights);
                }
                else
                {
                    kwargs["boneWeights"] = "";
                }

                // Bone Count
                kwargs["numBones"] = furVar.BoneCount != null ? furVar.BoneCount.REDValue : "0";

                // Bone Names
                kwargs["boneNamesSize"] = furVar.BoneNames != null ? furVar.BoneNames.Elements.Count.ToString() : "0";
                if (kwargs["boneNamesSize"] != "0")
                {
                    List<string> boneNames = new List<string>();
                    List<string> boneNamesList = new List<string>();
                    foreach (CName v in furVar.BoneNames)
                    {
                        boneNamesList.Add($"<value type=\"String\">{v.Value}</value>");
                        foreach (char c in v.Value)
                        {
                            boneNames.Add($"{((short)c)}");
                        }
                        boneNames.Add("0");
                    }
                    kwargs["boneNamesSize"] = boneNames.Count.ToString();
                    kwargs["boneNames"] = String.Join(" ", boneNames);
                    kwargs["boneNameList"] = String.Join("\n            ", boneNamesList);
                }
                else
                {
                    kwargs["boneNames"] = "";
                    kwargs["boneNameList"] = "";
                }

                // Bone Parents
                kwargs["num_boneParents"] = furVar.BoneParents != null ? furVar.BoneParents.Elements.Count.ToString() : "0";
                if (kwargs["num_boneParents"] != "0")
                {
                    List<string> boneParents = new List<string>();
                    foreach (CInt32 v in furVar.BoneParents)
                    {
                        boneParents.Add($"{v.val}");
                    }
                    kwargs["boneParents"] = String.Join(" ", boneParents);
                }
                else
                {
                    kwargs["boneParents"] = "";
                }

                // Bind Poses
                float scale = 1.0f;
                if (scalePoses)  // "the W vector should always be scale by x100, but the X, Y, Z vectors you should let the user choose" @Ard Carraigh
                    scale = 100.0f;

                if (kwargs["numBones"] != "0" && furVar.BindPoses != null)
                {
                    List<string> bindPoses = new List<string>();
                    foreach (CMatrix m in furVar.BindPoses)
                    {
                        bindPoses.Add($"{m.X.X.val * scale:N7} {m.X.Y.val * scale:N7} {m.X.Z.val * scale:N7} {m.X.W.val * scale:N7}");
                        bindPoses.Add($"{m.Y.X.val * scale:N7} {m.Y.Y.val * scale:N7} {m.Y.Z.val * scale:N7} {m.Y.W.val * scale:N7}");
                        bindPoses.Add($"{m.Z.X.val * scale:N7} {m.Z.Y.val * scale:N7} {m.Z.Z.val * scale:N7} {m.Z.W.val * scale:N7}");
                        bindPoses.Add($"{m.W.X.val * 100.0f:N7} {m.W.Y.val * 100.0f:N7} {m.W.Z.val * 100.0f:N7} {m.W.W.val * 100.0f:N7}");
                    }
                    kwargs["bindPoses"] = String.Join(", ", bindPoses);
                }
                else
                {
                    kwargs["bindPoses"] = "";
                }

                // Bone Spheres
                kwargs["numBonesSpheres"] = furVar.BoneSphereLocalPosArray != null ? furVar.BoneSphereLocalPosArray.Elements.Count.ToString() : "0";
                if (kwargs["numBonesSpheres"] != "0")
                {
                    List<string> boneSpheres = new List<string>();
                    for (int j = 0; j < furVar.BoneSphereLocalPosArray.Elements.Count; ++j)
                    {
                        Vector vec = furVar.BoneSphereLocalPosArray.Elements[j];
                        CUInt32 idx = furVar.BoneSphereIndexArray.Elements[j];
                        CFloat rad = furVar.BoneSphereRadiusArray.Elements[j];
                        boneSpheres.Add($"{idx} {rad.val * 100.0f:N7} {vec.X.val:N7} {vec.Y.val:N7} {vec.Z.val:N7}");
                    }
                    kwargs["boneSpheres"] = String.Join(", ", boneSpheres);
                } else
                {
                    kwargs["boneSpheres"] = "";
                }

                // Bone Spheres Connections
                kwargs["numBoneCapsuleIndices"] = furVar.BoneCapsuleIndices != null ? furVar.BoneCapsuleIndices.Elements.Count.ToString() : "0";
                if (kwargs["numBoneCapsuleIndices"] != "0")
                {
                    List<string> boneCapsuleIndices = new List<string>();
                    foreach (CUInt32 v in furVar.BoneCapsuleIndices)
                    {
                        boneCapsuleIndices.Add($"{v.val}");
                    }
                    kwargs["boneCapsuleIndices"] = String.Join(" ", boneCapsuleIndices);
                    kwargs["numBoneCapsules"] = (furVar.BoneCapsuleIndices.Elements.Count / 2).ToString();
                }
                else
                {
                    kwargs["boneCapsuleIndices"] = "";
                    kwargs["numBoneCapsules"] = "0";
                }

                // Pin Constraints
                kwargs["numPinConstraints"] = furVar.PinConstraintsLocalPosArray != null ? furVar.PinConstraintsLocalPosArray.Elements.Count.ToString() : "0";
                if (kwargs["numPinConstraints"] != "0")
                {
                    List<string> pinConstraints = new List<string>();
                    for (int j = 0; j < furVar.PinConstraintsLocalPosArray.Elements.Count; ++j)
                    {
                        Vector vec = furVar.PinConstraintsLocalPosArray.Elements[j];
                        CUInt32 idx = furVar.PinConstraintsIndexArray.Elements[j];
                        CFloat rad = furVar.PinConstraintsRadiusArray.Elements[j];
                        pinConstraints.Add($"{idx} {rad.val * 100.0f:N7} {vec.X.val * 100.0f:N7} {vec.Y.val * 100.0f:N7} {vec.Z.val * 100.0f:N7}");
                    }
                    kwargs["pinConstraints"] = String.Join(",", pinConstraints);
                }
                else
                {
                    kwargs["pinConstraints"] = "";
                }
            }

            // writing apx file
            string apxTemplate = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + "/Resources/ApxTemplate.txt");
            Debug.WriteLine($"kwargs: {kwargs.Count}");

            // manual formatting since C# can't help here
            StringBuilder apxResult = new StringBuilder();
            string argName = "";
            bool arg = false;
            for (int i = 0; i < apxTemplate.Length; ++i)
            {
                if (apxTemplate[i] == '{')
                {
                    arg = true;
                } else if (apxTemplate[i] == '}')
                {
                    if (kwargs.ContainsKey(argName))
                        apxResult.Append(kwargs[argName]);
                    else
                        Debug.WriteLine("arg is missed: " + argName);
                    argName = "";
                    arg = false;
                } else
                {
                    if (arg)
                        argName += apxTemplate[i];
                    else
                        apxResult.Append(apxTemplate[i]);
                }
            }
            File.WriteAllText(savePath, apxResult.ToString());

            return ret;
        }
		
        public void SaveCR2W(String fullpath)
        {
            using (var fs = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
            using (var writer = new BinaryWriter(fs))
            {
                // try save FCD
                if (cr2w.chunks[0].REDType == "CEntityTemplate")
                {
                    fcd.Write(((CEntityTemplate)cr2w.chunks[0].data).FlatCompiledData);
                    if (LogAll)
                        Logger.LogString($"[CS] SAVE: ok = FCD. Bytes: {((CEntityTemplate)cr2w.chunks[0].data).FlatCompiledData.ToString()}\r\n", Logtype.Success);
                }
                // save main cr2w
                cr2w.Write(writer);

                if (LogAll)
                    Logger.LogString($"[CS] SAVE: CR2W ok = {fullpath}. Bytes: {fs.Length}\r\n", Logtype.Success);
            }
        }
    }
}
