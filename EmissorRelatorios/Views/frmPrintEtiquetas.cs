using CrystalDecisions.CrystalReports.Engine;
using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using System;
using System.IO;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmPrintEtiquetas : Form
    {
        ReportDocument rp;
        DataSetEtiquetas dsEtiquetas;
        private static ClsUtil clsUtil;
        public frmPrintEtiquetas(DataSetEtiquetas ds, string relatorio)
        {
            InitializeComponent();
            dsEtiquetas = new DataSetEtiquetas();
            rp = new ReportDocument();
            dsEtiquetas = ds;
            imprimir(relatorio);
        }

        public void imprimir(string relatorio)
        {
            if (File.Exists(frmPrincipal.path + "relatorios\\etiquetas\\"+relatorio +""))
            {
            
                rp.Load(frmPrincipal.path + "relatorios\\etiquetas\\"+relatorio+"");
                rp.SetDataSource(dsEtiquetas);
                crvPrint.ReportSource = rp;
                rp.Refresh();
                //crv_resultado.PrintReport();
                //rp.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "documentoEtiqueta.pdf");
                //crvPrint.ExportReport();
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
