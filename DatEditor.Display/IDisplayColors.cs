namespace DatEditor.Display
{
    public abstract class IDisplayColors
    {
        public abstract void LoadBody(byte[] data, int length);
        public abstract uint ReturnMagic();
    }
}
