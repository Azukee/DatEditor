namespace Muto1503.Display.Haus
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

        public override uint offset10()
        {
            return 0x602;
        }
    }
}
