using DatEditor.Display.ColorTable;

namespace DatEditor.Display
{
    public class TDisplay
    {
        public TColorTable sub_10003CD0(int type)
        {
            if (type > 0)
            {
                switch (type)
                {
                    case 3:
                        return new TColorTableEffects();
                }
            }

            return new TColorTable();
        }
    }
}
