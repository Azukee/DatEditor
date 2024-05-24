using System.Text;

namespace Muto1503.GUI.Logic.Reader
{
    internal class DatReader : BinaryReader
    {
        public DatReader(Stream input) : base(input)
        {
        }

        public DatReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public DatReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public byte[] ReadSmallChunk()
        {
            // Read as many bytes to 0x08 as possible
            var canReadLength = (int)(BaseStream.Length - BaseStream.Position);

            return ReadBytes(canReadLength > 0x08 ? 0x08 : canReadLength);
        }

        public byte[] ReadChunk()
        {
            // Read as many bytes to 0x10 as possible
            var canReadLength = (int)(BaseStream.Length - BaseStream.Position);

            return ReadBytes(canReadLength > 0x10 && BaseStream.Position < BaseStream.Length ? 0x10 : canReadLength);
        }

        public byte[] ReadBigChunk()
        {
            // Read as many bytes to 0xC as possible
            var canReadLength = (int)(BaseStream.Length - BaseStream.Position);

            return ReadBytes(canReadLength > 0xC && BaseStream.Position < BaseStream.Length ? 0xC : canReadLength);
        }

        public byte[] ReadChunkSpecial()
        {
            var canReadLength = (int)(BaseStream.Length - BaseStream.Position);
            if (canReadLength < 8)
                return null;

            var chunk = ReadBytes(8);
            var v6 = BitConverter.ToUInt16(chunk, 6);
            if (v6 >= 0xFF00)
            {
                var word = BitConverter.GetBytes(v6);
                chunk[4] = word[0];
                chunk[5] = word[1];

                canReadLength = (int)(BaseStream.Length - BaseStream.Position);
                if (canReadLength < 2)
                    return null;
                var newChunk = ReadBytes(2);
                Array.Copy(newChunk, 0, chunk, 6, newChunk.Length);
            }

            return chunk;
        }

        public byte[] ReadChunkByLengthMask(byte[] maskChunk)
        {
            var secondLast = BitConverter.ToUInt16(maskChunk, 6);
            var last = BitConverter.ToUInt16(maskChunk, 4);
            var length = (last << 16) + secondLast;

            var canReadLength = (int)(BaseStream.Length - BaseStream.Position);
            if (canReadLength < length)
                return null;

            return ReadBytes(length);
        }

        public byte[] ReadChunkNoTraverse()
        {
            var previousPosition = BaseStream.Position;
            var bytes = ReadBytes(0x10);
            BaseStream.Seek(previousPosition, SeekOrigin.Begin);
            return bytes;
        }
    }
}
