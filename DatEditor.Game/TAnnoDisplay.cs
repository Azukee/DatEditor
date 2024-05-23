using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatEditor.Display;

namespace DatEditor.Game
{
    public class TAnnoDisplay : TAnno
    {
        public int somethingHere;
        public int dword63F8;

        public IDisplayColors[] m_SomeKindOfVector = new IDisplayColors[0x1000];

        public int m_ColorsBeginIndex;
        public IDisplayColors[] m_DisplayColors = new IDisplayColors[0x1000];


        public int m_SomeCount;
    }
}
