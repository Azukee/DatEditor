﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatEditor.Display;

namespace DatEditor.Game.Anlage
{
    public class TAnlage
    {
        public TAnno Parent { get; set; }
        public int ListIndex { get; set; }

        public TAnlageHead Head { get; set; }
        public TAnlageProd3 Prod3 { get; set; }

        public TAnlage()
        {
            Head = new TAnlageHead();
            Prod3 = new TAnlageProd3();
        }

        public int sub_10005BF0(IDisplayColors color, int index)
        {
            var v4 = color.ReturnMagic();
            if (v4 == 0x500)
            {
                var anlageProd3 = Prod3;
                anlageProd3.something270[index + 1] = color;
                anlageProd3.m_ColorIndex = index;

                Prod3 = anlageProd3;

                return index;
            }
            else
            {
                return 0xFFFF;
            }
        }

        public uint sub_100020E0(uint magic, byte[] data)
        {
            if (magic > 0x29)
            {
                if (magic == 0x466)
                {

                }
                else
                {
                    var v3 = magic - 0x73;
                    if (magic == 0x473)
                    {

                    }
                }
            }

            return magic;
        }

        public uint sub_10005460(uint magic, byte[] data)
        {
            if (magic == 0x17)
            {

            }else if (magic == 0x479)
            {

            }
            else
            {
                return sub_100020E0(magic, data);
            }

            return 0;
        }


    }
}
