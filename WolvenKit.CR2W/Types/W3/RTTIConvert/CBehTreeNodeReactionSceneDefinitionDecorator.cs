using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeNodeReactionSceneDefinitionDecorator : CBehTreeNodeConditionReactionEventDefinition
	{
		[Ordinal(1)] [RED("roles", 2,0)] 		public CArray<CName> Roles { get; set;}

		[Ordinal(2)] [RED("inInWorkBranch")] 		public CBehTreeValBool InInWorkBranch { get; set;}

		public CBehTreeNodeReactionSceneDefinitionDecorator(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeNodeReactionSceneDefinitionDecorator(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}