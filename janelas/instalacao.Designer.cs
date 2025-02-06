using System;
using System.Windows.Forms;

namespace CPJ_Universal
{
    public partial class instalacao : Form
    {
        private ComboBox selectBoxBanco;
        private ComboBox selectBoxCPJ3C;
        private ComboBox selectBoxARQ3C;
        private ComboBox selectBoxVersaoCPJ3C;
        private Label labelBanco;
        private Label labelCPJ3C;
        private Label labelARQ3C;
        private Label labelVersaoCPJ3C;
        private Button buttonIniciar;
        private Button buttonCancelar;
        private GroupBox groupInstalacao;
        private GroupBox groupAdmin;
        private GroupBox groupCPJ;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(instalacao));
            this.groupInstalacao = new System.Windows.Forms.GroupBox();
            this.labelBanco = new System.Windows.Forms.Label();
            this.selectBoxBanco = new System.Windows.Forms.ComboBox();
            this.labelCPJ3C = new System.Windows.Forms.Label();
            this.selectBoxCPJ3C = new System.Windows.Forms.ComboBox();
            this.labelVersaoCPJ3C = new System.Windows.Forms.Label();
            this.selectBoxVersaoCPJ3C = new System.Windows.Forms.ComboBox();
            this.labelARQ3C = new System.Windows.Forms.Label();
            this.selectBoxARQ3C = new System.Windows.Forms.ComboBox();
            this.cbSubirBase = new System.Windows.Forms.CheckBox();
            this.btnMariaInstalado = new System.Windows.Forms.Button();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.groupAdmin = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVersaoInstalada = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAdmin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbModeloCPJ = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.groupCPJ = new System.Windows.Forms.GroupBox();
            this.btnIniciarCPJLeviatan = new System.Windows.Forms.Button();
            this.btnIniciarCPJ = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCaminho = new System.Windows.Forms.Label();
            this.groupInstalacao.SuspendLayout();
            this.groupAdmin.SuspendLayout();
            this.groupCPJ.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInstalacao
            // 
            this.groupInstalacao.Controls.Add(this.labelBanco);
            this.groupInstalacao.Controls.Add(this.selectBoxBanco);
            this.groupInstalacao.Controls.Add(this.labelCPJ3C);
            this.groupInstalacao.Controls.Add(this.selectBoxCPJ3C);
            this.groupInstalacao.Controls.Add(this.labelVersaoCPJ3C);
            this.groupInstalacao.Controls.Add(this.selectBoxVersaoCPJ3C);
            this.groupInstalacao.Controls.Add(this.labelARQ3C);
            this.groupInstalacao.Controls.Add(this.selectBoxARQ3C);
            this.groupInstalacao.Controls.Add(this.cbSubirBase);
            this.groupInstalacao.Controls.Add(this.btnMariaInstalado);
            this.groupInstalacao.Controls.Add(this.buttonIniciar);
            this.groupInstalacao.Location = new System.Drawing.Point(12, 27);
            this.groupInstalacao.Name = "groupInstalacao";
            this.groupInstalacao.Size = new System.Drawing.Size(320, 247);
            this.groupInstalacao.TabIndex = 27;
            this.groupInstalacao.TabStop = false;
            this.groupInstalacao.Text = "Instalação e Estruturação";
            // 
            // labelBanco
            // 
            this.labelBanco.Location = new System.Drawing.Point(10, 20);
            this.labelBanco.Name = "labelBanco";
            this.labelBanco.Size = new System.Drawing.Size(88, 16);
            this.labelBanco.TabIndex = 0;
            this.labelBanco.Text = "Tipo do banco";
            // 
            // selectBoxBanco
            // 
            this.selectBoxBanco.Items.AddRange(new object[] {
            ""});
            this.selectBoxBanco.Location = new System.Drawing.Point(10, 42);
            this.selectBoxBanco.Name = "selectBoxBanco";
            this.selectBoxBanco.Size = new System.Drawing.Size(150, 21);
            this.selectBoxBanco.TabIndex = 1;
            // 
            // labelCPJ3C
            // 
            this.labelCPJ3C.Location = new System.Drawing.Point(10, 69);
            this.labelCPJ3C.Name = "labelCPJ3C";
            this.labelCPJ3C.Size = new System.Drawing.Size(150, 20);
            this.labelCPJ3C.TabIndex = 2;
            this.labelCPJ3C.Text = "Versão do CPJ";
            // 
            // selectBoxCPJ3C
            // 
            this.selectBoxCPJ3C.Items.AddRange(new object[] {
            "",
            "H04",
            "H03",
            "G03",
            "H02",
            "H01",
            "G02",
            "G01"});
            this.selectBoxCPJ3C.Location = new System.Drawing.Point(10, 95);
            this.selectBoxCPJ3C.Name = "selectBoxCPJ3C";
            this.selectBoxCPJ3C.Size = new System.Drawing.Size(150, 21);
            this.selectBoxCPJ3C.TabIndex = 3;
            // 
            // labelVersaoCPJ3C
            // 
            this.labelVersaoCPJ3C.Location = new System.Drawing.Point(183, 69);
            this.labelVersaoCPJ3C.Name = "labelVersaoCPJ3C";
            this.labelVersaoCPJ3C.Size = new System.Drawing.Size(120, 20);
            this.labelVersaoCPJ3C.TabIndex = 4;
            this.labelVersaoCPJ3C.Text = "Snapshot";
            // 
            // selectBoxVersaoCPJ3C
            // 
            this.selectBoxVersaoCPJ3C.Location = new System.Drawing.Point(186, 95);
            this.selectBoxVersaoCPJ3C.Name = "selectBoxVersaoCPJ3C";
            this.selectBoxVersaoCPJ3C.Size = new System.Drawing.Size(120, 21);
            this.selectBoxVersaoCPJ3C.TabIndex = 5;
            // 
            // labelARQ3C
            // 
            this.labelARQ3C.Location = new System.Drawing.Point(10, 122);
            this.labelARQ3C.Name = "labelARQ3C";
            this.labelARQ3C.Size = new System.Drawing.Size(150, 20);
            this.labelARQ3C.TabIndex = 6;
            this.labelARQ3C.Text = "Versão do ARQ";
            // 
            // selectBoxARQ3C
            // 
            this.selectBoxARQ3C.Items.AddRange(new object[] {
            ""});
            this.selectBoxARQ3C.Location = new System.Drawing.Point(10, 148);
            this.selectBoxARQ3C.Name = "selectBoxARQ3C";
            this.selectBoxARQ3C.Size = new System.Drawing.Size(150, 21);
            this.selectBoxARQ3C.TabIndex = 7;
            // 
            // cbSubirBase
            // 
            this.cbSubirBase.AutoSize = true;
            this.cbSubirBase.Location = new System.Drawing.Point(10, 175);
            this.cbSubirBase.Name = "cbSubirBase";
            this.cbSubirBase.Size = new System.Drawing.Size(185, 30);
            this.cbSubirBase.TabIndex = 11;
            this.cbSubirBase.Text = "Subir uma base limpa?\r\nMarque para a primeira instalação";
            this.cbSubirBase.UseVisualStyleBackColor = true;
            // 
            // btnMariaInstalado
            // 
            this.btnMariaInstalado.Location = new System.Drawing.Point(186, 146);
            this.btnMariaInstalado.Name = "btnMariaInstalado";
            this.btnMariaInstalado.Size = new System.Drawing.Size(100, 23);
            this.btnMariaInstalado.TabIndex = 12;
            this.btnMariaInstalado.Text = "Subir base";
            this.btnMariaInstalado.UseVisualStyleBackColor = true;
            this.btnMariaInstalado.Click += new System.EventHandler(this.btnMariaInstalado_Click);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(10, 211);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(290, 23);
            this.buttonIniciar.TabIndex = 8;
            this.buttonIniciar.Text = "Iniciar Instalação";
            this.buttonIniciar.Click += new System.EventHandler(this.ButtonIniciar_Click);
            // 
            // groupAdmin
            // 
            this.groupAdmin.Controls.Add(this.label1);
            this.groupAdmin.Controls.Add(this.cbVersaoInstalada);
            this.groupAdmin.Controls.Add(this.label2);
            this.groupAdmin.Controls.Add(this.cbAdmin);
            this.groupAdmin.Controls.Add(this.label3);
            this.groupAdmin.Controls.Add(this.cbModeloCPJ);
            this.groupAdmin.Controls.Add(this.label4);
            this.groupAdmin.Controls.Add(this.btnAdmin);
            this.groupAdmin.Location = new System.Drawing.Point(12, 280);
            this.groupAdmin.Name = "groupAdmin";
            this.groupAdmin.Size = new System.Drawing.Size(320, 179);
            this.groupAdmin.TabIndex = 26;
            this.groupAdmin.TabStop = false;
            this.groupAdmin.Text = "Rodar Admin";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "CPJ3C Instalados (Versão)";
            // 
            // cbVersaoInstalada
            // 
            this.cbVersaoInstalada.Items.AddRange(new object[] {
            ""});
            this.cbVersaoInstalada.Location = new System.Drawing.Point(9, 95);
            this.cbVersaoInstalada.Name = "cbVersaoInstalada";
            this.cbVersaoInstalada.Size = new System.Drawing.Size(150, 21);
            this.cbVersaoInstalada.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Rodar Admin";
            // 
            // cbAdmin
            // 
            this.cbAdmin.DropDownHeight = 50;
            this.cbAdmin.IntegralHeight = false;
            this.cbAdmin.ItemHeight = 13;
            this.cbAdmin.Items.AddRange(new object[] {
            ""});
            this.cbAdmin.Location = new System.Drawing.Point(162, 66);
            this.cbAdmin.MaxDropDownItems = 5;
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(144, 21);
            this.cbAdmin.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Snapshot Instaladas ";
            // 
            // cbModeloCPJ
            // 
            this.cbModeloCPJ.Items.AddRange(new object[] {
            ""});
            this.cbModeloCPJ.Location = new System.Drawing.Point(9, 42);
            this.cbModeloCPJ.Name = "cbModeloCPJ";
            this.cbModeloCPJ.Size = new System.Drawing.Size(150, 21);
            this.cbModeloCPJ.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(183, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Versão do ADMIN";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(9, 146);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(290, 23);
            this.btnAdmin.TabIndex = 17;
            this.btnAdmin.Text = "Rodar Admin";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // groupCPJ
            // 
            this.groupCPJ.Controls.Add(this.btnIniciarCPJLeviatan);
            this.groupCPJ.Controls.Add(this.btnIniciarCPJ);
            this.groupCPJ.Controls.Add(this.buttonCancelar);
            this.groupCPJ.Location = new System.Drawing.Point(12, 465);
            this.groupCPJ.Name = "groupCPJ";
            this.groupCPJ.Size = new System.Drawing.Size(320, 94);
            this.groupCPJ.TabIndex = 25;
            this.groupCPJ.TabStop = false;
            this.groupCPJ.Text = "Iniciar CPJ";
            // 
            // btnIniciarCPJLeviatan
            // 
            this.btnIniciarCPJLeviatan.Location = new System.Drawing.Point(10, 56);
            this.btnIniciarCPJLeviatan.Name = "btnIniciarCPJLeviatan";
            this.btnIniciarCPJLeviatan.Size = new System.Drawing.Size(230, 30);
            this.btnIniciarCPJLeviatan.TabIndex = 20;
            this.btnIniciarCPJLeviatan.Text = "Iniciar CPJ Leviatan";
            this.btnIniciarCPJLeviatan.Click += new System.EventHandler(this.btnIniciarCPJLeviatan_Click);
            // 
            // btnIniciarCPJ
            // 
            this.btnIniciarCPJ.Location = new System.Drawing.Point(10, 20);
            this.btnIniciarCPJ.Name = "btnIniciarCPJ";
            this.btnIniciarCPJ.Size = new System.Drawing.Size(230, 30);
            this.btnIniciarCPJ.TabIndex = 19;
            this.btnIniciarCPJ.Text = "Iniciar CPJ Local";
            this.btnIniciarCPJ.Click += new System.EventHandler(this.btnIniciarCPJ_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(250, 20);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(60, 30);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msOpcoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msOpcoes
            // 
            this.msOpcoes.Name = "msOpcoes";
            this.msOpcoes.Size = new System.Drawing.Size(79, 20);
            this.msOpcoes.Text = "Repositório";
            this.msOpcoes.Click += new System.EventHandler(this.msOpcoes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 562);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Repositório:";
            // 
            // lbCaminho
            // 
            this.lbCaminho.Location = new System.Drawing.Point(81, 562);
            this.lbCaminho.MaximumSize = new System.Drawing.Size(247, 0);
            this.lbCaminho.Name = "lbCaminho";
            this.lbCaminho.Size = new System.Drawing.Size(247, 38);
            this.lbCaminho.TabIndex = 24;
            this.lbCaminho.Text = "-";
            // 
            // instalacao
            // 
            this.ClientSize = new System.Drawing.Size(346, 611);
            this.Controls.Add(this.lbCaminho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupCPJ);
            this.Controls.Add(this.groupAdmin);
            this.Controls.Add(this.groupInstalacao);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "instalacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalação Local";
            this.groupInstalacao.ResumeLayout(false);
            this.groupInstalacao.PerformLayout();
            this.groupAdmin.ResumeLayout(false);
            this.groupCPJ.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CheckBox cbSubirBase;
        private Button btnMariaInstalado;
        private Label label1;
        private ComboBox cbVersaoInstalada;
        private Label label2;
        private ComboBox cbAdmin;
        private Button btnAdmin;
        private ComboBox cbModeloCPJ;
        private Button btnIniciarCPJ;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem msOpcoes;
        private Label label5;
        private Label lbCaminho;
        private Button btnIniciarCPJLeviatan;
    }
}