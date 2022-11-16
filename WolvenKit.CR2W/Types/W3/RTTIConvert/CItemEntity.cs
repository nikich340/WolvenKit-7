using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CItemEntity : CEntity
	{
		[Ordinal(1)] [RED("timeToDespawn")] 		public CFloat TimeToDespawn { get; set;}

		[Ordinal(2)] [RED("reportToScript")] 		public CBool ReportToScript { get; set;}

		public CItemEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CItemEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}

    // nikich340 debug: REMOVE!
    public class NR_LocalizedStringStorage : CEntity
    {
        [Ordinal(1)] [RED("stringValues")] public CArray<LocalizedString> stringValues { get; set; }

        [Ordinal(2)] [RED("stringKeys")] public CArray<CString> stringKeys { get; set; }

        [Ordinal(2)] [RED("stringIds")] public CArray<CInt32> stringIds { get; set; }

        public NR_LocalizedStringStorage(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new NR_LocalizedStringStorage(cr2w, parent, name);

        public override void Read(BinaryReader file, uint size) => base.Read(file, size);

        public override void Write(BinaryWriter file) => base.Write(file);

    }
}
