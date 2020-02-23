using System;
using System.Windows.Forms;

namespace Imetter
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain main = new FormMain();
            try {
                Application.Run(main);
            } finally {
                main.EndProgram();
            }
        }
    }
}
