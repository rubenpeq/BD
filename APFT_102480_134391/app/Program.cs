using System;
using System.Windows.Forms;

namespace Barbearia
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
            Application.Run(new FormMenu()); // Diz para começar abrindo a tua janela Form1
        }
    }
}