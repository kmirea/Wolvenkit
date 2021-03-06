using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class LibTreeDefTreeVariableISerializable : LibTreeDefTreeVariable
	{
		private CBool _exportAsProperty;

		[Ordinal(2)] 
		[RED("exportAsProperty")] 
		public CBool ExportAsProperty
		{
			get => GetProperty(ref _exportAsProperty);
			set => SetProperty(ref _exportAsProperty, value);
		}

		public LibTreeDefTreeVariableISerializable(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
