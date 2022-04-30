﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;
using FastMember;

namespace WolvenKit.CR2W.Types
{
    public partial class CQuestScriptBlock : CQuestGraphBlock
    {

        [Ordinal(1000)] [REDBuffer(true)] public CCompressedBuffer<CVariant> BufferParameters { get; set; }

        public CQuestScriptBlock(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
            BufferParameters = new CCompressedBuffer<CVariant>(cr2w, this, nameof(BufferParameters)) { IsSerialized = true };
        }

        public override void Read(BinaryReader file, uint size)
        {
            base.Read(file, size);

            while (true)
            {
                var nameId = file.ReadUInt16();

                if (nameId == 0)
                    break;

                // read cvariant
                var varname = cr2w.names[nameId].Str;
                CVariant cVariant = new CVariant(cr2w, BufferParameters, varname);
                cVariant.Read(file, 0);
                cVariant.IsSerialized = true;

                BufferParameters.AddVariableWithName(cVariant);
            }
            //SetIsSerialized() in base
        }

        public override void Write(BinaryWriter file)
        {
            base.Write(file);

            for (var i = 0; i < BufferParameters.Count; i++)
            {
                var variable = BufferParameters[i];

                file.Write(variable.GetnameId());

                variable.Write(file);
            }
            file.Write((ushort)0);
        }

    }
}