using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadSearch
{
    class Model : iModel
    {
        public List<FileInfo> Files
        {
            get;
            private set;
        }

        public event EventHandler SearchFinished;
        public event EventHandler SearchStarted;
        public event EventHandler SearchStopped;

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;

        public void Search(string file, string str, string loc, bool subdirs)
        {
            SearchStarted(this, null);

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            Task<List<FileInfo>> tsk = Task.Run(() => GetFiles(loc, file, subdirs, token));
            tsk.ContinueWith((x) =>
            {
                Files = x.Result;
                SearchFinished(this, null);
            });
        }

        public void StopSearch()
        {
            tokenSource.Cancel();
            tokenSource.Dispose();
        }

        private List<FileInfo> GetFiles(string path, string pattern, bool subdirs, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();
            }
            catch (Exception ex)
            {
                SearchStopped(this, null);
            }

            var files = new List<FileInfo>();

            try
            {
                string[] filenames;
                if (!subdirs)
                    filenames = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                else
                    filenames = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                foreach (string s in filenames)
                {
                    files.Add(new FileInfo(s));
                }
                foreach (var directory in Directory.GetDirectories(path))
                    files.AddRange(GetFiles(directory, pattern, subdirs, token));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }
    }
}
