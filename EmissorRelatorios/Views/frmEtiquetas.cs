﻿using EmissorRelatorios.Controles;
using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmEtiquetas : Form
    {
        private DataSet dtProdutos;
        private DataSetEtiquetas dtsEtiquetas;
        private ClsEtiquetasDAO clsEtiquetasDAO;
        private BindingSource bs;
        private ClsProduto clsProduto;
        private DataTable dtPrint;
        private DataTable dtPrintView;
        private static Boolean click;
        private static ClsUtil clsUtil;
        private static string codBarra;

        public frmEtiquetas()
        {
            InitializeComponent();
            clsProduto = new ClsProduto();
            bs = new BindingSource();
            dtProdutos = null;
            dtPrint = new DataTable();
            dtPrintView = new DataTable();
            dtsEtiquetas = new DataSetEtiquetas();
            ajusteDataTable();
            ajusteDataTableView();
            clsEtiquetasDAO = new ClsEtiquetasDAO();
            clsUtil = new ClsUtil();
            dtProdutos = clsEtiquetasDAO.GetProdutos();
            LoaddgvProdutos();
            loadCboRelatorio();
            click = false;
        }

        private void ajusteDataTable() {
            dtPrint.Columns.Add("ID_PRODUTO", typeof(int));
            dtPrint.Columns.Add("GTIN", typeof(string));
            dtPrint.Columns.Add("PRODUTO", typeof(string));
            dtPrint.Columns.Add("VALOR_VENDA", typeof(decimal));
            dtPrint.Columns.Add("VALOR_ATACADO", typeof(decimal));
        }
        private void ajusteDataTableView()
        {
            dtPrintView.Columns.Add("ID_PRODUTO", typeof(int));
            dtPrintView.Columns.Add("GTIN", typeof(string));
            dtPrintView.Columns.Add("PRODUTO", typeof(string));
            dtPrintView.Columns.Add("VALOR_VENDA", typeof(decimal));
            dtPrintView.Columns.Add("VALOR_ATACADO", typeof(decimal));
            dtPrintView.Columns.Add("QTD", typeof(int));
        }
        private void LoaddgvProdutos()
        {
            bs.DataSource = dtProdutos;
            bs.DataMember = dtProdutos.Tables[0].TableName;
            dgvProdutos.DataSource = bs;
            dgvProdutos.AutoResizeColumns();
            //dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutos.Columns["ID_PRODUTO"].HeaderText = "CODIGO";
            dgvProdutos.Columns["ID_PRODUTO"].Width = 45;
            dgvProdutos.Columns["GTIN"].HeaderText = "CODIGO BARRAS";
            dgvProdutos.Columns["PRODUTO"].HeaderText = "DESCRIÇÃO";
            dgvProdutos.Columns["PRODUTO"].Width = 350;
            dgvProdutos.Columns["VALOR_VENDA"].HeaderText = "PREÇO VENDA";
            dgvProdutos.Columns["VALOR_VENDA"].Width = 70;
            dgvProdutos.Columns["VALOR_VENDA"].ValueType = typeof(string);
            dgvProdutos.Columns["VALOR_VENDA"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
            dgvProdutos.Columns["VALOR_VENDA"].DefaultCellStyle.BackColor = Color.FromArgb(200,240,240); 
            dgvProdutos.Columns["VALOR_ATACADO"].HeaderText = "PREÇO ATACADO";
            dgvProdutos.Columns["VALOR_ATACADO"].Width = 70;
            dgvProdutos.Columns["VALOR_ATACADO"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
            dgvProdutos.Columns["VALOR_ATACADO"].DefaultCellStyle.BackColor = Color.FromArgb(100, 255, 255);

        }
        private void LoaddgvProdutosPrint()
        {

            dgvProdutosPrint.DataSource = dtPrintView;
            dgvProdutosPrint.AutoResizeColumns();
            //dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutosPrint.Columns["ID_PRODUTO"].HeaderText = "CODIGO";
            dgvProdutosPrint.Columns["ID_PRODUTO"].Width = 45;
            dgvProdutosPrint.Columns["GTIN"].HeaderText = "CODIGO BARRAS";
            dgvProdutosPrint.Columns["GTIN"].Width = 90;
            dgvProdutosPrint.Columns["PRODUTO"].HeaderText = "DESCRIÇÃO";
            dgvProdutosPrint.Columns["PRODUTO"].Width = 260;
            dgvProdutosPrint.Columns["VALOR_VENDA"].HeaderText = "PREÇO VENDA";
            dgvProdutosPrint.Columns["VALOR_VENDA"].Width = 70;
            dgvProdutosPrint.Columns["VALOR_VENDA"].ValueType = typeof(string);
            dgvProdutosPrint.Columns["VALOR_VENDA"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
            dgvProdutosPrint.Columns["VALOR_ATACADO"].HeaderText = "PREÇO ATACADO";
            dgvProdutosPrint.Columns["VALOR_ATACADO"].Width = 70;
            dgvProdutosPrint.Columns["VALOR_ATACADO"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
            dgvProdutosPrint.Columns["QTD"].HeaderText = "QUANTIDADE";
            dgvProdutosPrint.Columns["QTD"].Width = 100;

        }

        private void loadCboRelatorio() 
        {

            DirectoryInfo di = new DirectoryInfo(frmPrincipal.path + "relatorios\\etiquetas\\");
            Console.WriteLine("No search pattern returns:");
            foreach (var fi in di.GetFiles())
            {
                cbSelectEtq.Items.Add(fi.Name);
                //Console.WriteLine(fi.Name);
            }
            if (cbSelectEtq.Items.Count >= 1)
            {
                cbSelectEtq.SelectedIndex = 0;
            }

        }
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtProdutos.Tables[0].Rows.Count < 0)
            {
                dtProdutos = clsEtiquetasDAO.GetProdutos();
            }
            else if(dtProdutos.Tables[0].Rows.Count > 0)
            {
                bs.Filter = "PRODUTO like '%" + txtFiltro.Text.Replace("'", "''") + "%' OR GTIN LIKE '%" + txtFiltro.Text.Replace("'", "''") + "%'";

            }
            else if (e.KeyChar.ToString() == Convert.ToString((Char)Keys.Enter))
            {

                bs.Filter = "GTIN = '" + txtFiltro.Text.Replace("'", "''") + "'";
                nUpQtd.Focus();

            }
            else if (e.KeyChar.ToString() == Convert.ToString((Char)Keys.Enter) && txtFiltro.Text.Equals(""))
            {
                bs.RemoveFilter();
            }
            else if (e.KeyChar.ToString() == Convert.ToString((Char)Keys.Down) && txtFiltro.Text.ToString().Length > 0) 
            {
                dgvProdutos.Focus();
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clsProduto.setIdProduto(int.Parse(this.dgvProdutos["ID_PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setGtin(this.dgvProdutos["GTIN", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setProduto(this.dgvProdutos["PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setValorVenda(decimal.Parse(this.dgvProdutos["VALOR_VENDA", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setValorAtacado(decimal.Parse(this.dgvProdutos["VALOR_ATACADO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));

        }

        private void inserirNaLista()
        {

            if (click)
            {
                clsProduto.setQuantidade(int.Parse(nUpQtd.Value.ToString()));
                if (int.Parse(nUpQtd.Value.ToString()) > 1)
                {

                    for (int i = 0; i < int.Parse(nUpQtd.Value.ToString()); i++)
                    {
                        dtPrint.Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado());
                        dtsEtiquetas.Tables[0].Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado());
                    }
                    dtPrintView.Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.getQuantidade());
                }
                else
                {
                    dtPrint.Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado());
                    dtsEtiquetas.Tables[0].Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado());
                    dtPrintView.Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.getQuantidade());
                }
                LoaddgvProdutosPrint();
            }
            else
            {
                clsUtil.MsgBox("Por favor selecione na lista um produto!", MessageBoxIcon.Information);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            inserirNaLista();
            dgvProdutos.Focus();

        }

        private void gdvCarregaModel() {
            
            click = true;
            clsProduto.setIdProduto(int.Parse(this.dgvProdutos["ID_PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setGtin(this.dgvProdutos["GTIN", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setProduto(this.dgvProdutos["PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setValorVenda(decimal.Parse(this.dgvProdutos["VALOR_VENDA", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setValorAtacado(decimal.Parse(this.dgvProdutos["VALOR_ATACADO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));

        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gdvCarregaModel();
        }

        private void btnPrint_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbSelectEtq.SelectedIndex == -1)
            {
                clsUtil.MsgBox("Selecione a Etiqueta a ser Impressa!", MessageBoxIcon.Information);
            }
            else 
            {
                
                frmPrintEtiquetas frmPrint = new frmPrintEtiquetas(dtsEtiquetas, cbSelectEtq.SelectedItem.ToString());
                frmPrint.Show();

            }
           
        }

        private void dgvProdutosPrint_MouseClick(object sender, MouseEventArgs e)
        {
            codBarra = (this.dgvProdutosPrint["GTIN", this.dgvProdutosPrint.CurrentRow.Index].Value.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataRow[] oDataRow = dtPrintView.Select();
            foreach (DataRow dr in oDataRow)
            {
                if (dr["GTIN"].ToString() == codBarra)
                {
                    dtPrintView.Rows.Remove(dr);
                }
            }

            DataRow[] oDataRow2 = dtsEtiquetas.Tables[0].Select();
            foreach (DataRow dr in oDataRow2)
            {
                if (dr["GTIN"].ToString() == codBarra)
                {
                    dtsEtiquetas.Tables[0].Rows.Remove(dr);
                }
            }
        }

        private void dgvProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Convert.ToString((Char)Keys.Enter))
            {
              

            }
        }

        private void nUpQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Convert.ToString((Char)Keys.Enter))
            {
                btnInsert.Focus();

            }

        }

        private void dgvProdutos_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Enter) 
            { 
                e.SuppressKeyPress = true;
                gdvCarregaModel();
                nUpQtd.Focus();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                dgvProdutos.Focus();                    
            }
        }

        private void frmEtiquetas_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}