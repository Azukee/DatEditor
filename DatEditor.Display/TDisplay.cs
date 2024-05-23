using DatEditor.Display.ColorTable;
using DatEditor.Display.Haus;

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
                    case 4:
                        return new TColorTableEffectsMulti();
                }
            }

            return null;
        }

        public THaus ConstructHouseObject(ushort type)
        {
            return type switch
            {
                0 => new THaus(),
                1 => new THausBaum(),
                2 => new THausGebaude(),
                3 => new THausShadow(),
                4 => new THausFigur(),
                5 => new THausStrasse(),
                6 => new THausGebaude(),
                7 => new THausShip(),
                8 => new THausGelaende(),
                9 => new THausAnim(),
                10 => new THausAnimWasser(),
                _ => throw new Exception("error: reached unexpected end")
            };
        }
    }
}
