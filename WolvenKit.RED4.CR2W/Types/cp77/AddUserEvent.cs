using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class AddUserEvent : redEvent
	{
		private SecuritySystemClearanceEntry _userEntry;

		[Ordinal(0)] 
		[RED("userEntry")] 
		public SecuritySystemClearanceEntry UserEntry
		{
			get => GetProperty(ref _userEntry);
			set => SetProperty(ref _userEntry, value);
		}

		public AddUserEvent(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
