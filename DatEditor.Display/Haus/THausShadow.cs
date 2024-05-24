using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausShadow : THaus
    {
        public uint m_Dword1;

        public THausShadow()
        {
            m_Dword1 = 0x20001;
        }

        public override uint offset10()
        {
            return 0x603;
        }
    }
}
