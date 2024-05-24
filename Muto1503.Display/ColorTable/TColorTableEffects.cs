namespace Muto1503.Display.ColorTable
{
    public class TColorTableEffects : TColorTable
    {
        public byte dunno2;
        public uint[] m_BodyInfoMaybe;

        public TColorTableEffects()
        {
            dunno2 = unchecked((byte)-1);
            m_BodyInfoMaybe = new uint[640];
        }

        public override void LoadBody(byte[] data, int length)
        {
            if (length <= 0)
                return;

            for (var i = 0; i < length; i++)
            {
                m_BodyInfoMaybe[i] = BitConverter.ToUInt32(data, 4 * i);
            }
        }
    }
}
