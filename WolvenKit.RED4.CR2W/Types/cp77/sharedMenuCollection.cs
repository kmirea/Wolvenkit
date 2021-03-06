using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class sharedMenuCollection : CVariable
	{
		private CArray<sharedMenuItem> _items;

		[Ordinal(0)] 
		[RED("items")] 
		public CArray<sharedMenuItem> Items
		{
			get => GetProperty(ref _items);
			set => SetProperty(ref _items, value);
		}

		public sharedMenuCollection(IRed4EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
