using System;
using System.Collections.Generic;
using System.IO;

namespace MultithreadSearch
{
    public delegate void FileListDlg(List<FileInfo> arg);

    interface iModel
    {
        void Search(string file, string str, string loc, bool subdirs);
        void StopSearch();

        List<FileInfo> Files
        { get; }

        event EventHandler SearchFinished;
        event FileListDlg Found;
    }
    delegate void FileDlg(FileInfo file);
}
