using System;
using System.Collections.Generic;
using System.IO;
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

        public void Search(string file, string str, string loc, bool subdirs)
        {
            Task<List<FileInfo>> tsk = new Task<List<FileInfo>>(GetFiles(loc, file));
            tsk.Wait();
            tsk.Dispose();
            Files = tsk.Result;
        }

        public void StopSearch()
        {
            throw new NotImplementedException();
        }

        private List<FileInfo> GetFiles(string path, string pattern)
        {
            var files = new List<FileInfo>();

            try
            {
                string[] filenames = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                foreach (string s in filenames)
                {
                    files.Add(new FileInfo(s));
                }
                
                foreach (var directory in Directory.GetDirectories(path))
                    files.AddRange(GetFiles(directory, pattern));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }
    }
}
