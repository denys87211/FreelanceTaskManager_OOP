using System;
using System.Windows.Forms;
using FreelanceTaskManager.Database;

namespace FreelanceTaskManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
