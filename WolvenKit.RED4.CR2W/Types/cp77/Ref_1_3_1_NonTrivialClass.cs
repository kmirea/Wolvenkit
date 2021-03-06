using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Ref_1_3_1_NonTrivialClass : IScriptable
	{
		private CFloat _prop1;
		private CHandle<Ref_1_3_1_TrivialClass> _prop2;

		[Ordinal(0)] 
		[RED("prop1")] 
		public CFloat Prop1
		{
			get => GetProperty(ref _prop1);
			set => SetProperty(ref _prop1, value);
		}

		[Ordinal(1)] 
		[RED("prop2")] 
		public CHandle<Ref_1_3_1_TrivialClass> Prop2
		{
			get => GetProperty(ref _prop2);
			set => SetProperty(ref _prop2, value);
		}

		public Ref_1_3_1_NonTrivialClass(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
