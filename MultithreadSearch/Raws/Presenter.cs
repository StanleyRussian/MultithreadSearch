﻿using System.Drawing;
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
        int index = 0;

        public Presenter(iView view, iModel model)
        {
            _view = view;
            _view.SearchStart += _view_SearchStart;
            _view.SearchStop += _view_SearchStop;
            _view.SetVolumes(Directory.GetLogicalDrives());

            _model = model;
            _model.SearchFinished += _model_SearchFinished;
            _model.Found += _model_Found;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
        }

        private void _model_Found(System.Collections.Generic.List<FileInfo> foundfiles)
        {
            foreach (var file in foundfiles)
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
            }
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            counter++;
            if (counter % 10 == 0)
                _view.SearchState.Text = "Идет поиск. Время: " + counter + " миллисекунд";
        }

        private void _model_SearchFinished(object sender, System.EventArgs e)
        {
            timer.Stop();
            index = 0;

            if (_view.SearchResults.InvokeRequired)
            {
                SetStateDelegate setstate = new SetStateDelegate(_view.SetState);
                _view.SearchResults.Invoke(setstate, "Поиск завершён за " + counter + " миллисекунд, найдено: " + _model.Files.Count + " файлов");
            }
            else
                _view.SearchState.Text = "Поиск завершён за " + counter + " миллисекунд, найдено: " + _model.Files.Count + " файлов";
        }

        private void _view_SearchStop(object sender, System.EventArgs e)
        {
            _model.StopSearch();
            timer.Stop();
            if (_view.SearchResults.InvokeRequired)
            {
                SetStateDelegate setstate = new SetStateDelegate(_view.SetState);
                _view.SearchResults.Invoke(setstate, "Поиск остановлен на " + counter + " миллисекунде");
            }
            else
                _view.SearchState.Text = "Поиск остановлен на " + counter + " миллисекунде";
        }

        private void _view_SearchStart(object sender, System.EventArgs e)
        {
            if ((_view.SearchFilename != "" || _view.SearchString != "") && _view.Volume != "")
            {
                counter = 0;
                index = 0;
                timer.Start();
                _view.SearchResults.Items.Clear();
                _view.IconsSmall.Images.Clear();
                _view.IconsLarge.Images.Clear();

                _model.Search(_view.SearchFilename, _view.SearchString, _view.Volume, _view.SearchSubdirs);
            }
        }
    }
}
