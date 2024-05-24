using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Display.Haus
{
    public class THaus : IMagicObject
    {
        public int[] m_BigIntegerVector;

        public THaus()
        {
            m_BigIntegerVector = new int[4];
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

        public virtual uint offset10()
        {
            return 0x600;
        }

        public override uint GetMagic()
        {
            return offset10() & 0x7FFFFF00;
        }

        public virtual uint offset4c()
        {

        }
    }
}
