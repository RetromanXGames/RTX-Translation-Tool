using System;
using System.Windows.Forms; // Adicione esta linha

namespace WindowsFormsApp3
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Altere para Form1
        }
    }
}
