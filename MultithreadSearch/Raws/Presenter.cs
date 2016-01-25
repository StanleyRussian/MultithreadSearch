using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultithreadSearch
{
    class Presenter
    {
        delegate ListViewItem AddItemDelegate(ListViewItem item);
        delegate void AddIconDelegate(Icon icon);
        delegate void SetStateDelegate(string state);

        iView _view;
        iModel _model;
        Timer timer;
        ulong counter;

        public Presenter(iView view)
        {
            _view = view;
            _view.SearchStart += _view_SearchStart;
            _view.SearchStop += _view_SearchStop;
            _view.SetVolumes(Directory.GetLogicalDrives());

            _model = new Model();
            //_model.SearchStarted += _model_SearchStarted;
            _model.SearchFinished += _model_SearchFinished;
            _model.SearchStopped += _model_SearchStopped;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            counter++;
        }

        private void _model_SearchStopped(object sender, System.EventArgs e)
        {
            timer.Stop();
            if (_view.SearchResults.InvokeRequired)
            {
                SetStateDelegate setstate = new SetStateDelegate(_view.SetState);
                _view.SearchResults.Invoke(setstate, "Поиск остановлен на " + counter + " миллисекунде");
            }
        }

        private void _model_SearchFinished(object sender, System.EventArgs e)
        {
            timer.Stop();
            int index = 0;

            if (_view.SearchResults.InvokeRequired)
            {
                SetStateDelegate setstate = new SetStateDelegate(_view.SetState);
                _view.SearchResults.Invoke(setstate, "Поиск завершён за " + counter + " миллисекунд, найдено: " + _model.Files.Count + " файлов");
            }
            else
                _view.SearchState.Text = "Поиск завершён за " + counter + " миллисекунд, найдено: " + _model.Files.Count + " файлов";

            Task tsk = Task.Run(() =>
           {
               Parallel.ForEach(_model.Files, (file) =>
               {
                   string[] columns = { file.Name, file.FullName, (file.Length / 1024).ToString(), file.CreationTime.ToString() };
                   var item = new ListViewItem(columns, index++);
                   if (_view.SearchResults.InvokeRequired)
                   {
                       AddItemDelegate additem = new AddItemDelegate(_view.SearchResults.Items.Add);
                       _view.SearchResults.Invoke(additem, item);
                       AddIconDelegate addicon = new AddIconDelegate(_view.IconsSmall.Images.Add);
                       _view.SearchResults.Invoke(addicon, Icon.ExtractAssociatedIcon(file.FullName));
                       addicon = new AddIconDelegate(_view.IconsLarge.Images.Add);
                       _view.SearchResults.Invoke(addicon, Icon.ExtractAssociatedIcon(file.FullName));
                   }
                   else
                   {
                       _view.SearchResults.Items.Add(item);
                       _view.IconsSmall.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
                       _view.IconsLarge.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
                   }
               });
           });
        }

        private void _model_SearchStarted(object sender, System.EventArgs e)
        {

        }

        private void _view_SearchStop(object sender, System.EventArgs e)
        {
            _model.StopSearch();
        }

        private void _view_SearchStart(object sender, System.EventArgs e)
        {
            if (_view.SearchFilename != "" || _view.SearchString != "" && _view.Volume != "")
            {
                _view.SearchState.Text = "Идёт поиск";
                _view.SearchResults.Items.Clear();
                counter = 0;
                timer.Start();

                _view.IconsSmall.Images.Clear();
                _view.IconsLarge.Images.Clear();

                _model.Search(_view.SearchFilename, _view.SearchString, _view.Volume, _view.SearchSubdirs);
            }
        }
    }
}
