﻿using EmissorRelatorios.DadosTemp;
using System;
using System.Data;
using System.Windows.Forms;
using EmissorRelatorios.Controles;

namespace EmissorRelatorios.Views
{
    public partial class frmSaida : Form
    {
        ClsSaidaDAO clsSaidaDAO;
        private static string relatorioNome;
        DataSetVendas daVendas;
        private static int tipo; //tipo 1 DAV, 2 NFCE, 3 NFE
        private static int funcaoDAO;
        public frmSaida()
        {
            funcaoDAO = 0;
            tipo = 0;
            daVendas = new DataSetVendas();
            clsSaidaDAO = new ClsSaidaDAO();
            
            InitializeComponent();
            loadCombobox();
            rdbTodos.Checked = true;

        }


        private void loadCombobox() {
            
            
            DataTable dtCliente = new DataTable();
            dtCliente = clsSaidaDAO.GetClientes();
            if (dtCliente.Rows.Count > 0) {
                cboCliente.CausesValidation = false;
                cboCliente.DataSource = dtCliente;
                for (int i = 0; i > dtCliente.Rows.Count; i++) { cboCliente.AutoCompleteCustomSource.Add(dtCliente.Columns["RAZ_SOCIAL"].ToString()); }
                cboCliente.AutoCompleteMode = AutoCompleteMode.Append;
                cboCliente.ValueMember = "ID_CLIENTE";
                cboCliente.DisplayMember = "RAZ_SOCIAL";
                cboCliente.SelectedIndex = 0;
                cboCliente.CausesValidation = true;
            }



            DataTable dtUsuario = new DataTable();
            dtUsuario = clsSaidaDAO.GetUsuarios();
            if (dtUsuario.Rows.Count > 0) {
                cboUsuario.CausesValidation = false;
                cboUsuario.DataSource = dtUsuario;
                cboUsuario.ValueMember = "ID";
                cboUsuario.DisplayMember = "USUARIO";
                cboUsuario.SelectedIndex = 0;
                cboUsuario.CausesValidation = true;
            }




            DataTable dtVendedor = new DataTable();
            dtVendedor = clsSaidaDAO.GetVendedor();
            if (dtVendedor.Rows.Count > 0) {
                cboVendedor.CausesValidation = false;
                cboVendedor.DataSource = dtVendedor;
                cboVendedor.ValueMember = "ID";
                cboVendedor.DisplayMember = "DESCRICAO";
                cboVendedor.SelectedIndex = 0;
                cboVendedor.SelectedValue = 1;
                cboVendedor.CausesValidation = true;
            }


            DataTable dtGrupo = new DataTable();
            dtGrupo = clsSaidaDAO.GetGrupo();
            if (dtGrupo.Rows.Count > 0) {
                cboGrupo.DataSource = dtGrupo;
                cboGrupo.SelectedIndex = 0;
                cboGrupo.CausesValidation = false;
                cboGrupo.ValueMember = "ID";
                cboGrupo.DisplayMember = "GRUPO";
                cboGrupo.CausesValidation = true;
            }
        

        }
        /*tipo true saida tipo false entrada*/
  

      

        private void imprimirSaida(string nomeRelatorio, int funcao, int tipo) {
            try
            {
                if (int.Parse(daVendas.VENDAS.Rows.Count.ToString()) >= 0) { daVendas.VENDAS.Clear(); }
            }
            catch (Exception)
            {
                throw;
            }

            if (txtProduto.Text.ToString().Equals("")) { txtProduto.Text = "0"; }
            
            if(funcaoDAO == 7)
            {
                daVendas = clsSaidaDAO.selectMovimento(dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"));
                frmPrintVendas print = new frmPrintVendas(daVendas, nomeRelatorio);
                print.Show();
            }else  if (funcaoDAO == 8)
            {
                daVendas = clsSaidaDAO.selectMovimento(dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"), tipo);
                frmSelecaoTipoMov print = new frmSelecaoTipoMov(daVendas);
                print.Show();
            }
            else if (funcaoDAO != 8 && funcaoDAO != 7)
            {
                daVendas = clsSaidaDAO.selectVendas(funcao, tipo, dataInicial.Value.ToString("yyyy/MM/dd"), dataFinal.Value.ToString("yyyy/MM/dd"),txtProduto.Text.ToString(), cboVendedor.SelectedValue.ToString(), cboCliente.SelectedValue.ToString(), cboGrupo.SelectedValue.ToString());
                frmPrintVendas print = new frmPrintVendas(daVendas, nomeRelatorio);
                print.Show();
            }

        }
    

        private void rdbTodos_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 0;
        }

        private void btnGerarRel_MouseClick(object sender, MouseEventArgs e)
        {
            imprimirSaida(relatorioNome, funcaoDAO, tipo);      
        }

        private void rdbDav_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 1;
        }

        private void rdbNfce_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 2;
        }

        private void rdbNfe_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 3;
        }

        private void rdbdTodos_MouseClick(object sender, MouseEventArgs e)
        {
            tipo = 0;
        }


        private void rdbProdVendItem_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 1;
            relatorioNome = "VendasVendedorItem.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = true;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;

        }

        private void rdbProdVend_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 2;
            relatorioNome = "VendasVendedor.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = true;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendRes_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 2;
            relatorioNome = "VendasVendedorItemResFull.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = true;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendResItem_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 1;
            relatorioNome = "VendasVendedorItemRes.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = true;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendResTodos_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 3;
            relatorioNome = "VendasVendedorItemResTodos.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendResTodosItem_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 4;
            relatorioNome = "VendasVendedorItemResTodosItem.rpt";
            cboCliente.Enabled = true;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendResTodosCliente_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 5;
            relatorioNome = "VendasVendedorItemResTodosItemClientesFull.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendDetTodosCliente_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 5;
            relatorioNome = "VendasVendedorItemDetTodosItemClientesFull.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendDetTodosItem_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 4;
            relatorioNome = "VendasVendedorItemDetTodosItem.rpt";
            cboCliente.Enabled = true;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = true;
            cboGrupo.Enabled = false;
        }

        private void rdbProdVendDetGrupo_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 6;
            relatorioNome = "VendasVendedorItemDetGrupo.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = true;


        }

        private void rbdFechamentoCxDia_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 7;
            relatorioNome = "FechamentoCxDia.rpt";
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = false;
        }

        private void rbdFechamentoCx_MouseClick(object sender, MouseEventArgs e)
        {
            funcaoDAO = 8;
            cboCliente.Enabled = false;
            cboUsuario.Enabled = false;
            cboVendedor.Enabled = false;
            txtProduto.Enabled = false;
            cboGrupo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsAjusteMovimento aj = new ClsAjusteMovimento();
            aj.selectHist();
        }


        private void frmSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.F12)
            {
                ClsAjusteMovimento aj = new ClsAjusteMovimento();
                aj.selectHist();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClsAjusteMovimento aj = new ClsAjusteMovimento();
            aj.selectHist();
            aj.selectDavMovDel();
        }
    }
}