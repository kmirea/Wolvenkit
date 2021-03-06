using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SDefaultStateTransition : CVariable
	{
		[Ordinal(1)] [RED("m_StateNameN")] 		public CName M_StateNameN { get; set;}

		[Ordinal(2)] [RED("m_TimeToStartCheckingF")] 		public CFloat M_TimeToStartCheckingF { get; set;}

		public SDefaultStateTransition(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}