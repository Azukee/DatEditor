namespace Muto1503.Display.Haus
{
    public class THausBaum : THaus
    {
        public uint t_AnlageDisplayPtr;
        public byte m_Byte1;
        public byte m_Byte2;
        public byte m_Byte3;
        public byte m_Byte4;

        public THausBaum()
        {
            t_AnlageDisplayPtr = 0;
            m_Byte1 = 1; // double check
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
