using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AIFSMTransitionDefinition : CVariable
	{
		private CUInt16 _destination;
		private CUInt16 _condition;

		[Ordinal(0)] 
		[RED("destination")] 
		public CUInt16 Destination
		{
			get => GetProperty(ref _destination);
			set => SetProperty(ref _destination, value);
		}

		[Ordinal(1)] 
		[RED("condition")] 
		public CUInt16 Condition
		{
			get => GetProperty(ref _condition);
			set => SetProperty(ref _condition, value);
		}

		public AIFSMTransitionDefinition(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
