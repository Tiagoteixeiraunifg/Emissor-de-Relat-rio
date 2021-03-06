namespace EmissorRelatorios.Views
{
    partial class frmEtiquetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEtiquetas));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.nUpQtd = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvProdutosPrint = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelectEtq = new System.Windows.Forms.ComboBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbQtdMuti = new System.Windows.Forms.CheckBox();
            this.btnImportNota = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpQtd)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosPrint)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFiltro);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 71);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busca Produto";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(6, 23);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(753, 34);
            this.txtFiltro.TabIndex = 0;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // nUpQtd
            // 
            this.nUpQtd.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpQtd.Location = new System.Drawing.Point(20, 24);
            this.nUpQtd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUpQtd.Name = "nUpQtd";
            this.nUpQtd.Size = new System.Drawing.Size(112, 34);
            this.nUpQtd.TabIndex = 4;
            this.nUpQtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nUpQtd_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInsert);
            this.groupBox3.Controls.Add(this.nUpQtd);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(783, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 71);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inclusão/Quantidade";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProdutos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProdutos.GridColor = System.Drawing.SystemColors.Desktop;
            this.dgvProdutos.Location = new System.Drawing.Point(6, 19);
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.ShowEditingIcon = false;
            this.dgvProdutos.Size = new System.Drawing.Size(985, 226);
            this.dgvProdutos.TabIndex = 6;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellClick);
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            this.dgvProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProdutos_KeyDown);
            this.dgvProdutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvProdutos_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProdutos);
            this.groupBox4.Location = new System.Drawing.Point(12, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1007, 251);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resultado da Busca";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvProdutosPrint);
            this.groupBox5.Location = new System.Drawing.Point(12, 388);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(914, 210);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lista de Produtos a Serem Impressos";
            // 
            // dgvProdutosPrint
            // 
            this.dgvProdutosPrint.AllowUserToAddRows = false;
            this.dgvProdutosPrint.AllowUserToDeleteRows = false;
            this.dgvProdutosPrint.AllowUserToOrderColumns = true;
            this.dgvProdutosPrint.AllowUserToResizeColumns = false;
            this.dgvProdutosPrint.AllowUserToResizeRows = false;
            this.dgvProdutosPrint.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProdutosPrint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutosPrint.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProdutosPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosPrint.GridColor = System.Drawing.SystemColors.Desktop;
            this.dgvProdutosPrint.Location = new System.Drawing.Point(6, 19);
            this.dgvProdutosPrint.Name = "dgvProdutosPrint";
            this.dgvProdutosPrint.ReadOnly = true;
            this.dgvProdutosPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutosPrint.Size = new System.Drawing.Size(897, 173);
            this.dgvProdutosPrint.TabIndex = 6;
            this.dgvProdutosPrint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvProdutosPrint_MouseClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnPrint);
            this.groupBox6.Controls.Add(this.cbSelectEtq);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(12, 604);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1007, 119);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Seleção de Etiqueta / Impressão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecione o modelo da etiqueta para a impressão.";
            // 
            // cbSelectEtq
            // 
            this.cbSelectEtq.FormattingEnabled = true;
            this.cbSelectEtq.Location = new System.Drawing.Point(6, 27);
            this.cbSelectEtq.Name = "cbSelectEtq";
            this.cbSelectEtq.Size = new System.Drawing.Size(396, 27);
            this.cbSelectEtq.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(989, -1);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(58, 54);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(740, 28);
            this.label2.TabIndex = 51;
            this.label2.Text = "IMPRESSOR DE ETIQUETAS BAHIA - TECH AUTOMAÇÃO COMERCIAL";
            // 
            // ckbQtdMuti
            // 
            this.ckbQtdMuti.AutoSize = true;
            this.ckbQtdMuti.Location = new System.Drawing.Point(932, 559);
            this.ckbQtdMuti.Name = "ckbQtdMuti";
            this.ckbQtdMuti.Size = new System.Drawing.Size(106, 17);
            this.ckbQtdMuti.TabIndex = 52;
            this.ckbQtdMuti.Text = "Qtd Mutiplicada?";
            this.ckbQtdMuti.UseVisualStyleBackColor = true;
            this.ckbQtdMuti.CheckedChanged += new System.EventHandler(this.ckbQtdMuti_CheckedChanged);
            // 
            // btnImportNota
            // 
            this.btnImportNota.BackgroundImage = global::EmissorRelatorios.Properties.Resources.Nfe_entrada;
            this.btnImportNota.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportNota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportNota.Location = new System.Drawing.Point(944, 478);
            this.btnImportNota.Name = "btnImportNota";
            this.btnImportNota.Size = new System.Drawing.Size(75, 75);
            this.btnImportNota.TabIndex = 50;
            this.btnImportNota.UseVisualStyleBackColor = true;
            this.btnImportNota.Click += new System.EventHandler(this.btnImportNota_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::EmissorRelatorios.Properties.Resources.iconExcluir;
            this.btnExcluir.Location = new System.Drawing.Point(944, 393);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 75);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(892, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(99, 94);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseClick);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Image = global::EmissorRelatorios.Properties.Resources.shopping_cart_add256_24821;
            this.btnInsert.Location = new System.Drawing.Point(152, 14);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(68, 51);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // frmEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1042, 732);
            this.ControlBox = false;
            this.Controls.Add(this.ckbQtdMuti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportNota);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEtiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEtiquetas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpQtd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosPrint)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.NumericUpDown nUpQtd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvProdutosPrint;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbSelectEtq;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbQtdMuti;
    }
}