using System;

namespace MultithreadSearch
{
    public delegate void SearchDelegate(string arg1, string arg2, string arg3);

    interface iView
    {
        event SearchDelegate SearchStarted;
        event EventHandler SearchStop;

        bool SearchSubdirs
        { get; }
        System.Windows.Forms.ListView SearchResults
        { set; }
    }
}
