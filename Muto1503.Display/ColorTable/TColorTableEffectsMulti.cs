namespace Muto1503.Display.ColorTable
{
    internal class TColorTableEffectsMulti : TColorTable
    {
        public byte dunno3;
        public uint[] m_BodyInfoMaybe;

        public TColorTableEffectsMulti()
        {
            dunno3 = unchecked((byte)-1);
            m_BodyInfoMaybe = new uint[3712];
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
