namespace Muto1503.Display.Haus
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

        public override uint offset10()
        {
            return 0x607;
        }
    }
}
