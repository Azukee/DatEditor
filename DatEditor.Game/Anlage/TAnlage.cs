using System;
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
    }
}
