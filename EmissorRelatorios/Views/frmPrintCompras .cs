using CrystalDecisions.CrystalReports.Engine;
using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmPrintCompras : Form
    {
        ReportDocument rp;
        DataSetCompras dsCompras;
        private static ClsUtil clsUtil;
        public frmPrintCompras(DataSetCompras ds, string relatorio)
        {
            InitializeComponent();
            dsCompras = new DataSetCompras();
            rp = new ReportDocument();
            dsCompras = ds;
            imprimir(relatorio);
        }

        public void imprimir(string relatorio)
        {
            if (File.Exists(frmPrincipal.path + "relatorios\\"  + relatorio))
            {

                rp.Load(frmPrincipal.path + "relatorios\\" + relatorio);
                rp.SetDataSource(dsCompras);
                crvPrint.ReportSource = rp;
                rp.Refresh();
                //crv_resultado.PrintReport();
            }
            else
            {
                clsUtil.MsgBox("O arquivo "+ relatorio + " não está na pasta do sistema!", MessageBoxIcon.Question);
            }
        }
        private void frmPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
