using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class RevealStatusNotification : HUDManagerRequest
	{
		private CBool _isRevealed;

		[Ordinal(1)] 
		[RED("isRevealed")] 
		public CBool IsRevealed
		{
			get => GetProperty(ref _isRevealed);
			set => SetProperty(ref _isRevealed, value);
		}

		public RevealStatusNotification(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
