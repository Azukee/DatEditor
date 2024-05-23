using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausShip : THaus
    {
        public uint m_Dword1;
        public uint m_Dword2;

        public THausShip()
        {
            m_Dword2 = 1;
            m_Dword1 = 0;
        }
    }
}
