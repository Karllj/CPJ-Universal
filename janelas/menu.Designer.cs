namespace CPJ_Universal.janelas
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnLeviatan = new System.Windows.Forms.Button();
            this.btnInstalacao = new System.Windows.Forms.Button();
            this.btnDesinstalacao = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(12, 27);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(250, 40);
            this.btnLocal.TabIndex = 0;
            this.btnLocal.Text = "Inicialização Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnLeviatan
            // 
            this.btnLeviatan.Location = new System.Drawing.Point(12, 77);
            this.btnLeviatan.Name = "btnLeviatan";
            this.btnLeviatan.Size = new System.Drawing.Size(250, 40);
            this.btnLeviatan.TabIndex = 1;
            this.btnLeviatan.Text = "Inicialização Leviatan";
            this.btnLeviatan.UseVisualStyleBackColor = true;
            this.btnLeviatan.Click += new System.EventHandler(this.btnLeviatan_Click);
            // 
            // btnInstalacao
            // 
            this.btnInstalacao.Location = new System.Drawing.Point(12, 127);
            this.btnInstalacao.Name = "btnInstalacao";
            this.btnInstalacao.Size = new System.Drawing.Size(250, 40);
            this.btnInstalacao.TabIndex = 2;
            this.btnInstalacao.Text = "Instalação Local";
            this.btnInstalacao.UseVisualStyleBackColor = true;
            this.btnInstalacao.Click += new System.EventHandler(this.btnInstalacao_Click);
            // 
            // btnDesinstalacao
            // 
            this.btnDesinstalacao.Location = new System.Drawing.Point(12, 177);
            this.btnDesinstalacao.Name = "btnDesinstalacao";
            this.btnDesinstalacao.Size = new System.Drawing.Size(250, 40);
            this.btnDesinstalacao.TabIndex = 3;
            this.btnDesinstalacao.Text = "Desinstalação Local";
            this.btnDesinstalacao.UseVisualStyleBackColor = true;
            this.btnDesinstalacao.Click += new System.EventHandler(this.btnDesinstalacao_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(274, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.patchToolStripMenuItem});
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.testeToolStripMenuItem.Text = "Opções";
            // 
            // atualizarToolStripMenuItem
            // 
            this.atualizarToolStripMenuItem.Name = "atualizarToolStripMenuItem";
            this.atualizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.atualizarToolStripMenuItem.Text = "Atualizar";
            this.atualizarToolStripMenuItem.Click += new System.EventHandler(this.atualizarToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // patchToolStripMenuItem
            // 
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patchToolStripMenuItem.Text = "Patch";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 222);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.btnLeviatan);
            this.Controls.Add(this.btnInstalacao);
            this.Controls.Add(this.btnDesinstalacao);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.Text = "Menu Inicial";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnLeviatan;
        private System.Windows.Forms.Button btnInstalacao;
        private System.Windows.Forms.Button btnDesinstalacao;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchToolStripMenuItem;
    }
}
