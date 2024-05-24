namespace Muto1503.Display.Haus
{
    public class THausFigur : THausBaum
    {
        public byte m_Byte;
        public byte m_Byte1;
        public ushort m_Short2;
        public ushort m_Short4;
        public byte m_Byte4;
        public byte m_Byte5;
        public uint m_Dword2;
        public byte m_Byte2;
        public byte m_Byte3;
        public ushort m_Short3;
        public byte[] m_SomeBuffer;

        public THausFigur()
        {
            m_Short2 = 1000;
            m_Short4 = 256;
            base.m_Byte1 = unchecked((byte)263);
            m_SomeBuffer = new byte[384];
            m_SomeBuffer[0x180] = 7;
        }

        public override uint offset10()
        {
            return 0x604;
        }

        public override void offset4c(int type, byte[] data)
        {
            switch (type)
            {
                case 0x143:
                {
                    var v4 = data[0x04];
                    if (m_Byte5 != v4)
                        m_Byte5 = v4;
                    break;
                }
                case 0x13F: 
                {
                    var v4 = data[0x04];
                    if (base.m_Byte2 != v4)
                    {
                        if (v4 == 1)
                        {
                            data[0x04] = 3;
                            v4 = 3;
                        }

                        base.m_Byte2 = v4;
                        if (v4 >= 0xF)
                        {
                            base.m_Byte3 = 0;
                        }
                        else
                        {
                            byte cl = (byte)((v4 < 7) ? 1 : 0); //idk if this is the correct way around
                            base.m_Byte3 = (byte)(cl + 1);
                        }
                    }
                    break;
                }
            }
        }
    }
}
