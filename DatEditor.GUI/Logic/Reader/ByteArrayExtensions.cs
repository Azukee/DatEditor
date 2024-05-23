using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Logic.Reader
{
    public static class ByteArrayExtensions
    {
        public static byte At(this byte[] buffer, int offset)
        {
            return buffer[offset];
        }

        public static int GetInt(this byte[] buffer, int offset)
        {
            return BitConverter.ToInt32(buffer, offset);
        }

        public static uint GetUInt(this byte[] buffer, int offset)
        {
            return BitConverter.ToUInt32(buffer, offset);
        }

        public static float GetFloat(this byte[] buffer, int offset)
        {
            return BitConverter.ToSingle(buffer, offset);
        }

        public static ushort GetUShort(this byte[] buffer, int offset)
        {
            return BitConverter.ToUInt16(buffer, offset);
        }
    }
}