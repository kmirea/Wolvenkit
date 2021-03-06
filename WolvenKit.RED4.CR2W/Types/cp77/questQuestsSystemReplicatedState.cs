using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questQuestsSystemReplicatedState : gameIGameSystemReplicatedState
	{
		private CArray<questQuestPrefabsEntry> _replicatedQuestPrefabs;

		[Ordinal(0)] 
		[RED("replicatedQuestPrefabs")] 
		public CArray<questQuestPrefabsEntry> ReplicatedQuestPrefabs
		{
			get => GetProperty(ref _replicatedQuestPrefabs);
			set => SetProperty(ref _replicatedQuestPrefabs, value);
		}

		public questQuestsSystemReplicatedState(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
