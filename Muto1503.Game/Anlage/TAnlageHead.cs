namespace Muto1503.Game.Anlage
{
    public struct TAnlageHead
    {
        public byte[] data = new byte[56];

        public short m_IndexInArray;
        public byte something3;
        public byte something4;
        public byte something11;
        public byte something6;
        public byte something7;
        public byte something5;
        public byte something17;
        public byte something18;
        public uint dataOrSomething;
        public byte something15;
        public uint yeahyeah;
        public ushort somethingsomething;
        public uint yeayea;
        public byte something16;
        public byte something14;
        public ushort something9;
        public ushort something10;
        public byte something12;
        public ushort gangang;
        public ushort YEAH;
        public byte ssomething;
        public byte ssomething1;
        public byte ssomething2;
        public byte ssomething3;
        public byte something19;
        public byte something20;
        public ushort something21;
        public ushort something23;
        public ushort something25;
        public ushort something27;
        public byte something75;
        public byte something87;
        public byte something99;
        public byte something111;
        public ushort m_ProdType;
        public byte m_InframinType;

        public byte[] m_BauSampleData;

        public TAnlageHead()
        {
            m_BauSampleData = new byte[32];
        }

        public byte sub_10002AB0(byte a1, byte a2)
        {
            byte result = 0x00; // al

            result = a1;
            if (a1 >= 8)
            {
                result = (byte)((a1 - 8) | 0x80);
                switch (a2)
                {
                    case 0:
                        result = (byte)((a1 - 8) | 0xD0);
                        break;
                    case 1:
                        result = (byte)((a1 - 8) | 0xC8);
                        break;
                    case 2:
                        result = (byte)((a1 - 8) | 0xD8);
                        break;
                    case 3:
                        result = (byte)((a1 - 8) | 0xF8);
                        break;
                    case 4:
                        result = (byte)((a1 - 8) | 0x90);
                        break;
                    default:
                        return result;
                }
            }
            return result;
        }
    }
}
