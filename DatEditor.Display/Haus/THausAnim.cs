using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausAnim : THausGebaude
    {
        public uint m_Dword1;

        public THausAnim()
        {
            m_Dword1 = 0x3010032;
        }

        public override uint offset10()
        {
            return 0x609;
        }
    }
}
