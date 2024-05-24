using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausAnimWasser : THausAnim
    {
        public override uint offset10()
        {
            return 0x60A;
        }
    }
}
