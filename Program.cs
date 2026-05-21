using System;
using System.Windows.Forms;
using JobPortalSystemProject.Forms;

namespace JobPortalSystemProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new WelcomeDashboard());
        }
    }
}