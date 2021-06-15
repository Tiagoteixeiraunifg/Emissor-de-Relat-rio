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
        private static DadosTemp.DataSetVendas dsVendas;
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
            clsUtil = new ClsUtil();
            dsVendas = new DadosTemp.DataSetVendas();
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
                        chk.Size = new System.Drawing.Size(139, 17);
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

        private bool VerificaCkb()
        {
            bool cheked = false;
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {
                if (ctrl is CheckBox)
                {
                    if (((CheckBox)(ctrl)).Checked == true)
                    {
                        cheked = true;
                    }
                }
            }
            return cheked;
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            if (VerificaCkb()) {
                string express = criarExpressao();
                if (dsVendas.VENDAS_CAIXA.Count > 0) { dsVendas.VENDAS_CAIXA.Clear(); }
                dsVendas = clsSaidaDAO.selectMovimentoFormaPgto(DataInicial.ToString("yyyy/MM/dd"), DataFinal.ToString("yyyy/MM/dd"), Tipo, express);
                if (dsVendas.VENDAS_CAIXA.Count > 0)
                {
                    frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaCupom.rpt");
                    prtVnd.Show();
                }
                else 
                {
                    clsUtil.MsgBox("Sem informações para o filtro selecionado!", MessageBoxIcon.Information);
                }
      
            }
            else
            {
                clsUtil.MsgBox("Sem meios de pagamento selecionados!", MessageBoxIcon.Information);
            }

        }

        private void btnFolhaA4_Click(object sender, EventArgs e)
        {
            if (VerificaCkb())
            {
                string express = criarExpressao();
                if (dsVendas.VENDAS_CAIXA.Count > 0) { dsVendas.VENDAS_CAIXA.Clear(); }
                dsVendas = clsSaidaDAO.selectMovimentoFormaPgto(DataInicial.ToString("yyyy/MM/dd"), DataFinal.ToString("yyyy/MM/dd"), Tipo, express);
                if (dsVendas.VENDAS_CAIXA.Count > 0)
                {
                    frmPrintVendas prtVnd = new frmPrintVendas(dsVendas, "FechamentoCxDiaA4.rpt");
                    prtVnd.Show();
                }
                else
                {
                    clsUtil.MsgBox("Sem informações para o filtro selecionado!", MessageBoxIcon.Information);
                }

            }
            else 
            {
                clsUtil.MsgBox("Sem meios de pagamento selecionados!", MessageBoxIcon.Information);
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
