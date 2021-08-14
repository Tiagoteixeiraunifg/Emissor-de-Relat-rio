using EmissorRelatorios.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios
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
            frmPrincipal frmPrin = new frmPrincipal();
            frmPrin.verificaVersaoCrystal();
            if (frmPrin.requisitosOK) { Application.Run(new frmPrincipal()); } else { Application.Exit(); }
           
        }
    }
}
