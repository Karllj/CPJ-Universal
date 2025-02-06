namespace CPJ_Universal.janelas
{
    partial class novasenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(novasenha));
            this.btnSalvarNovaSenha = new System.Windows.Forms.Button();
            this.btnCancelarNovaSenha = new System.Windows.Forms.Button();
            this.txtNovasenha = new System.Windows.Forms.TextBox();
            this.txtConfirmeNovasenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSalvarNovaSenha
            // 
            this.btnSalvarNovaSenha.Location = new System.Drawing.Point(83, 71);
            this.btnSalvarNovaSenha.Name = "btnSalvarNovaSenha";
            this.btnSalvarNovaSenha.Size = new System.Drawing.Size(110, 23);
            this.btnSalvarNovaSenha.TabIndex = 0;
            this.btnSalvarNovaSenha.Text = "Salvar";
            this.btnSalvarNovaSenha.UseVisualStyleBackColor = true;
            this.btnSalvarNovaSenha.Click += new System.EventHandler(this.btnSalvarNovaSenha_Click);
            // 
            // btnCancelarNovaSenha
            // 
            this.btnCancelarNovaSenha.Location = new System.Drawing.Point(195, 71);
            this.btnCancelarNovaSenha.Name = "btnCancelarNovaSenha";
            this.btnCancelarNovaSenha.Size = new System.Drawing.Size(110, 23);
            this.btnCancelarNovaSenha.TabIndex = 1;
            this.btnCancelarNovaSenha.Text = "Cancelar";
            this.btnCancelarNovaSenha.UseVisualStyleBackColor = true;
            this.btnCancelarNovaSenha.Click += new System.EventHandler(this.btnCancelarNovaSenha_Click);
            // 
            // txtNovasenha
            // 
            this.txtNovasenha.Location = new System.Drawing.Point(83, 6);
            this.txtNovasenha.Name = "txtNovasenha";
            this.txtNovasenha.Size = new System.Drawing.Size(223, 20);
            this.txtNovasenha.TabIndex = 2;
            this.txtNovasenha.UseSystemPasswordChar = true;
            // 
            // txtConfirmeNovasenha
            // 
            this.txtConfirmeNovasenha.Location = new System.Drawing.Point(83, 45);
            this.txtConfirmeNovasenha.Name = "txtConfirmeNovasenha";
            this.txtConfirmeNovasenha.Size = new System.Drawing.Size(223, 20);
            this.txtConfirmeNovasenha.TabIndex = 3;
            this.txtConfirmeNovasenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nova senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirme";
            // 
            // novasenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmeNovasenha);
            this.Controls.Add(this.txtNovasenha);
            this.Controls.Add(this.btnCancelarNovaSenha);
            this.Controls.Add(this.btnSalvarNovaSenha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "novasenha";
            this.Text = "Atualizar senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvarNovaSenha;
        private System.Windows.Forms.Button btnCancelarNovaSenha;
        private System.Windows.Forms.TextBox txtNovasenha;
        private System.Windows.Forms.TextBox txtConfirmeNovasenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}