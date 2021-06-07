using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmSelecaoTipoMov : Form
    {
        private DadosTemp.DataSetVendas dsVendas;
        
        public frmSelecaoTipoMov(DadosTemp.DataSetVendas dsVnd)
        {
            InitializeComponent();
            dsVendas = dsVnd;

        }

        private void frmSelecaoTipoMov_Load(object sender, EventArgs e)
        {

        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaCupom.rpt");
            prtVnd.Show();
        }

        private void btnFolhaA4_Click(object sender, EventArgs e)
        {
            frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaA4.rpt");
            prtVnd.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
