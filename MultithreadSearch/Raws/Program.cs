using System;
using System.Windows.Forms;

namespace MultithreadSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            iView f = new MainForm();
            //iModel m = new Model_Async();
            //iModel m = new Model_Threading();
            iModel m = new Model_TPL();
            Presenter p = new Presenter(f, m);
            Application.Run((Form)f);
        }
    }
}
