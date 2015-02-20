using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public abstract class CommandBase
    {
        public abstract bool Execute();
        public abstract void Undo();
    }
}
