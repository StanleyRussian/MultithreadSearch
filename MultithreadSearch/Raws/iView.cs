using System;
using System.Windows.Forms;

namespace MultithreadSearch
{
    interface iView
    {
        event EventHandler SearchStart;
        event EventHandler SearchStop;

        bool SearchSubdirs
        { get; }
        string SearchFilename
        { get; }
        string SearchString
        { get; }
        string Volume
        { get; }
        Label SearchState
        { get; }
        ListView SearchResults
        { get; }
        ImageList IconsSmall
        { get; }
        ImageList IconsLarge
        { get; }

        void SetVolumes(string[] volumes);
        void SetState(string state);
    }
}
