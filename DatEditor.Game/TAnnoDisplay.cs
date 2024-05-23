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
        public int DADSD;
        public int dword63F8;

        public List<IDisplayColors> m_SomeKindOfVector = new List<IDisplayColors>();

        public int m_ColorsBeginIndex;
        public List<IDisplayColors> m_Colors = new List<IDisplayColors>();


        public int m_SomeCount;
    }
}
