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
            Presenter p = new Presenter();
            Application.Run(p.form);
            //Application.Run(new Form1());
        }
    }
}
