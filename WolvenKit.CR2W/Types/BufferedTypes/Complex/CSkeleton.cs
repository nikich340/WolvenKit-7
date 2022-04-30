﻿using System.Collections.Generic;
using System.IO;

using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;
using FastMember;

namespace WolvenKit.CR2W.Types
{

    public partial class CSkeleton : CResource
    {
       

        [Ordinal(1000)] [REDBuffer(true)] public CCompressedBuffer<SSkeletonRigData> rigdata { get; set; }

        public CSkeleton(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
            rigdata = new CCompressedBuffer<SSkeletonRigData>(cr2w, this, nameof(rigdata)) { IsSerialized = true };
        }

        public override void Read(BinaryReader file, uint size)
        {
            base.Read(file, size);

            // get bonecount for compressed buffers
            int bonecount = Bones.Count;

            rigdata.Read(file, (uint)bonecount * 48, bonecount);
            
            //SetIsSerialized() in base
        }

        public override void Write(BinaryWriter file)
        {
            base.Write(file);

            rigdata.Write(file);
        }


    }
}