using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameEffectObjectFilter_OnlyNearest : gameEffectObjectGroupFilter
	{
		private CUInt32 _count;

		[Ordinal(0)] 
		[RED("count")] 
		public CUInt32 Count
		{
			get => GetProperty(ref _count);
			set => SetProperty(ref _count, value);
		}

		public gameEffectObjectFilter_OnlyNearest(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
