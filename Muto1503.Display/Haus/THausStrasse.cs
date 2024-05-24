namespace Muto1503.Display.Haus
{
    public class THausStrasse : THaus
    {
        public byte m_Byte1;
        public byte m_Byte2;
        public ushort m_Short1;

        public THausStrasse()
        {
            m_Byte1 = 3;
        }

        public override uint offset10()
        {
            return 0x605;
        }
    }
}
