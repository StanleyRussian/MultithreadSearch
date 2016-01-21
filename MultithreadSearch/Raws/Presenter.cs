using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MultithreadSearch
{
    class Presenter
    {
        iView _view;
        iModel _model;

        public Presenter(iView view)
        {
            _view = view;
            _view.SearchStarted += _view_SearchStarted;
            _view.SearchStop += _view_SearchStop;
            _view.SetVolumes(Directory.GetLogicalDrives());

            _model = new Model();
        }

        private void _view_SearchStop(object sender, System.EventArgs e)
        {
            _model.StopSearch();
        }

        private void _view_SearchStarted(object sender, System.EventArgs e)
        {
            _view.IconsSmall.Images.Clear();
            _view.IconsLarge.Images.Clear();
            int index = 0;

            _model.Search(_view.SearchFilename, _view.SearchString, _view.Volume, _view.SearchSubdirs);
            foreach (FileInfo file in _model.Files)
            {
                string[] columns = { file.Name, file.FullName, (file.Length/1024).ToString(), file.CreationTime.ToString() };
                var item = new ListViewItem(columns, index++);
                _view.SearchResults.Items.Add(item);
                _view.IconsSmall.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
                _view.IconsLarge.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
            }
        }
    }
}
