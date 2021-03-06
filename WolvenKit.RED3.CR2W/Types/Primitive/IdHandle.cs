using System.Collections.Generic;
using System.IO;

using System.Diagnostics;
using System;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization;
using WolvenKit.Common.Model.Cr2w;
using WolvenKit.RED3.CR2W.Reflection;

namespace WolvenKit.RED3.CR2W.Types
{
    [REDMeta()]
    public class IdHandle : CVariable
    {
        public CName handlename;
        public CHandle<IEditableVariable> handle;

        public IdHandle(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
            handlename = new CName(cr2w, this, "handlename" );
            handle = new CHandle<IEditableVariable>(cr2w, this, "handle" );
        }

        public override void Read(BinaryReader file, uint size)
        {
            handlename.Read(file, 2);
            handle.Read(file, 2);
        }

        public override void Write(BinaryWriter file)
        {
            handlename.Write(file);
            handle.Write(file);
        }

        public override string ToString()
        {
            return $"[{handlename.ToString()}]:{handle.ToString()}";
        }
    }
}
