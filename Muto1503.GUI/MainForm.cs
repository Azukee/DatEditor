using Muto1503.GUI.Logic.Parser;

namespace Muto1503.GUI
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
