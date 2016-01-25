using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadSearch
{
    class Model_TPL: iModel
    {
        public List<FileInfo> Files
        {
            get;
            private set;
        }

        public event EventHandler SearchFinished;

        Task<List<FileInfo>> tsk;

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;

        public void Search(string file, string str, string loc, bool subdirs)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            if (str != "")
                tsk = Task.Run(() => SearchInFiles(loc, str, subdirs, token));
            else
                tsk = Task.Run(() => GetFiles(loc, file, subdirs, token));

            tsk.ContinueWith((x) =>
            {
                Files = x.Result;
                SearchFinished(this, null);
            });
        }

        public void StopSearch()
        {
            try
            {
                tokenSource.Cancel();
                tsk.Wait();
                tokenSource.Dispose();
            }
            catch (Exception ex) { }
        }

        private List<FileInfo> SearchInFiles(string path, string str, bool subdirs, CancellationToken token)
        {
            var files = new List<FileInfo>();
            if (token.IsCancellationRequested)
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
                        files.AddRange(SearchInFiles(directory, str, subdirs, token));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }

        private List<FileInfo> GetFiles(string path, string pattern, bool subdirs, CancellationToken token)
        {
            var files = new List<FileInfo>();
            if (token.IsCancellationRequested)
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
                        files.AddRange(GetFiles(directory, pattern, subdirs, token));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }
    }
}
