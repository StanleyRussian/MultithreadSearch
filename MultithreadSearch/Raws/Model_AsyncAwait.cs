using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadSearch
{
    class Model_AsyncAwait : iModel
    {
        public List<FileInfo> Files
        {
            get;
            private set;
        }

        public event EventHandler SearchFinished;
        public event FileListDlg Found;

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;
        Task tsk;

        public void Search(string file, string str, string loc, bool subdirs)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            SearchLauncher(file, str, loc, subdirs).GetAwaiter();
        }

        public void StopSearch()
        {
            try
            {
                tokenSource.Cancel();
                tokenSource.Dispose();
            }
            catch (Exception ex) { }
        }

        private async Task SearchLauncher (string file, string str, string loc, bool subdirs)
        {
            if (str != "")
                Files = await Task.Run(() => SearchInFiles(loc, str, subdirs, token));
            else
                Files = await Task.Run(() => SearchForFiles(loc, file, subdirs, token));

            await Task.Run(() =>
            {
                SearchFinished(this, null);
            });
            
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

            Found(files);
            return files;
        }

        private List<FileInfo> SearchForFiles(string path, string pattern, bool subdirs, CancellationToken token)
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
                        files.AddRange(SearchForFiles(directory, pattern, subdirs, token));
            }
            catch (UnauthorizedAccessException) { }

            Found(files);
            return files;
        }
    }
}
