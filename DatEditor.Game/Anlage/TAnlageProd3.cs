namespace DatEditor.Game.Anlage
{
    public struct TAnlageProd3
    {
        public byte[] data = new byte[68];

        public byte something115;
        public byte something113;
        public byte something114;
        public byte something116;
        public byte something118;
        public byte something117;
        public byte something120;
        public byte something119;
        public byte something121;
        public int something163;
        public int something165;
        public ushort something143;
        public ushort something159;
        public ushort something161;
        public ushort something152;
        public ushort something153;
        public ushort something155;
        public ushort something157;
        public ushort something166;
        public ushort something168;
        public ushort something147;
        public ushort something149;
        public byte something131;
        public byte something132;

        public byte[] something123_1;
        public byte[] something123_2;
        public byte[] something123_3;

        public byte something130;
        public byte[] m_WarenEntries;
        public byte[] m_RohstoffEntries;

        public uint[] m_WalkMask;
        public uint[] m_ShotMask;
        public uint[] m_OwnMask;


        public TAnlageProd3()
        {
            m_WarenEntries = new byte[2];
            m_RohstoffEntries = new byte[2];
            m_WalkMask = new uint[3];
            m_ShotMask = new uint[3];
            m_OwnMask = new uint[3];
        }
    }
}
