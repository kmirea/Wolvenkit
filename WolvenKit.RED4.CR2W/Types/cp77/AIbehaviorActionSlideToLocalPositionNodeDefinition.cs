using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AIbehaviorActionSlideToLocalPositionNodeDefinition : AIbehaviorActionSlideNodeDefinition
	{
		private CHandle<AIArgumentMapping> _localOffset;

		[Ordinal(4)] 
		[RED("localOffset")] 
		public CHandle<AIArgumentMapping> LocalOffset
		{
			get => GetProperty(ref _localOffset);
			set => SetProperty(ref _localOffset, value);
		}

		public AIbehaviorActionSlideToLocalPositionNodeDefinition(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
