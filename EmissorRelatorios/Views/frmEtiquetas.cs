using EmissorRelatorios.Controles;
using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmEtiquetas : Form
    {
        
        ClsPrincipal principal;
        private DataSet dtProdutos;
        private DataSetEtiquetas dtsEtiquetas;
        private ClsEtiquetasDAO clsEtiquetasDAO;
        private BindingSource bs;
        private ClsProduto clsProduto;
        private DataTable dtPrintView;
        private static Boolean click;
        private static ClsUtil clsUtil;
        private static string codBarra;
        private static bool importando;
        private EtiquetaController controller = new EtiquetaController();

        public frmEtiquetas()
        {
            InitializeComponent();
            principal = new ClsPrincipal(this);
            principal.inicializar();
            clsProduto = new ClsProduto();
            bs = new BindingSource();
            dtProdutos = null;
            dtPrintView = new DataTable();
            dtsEtiquetas = new DataSetEtiquetas();
            ajusteDataTableView();
            clsEtiquetasDAO = new ClsEtiquetasDAO();
            clsUtil = new ClsUtil();
            dtProdutos = clsEtiquetasDAO.GetProdutos();
            LoaddgvProdutos();
            loadCboRelatorio();
            click = false;
            importando = false;
            controller.executa(this);
        }

        public TextBox getTextBox() { return txtFiltro; }


        public void getTextBox(TextBox txt) { txtFiltro = txt; }

        
        private void ajusteDataTableView()
        {
            DataColumn id = new DataColumn();
            id.ColumnName = "_id";
            id.DataType = System.Type.GetType("System.Int32");
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Unique = true;

            dtPrintView.Columns.Add(id);
            dtPrintView.Columns.Add("ID_PRODUTO", typeof(int));
            dtPrintView.Columns.Add("GTIN", typeof(string));
            dtPrintView.Columns.Add("REFERENCIA", typeof(string));
            dtPrintView.Columns.Add("PRODUTO", typeof(string));
            dtPrintView.Columns.Add("VALOR_VENDA", typeof(decimal));
            dtPrintView.Columns.Add("VALOR_ATACADO", typeof(decimal));
            dtPrintView.Columns.Add("QTD", typeof(int));
            dtPrintView.Columns.Add("UNIDADE_COMECIAL", typeof(string));
        }
        private void LoaddgvProdutos()
        {
            bs.DataSource = dtProdutos;
            bs.DataMember = dtProdutos.Tables[0].TableName;
            dgvProdutos.DataSource = bs;
            //dgvProdutos.AutoResizeColumns();
            //dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutos.Columns["ID_PRODUTO"].HeaderText = "COD.";
            dgvProdutos.Columns["ID_PRODUTO"].Width = 45;
            dgvProdutos.Columns["GTIN"].HeaderText = "BARRAS";
            dgvProdutos.Columns["GTIN"].Width = 90;
            dgvProdutos.Columns["REFERENCIA"].HeaderText = "REFERÊNCIA";
            dgvProdutos.Columns["REFERENCIA"].Width = 90;
            dgvProdutos.Columns["PRODUTO"].HeaderText = "DESCRIÇÃO";
            dgvProdutos.Columns["PRODUTO"].Width = 400;
            dgvProdutos.Columns["UNIDADE_COMECIAL"].HeaderText = "UN";
            dgvProdutos.Columns["UNIDADE_COMECIAL"].Width = 25;
            dgvProdutos.Columns["ESTOQUE"].HeaderText = "QTD ESTOQUE";
            dgvProdutos.Columns["ESTOQUE"].Width = 65;
            dgvProdutos.Columns["VALOR_VENDA"].HeaderText = "PREÇO VENDA";
            dgvProdutos.Columns["VALOR_VENDA"].Width = 75;
            dgvProdutos.Columns["VALOR_VENDA"].DefaultCellStyle.Format = "C2";
            dgvProdutos.Columns["VALOR_VENDA"].DefaultCellStyle.BackColor = Color.FromArgb(200,240,240); 
            dgvProdutos.Columns["VALOR_ATACADO"].HeaderText = "PREÇO ATACADO";
            dgvProdutos.Columns["VALOR_ATACADO"].Width = 75;
            dgvProdutos.Columns["VALOR_ATACADO"].DefaultCellStyle.Format = "C2";
            dgvProdutos.Columns["VALOR_ATACADO"].DefaultCellStyle.BackColor = Color.FromArgb(100, 255, 255);

        }
        private void LoaddgvProdutosPrint()
        {
            //DataTable dt = new DataTable();
            //DataRow[] oDataRow = dtPrintView.Select("_id > 0", "_id ASC");
            //foreach (DataRow dr in oDataRow)
            //{
            //    dt.Rows.Add(dr);
            //}

            BindingSource bnds = new BindingSource();
            bnds.DataSource = dtPrintView;
            bnds.Sort = "_id DESC";
            dgvProdutosPrint.DataSource = bnds;
            
            dgvProdutosPrint.AutoResizeColumns();

            //dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutosPrint.Columns["_ID"].HeaderText = "Item";
            dgvProdutosPrint.Columns["_ID"].Width = 25;
            dgvProdutosPrint.Columns["ID_PRODUTO"].HeaderText = "CODIGO";
            dgvProdutosPrint.Columns["ID_PRODUTO"].Width = 45;
            dgvProdutosPrint.Columns["GTIN"].HeaderText = "CODIGO BARRAS";
            dgvProdutosPrint.Columns["GTIN"].Width = 90;
            dgvProdutosPrint.Columns["REFERENCIA"].HeaderText = "REFERÊNCIA";
            dgvProdutosPrint.Columns["REFERENCIA"].Width = 90;
            dgvProdutosPrint.Columns["PRODUTO"].HeaderText = "DESCRIÇÃO";
            dgvProdutosPrint.Columns["PRODUTO"].Width = 350;
            dgvProdutosPrint.Columns["UNIDADE_COMECIAL"].HeaderText = "UN";
            dgvProdutosPrint.Columns["UNIDADE_COMECIAL"].Width = 25;
            dgvProdutosPrint.Columns["VALOR_VENDA"].HeaderText = "PREÇO VENDA";
            dgvProdutosPrint.Columns["VALOR_VENDA"].Width = 70;
            dgvProdutosPrint.Columns["VALOR_VENDA"].DefaultCellStyle.Format = "C2";
            dgvProdutosPrint.Columns["VALOR_ATACADO"].HeaderText = "PREÇO ATACADO";
            dgvProdutosPrint.Columns["VALOR_ATACADO"].Width = 70;
            dgvProdutosPrint.Columns["VALOR_ATACADO"].DefaultCellStyle.Format = "C2";
            dgvProdutosPrint.Columns["QTD"].HeaderText = "QUANTIDADE";
            dgvProdutosPrint.Columns["QTD"].Width = 100;

        }

        private void loadCboRelatorio() 
        {
            cbSelectEtq.AutoCompleteMode = AutoCompleteMode.None;
            DirectoryInfo di = new DirectoryInfo(frmPrincipal.path + "relatorios\\etiquetas\\");
            Console.WriteLine("No search pattern returns:");
            foreach (var fi in di.GetFiles())
            {
                if (fi.Extension == ".rpt") {
                    cbSelectEtq.Items.Add(fi.Name.Replace(".rpt",""));
                }   
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
            clsProduto.referencia = this.dgvProdutos["REFERENCIA", this.dgvProdutos.CurrentRow.Index].Value.ToString();
            clsProduto.setProduto(this.dgvProdutos["PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setValorVenda(decimal.Parse(this.dgvProdutos["VALOR_VENDA", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setValorAtacado(decimal.Parse(this.dgvProdutos["VALOR_ATACADO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.unidade_comercial = this.dgvProdutos["UNIDADE_COMECIAL", this.dgvProdutos.CurrentRow.Index].Value.ToString();
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
                        dtsEtiquetas.Tables[0].Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.referencia, clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.unidade_comercial);
                    }
                    dtPrintView.Rows.Add(null,clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.referencia, clsProduto.getProduto(),  clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.getQuantidade(), clsProduto.unidade_comercial);
                }
                else
                {
                    dtsEtiquetas.Tables[0].Rows.Add(clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.referencia, clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.unidade_comercial);
                    dtPrintView.Rows.Add(null, clsProduto.GetIdProduto(), clsProduto.getGtin(), clsProduto.referencia, clsProduto.getProduto(), clsProduto.getValorVenda(), clsProduto.getValorAtacado(), clsProduto.getQuantidade(), clsProduto.unidade_comercial);                  
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
            clsProduto.referencia = this.dgvProdutos["REFERENCIA", this.dgvProdutos.CurrentRow.Index].Value.ToString();
            clsProduto.setProduto(this.dgvProdutos["PRODUTO", this.dgvProdutos.CurrentRow.Index].Value.ToString());
            clsProduto.setValorVenda(decimal.Parse(this.dgvProdutos["VALOR_VENDA", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.setValorAtacado(decimal.Parse(this.dgvProdutos["VALOR_ATACADO", this.dgvProdutos.CurrentRow.Index].Value.ToString()));
            clsProduto.unidade_comercial = this.dgvProdutos["UNIDADE_COMECIAL", this.dgvProdutos.CurrentRow.Index].Value.ToString();
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
            else if (dtsEtiquetas.Tables[0].Rows.Count > 0)
            {

                frmPrintEtiquetas frmPrint = new frmPrintEtiquetas(dtsEtiquetas, cbSelectEtq.SelectedItem.ToString());
                frmPrint.ShowDialog();

            }
            else 
            {
                clsUtil.MsgBox("Nenhuma etiqueta adicionada na lista!", MessageBoxIcon.Information);
            }
           
        }

        private void dgvProdutosPrint_MouseClick(object sender, MouseEventArgs e)
        {
            codBarra = (this.dgvProdutosPrint["GTIN", this.dgvProdutosPrint.CurrentRow.Index].Value.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (importando) {
                dtsEtiquetas.Clear();
                dtPrintView.Clear();
                importando = false;
                LoaddgvProdutosPrint();
            }
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
                controller.teste();
                dgvProdutos.Focus();                    
            }
            if (e.KeyCode == Keys.Back && txtFiltro.Text.Equals("")) 
            {
                bs.RemoveFilter();
                dtProdutos.Clear();
                dtProdutos = clsEtiquetasDAO.GetProdutos();
                LoaddgvProdutos();
            }
        }

        private void frmEtiquetas_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportNota_Click(object sender, EventArgs e)
        {
            bool ckb = ckbQtdMuti.Checked;
            if (txtFiltro.Text.Length > 1 && txtFiltro.Text.Length < 10)
            {
                importando = true;
                dtsEtiquetas.Clear();
                dtPrintView.Clear();
                dtsEtiquetas = clsEtiquetasDAO.getProdutosNotaCompra(txtFiltro.Text, ckb);
                if (!clsEtiquetasDAO.sucesso)
                {
                    clsUtil.MsgBox("Não foi possível encontar a  " + clsEtiquetasDAO.retorno, MessageBoxIcon.Information);
                }
                else
                {
                    dtPrintView = clsEtiquetasDAO.dsViewFull();
                    LoaddgvProdutosPrint();
                    clsUtil.MsgBox("Nota encontrada!", MessageBoxIcon.Information);
                    cbSelectEtq.Focus();
                }

            }
            else 
            {
                clsUtil.MsgBox("Digite o número da nota no campo de Busca Produto para pesquisar", MessageBoxIcon.Information);
            }
        }

        private void ckbQtdMuti_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
