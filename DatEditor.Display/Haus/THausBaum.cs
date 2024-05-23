using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausBaum : THaus
    {
        public uint t_AnlageDisplayPtr;
        public byte m_Byte1;
        public ushort m_Short2;
        public byte m_Byte2;

        public THausBaum()
        {
            t_AnlageDisplayPtr = 0;
            m_Byte1 = 1;
        }

        public override uint sub_100071E0(uint value)
        {
            t_AnlageDisplayPtr = value;
            return 0;
        }
    }
}
