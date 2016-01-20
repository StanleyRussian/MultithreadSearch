using System;
using System.Windows.Forms;

namespace MultithreadSearch
{
    public partial class Form1 : Form, iView
    {
        public bool SearchSubdirs
        {
            get { return checkBoxSubdirs.Checked; }
        }

        public ListView SearchResults
        { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public event SearchDelegate SearchStarted;
        public event EventHandler SearchStop;

        private void buttonSmallIcons_Click(object sender, EventArgs e)
        {
            listViewSearchResults.View = View.SmallIcon;
        }

        private void buttonBigIcons_Click(object sender, EventArgs e)
        {
            listViewSearchResults.View = View.LargeIcon;
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            listViewSearchResults.View = View.Details;
        }

        private void buttonSearchGo_Click(object sender, EventArgs e)
        {
            SearchStarted(textBoxSearchFilename.Text, textBoxSearchString.Text,comboBoxVolume.SelectedText);
        }

        private void buttonSearchStop_Click(object sender, EventArgs e)
        {
            SearchStop(this, null);
        }
    }
}
