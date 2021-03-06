using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questRadioAnnouncementNodeType : questIAudioNodeType
	{
		private CArray<questRadioStationAnnouncementEventStruct> _radioStationEvents;

		[Ordinal(0)] 
		[RED("radioStationEvents")] 
		public CArray<questRadioStationAnnouncementEventStruct> RadioStationEvents
		{
			get => GetProperty(ref _radioStationEvents);
			set => SetProperty(ref _radioStationEvents, value);
		}

		public questRadioAnnouncementNodeType(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
