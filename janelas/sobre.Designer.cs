namespace CPJ_Universal.janelas
{
    partial class sobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sobre));
            this.lblInformacoes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInformacoes
            // 
            this.lblInformacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInformacoes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInformacoes.Location = new System.Drawing.Point(8, 8);
            this.lblInformacoes.Margin = new System.Windows.Forms.Padding(3);
            this.lblInformacoes.Name = "lblInformacoes";
            this.lblInformacoes.Size = new System.Drawing.Size(441, 341);
            this.lblInformacoes.TabIndex = 0;
            this.lblInformacoes.Text = resources.GetString("lblInformacoes.Text");
            this.lblInformacoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(457, 357);
            this.Controls.Add(this.lblInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sobre";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInformacoes;
    }
}