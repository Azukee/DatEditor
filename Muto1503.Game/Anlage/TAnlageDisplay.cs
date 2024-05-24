namespace Muto1503.Game.Anlage
{
    public class TAnlageDisplay : TAnlage
    {
        public byte[] GAP;

        public TAnlageDisplay()
        {
            GAP = new byte[0x1000];
        }

        public int sub_1000C0B0(int type, byte[] data)
        {
            switch (type)
            {
                case 0x17:
                    var v4 = BitConverter.ToUInt32(data, 4);
                    var v5 = BitConverter.ToUInt32(data, 8);
                    var v3 = 16 * BitConverter.ToUInt32(data, 0);
                    
                    Array.Copy(data, 0, GAP, v3 + 0, 4);
                    Array.Copy(data, 4, GAP, v3 + 4, 4);
                    Array.Copy(data, 8, GAP, v3 + 8, 4);
                    break;
                // TODO : case 1145
            }

            return 0;
        }
    }
}
