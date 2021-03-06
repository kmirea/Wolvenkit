using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class questSceneLocation : CVariable
	{
		private CName _sceneWorldMarkerTag;

		[Ordinal(0)] 
		[RED("sceneWorldMarkerTag")] 
		public CName SceneWorldMarkerTag
		{
			get => GetProperty(ref _sceneWorldMarkerTag);
			set => SetProperty(ref _sceneWorldMarkerTag, value);
		}

		public questSceneLocation(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
