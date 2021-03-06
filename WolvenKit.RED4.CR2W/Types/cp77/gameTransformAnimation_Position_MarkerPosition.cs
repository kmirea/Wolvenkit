using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class gameTransformAnimation_Position_MarkerPosition : gameTransformAnimation_Position
	{
		private NodeRef _markerNode;
		private Vector3 _offset;

		[Ordinal(0)] 
		[RED("markerNode")] 
		public NodeRef MarkerNode
		{
			get => GetProperty(ref _markerNode);
			set => SetProperty(ref _markerNode, value);
		}

		[Ordinal(1)] 
		[RED("offset")] 
		public Vector3 Offset
		{
			get => GetProperty(ref _offset);
			set => SetProperty(ref _offset, value);
		}

		public gameTransformAnimation_Position_MarkerPosition(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
