using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausGelaende : THausGebaude
    {
        public override uint offset10()
        {
            return 0x608;
        }
    }
}
