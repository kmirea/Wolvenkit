using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class Sample_Class_2_8 : CVariable
	{
		private CArray<CInt32> _array;

		[Ordinal(0)] 
		[RED("array")] 
		public CArray<CInt32> Array
		{
			get => GetProperty(ref _array);
			set => SetProperty(ref _array, value);
		}

		public Sample_Class_2_8(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
