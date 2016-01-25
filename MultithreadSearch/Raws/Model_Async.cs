using System;
using System.Collections.Generic;
using System.IO;

namespace MultithreadSearch
{
    class Model_Async : iModel
    {
        public List<FileInfo> Files
        {
            get;
            private set;
        }

        public event EventHandler SearchFinished;

        delegate List<FileInfo> SearchDlg(string path, string pattern_filename, bool subdirs);
        private volatile bool _shouldStop;
        SearchDlg search_dlg;
        IAsyncResult resultObj;

        public void Search(string file, string str, string loc, bool subdirs)
        {
            _shouldStop = false;

            if (str != "")
            {
                search_dlg = new SearchDlg(SearchInFiles);
                resultObj = search_dlg.BeginInvoke(loc, str, subdirs, AsyncCallbackFinished, null);
            }
            else
            {
                search_dlg = new SearchDlg(SearchForFiles);
                resultObj = search_dlg.BeginInvoke(loc, file, subdirs, AsyncCallbackFinished, null);
            }

        }

        public void StopSearch()
        {
            _shouldStop = true;
        }

        public void AsyncCallbackFinished ( IAsyncResult ar)
        {
            Files = search_dlg.EndInvoke(ar);
            SearchFinished(this, null);
        }

        private List<FileInfo> SearchInFiles(string path, string str, bool subdirs)
        {
            var files = new List<FileInfo>();
            if (_shouldStop)
                return files;
            try
            {
                string[] filenames = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);
                foreach (string s in filenames)
                {
                    foreach (string line in File.ReadLines(s))
                    {
                        if (line.Contains(str))
                        {
                            files.Add(new FileInfo(s));
                            break;
                        }
                    }
                }
                if (subdirs)
                    foreach (var directory in Directory.GetDirectories(path))
                        files.AddRange(SearchInFiles(directory, str, subdirs));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }

        private List<FileInfo> SearchForFiles(string path, string pattern, bool subdirs)
        {
            var files = new List<FileInfo>();
            if (_shouldStop)
                return files;
            try
            {
                string[] filenames = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                foreach (string s in filenames)
                {
                    files.Add(new FileInfo(s));
                }
                if (subdirs)
                    foreach (var directory in Directory.GetDirectories(path))
                        files.AddRange(SearchForFiles(directory, pattern, subdirs));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }

    }
}
