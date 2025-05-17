using System;
using System.Windows.Forms;
using CapaPresentacion;

namespace CapPresentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PrincipalMDI());  
        }
    }
}