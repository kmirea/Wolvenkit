using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class ForceShootCommandHandler : AIbehaviortaskScript
	{
		private CHandle<AIArgumentMapping> _inCommand;
		private wCHandle<AIForceShootCommand> _currentCommand;

		[Ordinal(0)] 
		[RED("inCommand")] 
		public CHandle<AIArgumentMapping> InCommand
		{
			get => GetProperty(ref _inCommand);
			set => SetProperty(ref _inCommand, value);
		}

		[Ordinal(1)] 
		[RED("currentCommand")] 
		public wCHandle<AIForceShootCommand> CurrentCommand
		{
			get => GetProperty(ref _currentCommand);
			set => SetProperty(ref _currentCommand, value);
		}

		public ForceShootCommandHandler(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
