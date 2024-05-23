using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
