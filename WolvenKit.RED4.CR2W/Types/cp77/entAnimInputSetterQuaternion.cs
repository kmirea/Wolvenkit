using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class entAnimInputSetterQuaternion : entAnimInputSetter
	{
		private Quaternion _value;

		[Ordinal(1)] 
		[RED("value")] 
		public Quaternion Value
		{
			get => GetProperty(ref _value);
			set => SetProperty(ref _value, value);
		}

		public entAnimInputSetterQuaternion(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
