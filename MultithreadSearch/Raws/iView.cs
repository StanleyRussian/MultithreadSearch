using System;
using System.Windows.Forms;

namespace MultithreadSearch
{
    interface iView
    {
        event EventHandler SearchStarted;
        event EventHandler SearchStop;

        bool SearchSubdirs
        { get; }
        string SearchFilename
        { get; }
        string SearchString
        { get; }
        string Volume
        { get; }

        ListView SearchResults
        { get; }
        ImageList IconsSmall
        { get; }
        ImageList IconsLarge
        { get; }

        void SetVolumes(string[] volumes);
    }
}
