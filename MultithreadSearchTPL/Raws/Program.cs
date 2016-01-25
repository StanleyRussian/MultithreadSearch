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
            MainForm mf = new MainForm();
            Presenter p = new Presenter(mf);
            Application.Run(mf);
        }
    }
}
