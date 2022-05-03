using System;
using System.Collections.Generic;
using System.IO;
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
                if (cr2w.chunks[0].REDType == "CEntityTemplate")
                {
                    CByteArray fcdBytes = ((CEntityTemplate)cr2w.chunks[0].data).FlatCompiledData;
                    fcd = new CR2WFile();
                    ret2 = fcd.Read(fcdBytes.GetBytes());
                    if (LogAll || ret2 != EFileReadErrorCodes.NoError)
                        Logger.LogString($"[CS] READ FCD: result = {ret2}. Bytes: {fcdBytes.GetBytes().Length}\r\n", ret2 == EFileReadErrorCodes.NoError ? Logtype.Success : Logtype.Error);
                } else
                {
                    fcd = null;
                }
                if (LogAll || ret != EFileReadErrorCodes.NoError)
                    Logger.LogString($"[CS] READ CR2W: result = {ret}. Bytes: {fs.Length}\r\n", ret == EFileReadErrorCodes.NoError ? Logtype.Success : Logtype.Error);
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
        public void SaveCR2W(String fullpath)
        {
            using (var fs = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
            using (var writer = new BinaryWriter(fs))
            {
                // try save FCD
                if (cr2w.chunks[0].REDType == "CEntityTemplate")
                {
                    fcd.Write( ((CEntityTemplate)cr2w.chunks[0].data).FlatCompiledData );
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
