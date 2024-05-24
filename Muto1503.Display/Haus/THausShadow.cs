namespace Muto1503.Display.Haus
{
    public class THausShadow : THaus
    {
        public uint m_Dword1;

        public THausShadow()
        {
            m_Dword1 = 0x20001;
        }

        public override uint offset10()
        {
            return 0x603;
        }
    }
}
