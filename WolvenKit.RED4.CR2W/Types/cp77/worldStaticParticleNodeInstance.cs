using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class worldStaticParticleNodeInstance : worldINodeInstance
	{
		private CEnum<RenderSceneLayerMask> _renderLayerMask;

		[Ordinal(0)] 
		[RED("renderLayerMask")] 
		public CEnum<RenderSceneLayerMask> RenderLayerMask
		{
			get => GetProperty(ref _renderLayerMask);
			set => SetProperty(ref _renderLayerMask, value);
		}

		public worldStaticParticleNodeInstance(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
