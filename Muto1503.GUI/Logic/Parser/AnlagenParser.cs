﻿using Muto1503.Display;
using Muto1503.Display.ColorTable;
using Muto1503.Display.Haus;
using Muto1503.Game;
using Muto1503.Game.Anlage;
using Muto1503.GUI.Logic.Reader;

namespace Muto1503.GUI.Logic.Parser
{
    internal class AnlagenParser(string filePath)
    {
        private int _bytesRead = 0;
        private TAnnoDisplay _anno = new TAnnoDisplay();
        private TDisplay _display = new TDisplay();

        private readonly DatReader _datReader = new(File.OpenRead(filePath));

        private Int32 getSize(byte[] data)
        {
            return data.GetInt(0x0C);
        }

        private Int32 sub_100037E0(byte[] data, int a2)
        {
            return BitConverter.ToInt32(data.AsSpan(a2 + 0x85, 4));
        }

        private void parseAnlage(ref TAnlageDisplay anlage, byte[] data)
        {
            var bytesRead = 0;

            var v8 = 0;
            var v136 = 0;
            if (data.Matches("ADDON"))
            {
                var offset = getSize(data);
                byte[] chunk = new byte[4 * 4];
                for (; offset > 0; offset = v8 - v136)
                {
                    var nChunk = _datReader.ReadChunk();
                    v8 = offset - nChunk.Length;
                    chunk = nChunk;
                    var nOffset = getSize(chunk);
                    _datReader.BaseStream.Seek(nOffset, SeekOrigin.Current);
                }
                return;
            }

            if (data.Matches("CLASSIC"))
            {
                var v9 = getSize(data);
                for (var i = v9; v9 > 0; v9 -= v136)
                {
                    v136 = v9;
                    var offset = getSize(data);
                    _datReader.BaseStream.Seek(offset, SeekOrigin.Current);
                    v136 = offset;
                }

                return;
            }

            TAnlageHead anlageHead = anlage.Head;
            if (data.Matches("HEAD"))
            {
                var size = getSize(data);
                var headData = _datReader.ReadBytes(size);
                anlageHead.something3 = headData[0];
                anlageHead.something4 = headData[1];
                anlageHead.something11 = headData[2];
                anlageHead.something6 = headData[0x10];
                anlageHead.something7 = headData[0x18];
                anlageHead.something5 = headData[0x11];
                anlageHead.something17 = headData[0xA];
                anlageHead.something18 = headData[0x12];
                var v10 = headData[0x13];
                if (v10 == 0)
                    v10 = unchecked((byte)-2);
                anlageHead.dataOrSomething = BitConverter.ToUInt32(headData.AsSpan(0x14, 4));
                anlageHead.something15 = v10;
                anlageHead.yeahyeah = BitConverter.ToUInt32(headData.AsSpan(0xC, 4));
                anlageHead.somethingsomething = headData.GetUShort(0x1C);
                anlageHead.yeayea = BitConverter.ToUInt32(headData.AsSpan(0x20, 4));
                anlageHead.something16 = headData[0x31];
                anlageHead.something14 = headData[0x19];
                anlageHead.something9 = BitConverter.ToUInt16(headData.AsSpan(0x2C, 2));

                if (BitConverter.ToUInt16(headData.AsSpan(0x32, 2)) == 0xFFFF)
                    anlageHead.something10 = 0;
                else
                    anlageHead.something10 = BitConverter.ToUInt16(headData.AsSpan(0x32, 2));

                if (headData[0x2F] > 0 || headData[0x30] > 0)
                    anlageHead.something12 = anlageHead.sub_10002AB0(headData[0x2F], headData[0x30]);

                var v14 = (ushort)(headData[0x25] & 1 | (headData[0x2E] << 8));
                anlageHead.gangang = BitConverter.ToUInt16(headData.AsSpan(0x08, 2));
                anlageHead.YEAH = v14;
                v14 = headData[0xB];
                anlageHead.ssomething = headData[0x05];
                anlageHead.ssomething2 = headData[0x03];
                anlageHead.ssomething1 = headData[0x04];
                anlageHead.ssomething3 = headData[0x06];
                anlageHead.something19 = (byte)(v14 & 0x3F);
                anlageHead.something20 = (byte)(v14 >> 6);
                anlageHead.something21 = BitConverter.ToUInt16(headData.AsSpan(0x1A, 2));
                anlageHead.something27 = BitConverter.ToUInt16(headData.AsSpan(0x26, 2));
                anlageHead.something25 = BitConverter.ToUInt16(headData.AsSpan(0x28, 2));
                anlageHead.something23 = BitConverter.ToUInt16(headData.AsSpan(0x2A, 2));
                if ((headData[0x24] & 1) != 0)
                    anlageHead.something75 |= 1;
                if ((headData[0x24] & 2) != 0)
                    anlageHead.something87 |= 1;
                if ((headData[0x24] & 4) != 0)
                    anlageHead.something99 |= 1;
                if ((headData[0x24] & 8) != 0)
                    anlageHead.something111 |= 1;

                anlage.Head = anlageHead;
                return;
            }

            TAnlageProd3 prod3 = anlage.Prod3;
            if (data.Matches("PROD3"))
            {
                var size = getSize(data);
                var prod3Data = _datReader.ReadBytes(size);
                var v18 = prod3Data[0x28];
                var v120 = prod3Data[0x28]; // TODO: investigate if this is a dword in the assembly

                var something123_1 = new byte[2 * prod3Data[0x28]];
                Array.Copy(prod3Data, 2 * prod3Data[0x2A] + 0x32, something123_1, 0, 2 * prod3Data[0x28]);
                prod3.something123_1 = something123_1;

                var v19 = prod3Data[0x29];
                prod3.something115 = v18;
                var v20 = prod3Data[0x2B];
                prod3.something113 = v19;
                var v21 = v20;
                prod3.something114 = 0x00;

                var something123_2 = new byte[2 * v20];
                Array.Copy(prod3Data, 2 * prod3Data[0x2D] + 0x32, something123_2, 0, 2 * v20);
                prod3.something123_2 = something123_2;

                var v22 = v120;
                prod3.something116 = prod3Data[0x2C];
                prod3.something118 = v20;
                var v23 = prod3Data[0x2E];
                var v24 = 2 * prod3Data[0x2E];
                prod3.something117 = v22;
                v120 = (byte)(v21 + v22); // TODO:: could be bug, v120 is int in pseudo

                var something123_3 = new byte[v24];
                Array.Copy(prod3Data, 2 * prod3Data[0x30] + 0x32, something123_3, 0, v24);
                prod3.something123_3 = something123_3;

                var v25 = BitConverter.ToSingle(prod3Data.AsSpan(0xC, 4));
                var v11 = BitConverter.ToSingle(prod3Data.AsSpan(0xC, 4)) == 0.0;
                prod3.something120 = v120;
                prod3.something119 = prod3Data[0x2F];
                prod3.something121 = v23;
                var v26 = BitConverter.ToSingle(prod3Data.AsSpan(0x08, 4));
                if (v11)
                    v25 = BitConverter.ToSingle(prod3Data.AsSpan(0x08, 4));
                var v27 = (int)(BitConverter.ToSingle(prod3Data.AsSpan(0x08, 4)) * 128.0f);
                prod3.something163 = v27;
                prod3.something165 = (int)(v25 * 128.0f);
                var prodType = anlageHead.m_ProdType;
                if (prodType < 0xE2 || prodType > 0xE3)
                {
                    prod3.something143 = 0;
                }
                else
                {
                    var something6 = anlageHead.something6;
                    if (something6 < 2)
                        prod3.something143 = 0;
                    else
                        prod3.something143 = (ushort)((1000 * v27 / (something6 * (1 << anlageHead.something7))) << 7);
                }

                prod3.something159 = (ushort)((256.0 / v26) + 0.5);
                var v31 = BitConverter.ToSingle(prod3Data.AsSpan(0x20, 4));
                prod3.something161 = (ushort)((256.0 / v25) + 0.5);
                prod3.something152 = (ushort)(BitConverter.ToUInt16(prod3Data.AsSpan(0x04, 2)) << 0x08);
                prod3.something153 = (ushort)(BitConverter.ToUInt16(prod3Data.AsSpan(0x06, 2)) << 0x08);

                var v32 = (int)(v31 * 256.0);
                var v33 = BitConverter.ToSingle(prod3Data.AsSpan(0x24, 4)) * 256.0f;
                prod3.something155 = (ushort)v32;
                prod3.something157 = (ushort)v33;

                var something143 = prod3.something143;
                if (something143 > 0)
                    prod3.something155 = (ushort)(0xEA60000 / (anlageHead.something6 * (something143 << anlageHead.something7)));

                var v35 = BitConverter.ToSingle(prod3Data.AsSpan(0x10, 4));
                prod3.something166 = BitConverter.ToUInt16(prod3Data.AsSpan(0x00, 2));
                prod3.something168 = BitConverter.ToUInt16(prod3Data.AsSpan(0x02, 2));

                var v36 = (int)(v35 * (256.0 / v26));
                var v37 = BitConverter.ToSingle(prod3Data.AsSpan(0x14, 4)) * (256.0f / v25);
                prod3.something147 = (ushort)v36;
                prod3.something149 = (ushort)v37;
                prod3.something131 = prod3Data[0x43];
                prod3.something132 = prod3Data[0x42];

                anlage.Prod3 = prod3;
                return;
            }

            if (data.Matches("PRODTYPE"))
            {
                var size = getSize(data);
                var prod3Data = _datReader.ReadBytes(size);

                var v38 = 0;
                int v132;
                while (true)
                {
                    //TODO: refactor, remove v132, replace with v38 in func
                    v132 = v38;
                    var str = _anno.sub_10009EC0(0x1E, v132);
                    if (!string.IsNullOrEmpty(str))
                    {
                        var conv = prod3Data.GetZeroTerminatedString();
                        if (str == conv)
                            break;
                    }

                    if (++v38 >= 0x1A1)
                        return;
                }

                //TODO: refactor, v132 = v38-1
                anlageHead.m_ProdType = (ushort)v132;
                anlage.Head = anlageHead;
                return;
            }

            if (data.Matches("FORSCHTYPE"))
            {
                var size = getSize(data);
                var prod3Data = _datReader.ReadBytes(size);
                return;
            }

            if (data.Matches("INFRAMIN"))
            {
                var size = getSize(data);
                var inframinData = _datReader.ReadBytes(size);
                var v44 = 0;
                int v132;
                while (true)
                {
                    v132 = v44;
                    var str = _anno.sub_10009EC0(0x21, v132);
                    if (!string.IsNullOrEmpty(str))
                    {
                        var conv = inframinData.GetZeroTerminatedString();
                        if (str == conv)
                            break;
                    }

                    if (++v44 >= 0x20)
                        return;
                }

                anlageHead.m_InframinType = (byte)v132;
                anlage.Head = anlageHead;
                return;
            }

            if (data.Matches("WALKMASK"))
            {
                var size = getSize(data);
                var walkmaskData = _datReader.ReadBytes(size);
                if (3 * anlageHead.something4 <= 0)
                    return;

                for (var i = 0; i < 3 * anlageHead.something4; i++)
                {
                    prod3.m_WalkMask[i] = walkmaskData[i];
                }

                anlage.Prod3 = prod3;
                return;
            }

            if (data.Matches("SHOTMASK"))
            {
                var size = getSize(data);
                var shotmaskData = _datReader.ReadBytes(size);
                if (3 * anlageHead.something4 <= 0)
                    return;

                for (var i = 0; i < 3 * anlageHead.something4; i++)
                {
                    prod3.m_ShotMask[i] = shotmaskData[i];
                }

                anlage.Prod3 = prod3;
                return;
            }

            if (data.Matches("OWNMASK"))
            {
                var size = getSize(data);
                var ownmaskData = _datReader.ReadBytes(size);
                if (3 * anlageHead.something4 <= 0)
                    return;

                for (var i = 0; i < 3 * anlageHead.something4; i++)
                {
                    prod3.m_OwnMask[i] = ownmaskData[i];
                }

                anlage.Prod3 = prod3;
                return;
            }

            if (data.Matches("ENTRANCE"))
            {
                var size = getSize(data);
                var prod3Data = _datReader.ReadBytes(size);
                return;
            }

            if (data.Matches("HIGHMAP"))
            {
                var size = getSize(data);
                var prod3Data = _datReader.ReadBytes(size);
                return;
            }


            if (!data.Matches("OBJECTPOS"))
            {
                if (!data.Matches("FIREPOS"))
                {
                    if (data.Matches("WARE"))
                    {
                        var size = getSize(data);
                        var wareData = _datReader.ReadBytes(size);
                        var readingPosition = 0;
                        for (var i = 0; i < 2; i++)
                        {
                            if (readingPosition >= wareData.Length)
                                break;
                            var v107 = 0;
                            while (true)
                            {
                                var v132 = v107;
                                var str = _anno.sub_10009EC0(0x20, v132);

                                if (!string.IsNullOrEmpty(str))
                                {
                                    if (str == wareData.AsSpan(readingPosition).ToArray().GetZeroTerminatedString())
                                        break;
                                }

                                if (++v107 >= 0x8F)
                                    goto LABEL_154;
                            }

                            prod3.m_WarenEntries[i] = (byte)v107;
                        LABEL_154:
                            readingPosition += wareData.AsSpan(readingPosition).ToArray().GetZeroTerminatedString().Length + 1;
                        }

                        return;
                    }
                    else if (data.Matches("ROHSTOFF"))
                    {
                        var size = getSize(data);
                        var rohstoffData = _datReader.ReadBytes(size);
                        var readingPosition = 0;

                        for (var i = 0; i < 2; i++)
                        {
                            if (readingPosition >= rohstoffData.Length)
                                break;
                            var v112 = 0;
                            while (true)
                            {
                                var v132 = v112;
                                var str = _anno.sub_10009EC0(0x20, v132);

                                if (!string.IsNullOrEmpty(str))
                                {
                                    if (str == rohstoffData.AsSpan(readingPosition).ToArray().GetZeroTerminatedString())
                                        break;
                                }

                                if (++v112 >= 0x8F)
                                    goto LABEL_164;
                            }

                            prod3.m_RohstoffEntries[i] = (byte)v112;
                            if (v112 > 0)
                                prod3.something130 = (byte)(i + 1);
                            LABEL_164:
                            readingPosition += rohstoffData.AsSpan(readingPosition).ToArray().GetZeroTerminatedString().Length + 1;
                        }

                        return;
                    }
                    else if (data.Matches("VERSION2")) // doesnt seem to be used?
                    {
                        var size = getSize(data) / 0xC;

                        for (int i = 0; i < size; i++)
                        {
                            var versionData = _datReader.ReadBigChunk();
                            bytesRead += versionData.Length;
                        }
                    }
                    else
                    {
                        if (data.Matches("BAUSAMPLE"))
                        {
                            var size = getSize(data);
                            anlageHead.m_BauSampleData = _datReader.ReadBytes(size);

                            anlage.Head = anlageHead;
                        }
                        else
                        {
                            var offset = getSize(data);
                            _datReader.BaseStream.Seek(offset, SeekOrigin.Current);
                        }
                    }
                    return;
                }

                {
                    var size = getSize(data);
                    var prod3Data = _datReader.ReadBytes(size);
                }


                return;
            }
        }

        public int parseHouseBody(ref THaus haus, byte[] data)
        {
            int bytesRead = 0;

            if (data.Matches("BODY2"))
            {
                var size = getSize(data);
                var chunk = _datReader.ReadBytes(size);
                var v62 = new byte[162]; //this is defo not the real size LOL
                var intermediate = chunk[8] & 0xF;

                bytesRead = chunk.Length;

                //BitConverter.GetBytes(intermediate).CopyTo(v62, 4);
                //haus.offset4c(0x13F, v62);
                //intermediate = (chunk[8] >> 4) & 1;
                //BitConverter.GetBytes(intermediate).CopyTo(v62, 4);
                //haus.offset4c(0x143, v62);
            }
            else if (data.Matches("ANIM"))
            {
                var size = getSize(data);
                var chunk = _datReader.ReadBytes(size);
                bytesRead = chunk.Length;
            }else if (data.Matches("SOUND"))
            {

                var size = getSize(data);
                var chunk = _datReader.ReadBytes(size);
                bytesRead = chunk.Length;
            }else if (data.Matches("TEXTURES"))
            {
                var chunk = _datReader.ReadSmallChunk();
                bytesRead = chunk.Length;
            }else if (data.Matches("SHADOW"))
            {

                var size = getSize(data);
                bytesRead += size;
                var chunk = _datReader.ReadSmallChunk();
            }else if (data.Matches("OUTLINE"))
            {
                var size = getSize(data);
                bytesRead += size;
                var chunk = _datReader.ReadSmallChunk();
            }
            else
            {
                var size = getSize(data);
                bytesRead = size;
                _datReader.BaseStream.Seek(size, SeekOrigin.Current);
            }

            return _bytesRead;
        }
      
        public void parseRealAnlage(ref TAnlageDisplay anlage, byte[] data)
        {
            if (!data.Matches("HAEUSER")) {
                parseAnlage(ref anlage, data);
                return;
            }

            var size = getSize(data);
            if (size <= 0)
                return;
            byte[] chunk; 
            while (true)
            {
                chunk = _datReader.ReadChunk();
                size -= chunk.Length;
                THaus houseObject = null;
                if (chunk.Matches("ENTRY"))
                {
                    var v7 = getSize(chunk);
                    var v23 = size - v7;
                    var buffer = _datReader.ReadChunk();
                    var v8 = v7 - buffer.Length;
                    houseObject = _display.ConstructHouseObject(buffer.GetUShort(0x02));
                    var index = anlage.sub_10005BF0(houseObject, buffer.GetUShort(0x00));
                    houseObject.sub_10005220(index);
                // watch out maybe this needs to be written in the array at anlage
                LABEL_8:
                    if (v8 <= 0)
                    {
                        byte[] v15 = new byte[16];
                        v15[4] = 0;
                        v15[5] = 0;
                        v15[6] = 0;
                        v15[7] = 0;
                        buffer.CopyTo(v15, 0);
                        BitConverter.GetBytes(buffer.GetFloat(8)).CopyTo(v15, 8);
                        BitConverter.GetBytes(buffer.GetInt(4)).CopyTo(v15, 4);
                        BitConverter.GetBytes(buffer.GetFloat(12)).CopyTo(v15, 12);

                        anlage.sub_1000C0B0(0x17, v15);
                        size = v23;
                        goto LABEL_9;
                    }
                    while (true)
                    {
                        var v28 = _datReader.ReadChunk();
                        var v12 = v8 - v28.Length;

                        int read = parseHouseBody(ref houseObject, v28);
                        v8 = v12 - read;
                        if (v8 <= 0)
                            goto LABEL_8;
                    }
                }
                LABEL_9:
                if (size <= 0)
                    return;
            }

            
        }

        private int parseColor(ref TColor color, byte[] data)
        {
            int bytesRead = 0;
            var v5 = getSize(data);
            while (v5 != 0)
            {
                var chunk = _datReader.ReadChunk();
                bytesRead = chunk.Length;

                var v7 = bytesRead;
                var v8 = v5 - bytesRead;
                var sizea = v8;
                _anno.m_BytesRead += v7;
                if (chunk.Matches("ENTRY"))
                {
                    var size = getSize(chunk);
                    var sizeb = sizea - size;
                    bytesRead += size;
                    _anno.m_BytesRead += size;

                    var bytes = _datReader.ReadSmallChunk();
                    bytesRead = bytes.Length;
                    var v10 = BitConverter.ToInt32(bytes, 0);
                    var v11 = size - bytesRead;
                    if (v10 <= 0)
                        v10 = 3;

                    var colorTable = _display.sub_10003CD0(v10);
                    if (colorTable == null) // result < 0
                        return unchecked((int)0xDEADBEEF); // TODO: return error, so probably throw here
                  
                    colorTable.sub_1002CFE0();

                    var idx = BitConverter.ToInt32(bytes, 4);
                    var v15 = (_anno.somethingHere - _anno.dword63F8) >> 2;
                    var count = BitConverter.ToInt32(bytes, 4);
                    var index = v15;

                    if (v15 <= BitConverter.ToInt32(bytes, 4))
                    {
                        var v16 = count + BitConverter.ToInt32(bytes, 4) / 4;
                        if (v16 < 10)
                        {
                            v16 = 10;
                            if (v15 >= 10)
                                v16 = v15 + 1;
                        }

                        _anno.m_SomeKindOfVector = new IDisplayColors[v16];

                        _anno.m_SomeKindOfVector[index] = colorTable;
                        idx = count;
                    }

                    if (_anno.m_SomeKindOfVector[idx] == null)
                        _anno.m_SomeKindOfVector[idx] = colorTable;
                    var v20 = count;
                    var v24 = count;

                    ++_anno.m_SomeCount;
                    _anno.m_DisplayColors[idx] = colorTable;
                    colorTable.SetIndexInArray((ushort)v24);
                    while (v11 > 0)
                    {
                        var specialChunk = _datReader.ReadChunkSpecial();
                        v11 -= specialChunk.Length;
                        if (specialChunk.Matches("BODY"))
                        {
                            var dat = _datReader.ReadChunkByLengthMask(specialChunk);
                            v11 -= dat.Length;
                            colorTable.LoadBody(dat, dat.Length >> 2);
                        }
                        else if (specialChunk.Matches("NAME"))
                        {
                            var dat = _datReader.ReadChunkByLengthMask(specialChunk);
                            v11 -= dat.Length;
                            colorTable.sub_1002CEF0(18);
                            //(*(void(__thiscall * *)(int, int, char *))(*(_DWORD*)tColorTableEffectsPtr + 76))(
                            //    tColorTableEffectsPtr,
                            //    18,
                            //    v37);
                        }
                    }

                    v5 = sizeb;
                }
                else
                {
                    var offset = getSize(chunk);
                    _datReader.BaseStream.Seek(offset, SeekOrigin.Current);

                    v5 = v8 - bytesRead;
                    _anno.m_BytesRead += bytesRead;
                }
            }

            return bytesRead;
        }

        private int woah = 0;
        public void Parse()
        {
            var anlagenIndex = 0;

            var chunk = _datReader.ReadChunk();
            if (!chunk.Matches("ANNO"))
                return;

            var anlagenSize = getSize(chunk);
            if (anlagenSize <= 0)
                return;

            var v7 = 0;
            do
            {
                chunk = _datReader.ReadChunk();
                anlagenSize -= chunk.Length;

                if (chunk.Matches("ANLAGEN"))
                {
                    var BufferPlusC = getSize(chunk);
                    v7 = anlagenSize - BufferPlusC;
                    anlagenSize -= BufferPlusC;
                    if (BufferPlusC > 0)
                    {
                        do
                        {
                            chunk = _datReader.ReadChunk();
                            var v8 = BufferPlusC - chunk.Length;
                            var v33 = v8;
                            if (chunk.Matches("ENTRY"))
                            {
                                TAnlageDisplay anlage = null;

                                var v9 = getSize(chunk);
                                v33 -= v9;
                                var tinyChunk = _datReader.ReadSmallChunk();
                                var v10 = v9 - tinyChunk.Length;
                                if (!_anno.AnlageExists(anlagenIndex))
                                {
                                    // construct anlage
                                    anlage = new TAnlageDisplay
                                    {
                                        Parent = _anno,
                                        ListIndex = _anno.Anlagen.Count
                                    };
                                    _anno.Anlagen.Add(anlage);
                                    anlagenIndex++; //TODO: i dont know if this is correct, i dont think so
                                }
                                else
                                    anlage = _anno.Anlagen[anlagenIndex];

                                if (v10 > 0)
                                {
                                    do
                                    {
                                        chunk = _datReader.ReadChunk();
                                        Console.WriteLine($"owo {woah++}");
                                        var v15 = v10 - chunk.Length;
                                        if (chunk.Matches("COLORS"))
                                        {
                                            var length = getSize(chunk);
                                            var colorBuffer = _datReader.ReadBytes(length);
                                            var idx = 0;
                                            v10 = v15 - colorBuffer.Length;
                                            var v30 = v10;
                                            var v31 = colorBuffer.Length >> 2;

                                            if (colorBuffer.Length >> 2 != 0)
                                            {
                                                do
                                                {
                                                    if (idx < _anno.m_DisplayColors.Length && _anno.m_DisplayColors[idx] != null)
                                                    {
                                                        var displayColor = _anno.m_DisplayColors[idx] as TColorTable;
                                                        displayColor.sub_1002CFE0();
                                                        anlage.sub_10005BF0(displayColor, idx);
                                                    }
                                                    ++idx;
                                                } while (idx < v31);

                                                v10 = v30;
                                            }
                                        }
                                        else
                                        {
                                            parseRealAnlage(ref anlage, chunk);

                                            v10 = v15 - 0;
                                            _bytesRead += v10;
                                        }
                                        // ...
                                    } while (v10 > 0);

                                }

                                //tinyChunk
                                tinyChunk[4] = 0x00;
                                tinyChunk[5] = 0x00;
                                tinyChunk[6] = 0x00;
                                tinyChunk[7] = 0x00;

                                anlage.sub_10005460(0x35, tinyChunk); //TODO; reverse this some more

                                //functions here
                                BufferPlusC = v33;
                            }
                            else
                            {
                                var offset = getSize(chunk);
                                _datReader.BaseStream.Seek(offset, SeekOrigin.Current);
                                BufferPlusC = v8 - offset;
                            }
                        } while (BufferPlusC > 0);
                        v7 = anlagenSize;
                    }
                    
                    continue;
                }

                var numberOfBytesRead = 0;

                if (chunk.Matches("COLORS"))
                {
                    TColor color = new TColor();
                    var x = parseColor(ref color, chunk);
                    numberOfBytesRead += x;
                }
                else
                {
                    if (!chunk.Matches("TEXTURES"))
                    {
                        var offset = getSize(chunk);
                        _datReader.BaseStream.Seek(offset, SeekOrigin.Current);
                        v7 = anlagenSize - offset;
                        anlagenSize -= offset;
                        continue;
                    }

                    var v23 = getSize(chunk);
                    _datReader.BaseStream.Seek(v23, SeekOrigin.Current);
                    numberOfBytesRead = v23;
                }

                v7 = anlagenSize - numberOfBytesRead;
                anlagenSize -= numberOfBytesRead;
            } while (v7 > 0);
        }
    }
}
