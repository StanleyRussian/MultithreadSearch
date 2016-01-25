using System;
using System.Collections.Generic;
using System.IO;

namespace MultithreadSearch
{
    interface iModel
    {
        void Search(string file, string str, string loc, bool subdirs);
        void StopSearch();

        List<FileInfo> Files
        { get; }

        event EventHandler SearchFinished;
        event EventHandler SearchStopped;
    }
}
