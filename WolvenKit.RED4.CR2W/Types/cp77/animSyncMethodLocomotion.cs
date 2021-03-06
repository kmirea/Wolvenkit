using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animSyncMethodLocomotion : animISyncMethod
	{
		private CName _locomotionFeatureName;
		private CName _accelStopTimeEvent;

		[Ordinal(0)] 
		[RED("locomotionFeatureName")] 
		public CName LocomotionFeatureName
		{
			get => GetProperty(ref _locomotionFeatureName);
			set => SetProperty(ref _locomotionFeatureName, value);
		}

		[Ordinal(1)] 
		[RED("accelStopTimeEvent")] 
		public CName AccelStopTimeEvent
		{
			get => GetProperty(ref _accelStopTimeEvent);
			set => SetProperty(ref _accelStopTimeEvent, value);
		}

		public animSyncMethodLocomotion(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
