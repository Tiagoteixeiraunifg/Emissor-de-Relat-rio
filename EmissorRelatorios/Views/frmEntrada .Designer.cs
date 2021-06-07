namespace EmissorRelatorios.Views
{
    partial class frmEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntrada));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNfe55 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.dataInicial = new System.Windows.Forms.DateTimePicker();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboNfeE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGerarRel = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdbCompras1 = new System.Windows.Forms.RadioButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNfe55);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rdbNfe55
            // 
            this.rdbNfe55.AutoSize = true;
            this.rdbNfe55.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbNfe55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNfe55.Location = new System.Drawing.Point(6, 23);
            this.rdbNfe55.Name = "rdbNfe55";
            this.rdbNfe55.Size = new System.Drawing.Size(86, 24);
            this.rdbNfe55.TabIndex = 4;
            this.rdbNfe55.TabStop = true;
            this.rdbNfe55.Text = "NFe-55";
            this.rdbNfe55.UseVisualStyleBackColor = true;
            this.rdbNfe55.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbNfe55_MouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboCliente);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(11, 266);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fornecedor";
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
            this.cboCliente.Validated += new System.EventHandler(this.cboCliente_Validated);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboNfeE);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(603, 266);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(286, 64);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nº Nota Fiscal";
            // 
            // cboNfeE
            // 
            this.cboNfeE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboNfeE.FormattingEnabled = true;
            this.cboNfeE.Location = new System.Drawing.Point(6, 25);
            this.cboNfeE.Name = "cboNfeE";
            this.cboNfeE.Size = new System.Drawing.Size(269, 28);
            this.cboNfeE.TabIndex = 10;
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
            this.btnGerarRel.Location = new System.Drawing.Point(311, 405);
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
            this.flowLayoutPanel1.Controls.Add(this.rdbCompras1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 149);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // rdbCompras1
            // 
            this.rdbCompras1.AutoSize = true;
            this.rdbCompras1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbCompras1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCompras1.Location = new System.Drawing.Point(3, 3);
            this.rdbCompras1.Name = "rdbCompras1";
            this.rdbCompras1.Size = new System.Drawing.Size(385, 24);
            this.rdbCompras1.TabIndex = 0;
            this.rdbCompras1.TabStop = true;
            this.rdbCompras1.Text = "Compras - Espelho NFe - Grade de Produtos";
            this.ToolTip.SetToolTip(this.rdbCompras1, "Relatório de Espelho de Nota com produtos de grade!");
            this.rdbCompras1.UseVisualStyleBackColor = true;
            this.rdbCompras1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbCompras1_MouseClick);
            // 
            // frmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 490);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnGerarRel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dataFinal);
            this.Controls.Add(this.dataInicial);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(917, 529);
            this.MinimumSize = new System.Drawing.Size(917, 529);
            this.Name = "frmEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios Entrada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.DateTimePicker dataInicial;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGerarRel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rdbCompras1;
        private System.Windows.Forms.RadioButton rdbNfe55;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cboNfeE;
    }
}