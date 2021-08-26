using System;
using System.Windows.Forms;

namespace AP1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmEmploymentRecord());
        }
    }
}
