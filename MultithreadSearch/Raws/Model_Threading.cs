using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MultithreadSearch
{
    class Model_Threading : iModel
    {
        public List<FileInfo> Files
        {
            get;
            private set;
        }
        public event EventHandler SearchFinished;

        Thread trd;
        private volatile bool _shouldStop;

        public void Search(string file, string str, string loc, bool subdirs)
        {
            trd = new Thread(() => SearchLauncher(file, str, loc, subdirs));
            _shouldStop = false;
            trd.Start();
        }

        public void StopSearch()
        {
            _shouldStop = true;
        }

        private void SearchLauncher (string file, string str, string loc, bool subdirs)
        {
            if (str != "")
                Files = SearchInFiles(loc, str, subdirs);
            else
                Files = SearchForFiles(loc, file, subdirs);

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
