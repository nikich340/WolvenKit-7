﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    /// <summary>
    /// A generic wrapper class for a single CVariable
    /// Format: [uint size] [ushort typeID] [ushort nameID] [byte[size] data]
    /// </summary>
    [DataContract(Namespace = "")]
    [REDMeta()]
    public class CVariantSizeTypeName : CVariable, IBufferVariantAccessor
    {
        public CVariable Variant { get; set; }

        public CVariantSizeTypeName(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }

        public override void Read(BinaryReader file, uint size)
        {
            CVariable parsedvar = null;
            var varsize = file.ReadUInt32();
            var buffer = file.ReadBytes((int)varsize - 4);
            using (var ms = new MemoryStream(buffer))
            using (var br = new BinaryReader(ms))
            {

                var typeId = br.ReadUInt16();
                var nameId = br.ReadUInt16();

                if (nameId == 0)
                {
                    return;
                }

                var typename = cr2w.names[typeId].Str;
                var varname = cr2w.names[nameId].Str;

                parsedvar = CR2WTypeManager.Create(typename, varname, cr2w, this);
                parsedvar.IsSerialized = true;
                parsedvar.Read(br, size);
            }

            Variant = parsedvar;
            SetIsSerialized();
        }

        public override void Write(BinaryWriter file)
        {

            UInt32 varsize = 4 + 4; //4 for the uint32 varsize, 4 for 2 x uint16 typeID and nameID
            byte[] varvalue;

            // use a temporary stream to write the variable and get the length of the variable
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                Variant.Write(bw);
                varsize += (UInt32)ms.Length;
                varvalue = ms.ToArray();
            }

            // write variable
            file.Write(varsize);
            file.Write(Variant.GettypeId());
            file.Write(Variant.GetnameId());
            file.Write(varvalue);
        }

        public override string ToString()
        {
            return Variant.ToString();
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var copy = (CVariantSizeTypeName)base.Copy(context);
            if (Variant != null)
                copy.Variant = Variant.Copy(context);
            return copy;
        }

        public override List<IEditableVariable> GetEditableVariables() => Variant?.GetEditableVariables();
        public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CVariantSizeTypeName(cr2w, parent, name);
    }
}
