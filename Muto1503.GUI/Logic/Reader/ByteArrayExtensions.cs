using System.Text;

namespace Muto1503.GUI.Logic.Reader
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

        public static bool Matches(this byte[] buffer, string str)
        {
            if (buffer.Length < str.Length)
                return false;

            return !str.Where((t, i) => buffer[i] != t).Any();
        }

        public static string GetZeroTerminatedString(this byte[] buffer)
        {
            int length = Array.IndexOf(buffer, (byte)0);
            return Encoding.UTF8.GetString(buffer, 0, length);
        }
    }
}