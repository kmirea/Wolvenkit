using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameuiRequestSwapContextEvent : redEvent
	{
		private CEnum<UIGameContext> _oldContext;
		private CEnum<UIGameContext> _newContext;

		[Ordinal(0)] 
		[RED("oldContext")] 
		public CEnum<UIGameContext> OldContext
		{
			get => GetProperty(ref _oldContext);
			set => SetProperty(ref _oldContext, value);
		}

		[Ordinal(1)] 
		[RED("newContext")] 
		public CEnum<UIGameContext> NewContext
		{
			get => GetProperty(ref _newContext);
			set => SetProperty(ref _newContext, value);
		}

		public gameuiRequestSwapContextEvent(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
