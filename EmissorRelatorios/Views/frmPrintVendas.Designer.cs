namespace EmissorRelatorios.Views
{
    partial class frmPrintVendas
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
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrint.Location = new System.Drawing.Point(0, 0);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.Size = new System.Drawing.Size(826, 482);
            this.crvPrint.TabIndex = 0;
            // 
            // frmPrintVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 482);
            this.Controls.Add(this.crvPrint);
            this.Name = "frmPrintVendas";
            this.Text = "Relatorio";
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
    }
}