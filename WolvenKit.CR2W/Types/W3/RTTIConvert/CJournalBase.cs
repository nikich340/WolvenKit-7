using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CJournalBase : CObject
	{
		[RED("guid")] 		public CGUID Guid { get; set;}

		[RED("baseName")] 		public CString BaseName { get; set;}

		[RED("order")] 		public CUInt32 Order { get; set;}

		[RED("uniqueScriptIdentifier")] 		public CName UniqueScriptIdentifier { get; set;}

		public CJournalBase(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CJournalBase(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}