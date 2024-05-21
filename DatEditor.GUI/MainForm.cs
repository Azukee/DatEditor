using DatEditor.Logic.Parser;

namespace DatEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnlagenParser ap = new AnlagenParser("H:\\Games\\Anno 1503\\Anno 1503 AD\\Anlagen.dat");
            ap.Parse();
        }
    }
}
