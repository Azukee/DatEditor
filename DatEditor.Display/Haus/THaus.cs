using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THaus
    {
        public List<int> m_BigIntegerVector;

        public THaus()
        {
            m_BigIntegerVector = new List<int>();
        }

        public virtual uint sub_100071E0(uint value)
        {
            return 0xFFFF;
        }

        public int sub_10005220(int value)
        {
            m_BigIntegerVector[0] = value;
            return value;
        }
    }
}
