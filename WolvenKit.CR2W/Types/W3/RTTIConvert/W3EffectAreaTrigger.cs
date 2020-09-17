using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3EffectAreaTrigger : CGameplayEntity
	{
		[Ordinal(1)] [RED("effect")] 		public CEnum<EEffectType> Effect { get; set;}

		[Ordinal(2)] [RED("useDefaultValuesFromXML")] 		public CBool UseDefaultValuesFromXML { get; set;}

		[Ordinal(3)] [RED("effectDuration")] 		public CFloat EffectDuration { get; set;}

		[Ordinal(4)] [RED("customDamageValuePerSec")] 		public SAbilityAttributeValue CustomDamageValuePerSec { get; set;}

		[Ordinal(5)] [RED("immunityFact")] 		public CString ImmunityFact { get; set;}

		[Ordinal(6)] [RED("customParams")] 		public CHandle<W3BuffCustomParams> CustomParams { get; set;}

		[Ordinal(7)] [RED("entitiesInRange", 2,0)] 		public CArray<CHandle<CActor>> EntitiesInRange { get; set;}

		public W3EffectAreaTrigger(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3EffectAreaTrigger(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}