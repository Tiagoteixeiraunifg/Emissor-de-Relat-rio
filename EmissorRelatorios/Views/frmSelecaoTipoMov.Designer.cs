namespace EmissorRelatorios.Views
{
    partial class frmSelecaoTipoMov
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecaoTipoMov));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCupom = new System.Windows.Forms.Button();
            this.btnFolhaA4 = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCupom);
            this.groupBox1.Controls.Add(this.btnFolhaA4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo da Saída";
            // 
            // btnCupom
            // 
            this.btnCupom.Image = global::EmissorRelatorios.Properties.Resources.kisspng_paper_printer_thermal_printing_computer_icons_clip_printer_5abe6369e8cd67_3081346315224267299536__1_;
            this.btnCupom.Location = new System.Drawing.Point(22, 19);
            this.btnCupom.Name = "btnCupom";
            this.btnCupom.Size = new System.Drawing.Size(121, 111);
            this.btnCupom.TabIndex = 0;
            this.btnCupom.UseVisualStyleBackColor = true;
            this.btnCupom.Click += new System.EventHandler(this.btnCupom_Click);
            // 
            // btnFolhaA4
            // 
            this.btnFolhaA4.Image = global::EmissorRelatorios.Properties.Resources.kisspng_printer_computer_icons_printing_printer_5abe6373d94889_80584876152242673989__1_;
            this.btnFolhaA4.Location = new System.Drawing.Point(162, 19);
            this.btnFolhaA4.Name = "btnFolhaA4";
            this.btnFolhaA4.Size = new System.Drawing.Size(121, 111);
            this.btnFolhaA4.TabIndex = 1;
            this.btnFolhaA4.UseVisualStyleBackColor = true;
            this.btnFolhaA4.Click += new System.EventHandler(this.btnFolhaA4_Click);
            // 
            // btnSair
            // 
            this.btnSair.Image = global::EmissorRelatorios.Properties.Resources.sair__1_;
            this.btnSair.Location = new System.Drawing.Point(450, 83);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(83, 83);
            this.btnSair.TabIndex = 3;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmSelecaoTipoMov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 177);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelecaoTipoMov";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmação";
            this.Load += new System.EventHandler(this.frmSelecaoTipoMov_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCupom;
        private System.Windows.Forms.Button btnFolhaA4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSair;
    }
}