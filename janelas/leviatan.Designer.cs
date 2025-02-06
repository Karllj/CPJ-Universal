namespace CPJ_Universal.janelas
{
    partial class leviatan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button acessarCpjb;
        private System.Windows.Forms.Button acessarConfigb;
        private System.Windows.Forms.Button acessarConnectb;
        private System.Windows.Forms.Button voltarb;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button atualizarb;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelDownloaded;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(leviatan));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.acessarCpjb = new System.Windows.Forms.Button();
            this.acessarConfigb = new System.Windows.Forms.Button();
            this.acessarConnectb = new System.Windows.Forms.Button();
            this.voltarb = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.atualizarb = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.StatusBancolb = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLogin = new System.Windows.Forms.Label();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PESQUISAR";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(15, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(820, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // acessarCpjb
            // 
            this.acessarCpjb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acessarCpjb.Location = new System.Drawing.Point(15, 218);
            this.acessarCpjb.Name = "acessarCpjb";
            this.acessarCpjb.Size = new System.Drawing.Size(100, 23);
            this.acessarCpjb.TabIndex = 3;
            this.acessarCpjb.Text = "Acessar CPJ";
            this.acessarCpjb.UseVisualStyleBackColor = true;
            this.acessarCpjb.Click += new System.EventHandler(this.acessarCpjb_Click);
            // 
            // acessarConfigb
            // 
            this.acessarConfigb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acessarConfigb.Location = new System.Drawing.Point(227, 218);
            this.acessarConfigb.Name = "acessarConfigb";
            this.acessarConfigb.Size = new System.Drawing.Size(100, 23);
            this.acessarConfigb.TabIndex = 4;
            this.acessarConfigb.Text = "Acessar Config";
            this.acessarConfigb.UseVisualStyleBackColor = true;
            this.acessarConfigb.Click += new System.EventHandler(this.acessarConfigb_Click);
            // 
            // acessarConnectb
            // 
            this.acessarConnectb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acessarConnectb.Location = new System.Drawing.Point(121, 218);
            this.acessarConnectb.Name = "acessarConnectb";
            this.acessarConnectb.Size = new System.Drawing.Size(100, 23);
            this.acessarConnectb.TabIndex = 5;
            this.acessarConnectb.Text = "Acessar Connect";
            this.acessarConnectb.UseVisualStyleBackColor = true;
            this.acessarConnectb.Click += new System.EventHandler(this.acessarConnectb_Click);
            // 
            // voltarb
            // 
            this.voltarb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.voltarb.Location = new System.Drawing.Point(414, 218);
            this.voltarb.Name = "voltarb";
            this.voltarb.Size = new System.Drawing.Size(75, 23);
            this.voltarb.TabIndex = 7;
            this.voltarb.Text = "Voltar";
            this.voltarb.UseVisualStyleBackColor = true;
            this.voltarb.Click += new System.EventHandler(this.voltar_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(90, 37);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(745, 20);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // atualizarb
            // 
            this.atualizarb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.atualizarb.Location = new System.Drawing.Point(333, 218);
            this.atualizarb.Name = "atualizarb";
            this.atualizarb.Size = new System.Drawing.Size(75, 23);
            this.atualizarb.TabIndex = 9;
            this.atualizarb.Text = "Atualizar";
            this.atualizarb.UseVisualStyleBackColor = true;
            this.atualizarb.Click += new System.EventHandler(this.atualizarb_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(800, 9);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(28, 13);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "v1.0";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(15, 247);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(820, 23);
            this.progressBar.TabIndex = 13;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(15, 273);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(57, 13);
            this.labelProgress.TabIndex = 14;
            this.labelProgress.Text = "Progresso:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(15, 286);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(63, 13);
            this.labelSpeed.TabIndex = 15;
            this.labelSpeed.Text = "Velocidade:";
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(15, 299);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(48, 13);
            this.labelDownloaded.TabIndex = 16;
            this.labelDownloaded.Text = "Baixado:";
            // 
            // StatusBancolb
            // 
            this.StatusBancolb.AutoSize = true;
            this.StatusBancolb.Location = new System.Drawing.Point(495, 222);
            this.StatusBancolb.Name = "StatusBancolb";
            this.StatusBancolb.Size = new System.Drawing.Size(71, 13);
            this.StatusBancolb.TabIndex = 18;
            this.StatusBancolb.Text = "Banco Offline";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(847, 24);
            this.menuStrip2.TabIndex = 19;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(641, 222);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(41, 13);
            this.lbLogin.TabIndex = 20;
            this.lbLogin.Text = "lbLogin";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // leviatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 320);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.StatusBancolb);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.atualizarb);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.voltarb);
            this.Controls.Add(this.acessarConnectb);
            this.Controls.Add(this.acessarConfigb);
            this.Controls.Add(this.acessarCpjb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "leviatan";
            this.Text = "Inicialização Leviatan";
            this.Load += new System.EventHandler(this.leviatan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label StatusBancolb;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}