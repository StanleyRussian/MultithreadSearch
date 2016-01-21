using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultithreadSearch
{
    public partial class MainForm : Form, iView
    {
        public bool SearchSubdirs
        {
            get { return checkBoxSubdirs.Checked; }
        }

        public ListView SearchResults
        {
            get { return listViewSearchResults; }
        }

        public string SearchFilename
        {
            get { return textBoxSearchFilename.Text; }
        }

        public string SearchString
        {
            get { return textBoxSearchString.Text; }
        }

        public string Volume
        {
            get {return comboBoxVolume.Text; }
        }

        public ImageList IconsSmall
        {
            get;
            private set;
        }

        public ImageList IconsLarge
        {
            get;
            private set;
        }

        public MainForm()
        {
            InitializeComponent();
            new Presenter(this);

            IconsSmall = new ImageList();
            IconsLarge = new ImageList();
            IconsSmall.ImageSize = new Size(16, 16);
            IconsSmall.ColorDepth = ColorDepth.Depth32Bit;
            IconsLarge.ImageSize = new Size(32, 32);
            IconsLarge.ColorDepth = ColorDepth.Depth32Bit;

            SearchResults.SmallImageList = IconsSmall;
            SearchResults.LargeImageList = IconsLarge;
        }

        public event EventHandler SearchStarted;
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
            SearchStarted(this, null);
        }

        private void buttonSearchStop_Click(object sender, EventArgs e)
        {
            SearchStop(this, null);
        }

        public void SetVolumes(string[] volumes)
        {
            comboBoxVolume.Items.Clear();
            comboBoxVolume.Items.AddRange(volumes);
        }
    }
}
