using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimStateTransitionCondition_IntVariable : animIAnimStateTransitionCondition
	{
		private CName _variableName;
		private CInt32 _compareValue;
		private CEnum<animCompareFunc> _compareFunc;

		[Ordinal(0)] 
		[RED("variableName")] 
		public CName VariableName
		{
			get => GetProperty(ref _variableName);
			set => SetProperty(ref _variableName, value);
		}

		[Ordinal(1)] 
		[RED("compareValue")] 
		public CInt32 CompareValue
		{
			get => GetProperty(ref _compareValue);
			set => SetProperty(ref _compareValue, value);
		}

		[Ordinal(2)] 
		[RED("compareFunc")] 
		public CEnum<animCompareFunc> CompareFunc
		{
			get => GetProperty(ref _compareFunc);
			set => SetProperty(ref _compareFunc, value);
		}

		public animAnimStateTransitionCondition_IntVariable(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
