using System.Windows.Forms;

namespace MultithreadSearch
{
    class Presenter
    {
        iView _view;
        iModel _model;

        public Form form
        {
            get { return _view as Form; }
        }

        public Presenter()
        {
            _view = new Form1();
            _view.SearchStarted += _view_SearchStarted;
            _view.SearchStop += _view_SearchStop;

            _model = new Model();
        }

        private void _view_SearchStop(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _view_SearchStarted(string arg1, string arg2, string arg3)
        {
            throw new System.NotImplementedException();
        }
    }
}
