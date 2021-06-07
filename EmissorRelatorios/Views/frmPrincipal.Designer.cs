namespace EmissorRelatorios.Views
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEtiquetas = new System.Windows.Forms.Button();
            this.btnDecisao = new System.Windows.Forms.Button();
            this.btnEntradaCompra = new System.Windows.Forms.Button();
            this.btnSaidaVenda = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDecisao);
            this.groupBox1.Controls.Add(this.btnEntradaCompra);
            this.groupBox1.Controls.Add(this.btnSaidaVenda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 371);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relatórios Gerenciais";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEtiquetas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(333, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 371);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ferramentas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Developer Tiago Teixeira";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "WhatsApp (77) 3451 - 9456";
            // 
            // btnEtiquetas
            // 
            this.btnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEtiquetas.FlatAppearance.BorderSize = 0;
            this.btnEtiquetas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnEtiquetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEtiquetas.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtiquetas.Image = ((System.Drawing.Image)(resources.GetObject("btnEtiquetas.Image")));
            this.btnEtiquetas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEtiquetas.Location = new System.Drawing.Point(6, 21);
            this.btnEtiquetas.Name = "btnEtiquetas";
            this.btnEtiquetas.Size = new System.Drawing.Size(301, 82);
            this.btnEtiquetas.TabIndex = 6;
            this.btnEtiquetas.Text = "Impressão de Etiquetas";
            this.btnEtiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEtiquetas.UseVisualStyleBackColor = true;
            this.btnEtiquetas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEtiquetas_MouseClick);
            // 
            // btnDecisao
            // 
            this.btnDecisao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecisao.FlatAppearance.BorderSize = 0;
            this.btnDecisao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDecisao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnDecisao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecisao.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecisao.Image = ((System.Drawing.Image)(resources.GetObject("btnDecisao.Image")));
            this.btnDecisao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDecisao.Location = new System.Drawing.Point(5, 253);
            this.btnDecisao.Name = "btnDecisao";
            this.btnDecisao.Size = new System.Drawing.Size(232, 92);
            this.btnDecisao.TabIndex = 7;
            this.btnDecisao.Text = "Gestão Estoque";
            this.btnDecisao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDecisao.UseVisualStyleBackColor = true;
            // 
            // btnEntradaCompra
            // 
            this.btnEntradaCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntradaCompra.FlatAppearance.BorderSize = 0;
            this.btnEntradaCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnEntradaCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnEntradaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradaCompra.Image = ((System.Drawing.Image)(resources.GetObject("btnEntradaCompra.Image")));
            this.btnEntradaCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaCompra.Location = new System.Drawing.Point(5, 135);
            this.btnEntradaCompra.Name = "btnEntradaCompra";
            this.btnEntradaCompra.Size = new System.Drawing.Size(232, 92);
            this.btnEntradaCompra.TabIndex = 6;
            this.btnEntradaCompra.Text = "Entradas Compras";
            this.btnEntradaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntradaCompra.UseVisualStyleBackColor = true;
            this.btnEntradaCompra.Click += new System.EventHandler(this.btnEntradaCompra_Click);
            // 
            // btnSaidaVenda
            // 
            this.btnSaidaVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaidaVenda.FlatAppearance.BorderSize = 0;
            this.btnSaidaVenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnSaidaVenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnSaidaVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaidaVenda.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaidaVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnSaidaVenda.Image")));
            this.btnSaidaVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaidaVenda.Location = new System.Drawing.Point(6, 21);
            this.btnSaidaVenda.Name = "btnSaidaVenda";
            this.btnSaidaVenda.Size = new System.Drawing.Size(231, 92);
            this.btnSaidaVenda.TabIndex = 5;
            this.btnSaidaVenda.Text = "Saídas Vendas";
            this.btnSaidaVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaidaVenda.UseVisualStyleBackColor = true;
            this.btnSaidaVenda.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSaidaVenda_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 420);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 59);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(684, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 530);
            this.MinimumSize = new System.Drawing.Size(700, 530);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecisao;
        private System.Windows.Forms.Button btnEntradaCompra;
        private System.Windows.Forms.Button btnSaidaVenda;
        private System.Windows.Forms.Button btnEtiquetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

