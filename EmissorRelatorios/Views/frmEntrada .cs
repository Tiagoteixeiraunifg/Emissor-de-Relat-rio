using CrystalDecisions.CrystalReports.Engine;
using EmissorRelatorios.Modelos;
using EmissorRelatorios.DadosTemp;
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
using EmissorRelatorios.Controles;

namespace EmissorRelatorios.Views
{
    public partial class frmEntrada : Form
    {
        ClsSaidaDAO clsSaidaDAO;
        ClsEntradaDAO clsEntradaDAO;
        private static string relatorioNome;
        DataSetCompras dsCompras;
        private static int tipo; //tipo 1 DAV, 2 NFCE, 3 NFE
        private static int funcaoDAO;
        public frmEntrada()
        {
            funcaoDAO = 0;
            tipo = 0;
            dsCompras = new DataSetCompras();
            clsSaidaDAO = new ClsSaidaDAO();
            clsEntradaDAO = new ClsEntradaDAO();
            
            InitializeComponent();
            loadCombobox();
            rdbNfe55.Checked = true;
            cboNfeE.Enabled = false;

        }


        private void loadCombobox() {
            cboCliente.CausesValidation = false;
            cboCliente.DataSource = clsEntradaDAO.GetFornecedores();
            DataTable dt = new DataTable();
            dt = clsEntradaDAO.GetFornecedores();
            for (int i = 0; i > dt.Rows.Count; i ++) { cboCliente.AutoCompleteCustomSource.Add(dt.Columns["FANTASIA"].ToString()); }
            cboCliente.AutoCompleteMode = AutoCompleteMode.Append;
            cboCliente.ValueMember = "ID_FORNECEDOR";
            cboCliente.DisplayMember = "RAZ_SOCIAL";
            cboCliente.SelectedIndex = 0;
            cboCliente.CausesValidation = true;

        }
        /*tipo true saida tipo false entrada*/

        private void loadComboNota() {
            cboNfeE.Enabled = true;
            cboNfeE.CausesValidation = false;
            cboNfeE.DataSource = clsEntradaDAO.GetNfeE(cboCliente.SelectedValue.ToString(), dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"));
            cboNfeE.ValueMember = "ID";
            cboNfeE.DisplayMember = "NOTA";
            cboNfeE.SelectedIndex = -1;
            cboNfeE.CausesValidation = true;
        }
      

        private void imprimirSaida(string nomeRelatorio, int funcao, int tipo) {
            try
            {
                if (int.Parse(dsCompras.COMPRAS.Rows.Count.ToString()) >= 0) { dsCompras.COMPRAS.Clear(); }
            }
            catch (Exception)
            {
                throw;
            }

            dsCompras = clsEntradaDAO.selectCompras(funcao, tipo, dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"), cboCliente.SelectedValue.ToString(), cboNfeE.SelectedValue.ToString());
           // daVendas = clsSaidaDAO.selectVendas(funcao, tipo, dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"),txtProduto.Text.ToString(), cboVendedor.SelectedValue.ToString(), cboCliente.SelectedValue.ToString());
           // functionOut(funcaoDAO);

            frmPrintCompras print = new frmPrintCompras(dsCompras, nomeRelatorio);
            print.Show();
        }
    


        private void btnGerarRel_MouseClick(object sender, MouseEventArgs e)
        {
            imprimirSaida(relatorioNome, funcaoDAO, tipo);      
        }

        private void rdbProdVendItem_MouseClick(object sender, MouseEventArgs e)
        {
          
           
        }

        private void cboCliente_Validated(object sender, EventArgs e)
        {
            loadComboNota();
        }

        private void rdbNfe55_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 0;
        }

        private void rdbCompras1_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 1;
            relatorioNome = "Compras1.rpt";
        }
    }
}
