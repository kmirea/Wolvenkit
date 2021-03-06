using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class VirtualQuestListController : inkVirtualCompoundItemController
	{
		private inkWidgetReference _questList;

		[Ordinal(15)] 
		[RED("questList")] 
		public inkWidgetReference QuestList
		{
			get => GetProperty(ref _questList);
			set => SetProperty(ref _questList, value);
		}

		public VirtualQuestListController(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
