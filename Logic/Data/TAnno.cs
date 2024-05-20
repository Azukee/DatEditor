using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEditor.Logic.Data
{
    internal class TAnno
    {
        public List<TAnlage> Anlagen { get; set; } = new();

        // TODO: diese benamungen sind arsch
        private readonly string[] _wasserTyp = { "FLUSS", "MEER", "WASSERFALL" };
        private readonly string[] _ortTyp = { "FELSEN", "KLIPPE", "STEIN", "ROHSTSPEZ", "TIERHOEHLE" };
        private readonly string[] _denkmalTyp = { "DNEKMAL", "TRIUMPH", "ZIERDE" };
        private readonly string[] _ruineTyp = { "RUINE" };
        private readonly string[] _mauerTyp = { "MAUER", "MAUERUP", "TOR" };
        private readonly string[] _wegTyp = { "STRASSE", "RAMPE", "RAMPELOW", "RAMPWHIGH", "PIER", "BRUECKE", "PLATZ", "GAUKLERPLATZ", "ZAUN" };
        private readonly string[] _marktStandTyp = { "MARKTSTAND" };
        private readonly string[] _turmTyp = { "WACHTURM", "MILITAR", "KANONENTURM" };
        private readonly string[] _nutzHausTyp = { "BRUNNEN", "WIRT", "KAPELLE", "KIRCHE", "BADEHAUS", "THEATER", "ARZT", "SCHULE", "HOCHSCHULE", "SCHLOSS", "GALGEN", "GERICHT", "FEUERWEHR", "BIBLIOTHEK", "PAVILLION" };
        private readonly string[] _rohstoffWachstumTyp = {"ROHSTOFF", "ROHSTWACHS", "ROHSTDUERR" };
        private readonly string[] _einwohnerStufeTyp = { "PIONIER", "SIEDLER", "BUERGER", "KAUFLEUTE", "ARISTOKRATEN" };
        private readonly string[] _marktTyp = { "HAUPT", "MARKT", "KONTOR", "MARKTKOMBI" };
        private readonly string[] _produktionsTyp = { "", "HANDWERK", "PLANTAGE", "MINE", "WEIDETIER", "JAGDHAUS", "FISCHER", "WERFT", "STEINMETZ", "UNIVERSAL", "SCHAFFARM", "KANONENBAU", "HANDWERKDUAL", "STEINBRUCH", "EISLOCH", "WALFAENGER", "PELZJAEGER", "HANDWERKWAFFEN" };

        private string[] _armeeTyp =
        {
            "ALL", "WAFFEN_FERTIGUNG_01", "KATAPULT", "WAFFEN_FERTIGUNG_02", "BOGNER", "BELAGERUNGSMASCHINE",
            "KAVALLERIE", "GEHAERTETE_SPITZEN", "GEFRIEDERTER_SCHAFT", "ARMBRUST", "ARMBRUST_REICHWEITE", "BRANDPFEILE",
            "MUSKETE", "RADSCHLOSS"
        };

        private string[] _schatzTyp = { "SCHATZ" };

        private string[] _tierTyp = { "FLEISCHTIER", "PELZTIER", "WALFISCH" };
        private string[] _schiffTyp = { "HANDELSCHIFF1", "HANDELSCHIFF2", "HANDELSCHIFF3", "KRIEGSCHIFF1", "KRIEGSCHIFF2", "KRIEGSCHIFF3", "TRADERSCHIFF", "PIRATSCHIFF" };

        private string[] _einheitTyp =
        {
            "SPIESSTRAEGER", "SCHWERTKAEMPFER", "BOGENSCHUETZE", "LANZENKNECHT", "KAVALERIE", "ARMBRUSTSCHUETZE",
            "MUSKETENSCHUETZE", "MUSKETIER", "PIONIER", "BEDIENUNG", "MEDICUS", "TRAGTIER", "KATAPULT", "KATAPULT_GRP",
            "KANONE", "KANONE_GRP", "MOERSER", "MOERSER_GRP", "BALGERTURM", "BELAGERTURM_GRP", "STATIST",
            "WELTBEHERRSCHER"
        };

        private string[] _nutzHausTyp2 =
        {
            "WIRTSHAUS", "BADEHAUS", "THEATER", "KLINIK", "SCHULE", "HOCHSCHULE", "KAPELLE", "KIRCHE", "KATHETRALE",
            "PARK", "BIBLIOTHEK", "FEUERWEHR", "GERICHT", "GALGEN"
        };

        private string[] _feldTyp =
        {
            "GETREIDE", "TABAKBAUM", "GEWUERZBAUM", "FLACHSBAUM", "ZUCKERROHR", "BAUMWOLLE", "WEINTRAUBEN", "KAKAOBAUM",
            "HOPFENBAUM", "SEIDENRAUPE", "FARBBAUM", "KRÄUTER", "KARTOFFEL", "GRAS", "BAUM", "FISCH", "EISFISCH"
        }; // why did they use diacritics here, but nowhere else AHAAAAAAAA

        private string[] _rohstoffTyp = { "WERKZEUG", "HOLZ", "ZIEGEL", "MAMOR" };

        private string[] _nutzGutTyp = 
        { 
            "NAHRUNG", "LEDER", "SALZ", "ALKOHOL", "TABAKWAREN", "GEWUERZE", "HEILKRAEUTER", 
            "STOFFE", "SEIDESTOFFE", "LAMPELOEL", "KLEIDUNG", "SCHMUCK", "PELZE", "WEIN"
        };

        private string[] _waffenTyp = { "SCHWERT", "BOGEN", "ARMBRUST", "MUSKETE", "RUESTUNG", "LANZE", "AXT", "KANONESHIP" };

        private string[] _nutzGutTyp2 =
        {
            "WOLLE", "ZUCKER", "TABAK", "FLEISCH", "KORN", "MEHL", "EISEN", "FLACHS", "HOPFEN", "TIERHAEUTE", "SEILE",
            "SEIDE", "FARBSTOFFE", "WALSPECK", "HOLZKOHLE"
        };

        private string[] _steinTyp = { "", "EISENERZ", "GOLD", "SALZSTEIN", "EDELSTINE", "STEINE", "MAMORSTEIN" };

        private string[] _infraStufe =
        {
            "INFRA_EVER", "INFRA_STUFE_1A", "INFRA_STUFE_1B", "INFRA_STUFE_1C", "INFRA_STUFE_2A", "INFRA_STUFE_2B",
            "INFRA_STUFE_2C", "INFRA_STUFE_2D", "INFRA_STUFE_2E", "INFRA_STUFE_2F", "INFRA_STUFE_2G", "INFRA_STUFE_3A",
            "INFRA_STUFE_3B", "INFRA_STUFE_3C", "INFRA_STUFE_3D", "INFRA_STUFE_3E", "INFRA_STUFE_3F", "INFRA_STUFE_4A",
            "INFRA_STUFE_4B", "INFRA_STUFE_4C", "INFRA_STUFE_4D", "INFRA_STUFE_4E", "INFRA_STUFE_4F", "INFRA_STUFE_5A", 
            "INFRA_STUFE_5B", "INFRA_STUFE_5C", "INFRA_STUFE_5D", "INFRA_STUFE_5E", "INFRA_STUFE_5F", "INFRA_STUFE_TRIUMPH", "INFRA_STUFE_DENKMAL", "INFRA_STUFE_FORSCH"
        };


        private List<IDisplayColors> m_Vector = new List<IDisplayColors>();

        public int m_BytesRead = 0;

        public bool AnlageExists(int index)
        {
            return Anlagen.Count > index;
        }
        
        private string sub_10015C70(int type)
        {
            return type switch
            {
                >= 0 and <= 32 when _produktionsTyp.Length <= type => "UNUSED",
                >= 0 and <= 32 => _produktionsTyp[type],
                >= 33 and <= 64 when _marktTyp.Length <= type - 33 => "UNUSED",
                >= 33 and <= 64 => _marktTyp[type - 33],
                >= 97 and <= 128 when _einwohnerStufeTyp.Length <= type - 97 => "UNUSED",
                >= 97 and <= 128 => _einwohnerStufeTyp[type - 97],
                >= 225 and <= 256 when _rohstoffWachstumTyp.Length <= type - 225 => "UNUSED",
                >= 225 and <= 256 => _rohstoffWachstumTyp[type - 225],
                >= 65 and <= 96 when _nutzHausTyp.Length <= type - 65 => "UNUSED",
                >= 65 and <= 96 => _nutzHausTyp[type - 65],
                >= 129 and <= 160 when _turmTyp.Length <= type - 129 => "UNUSED",
                >= 129 and <= 160 => _turmTyp[type - 129],
                >= 161 and <= 192 when _marktStandTyp.Length <= type - 161 => "UNUSED",
                >= 161 and <= 192 => _marktStandTyp[type - 161],
                >= 193 and <= 224 when _wegTyp.Length <= type - 193 => "UNUSED",
                >= 193 and <= 224 => _wegTyp[type - 193],
                >= 257 and <= 288 when _mauerTyp.Length <= type - 257 => "UNUSED",
                >= 257 and <= 288 => _mauerTyp[type - 257],
                >= 385 and <= 416 when _ruineTyp.Length <= type - 385 => "UNUSED",
                >= 385 and <= 416 => _ruineTyp[type - 385],
                >= 289 and <= 320 when _denkmalTyp.Length <= type - 289 => "UNUSED",
                >= 289 and <= 320 => _denkmalTyp[type - 289],
                >= 321 and <= 352 when _ortTyp.Length <= type - 321 => "UNUSED",
                >= 321 and <= 352 => _ortTyp[type - 321],
                >= 353 and <= 384 when _wasserTyp.Length <= type - 353 => "UNUSED",
                >= 353 and <= 384 => _wasserTyp[type - 353],
                _ => "UNUSED",
            };
        }

        private string sub_10016190(int type)
        {
            return type switch
            {
                >= 0 and <= 8 when _steinTyp.Length <= type => "UNUSED",
                >= 0 and <= 8 => _steinTyp[type],
                >= 9 and <= 25 when _nutzGutTyp2.Length <= type - 9 => "UNUSED",
                >= 9 and <= 25 => _nutzGutTyp2[type - 9],
                >= 46 and <= 55 when _waffenTyp.Length <= type - 46 => "UNUSED",
                >= 46 and <= 55 => _waffenTyp[type - 46],
                >= 26 and <= 40 when _nutzGutTyp.Length <= type - 26 => "UNUSED",
                >= 26 and <= 40 => _nutzGutTyp[type - 26],
                >= 41 and <= 45 when _rohstoffTyp.Length <= type - 41 => "UNUSED",
                >= 41 and <= 45 => _rohstoffTyp[type - 41],
                >= 56 and <= 75 when _feldTyp.Length <= type - 56 => "UNUSED",
                >= 56 and <= 75 => _feldTyp[type - 56],
                >= 76 and <= 90 when _nutzHausTyp2.Length <= type - 76 => "UNUSED",
                >= 76 and <= 90 => _nutzHausTyp2[type - 76],
                >= 96 and <= 121 when _einheitTyp.Length <= type - 96 => "UNUSED",
                >= 96 and <= 121 => _einheitTyp[type - 96],
                >= 122 and <= 131 when _schiffTyp.Length <= type - 122 => "UNUSED",
                >= 122 and <= 131 => _schiffTyp[type - 122],
                >= 137 and <= 141 when _tierTyp.Length <= type - 137 => "UNUSED",
                >= 137 and <= 141 => _tierTyp[type - 137],
                >= 132 and <= 136 when _schatzTyp.Length <= type - 132 => "UNUSED",
                >= 132 and <= 136 => _schatzTyp[type - 132],
                142 => _armeeTyp[0],
                _ => "UNUSED"
            };
        }

        private string sub_10015640(int type) => type >= 0x20 ? "UNUSED" : _infraStufe[type];

        private IDisplayColors sub_1000CF00(int index)
        {
            return m_Vector[index];
        }

        private IDisplayColors? sub_1000E340(int type, int index)
        {
            if (type <= 0xE00)
            {
                switch (type)
                {
                    case 0x500:
                        return sub_1000CF00(index);
                }
            }

            return null;
        }

        public string sub_10009EC0(byte type, int index)
        {
            switch (type)
            {
                case 0x1E:
                    string v3 = sub_10015C70(index);

                    if (string.IsNullOrEmpty(v3))
                        return string.Empty;
                    return v3;
                case 0x20:
                    string v12 = sub_10016190(index);

                    if (string.IsNullOrEmpty(v12))
                        return string.Empty;
                    return v12;
                case 0x21:
                    string v24 = sub_10015640(index);

                    if (string.IsNullOrEmpty(v24))
                        return string.Empty;
                    return v24;
                default:
                    return string.Empty;
            }
        }
    }
}
