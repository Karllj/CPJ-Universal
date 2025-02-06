namespace CPJ_Universal.janelas
{
    partial class desinstalacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(desinstalacao));
            this.labelCPJ3C = new System.Windows.Forms.Label();
            this.comboBoxCPJ3C = new System.Windows.Forms.ComboBox();
            this.labelVersaoCPJ3C = new System.Windows.Forms.Label();
            this.comboBoxVersaoCPJ3C = new System.Windows.Forms.ComboBox();
            this.labelARQ3C = new System.Windows.Forms.Label();
            this.comboBoxARQ3C = new System.Windows.Forms.ComboBox();
            this.btnDesinstalar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCPJ3C
            // 
            this.labelCPJ3C.AutoSize = true;
            this.labelCPJ3C.Location = new System.Drawing.Point(20, 30);
            this.labelCPJ3C.Name = "labelCPJ3C";
            this.labelCPJ3C.Size = new System.Drawing.Size(148, 13);
            this.labelCPJ3C.TabIndex = 0;
            this.labelCPJ3C.Text = "Selecione a versão do CPJ3C";
            // 
            // comboBoxCPJ3C
            // 
            this.comboBoxCPJ3C.FormattingEnabled = true;
            this.comboBoxCPJ3C.Location = new System.Drawing.Point(20, 50);
            this.comboBoxCPJ3C.Name = "comboBoxCPJ3C";
            this.comboBoxCPJ3C.Size = new System.Drawing.Size(280, 21);
            this.comboBoxCPJ3C.TabIndex = 1;
            // 
            // labelVersaoCPJ3C
            // 
            this.labelVersaoCPJ3C.AutoSize = true;
            this.labelVersaoCPJ3C.Location = new System.Drawing.Point(20, 90);
            this.labelVersaoCPJ3C.Name = "labelVersaoCPJ3C";
            this.labelVersaoCPJ3C.Size = new System.Drawing.Size(159, 13);
            this.labelVersaoCPJ3C.TabIndex = 2;
            this.labelVersaoCPJ3C.Text = "Selecione a snapshot do CPJ3C";
            // 
            // comboBoxVersaoCPJ3C
            // 
            this.comboBoxVersaoCPJ3C.FormattingEnabled = true;
            this.comboBoxVersaoCPJ3C.Location = new System.Drawing.Point(20, 110);
            this.comboBoxVersaoCPJ3C.Name = "comboBoxVersaoCPJ3C";
            this.comboBoxVersaoCPJ3C.Size = new System.Drawing.Size(280, 21);
            this.comboBoxVersaoCPJ3C.TabIndex = 3;
            // 
            // labelARQ3C
            // 
            this.labelARQ3C.AutoSize = true;
            this.labelARQ3C.Location = new System.Drawing.Point(20, 150);
            this.labelARQ3C.Name = "labelARQ3C";
            this.labelARQ3C.Size = new System.Drawing.Size(152, 13);
            this.labelARQ3C.TabIndex = 4;
            this.labelARQ3C.Text = "Selecione a versão do ARQ3C";
            // 
            // comboBoxARQ3C
            // 
            this.comboBoxARQ3C.FormattingEnabled = true;
            this.comboBoxARQ3C.Location = new System.Drawing.Point(20, 170);
            this.comboBoxARQ3C.Name = "comboBoxARQ3C";
            this.comboBoxARQ3C.Size = new System.Drawing.Size(280, 21);
            this.comboBoxARQ3C.TabIndex = 5;
            // 
            // btnDesinstalar
            // 
            this.btnDesinstalar.Location = new System.Drawing.Point(20, 210);
            this.btnDesinstalar.Name = "btnDesinstalar";
            this.btnDesinstalar.Size = new System.Drawing.Size(70, 20);
            this.btnDesinstalar.TabIndex = 6;
            this.btnDesinstalar.Text = "Deinstalar";
            this.btnDesinstalar.UseVisualStyleBackColor = true;
            this.btnDesinstalar.Click += new System.EventHandler(this.btnDesinstalar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(90, 210);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 20);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // desinstalacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 244);
            this.Controls.Add(this.labelCPJ3C);
            this.Controls.Add(this.comboBoxCPJ3C);
            this.Controls.Add(this.labelVersaoCPJ3C);
            this.Controls.Add(this.comboBoxVersaoCPJ3C);
            this.Controls.Add(this.labelARQ3C);
            this.Controls.Add(this.comboBoxARQ3C);
            this.Controls.Add(this.btnDesinstalar);
            this.Controls.Add(this.btnVoltar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "desinstalacao";
            this.Text = "Desinstalação Local";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCPJ3C;
        private System.Windows.Forms.ComboBox comboBoxCPJ3C;
        private System.Windows.Forms.Label labelVersaoCPJ3C;
        private System.Windows.Forms.ComboBox comboBoxVersaoCPJ3C;
        private System.Windows.Forms.Label labelARQ3C;
        private System.Windows.Forms.ComboBox comboBoxARQ3C;
        private System.Windows.Forms.Button btnDesinstalar;
        private System.Windows.Forms.Button btnVoltar;
    }
}