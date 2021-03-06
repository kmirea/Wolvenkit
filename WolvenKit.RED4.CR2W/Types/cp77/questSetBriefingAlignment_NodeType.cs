using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSetBriefingAlignment_NodeType : questIUIManagerNodeType
	{
		private CEnum<questJournalAlignmentEventType> _briefingAlignment;

		[Ordinal(0)] 
		[RED("briefingAlignment")] 
		public CEnum<questJournalAlignmentEventType> BriefingAlignment
		{
			get => GetProperty(ref _briefingAlignment);
			set => SetProperty(ref _briefingAlignment, value);
		}

		public questSetBriefingAlignment_NodeType(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
