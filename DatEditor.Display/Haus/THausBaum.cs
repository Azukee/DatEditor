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
        public ushort m_Short1;
        public byte m_Byte3;
        public byte m_Byte4;

        public THausBaum()
        {
            t_AnlageDisplayPtr = 0;
            m_Short1 = 1;
        }

        public override uint sub_100071E0(uint value)
        {
           // t_AnlageDisplayPtr = value;
            return 0xFFFF;
        }

        public override uint offset10()
        {
            return 0x601;
        }
    }
}
