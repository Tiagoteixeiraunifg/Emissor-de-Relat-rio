using EmissorRelatorios.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios.Controles
{
    class EtiquetaController : IController
    {
        private frmEtiquetas frm;
        public void executa(object view)
        {
            frm = (frmEtiquetas)view;
            string teste = frm.getTextBox().Text;
            //
        }

        public void teste() {
            if (frm.getTextBox().Text.Equals("teste")) { MessageBox.Show("Apertou o enter"); frm.getTextBox().Text = "Usou a classe de controller"; } 
        }
        public void IController(object view)
        {
            throw new NotImplementedException();
        }
    }
}
