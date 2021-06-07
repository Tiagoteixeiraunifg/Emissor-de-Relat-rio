namespace EmissorRelatorios.Views
{
    partial class frmSaida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaida));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbNfe = new System.Windows.Forms.RadioButton();
            this.rdbNfce = new System.Windows.Forms.RadioButton();
            this.rdbDav = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.dataInicial = new System.Windows.Forms.DateTimePicker();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGerarRel = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdbProdVendItem = new System.Windows.Forms.RadioButton();
            this.rdbProdVend = new System.Windows.Forms.RadioButton();
            this.rdbProdVendResItem = new System.Windows.Forms.RadioButton();
            this.rdbProdVendRes = new System.Windows.Forms.RadioButton();
            this.rdbProdVendResTodos = new System.Windows.Forms.RadioButton();
            this.rdbProdVendDetTodosCliente = new System.Windows.Forms.RadioButton();
            this.rdbProdVendResTodosItem = new System.Windows.Forms.RadioButton();
            this.rdbProdVendResTodosCliente = new System.Windows.Forms.RadioButton();
            this.rdbProdVendDetTodosItem = new System.Windows.Forms.RadioButton();
            this.rdbProdVendDetGrupo = new System.Windows.Forms.RadioButton();
            this.rbdFechamentoCxDia = new System.Windows.Forms.RadioButton();
            this.rbdFechamentoCx = new System.Windows.Forms.RadioButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.rdbNfe);
            this.groupBox1.Controls.Add(this.rdbNfce);
            this.groupBox1.Controls.Add(this.rdbDav);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTodos.Location = new System.Drawing.Point(6, 23);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(76, 24);
            this.rdbTodos.TabIndex = 4;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbTodos_MouseClick);
            // 
            // rdbNfe
            // 
            this.rdbNfe.AutoSize = true;
            this.rdbNfe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbNfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNfe.Location = new System.Drawing.Point(6, 113);
            this.rdbNfe.Name = "rdbNfe";
            this.rdbNfe.Size = new System.Drawing.Size(68, 24);
            this.rdbNfe.TabIndex = 3;
            this.rdbNfe.TabStop = true;
            this.rdbNfe.Text = "NF-E";
            this.rdbNfe.UseVisualStyleBackColor = true;
            this.rdbNfe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbNfe_MouseClick);
            // 
            // rdbNfce
            // 
            this.rdbNfce.AutoSize = true;
            this.rdbNfce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbNfce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNfce.Location = new System.Drawing.Point(6, 83);
            this.rdbNfce.Name = "rdbNfce";
            this.rdbNfce.Size = new System.Drawing.Size(80, 24);
            this.rdbNfce.TabIndex = 2;
            this.rdbNfce.TabStop = true;
            this.rdbNfce.Text = "NFC-E";
            this.rdbNfce.UseVisualStyleBackColor = true;
            this.rdbNfce.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbNfce_MouseClick);
            // 
            // rdbDav
            // 
            this.rdbDav.AutoSize = true;
            this.rdbDav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbDav.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDav.Location = new System.Drawing.Point(6, 53);
            this.rdbDav.Name = "rdbDav";
            this.rdbDav.Size = new System.Drawing.Size(64, 24);
            this.rdbDav.TabIndex = 1;
            this.rdbDav.TabStop = true;
            this.rdbDav.Text = "DAV";
            this.rdbDav.UseVisualStyleBackColor = true;
            this.rdbDav.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbDav_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboUsuario);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuário";
            // 
            // cboUsuario
            // 
            this.cboUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(6, 25);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(269, 28);
            this.cboUsuario.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboGrupo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(603, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 64);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grupo Produto";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(6, 25);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(269, 28);
            this.cboGrupo.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboCliente);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 338);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.IntegralHeight = false;
            this.cboCliente.Location = new System.Drawing.Point(6, 25);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(568, 28);
            this.cboCliente.TabIndex = 2;
            // 
            // dataInicial
            // 
            this.dataInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicial.Location = new System.Drawing.Point(11, 34);
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.Size = new System.Drawing.Size(117, 26);
            this.dataInicial.TabIndex = 4;
            // 
            // dataFinal
            // 
            this.dataFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFinal.Location = new System.Drawing.Point(142, 34);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(122, 26);
            this.dataFinal.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboVendedor);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(311, 266);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 64);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vendedor";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(6, 25);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(269, 28);
            this.cboVendedor.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtProduto);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(603, 266);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(286, 64);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Produto";
            // 
            // txtProduto
            // 
            this.txtProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(6, 25);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(269, 29);
            this.txtProduto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data Final";
            // 
            // btnGerarRel
            // 
            this.btnGerarRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRel.Location = new System.Drawing.Point(311, 427);
            this.btnGerarRel.Name = "btnGerarRel";
            this.btnGerarRel.Size = new System.Drawing.Size(262, 48);
            this.btnGerarRel.TabIndex = 8;
            this.btnGerarRel.Text = "Gerar Relatório";
            this.btnGerarRel.UseVisualStyleBackColor = true;
            this.btnGerarRel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGerarRel_MouseClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.flowLayoutPanel1);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(114, 75);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(775, 180);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipo Listagem";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendItem);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVend);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendResItem);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendRes);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendResTodos);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendDetTodosCliente);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendResTodosItem);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendResTodosCliente);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendDetTodosItem);
            this.flowLayoutPanel1.Controls.Add(this.rdbProdVendDetGrupo);
            this.flowLayoutPanel1.Controls.Add(this.rbdFechamentoCxDia);
            this.flowLayoutPanel1.Controls.Add(this.rbdFechamentoCx);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 149);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // rdbProdVendItem
            // 
            this.rdbProdVendItem.AutoSize = true;
            this.rdbProdVendItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendItem.Location = new System.Drawing.Point(3, 3);
            this.rdbProdVendItem.Name = "rdbProdVendItem";
            this.rdbProdVendItem.Size = new System.Drawing.Size(439, 24);
            this.rdbProdVendItem.TabIndex = 0;
            this.rdbProdVendItem.TabStop = true;
            this.rdbProdVendItem.Text = "Produtos Vendidos Por Vendedor  Detalhado - Item";
            this.ToolTip.SetToolTip(this.rdbProdVendItem, "Selecione também um vendedor e em seguida digite o codigo do item a ser buscado.");
            this.rdbProdVendItem.UseVisualStyleBackColor = true;
            this.rdbProdVendItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendItem_MouseClick);
            // 
            // rdbProdVend
            // 
            this.rdbProdVend.AutoSize = true;
            this.rdbProdVend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVend.Location = new System.Drawing.Point(3, 33);
            this.rdbProdVend.Name = "rdbProdVend";
            this.rdbProdVend.Size = new System.Drawing.Size(382, 24);
            this.rdbProdVend.TabIndex = 1;
            this.rdbProdVend.TabStop = true;
            this.rdbProdVend.Text = "Produtos Vendidos Por Vendedor Detalhado";
            this.ToolTip.SetToolTip(this.rdbProdVend, "Selecione também um vendedor!");
            this.rdbProdVend.UseVisualStyleBackColor = true;
            this.rdbProdVend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVend_MouseClick);
            // 
            // rdbProdVendResItem
            // 
            this.rdbProdVendResItem.AutoSize = true;
            this.rdbProdVendResItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendResItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendResItem.Location = new System.Drawing.Point(3, 63);
            this.rdbProdVendResItem.Name = "rdbProdVendResItem";
            this.rdbProdVendResItem.Size = new System.Drawing.Size(436, 24);
            this.rdbProdVendResItem.TabIndex = 2;
            this.rdbProdVendResItem.Text = "Produtos Vendidos Por Vendedor  Resumido - Item";
            this.ToolTip.SetToolTip(this.rdbProdVendResItem, "Selecione também um vendedor e em seguida digite o codigo do item a ser buscado.");
            this.rdbProdVendResItem.UseVisualStyleBackColor = true;
            this.rdbProdVendResItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendResItem_MouseClick);
            // 
            // rdbProdVendRes
            // 
            this.rdbProdVendRes.AutoSize = true;
            this.rdbProdVendRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendRes.Location = new System.Drawing.Point(3, 93);
            this.rdbProdVendRes.Name = "rdbProdVendRes";
            this.rdbProdVendRes.Size = new System.Drawing.Size(379, 24);
            this.rdbProdVendRes.TabIndex = 3;
            this.rdbProdVendRes.TabStop = true;
            this.rdbProdVendRes.Text = "Produtos Vendidos Por Vendedor Resumido";
            this.ToolTip.SetToolTip(this.rdbProdVendRes, "Selecione também um vendedor!");
            this.rdbProdVendRes.UseVisualStyleBackColor = true;
            this.rdbProdVendRes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendRes_MouseClick);
            // 
            // rdbProdVendResTodos
            // 
            this.rdbProdVendResTodos.AutoSize = true;
            this.rdbProdVendResTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendResTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendResTodos.Location = new System.Drawing.Point(3, 123);
            this.rdbProdVendResTodos.Name = "rdbProdVendResTodos";
            this.rdbProdVendResTodos.Size = new System.Drawing.Size(509, 24);
            this.rdbProdVendResTodos.TabIndex = 4;
            this.rdbProdVendResTodos.TabStop = true;
            this.rdbProdVendResTodos.Text = "Produtos Vendidos Por Todos Vendedores  Resumido - Item";
            this.ToolTip.SetToolTip(this.rdbProdVendResTodos, "Digite o codigo do item a ser buscado!");
            this.rdbProdVendResTodos.UseVisualStyleBackColor = true;
            this.rdbProdVendResTodos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendResTodos_MouseClick);
            // 
            // rdbProdVendDetTodosCliente
            // 
            this.rdbProdVendDetTodosCliente.AutoSize = true;
            this.rdbProdVendDetTodosCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendDetTodosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendDetTodosCliente.Location = new System.Drawing.Point(3, 153);
            this.rdbProdVendDetTodosCliente.Name = "rdbProdVendDetTodosCliente";
            this.rdbProdVendDetTodosCliente.Size = new System.Drawing.Size(635, 24);
            this.rdbProdVendDetTodosCliente.TabIndex = 7;
            this.rdbProdVendDetTodosCliente.TabStop = true;
            this.rdbProdVendDetTodosCliente.Text = "Produtos Vendidos Por Todos Vendedores  Detalhado Agrupado por Cliente";
            this.rdbProdVendDetTodosCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ToolTip.SetToolTip(this.rdbProdVendDetTodosCliente, "Escolha a data e gere o relatório!");
            this.rdbProdVendDetTodosCliente.UseVisualStyleBackColor = true;
            this.rdbProdVendDetTodosCliente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendDetTodosCliente_MouseClick);
            // 
            // rdbProdVendResTodosItem
            // 
            this.rdbProdVendResTodosItem.AutoSize = true;
            this.rdbProdVendResTodosItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendResTodosItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendResTodosItem.Location = new System.Drawing.Point(3, 183);
            this.rdbProdVendResTodosItem.Name = "rdbProdVendResTodosItem";
            this.rdbProdVendResTodosItem.Size = new System.Drawing.Size(570, 24);
            this.rdbProdVendResTodosItem.TabIndex = 5;
            this.rdbProdVendResTodosItem.TabStop = true;
            this.rdbProdVendResTodosItem.Text = "Produtos Vendidos Por Todos Vendedores  Resumido - Cliente/Item";
            this.ToolTip.SetToolTip(this.rdbProdVendResTodosItem, "Digite o codigo do item e cliente a ser buscado!");
            this.rdbProdVendResTodosItem.UseVisualStyleBackColor = true;
            this.rdbProdVendResTodosItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendResTodosItem_MouseClick);
            // 
            // rdbProdVendResTodosCliente
            // 
            this.rdbProdVendResTodosCliente.AutoSize = true;
            this.rdbProdVendResTodosCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendResTodosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendResTodosCliente.Location = new System.Drawing.Point(3, 213);
            this.rdbProdVendResTodosCliente.Name = "rdbProdVendResTodosCliente";
            this.rdbProdVendResTodosCliente.Size = new System.Drawing.Size(632, 24);
            this.rdbProdVendResTodosCliente.TabIndex = 6;
            this.rdbProdVendResTodosCliente.TabStop = true;
            this.rdbProdVendResTodosCliente.Text = "Produtos Vendidos Por Todos Vendedores  Resumido Agrupado por Cliente";
            this.rdbProdVendResTodosCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ToolTip.SetToolTip(this.rdbProdVendResTodosCliente, "Digite o codigo do item a ser buscado!");
            this.rdbProdVendResTodosCliente.UseVisualStyleBackColor = true;
            this.rdbProdVendResTodosCliente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendResTodosCliente_MouseClick);
            // 
            // rdbProdVendDetTodosItem
            // 
            this.rdbProdVendDetTodosItem.AutoSize = true;
            this.rdbProdVendDetTodosItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendDetTodosItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendDetTodosItem.Location = new System.Drawing.Point(3, 243);
            this.rdbProdVendDetTodosItem.Name = "rdbProdVendDetTodosItem";
            this.rdbProdVendDetTodosItem.Size = new System.Drawing.Size(573, 24);
            this.rdbProdVendDetTodosItem.TabIndex = 8;
            this.rdbProdVendDetTodosItem.TabStop = true;
            this.rdbProdVendDetTodosItem.Text = "Produtos Vendidos Por Todos Vendedores  Detalhado - Cliente/Item";
            this.ToolTip.SetToolTip(this.rdbProdVendDetTodosItem, "Digite o codigo do item e cliente a ser buscado!");
            this.rdbProdVendDetTodosItem.UseVisualStyleBackColor = true;
            this.rdbProdVendDetTodosItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendDetTodosItem_MouseClick);
            // 
            // rdbProdVendDetGrupo
            // 
            this.rdbProdVendDetGrupo.AutoSize = true;
            this.rdbProdVendDetGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbProdVendDetGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProdVendDetGrupo.Location = new System.Drawing.Point(3, 273);
            this.rdbProdVendDetGrupo.Name = "rdbProdVendDetGrupo";
            this.rdbProdVendDetGrupo.Size = new System.Drawing.Size(530, 24);
            this.rdbProdVendDetGrupo.TabIndex = 9;
            this.rdbProdVendDetGrupo.TabStop = true;
            this.rdbProdVendDetGrupo.Text = "Produtos Vendidos Por Vendedor  Detalhado - Grupo Produtos";
            this.ToolTip.SetToolTip(this.rdbProdVendDetGrupo, "Selecione a data e o grupo de produto para listar.");
            this.rdbProdVendDetGrupo.UseVisualStyleBackColor = true;
            this.rdbProdVendDetGrupo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbProdVendDetGrupo_MouseClick);
            // 
            // rbdFechamentoCxDia
            // 
            this.rbdFechamentoCxDia.AutoSize = true;
            this.rbdFechamentoCxDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbdFechamentoCxDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbdFechamentoCxDia.Location = new System.Drawing.Point(3, 303);
            this.rbdFechamentoCxDia.Name = "rbdFechamentoCxDia";
            this.rbdFechamentoCxDia.Size = new System.Drawing.Size(387, 24);
            this.rbdFechamentoCxDia.TabIndex = 10;
            this.rbdFechamentoCxDia.TabStop = true;
            this.rbdFechamentoCxDia.Text = "Movimento de Caixa Resumido Agrupado Dia";
            this.ToolTip.SetToolTip(this.rbdFechamentoCxDia, "Seleciono o periodo para saber os resultados");
            this.rbdFechamentoCxDia.UseVisualStyleBackColor = true;
            this.rbdFechamentoCxDia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbdFechamentoCxDia_MouseClick);
            // 
            // rbdFechamentoCx
            // 
            this.rbdFechamentoCx.AutoSize = true;
            this.rbdFechamentoCx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbdFechamentoCx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbdFechamentoCx.Location = new System.Drawing.Point(3, 333);
            this.rbdFechamentoCx.Name = "rbdFechamentoCx";
            this.rbdFechamentoCx.Size = new System.Drawing.Size(446, 24);
            this.rbdFechamentoCx.TabIndex = 11;
            this.rbdFechamentoCx.TabStop = true;
            this.rbdFechamentoCx.Text = "Movimento de Caixa Resumido Agrupado Movimento";
            this.ToolTip.SetToolTip(this.rbdFechamentoCx, "Seleciono o periodo para saber os resultados");
            this.rbdFechamentoCx.UseVisualStyleBackColor = true;
            this.rbdFechamentoCx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbdFechamentoCx_MouseClick);
            // 
            // frmSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 490);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnGerarRel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dataFinal);
            this.Controls.Add(this.dataInicial);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(917, 529);
            this.MinimumSize = new System.Drawing.Size(917, 529);
            this.Name = "frmSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios Saidas";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSaida_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNfe;
        private System.Windows.Forms.RadioButton rdbNfce;
        private System.Windows.Forms.RadioButton rdbDav;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.DateTimePicker dataInicial;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGerarRel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rdbProdVend;
        private System.Windows.Forms.RadioButton rdbProdVendItem;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbProdVendResItem;
        private System.Windows.Forms.RadioButton rdbProdVendRes;
        private System.Windows.Forms.RadioButton rdbProdVendResTodos;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rdbProdVendResTodosItem;
        private System.Windows.Forms.RadioButton rdbProdVendResTodosCliente;
        private System.Windows.Forms.RadioButton rdbProdVendDetTodosCliente;
        private System.Windows.Forms.RadioButton rdbProdVendDetTodosItem;
        private System.Windows.Forms.RadioButton rdbProdVendDetGrupo;
        private System.Windows.Forms.RadioButton rbdFechamentoCxDia;
        private System.Windows.Forms.RadioButton rbdFechamentoCx;
    }
}