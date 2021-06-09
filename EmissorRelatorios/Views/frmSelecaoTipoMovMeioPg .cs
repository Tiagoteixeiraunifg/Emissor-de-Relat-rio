using EmissorRelatorios.Controles;
using EmissorRelatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmSelecaoTipoMovMeioPg : Form
    {
        private DadosTemp.DataSetVendas dsVendas;
        private static DateTime DataInicial;
        private static DateTime DataFinal;
        private static int Tipo;
        private static ClsSaidaDAO clsSaidaDAO; 
        private static ClsUtil clsUtil;

        public frmSelecaoTipoMovMeioPg(DateTime DataIni, DateTime DataFim, int TipoMovi)
        {
            InitializeComponent();
            DataInicial = DataIni;
            DataFinal = DataFim;
            Tipo = TipoMovi;
            clsSaidaDAO = new ClsSaidaDAO();
        }

        private void frmSelecaoTipoMov_Load(object sender, EventArgs e)
        {
            criarCheckBox(Tipo);
            //MessageBox.Show("" + flowLayoutPanel.Controls.Count);
        }

        private void criarCheckBox(int tipoMovimento) {
            dsVendas = clsSaidaDAO.selectFormasPgto(tipoMovimento);
            if (clsSaidaDAO.sucesso == true && dsVendas.FormasPgto.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dsVendas.FormasPgto.Count; i++)
                    {
                        this.SuspendLayout();
                        var chk = new System.Windows.Forms.CheckBox();
                        chk.Name = dsVendas.FormasPgto[i].SIGLA;
                        chk.Text = dsVendas.FormasPgto[i].DESCRICAO;
                        flowLayoutPanel.Controls.Add(chk);
                        this.ResumeLayout(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            else 
            {
                clsUtil.MsgBox("Não foram localizados Formas de Pagamentos", MessageBoxIcon.Question); 
            }

        }

        private string criarExpressao()
        {
            string express = "";
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {                
                if (ctrl is CheckBox)
                {
                    if (((CheckBox)(ctrl)).Checked == true)
                    {
                        express = express + ",'" + ((CheckBox)(ctrl)).Name +"'";
                    }  
                }                
            }
            return express;
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            string express = criarExpressao();
            dsVendas = clsSaidaDAO.selectMovimentoFormaPgto(DataInicial.ToString("yyyy/MM/dd"), DataFinal.ToString("yyyy/MM/dd"), Tipo, express);
            frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaCupom.rpt");
            prtVnd.Show();
        }

        private void btnFolhaA4_Click(object sender, EventArgs e)
        {
            string express = criarExpressao();
            dsVendas = clsSaidaDAO.selectMovimentoFormaPgto(DataInicial.ToString("yyyy/MM/dd"), DataFinal.ToString("yyyy/MM/dd"), Tipo, express);
            frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaA4.rpt");
            prtVnd.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
