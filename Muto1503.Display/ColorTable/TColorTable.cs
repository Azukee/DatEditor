﻿namespace Muto1503.Display.ColorTable
{
    public class TColorTable : IDisplayColors
    {
        public ushort m_IndexInArray; //TODO: update name in database

        public TColorTable()
        {
            m_IndexInArray = unchecked((ushort)-1);
        }

        public int sub_1002CFE0()
        {
            byte[] v3 = new byte[204];

            return 0xFFFF;
        }

        public ushort SetIndexInArray(ushort a2) //TODO: sub_10002000 UPDATE name in database
        {
            m_IndexInArray = a2;
            return a2;
        }

        public int sub_1002CEF0(int x)
        {
            return 8;
        }

        public override void LoadBody(byte[] data, int length)
        {
            throw new NotImplementedException();
        }

        public override uint GetMagic()
        {
            return 0x500;
        }
    }
}
