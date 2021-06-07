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
    public partial class frmPrintVendas : Form
    {
        ReportDocument rp;
        DataSetVendas dsVendas;
        private static ClsUtil clsUtil;
        public frmPrintVendas(DataSetVendas ds, string relatorio)
        {
            InitializeComponent();
            dsVendas = new DataSetVendas();
            rp = new ReportDocument();
            dsVendas = ds;
            imprimir(relatorio);
        }

        public void imprimir(string relatorio)
        {
            if (File.Exists(frmPrincipal.path + "relatorios\\"+ relatorio))
            {

                rp.Load(frmPrincipal.path + "relatorios\\"+ relatorio);
                rp.SetDataSource(dsVendas);
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
