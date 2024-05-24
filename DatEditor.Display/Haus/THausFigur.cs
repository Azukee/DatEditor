using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THausFigur : THausBaum
    {
        public byte m_Byte;
        public byte m_Byte1;
        public ushort m_Short2;
        public uint m_Dword1;
        public uint m_Dword2;
        public byte m_Byte2;
        public byte m_Byte3;
        public ushort m_Short3;
        public byte[] m_SomeBuffer;

        public THausFigur()
        {
            m_Short2 = 1000;
            m_Dword1 = 256;
            m_Short1 = 263;
            m_SomeBuffer = new byte[384];
            m_SomeBuffer[0x180] = 7;
        }

        public override uint offset10()
        {
            return 0x604;
        }
    }
}
