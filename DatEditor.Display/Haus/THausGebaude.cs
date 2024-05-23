using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausGebaude : THaus
    {
        public uint m_Dword1;
        public ushort m_Short1;
        public ushort m_Short2;

        public THausGebaude()
        {
            m_Short1 = 1;
            m_Dword1 = 0;
        }
    }
}
