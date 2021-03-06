using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimStateTransitionCondition_CompositeSimultaneous : animIAnimStateTransitionCondition
	{
		private CArray<CHandle<animIAnimStateTransitionCondition>> _conditions;

		[Ordinal(0)] 
		[RED("conditions")] 
		public CArray<CHandle<animIAnimStateTransitionCondition>> Conditions
		{
			get => GetProperty(ref _conditions);
			set => SetProperty(ref _conditions, value);
		}

		public animAnimStateTransitionCondition_CompositeSimultaneous(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
