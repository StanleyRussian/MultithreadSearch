namespace MultithreadSearch
{
    interface iModel
    {
        void SearchByName(string str, string loc, bool subdirs);
        void SearchInFiles(string str, string loc, bool subdirs);
        void StopSearch();

        string[] FileNames
        { get; }
    }
}
