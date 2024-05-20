using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Logic.Reader
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

        public byte[] ReadChunkNoTraverse()
        {
            var previousPosition = BaseStream.Position;
            var bytes = ReadBytes(0x10);
            BaseStream.Seek(previousPosition, SeekOrigin.Begin);
            return bytes;
        }
    }
}
