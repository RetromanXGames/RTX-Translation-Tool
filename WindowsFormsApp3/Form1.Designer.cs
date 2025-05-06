using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    partial class Form1
    {
        private System.Windows.Forms.TextBox txtOriginalText;
        private System.Windows.Forms.RichTextBox txtTranslatedText;
        private System.Windows.Forms.TextBox txtOriginalTextLabel;
        private System.Windows.Forms.TextBox txtTranslatedTextLabel;
        private System.Windows.Forms.TextBox txtRenderTextLabel;
        private System.Windows.Forms.TextBox txtPreviewLabel;
        private System.Windows.Forms.Button btnSalvarScriptTraduzido;
        private System.Windows.Forms.Button btnGravarConfiguracoes;
        private System.Windows.Forms.Button btnCarregarConfiguracao;
        private System.Windows.Forms.Button btnNovoProjeto;
        private PictureBox picTranslatedImage;
        private System.Windows.Forms.Button btnCorDeFundo;
        private ComboBox comboBoxCodecs;
        private System.Windows.Forms.Button btnExportarCodec;
        private Dictionary<string, string> novoScriptMap = new Dictionary<string, string>();
        private System.Windows.Forms.PictureBox pictureBoxMovel;
        private NumericUpDown numericWidth;
        private NumericUpDown numericHeight;
        private System.Windows.Forms.NumericUpDown numericHorizontalOffset;
        private System.Windows.Forms.NumericUpDown numericVerticalOffset;
        private System.Windows.Forms.NumericUpDown numericTextHorizontalOffset;
        private System.Windows.Forms.NumericUpDown numericTextVerticalOffset;
        private System.Windows.Forms.NumericUpDown numericSelectedLine;
        private System.Windows.Forms.NumericUpDown numericLineHeight;
        private System.Windows.Forms.ComboBox comboBoxDimensoes;
        private System.Windows.Forms.Button btnTranslateWithGoogle;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.ComboBox comboBoxScripts;        
        private System.Windows.Forms.Button btnSelectTranslatedFolder;
        private System.Windows.Forms.ComboBox comboBoxTranslatedScripts;
        private ScintillaNET.Scintilla scintillaEditor;
        private System.Windows.Forms.Button btnLoadFolder;
        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.Button btnSalvarAsm;
        private System.Windows.Forms.Button btnSalvarAsmComo;
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCarregarConfiguracao = new System.Windows.Forms.Button();
            this.txtOriginalText = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.numericTextHorizontalOffset = new System.Windows.Forms.NumericUpDown();
            this.numericTextVerticalOffset = new System.Windows.Forms.NumericUpDown();
            this.txtOriginalTextLabel = new System.Windows.Forms.TextBox();
            this.txtTranslatedTextLabel = new System.Windows.Forms.TextBox();
            this.txtRenderTextLabel = new System.Windows.Forms.TextBox();
            this.txtPreviewLabel = new System.Windows.Forms.TextBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnLoadTable = new System.Windows.Forms.Button();
            this.btnLoadReferenceImage = new System.Windows.Forms.Button();
            this.POSICAO_TELA = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtTranslatedText = new System.Windows.Forms.RichTextBox();
            this.numericSelectedLine = new System.Windows.Forms.NumericUpDown();
            this.numericLineHeight = new System.Windows.Forms.NumericUpDown();
            this.btnSalvarScriptTraduzido = new System.Windows.Forms.Button();
            this.btnGravarConfiguracoes = new System.Windows.Forms.Button();
            this.btnCorDeFundo = new System.Windows.Forms.Button();
            this.btnNovoProjeto = new System.Windows.Forms.Button();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.comboBoxCodecs = new System.Windows.Forms.ComboBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.texto_renderizado_para_exportar = new System.Windows.Forms.PictureBox();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericHorizontalOffset = new System.Windows.Forms.NumericUpDown();
            this.numericVerticalOffset = new System.Windows.Forms.NumericUpDown();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.comboBoxDimensoes = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.pictureBoxMovel = new System.Windows.Forms.PictureBox();
            this.btnExportPng = new System.Windows.Forms.Button();
            this.picTranslatedImage = new System.Windows.Forms.PictureBox();
            this.btnExportarCodec = new System.Windows.Forms.Button();
            this.btnTranslateWithGoogle = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.comboBoxScripts = new System.Windows.Forms.ComboBox();
            this.btnSelectTranslatedFolder = new System.Windows.Forms.Button();
            this.comboBoxTranslatedScripts = new System.Windows.Forms.ComboBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.btnLoadFolder = new System.Windows.Forms.Button();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.scintillaEditor = new ScintillaNET.Scintilla();
            this.btnSalvarAsm = new System.Windows.Forms.Button();
            this.btnSalvarAsmComo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericTextHorizontalOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTextVerticalOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSelectedLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texto_renderizado_para_exportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizontalOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVerticalOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslatedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Location = new System.Drawing.Point(12, 532);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 327);
            this.listBox1.TabIndex = 73;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // btnCarregarConfiguracao
            // 
            this.btnCarregarConfiguracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnCarregarConfiguracao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarregarConfiguracao.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarConfiguracao.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCarregarConfiguracao.Location = new System.Drawing.Point(124, 5);
            this.btnCarregarConfiguracao.Name = "btnCarregarConfiguracao";
            this.btnCarregarConfiguracao.Size = new System.Drawing.Size(132, 30);
            this.btnCarregarConfiguracao.TabIndex = 2;
            this.btnCarregarConfiguracao.Text = "Carregar Projeto";
            this.btnCarregarConfiguracao.UseVisualStyleBackColor = false;
            this.btnCarregarConfiguracao.Click += new System.EventHandler(this.BtnCarregarConfiguracao_Click);
            // 
            // txtOriginalText
            // 
            this.txtOriginalText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtOriginalText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOriginalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtOriginalText.Location = new System.Drawing.Point(228, 68);
            this.txtOriginalText.Multiline = true;
            this.txtOriginalText.Name = "txtOriginalText";
            this.txtOriginalText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOriginalText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOriginalText.Size = new System.Drawing.Size(471, 213);
            this.txtOriginalText.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.Location = new System.Drawing.Point(12, 132);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(210, 301);
            this.listBox2.TabIndex = 75;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // numericTextHorizontalOffset
            // 
            this.numericTextHorizontalOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericTextHorizontalOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTextHorizontalOffset.ForeColor = System.Drawing.SystemColors.Window;
            this.numericTextHorizontalOffset.Location = new System.Drawing.Point(1319, 205);
            this.numericTextHorizontalOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTextHorizontalOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericTextHorizontalOffset.Name = "numericTextHorizontalOffset";
            this.numericTextHorizontalOffset.Size = new System.Drawing.Size(55, 20);
            this.numericTextHorizontalOffset.TabIndex = 92;
            this.numericTextHorizontalOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTextHorizontalOffset.ValueChanged += new System.EventHandler(this.NumericTextHorizontalOffset_ValueChanged);
            // 
            // numericTextVerticalOffset
            // 
            this.numericTextVerticalOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericTextVerticalOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTextVerticalOffset.ForeColor = System.Drawing.SystemColors.Window;
            this.numericTextVerticalOffset.Location = new System.Drawing.Point(1319, 230);
            this.numericTextVerticalOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTextVerticalOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericTextVerticalOffset.Name = "numericTextVerticalOffset";
            this.numericTextVerticalOffset.Size = new System.Drawing.Size(55, 20);
            this.numericTextVerticalOffset.TabIndex = 93;
            this.numericTextVerticalOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTextVerticalOffset.ValueChanged += new System.EventHandler(this.NumericTextVerticalOffset_ValueChanged);
            // 
            // txtOriginalTextLabel
            // 
            this.txtOriginalTextLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtOriginalTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOriginalTextLabel.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalTextLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.txtOriginalTextLabel.Location = new System.Drawing.Point(228, 42);
            this.txtOriginalTextLabel.Name = "txtOriginalTextLabel";
            this.txtOriginalTextLabel.ReadOnly = true;
            this.txtOriginalTextLabel.Size = new System.Drawing.Size(471, 22);
            this.txtOriginalTextLabel.TabIndex = 8;
            this.txtOriginalTextLabel.Text = "TEXTO ORIGINAL";
            this.txtOriginalTextLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTranslatedTextLabel
            // 
            this.txtTranslatedTextLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtTranslatedTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranslatedTextLabel.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslatedTextLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.txtTranslatedTextLabel.Location = new System.Drawing.Point(228, 286);
            this.txtTranslatedTextLabel.Name = "txtTranslatedTextLabel";
            this.txtTranslatedTextLabel.ReadOnly = true;
            this.txtTranslatedTextLabel.Size = new System.Drawing.Size(471, 22);
            this.txtTranslatedTextLabel.TabIndex = 9;
            this.txtTranslatedTextLabel.Text = "TEXTO TRADUZIDO";
            this.txtTranslatedTextLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRenderTextLabel
            // 
            this.txtRenderTextLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtRenderTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRenderTextLabel.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenderTextLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.txtRenderTextLabel.Location = new System.Drawing.Point(228, 583);
            this.txtRenderTextLabel.Name = "txtRenderTextLabel";
            this.txtRenderTextLabel.ReadOnly = true;
            this.txtRenderTextLabel.Size = new System.Drawing.Size(471, 22);
            this.txtRenderTextLabel.TabIndex = 11;
            this.txtRenderTextLabel.Text = "TEXTO TRADUZIDO PELO GOOGLE TRANSLATOR";
            this.txtRenderTextLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRenderTextLabel.TextChanged += new System.EventHandler(this.txtRenderTextLabel_TextChanged);
            // 
            // txtPreviewLabel
            // 
            this.txtPreviewLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreviewLabel.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviewLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPreviewLabel.Location = new System.Drawing.Point(705, 42);
            this.txtPreviewLabel.Name = "txtPreviewLabel";
            this.txtPreviewLabel.ReadOnly = true;
            this.txtPreviewLabel.Size = new System.Drawing.Size(424, 22);
            this.txtPreviewLabel.TabIndex = 12;
            this.txtPreviewLabel.Text = "PREVIEW INGAME";
            this.txtPreviewLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPreviewLabel.TextChanged += new System.EventHandler(this.txtPreviewLabel_TextChanged);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadImage.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLoadImage.Location = new System.Drawing.Point(1135, 105);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(239, 31);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Carregar Gráfico da Fonte";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnLoadTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadTable.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTable.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLoadTable.Location = new System.Drawing.Point(1135, 68);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(239, 31);
            this.btnLoadTable.TabIndex = 1;
            this.btnLoadTable.Text = "Carregar Largura dos Carácteres";
            this.btnLoadTable.UseVisualStyleBackColor = false;
            this.btnLoadTable.Click += new System.EventHandler(this.BtnLoadTable_Click);
            // 
            // btnLoadReferenceImage
            // 
            this.btnLoadReferenceImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnLoadReferenceImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadReferenceImage.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadReferenceImage.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLoadReferenceImage.Location = new System.Drawing.Point(1135, 142);
            this.btnLoadReferenceImage.Name = "btnLoadReferenceImage";
            this.btnLoadReferenceImage.Size = new System.Drawing.Size(239, 34);
            this.btnLoadReferenceImage.TabIndex = 7;
            this.btnLoadReferenceImage.Text = "Carregar Imagem de Referência";
            this.btnLoadReferenceImage.UseVisualStyleBackColor = false;
            this.btnLoadReferenceImage.Click += new System.EventHandler(this.BtnLoadReferenceImage_Click);
            // 
            // POSICAO_TELA
            // 
            this.POSICAO_TELA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.POSICAO_TELA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.POSICAO_TELA.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POSICAO_TELA.ForeColor = System.Drawing.SystemColors.Window;
            this.POSICAO_TELA.Location = new System.Drawing.Point(1135, 179);
            this.POSICAO_TELA.Name = "POSICAO_TELA";
            this.POSICAO_TELA.ReadOnly = true;
            this.POSICAO_TELA.Size = new System.Drawing.Size(239, 22);
            this.POSICAO_TELA.TabIndex = 20;
            this.POSICAO_TELA.Text = "POSIÇÃO DO TEXTO NA TELA";
            this.POSICAO_TELA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(705, 296);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(424, 22);
            this.textBox2.TabIndex = 30;
            this.textBox2.Text = "TEXTO RENDERIZADO PARA EXPORTAR";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(12, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(210, 22);
            this.textBox4.TabIndex = 42;
            this.textBox4.Text = "ÍNDICE DOS DIÁLOGOS ORIGINAIS";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTranslatedText
            // 
            this.txtTranslatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.txtTranslatedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranslatedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslatedText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTranslatedText.Location = new System.Drawing.Point(228, 313);
            this.txtTranslatedText.Name = "txtTranslatedText";
            this.txtTranslatedText.Size = new System.Drawing.Size(471, 230);
            this.txtTranslatedText.TabIndex = 5;
            this.txtTranslatedText.Text = "";
            this.txtTranslatedText.TextChanged += new System.EventHandler(this.txtTranslatedText_TextChanged);
            // 
            // numericSelectedLine
            // 
            this.numericSelectedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericSelectedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSelectedLine.ForeColor = System.Drawing.SystemColors.Window;
            this.numericSelectedLine.Location = new System.Drawing.Point(1319, 630);
            this.numericSelectedLine.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSelectedLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSelectedLine.Name = "numericSelectedLine";
            this.numericSelectedLine.Size = new System.Drawing.Size(55, 20);
            this.numericSelectedLine.TabIndex = 0;
            this.numericSelectedLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSelectedLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSelectedLine.ValueChanged += new System.EventHandler(this.NumericSelectedLine_ValueChanged);
            // 
            // numericLineHeight
            // 
            this.numericLineHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericLineHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericLineHeight.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.numericLineHeight.Location = new System.Drawing.Point(1319, 279);
            this.numericLineHeight.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericLineHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLineHeight.Name = "numericLineHeight";
            this.numericLineHeight.Size = new System.Drawing.Size(55, 20);
            this.numericLineHeight.TabIndex = 1;
            this.numericLineHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericLineHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericLineHeight.ValueChanged += new System.EventHandler(this.NumericLineHeight_ValueChanged);
            // 
            // btnSalvarScriptTraduzido
            // 
            this.btnSalvarScriptTraduzido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnSalvarScriptTraduzido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarScriptTraduzido.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarScriptTraduzido.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSalvarScriptTraduzido.Location = new System.Drawing.Point(228, 547);
            this.btnSalvarScriptTraduzido.Name = "btnSalvarScriptTraduzido";
            this.btnSalvarScriptTraduzido.Size = new System.Drawing.Size(471, 30);
            this.btnSalvarScriptTraduzido.TabIndex = 44;
            this.btnSalvarScriptTraduzido.Text = "Salvar Script Traduzido";
            this.btnSalvarScriptTraduzido.UseVisualStyleBackColor = false;
            this.btnSalvarScriptTraduzido.Click += new System.EventHandler(this.BtnSalvarScriptTraduzido_Click);
            // 
            // btnGravarConfiguracoes
            // 
            this.btnGravarConfiguracoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnGravarConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGravarConfiguracoes.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravarConfiguracoes.ForeColor = System.Drawing.SystemColors.Info;
            this.btnGravarConfiguracoes.Location = new System.Drawing.Point(262, 5);
            this.btnGravarConfiguracoes.Name = "btnGravarConfiguracoes";
            this.btnGravarConfiguracoes.Size = new System.Drawing.Size(113, 30);
            this.btnGravarConfiguracoes.TabIndex = 1;
            this.btnGravarConfiguracoes.Text = "Salvar Projeto";
            this.btnGravarConfiguracoes.UseVisualStyleBackColor = false;
            this.btnGravarConfiguracoes.Click += new System.EventHandler(this.BtnGravarConfiguracoes_Click);
            // 
            // btnCorDeFundo
            // 
            this.btnCorDeFundo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnCorDeFundo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCorDeFundo.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorDeFundo.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCorDeFundo.Location = new System.Drawing.Point(1135, 706);
            this.btnCorDeFundo.Name = "btnCorDeFundo";
            this.btnCorDeFundo.Size = new System.Drawing.Size(239, 27);
            this.btnCorDeFundo.TabIndex = 64;
            this.btnCorDeFundo.Text = "COR DE FUNDO DA JANELA";
            this.btnCorDeFundo.UseVisualStyleBackColor = false;
            this.btnCorDeFundo.Click += new System.EventHandler(this.BtnCorDeFundo_Click);
            // 
            // btnNovoProjeto
            // 
            this.btnNovoProjeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnNovoProjeto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNovoProjeto.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProjeto.ForeColor = System.Drawing.SystemColors.Info;
            this.btnNovoProjeto.Location = new System.Drawing.Point(12, 5);
            this.btnNovoProjeto.Name = "btnNovoProjeto";
            this.btnNovoProjeto.Size = new System.Drawing.Size(106, 30);
            this.btnNovoProjeto.TabIndex = 0;
            this.btnNovoProjeto.Text = "Novo Projeto";
            this.btnNovoProjeto.UseVisualStyleBackColor = false;
            this.btnNovoProjeto.Click += new System.EventHandler(this.BtnNovoProjeto_Click);
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox23.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox23.Location = new System.Drawing.Point(12, 443);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(210, 22);
            this.textBox23.TabIndex = 74;
            this.textBox23.Text = "ÍNDICE DOS DIÁLOGOS TRADUZIDOS";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(228, 611);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(471, 214);
            this.textBox1.TabIndex = 76;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox15.Location = new System.Drawing.Point(1135, 303);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(239, 22);
            this.textBox15.TabIndex = 77;
            this.textBox15.Text = "AJUSTES PARA EXPORTAR O BINÁRIO";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxCodecs
            // 
            this.comboBoxCodecs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBoxCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCodecs.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBoxCodecs.FormattingEnabled = true;
            this.comboBoxCodecs.Items.AddRange(new object[] {
            "1bpp planar",
            "2bpp planar",
            "3bpp planar",
            "4bpp planar",
            "5bpp planar",
            "6bpp planar",
            "7bpp planar",
            "8bpp planar",
            "1bpp linear",
            "1bpp linear com ordem reversa",
            "2bpp linear",
            "2bpp linear com ordem reversa",
            "4bpp linear",
            "4bpp linear com ordem reversa",
            "8bpp linear",
            "2bpp planar composto",
            "3bpp planar composto(2bpp+1bpp)",
            "4bpp planar composto(2x2bpp)",
            "8bpp planar composto(4x2bpp)",
            "3bpp linear",
            "15bpp RGB(555)",
            "15bpp BGR(555)",
            "16bpp RGB(565)",
            "16bpp BGR(565)",
            "16bpp ARGB(1555)",
            "16bpp ABGR(1555)",
            "16bpp RGBA(5551)",
            "16bpp BGRA(5551)",
            "24bpp RGB(888)",
            "24bpp BGR(888)",
            "32bpp ARGB(8888)",
            "32bpp ABGR(8888)",
            "32bpp RGBA(8888)",
            "32bpp BGRA(8888)"});
            this.comboBoxCodecs.Location = new System.Drawing.Point(1135, 356);
            this.comboBoxCodecs.Name = "comboBoxCodecs";
            this.comboBoxCodecs.Size = new System.Drawing.Size(239, 21);
            this.comboBoxCodecs.TabIndex = 80;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox16.Location = new System.Drawing.Point(1135, 330);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(239, 22);
            this.textBox16.TabIndex = 85;
            this.textBox16.Text = "CODEC DO BINÁRIO";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox17.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox17.Location = new System.Drawing.Point(1135, 382);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(135, 22);
            this.textBox17.TabIndex = 86;
            this.textBox17.Text = "DIMENSÃO";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericWidth
            // 
            this.numericWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericWidth.ForeColor = System.Drawing.SystemColors.Window;
            this.numericWidth.Location = new System.Drawing.Point(1319, 553);
            this.numericWidth.Maximum = new decimal(new int[] {
            424,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(55, 20);
            this.numericWidth.TabIndex = 87;
            this.numericWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericWidth.Value = this.texto_renderizado_para_exportar.Width;
            this.numericWidth.ValueChanged += new System.EventHandler(this.NumericWidth_ValueChanged);
            // 
            // texto_renderizado_para_exportar
            // 
            this.texto_renderizado_para_exportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.texto_renderizado_para_exportar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.texto_renderizado_para_exportar.Location = new System.Drawing.Point(705, 322);
            this.texto_renderizado_para_exportar.Name = "texto_renderizado_para_exportar";
            this.texto_renderizado_para_exportar.Size = new System.Drawing.Size(424, 240);
            this.texto_renderizado_para_exportar.TabIndex = 62;
            this.texto_renderizado_para_exportar.TabStop = false;
            // 
            // numericHeight
            // 
            this.numericHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHeight.ForeColor = System.Drawing.SystemColors.Window;
            this.numericHeight.Location = new System.Drawing.Point(1319, 578);
            this.numericHeight.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(55, 20);
            this.numericHeight.TabIndex = 88;
            this.numericHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHeight.Value = this.texto_renderizado_para_exportar.Height;
            this.numericHeight.ValueChanged += new System.EventHandler(this.NumericHeight_ValueChanged);
            // 
            // numericHorizontalOffset
            // 
            this.numericHorizontalOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericHorizontalOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHorizontalOffset.ForeColor = System.Drawing.SystemColors.Window;
            this.numericHorizontalOffset.Location = new System.Drawing.Point(1319, 655);
            this.numericHorizontalOffset.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericHorizontalOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericHorizontalOffset.Name = "numericHorizontalOffset";
            this.numericHorizontalOffset.Size = new System.Drawing.Size(55, 20);
            this.numericHorizontalOffset.TabIndex = 90;
            this.numericHorizontalOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHorizontalOffset.ValueChanged += new System.EventHandler(this.NumericHorizontalOffset_ValueChanged);
            // 
            // numericVerticalOffset
            // 
            this.numericVerticalOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.numericVerticalOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericVerticalOffset.ForeColor = System.Drawing.SystemColors.Window;
            this.numericVerticalOffset.Location = new System.Drawing.Point(1319, 680);
            this.numericVerticalOffset.Maximum = new decimal(new int[] {
            440,
            0,
            0,
            0});
            this.numericVerticalOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericVerticalOffset.Name = "numericVerticalOffset";
            this.numericVerticalOffset.Size = new System.Drawing.Size(55, 20);
            this.numericVerticalOffset.TabIndex = 91;
            this.numericVerticalOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericVerticalOffset.ValueChanged += new System.EventHandler(this.NumericVerticalOffset_ValueChanged);
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox18.Location = new System.Drawing.Point(1135, 526);
            this.textBox18.Margin = new System.Windows.Forms.Padding(0);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(239, 22);
            this.textBox18.TabIndex = 89;
            this.textBox18.Text = "TAMANHO DA JANELA DE EXPORTAÇÃO";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox3.Location = new System.Drawing.Point(1135, 654);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(182, 22);
            this.textBox3.TabIndex = 92;
            this.textBox3.Text = "POSIÇÃO HORIZONTAL";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox5.Location = new System.Drawing.Point(1135, 679);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(182, 22);
            this.textBox5.TabIndex = 93;
            this.textBox5.Text = "POSIÇÃO VERTICAL";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox6.Location = new System.Drawing.Point(1135, 603);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(239, 22);
            this.textBox6.TabIndex = 94;
            this.textBox6.Text = "POSIÇÃO DO TEXTO NA JANELA";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox7.Location = new System.Drawing.Point(1135, 204);
            this.textBox7.Margin = new System.Windows.Forms.Padding(0);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(179, 22);
            this.textBox7.TabIndex = 96;
            this.textBox7.Text = "POSIÇÃO HORIZONTAL";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox8.Location = new System.Drawing.Point(1135, 229);
            this.textBox8.Margin = new System.Windows.Forms.Padding(0);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(179, 22);
            this.textBox8.TabIndex = 97;
            this.textBox8.Text = "POSIÇÃO VERTICAL";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox9.Location = new System.Drawing.Point(1135, 577);
            this.textBox9.Margin = new System.Windows.Forms.Padding(0);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(182, 22);
            this.textBox9.TabIndex = 99;
            this.textBox9.Text = "TAMANHO VERTICAL";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox10.Location = new System.Drawing.Point(1135, 552);
            this.textBox10.Margin = new System.Windows.Forms.Padding(0);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(182, 22);
            this.textBox10.TabIndex = 98;
            this.textBox10.Text = "TAMANHO HORIZONTAL";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox11.Location = new System.Drawing.Point(1135, 500);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(239, 20);
            this.textBox11.TabIndex = 100;
            this.textBox11.Text = "AJUSTES TEXTO RENDERIZADO";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox12.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox12.Location = new System.Drawing.Point(1135, 629);
            this.textBox12.Margin = new System.Windows.Forms.Padding(0);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(182, 22);
            this.textBox12.TabIndex = 101;
            this.textBox12.Text = "LINHA";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox13.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox13.Location = new System.Drawing.Point(1135, 254);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(239, 22);
            this.textBox13.TabIndex = 102;
            this.textBox13.Text = "TAMANHO DA FONTE";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox14.Location = new System.Drawing.Point(1135, 280);
            this.textBox14.Margin = new System.Windows.Forms.Padding(0);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(182, 22);
            this.textBox14.TabIndex = 103;
            this.textBox14.Text = "TAMANHO VERTICAL EM PIXELS";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxDimensoes
            // 
            this.comboBoxDimensoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBoxDimensoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDimensoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDimensoes.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBoxDimensoes.FormattingEnabled = true;
            this.comboBoxDimensoes.Items.AddRange(new object[] {
            "1 Dimensão",
            "2 Dimensões"});
            this.comboBoxDimensoes.Location = new System.Drawing.Point(1276, 382);
            this.comboBoxDimensoes.Name = "comboBoxDimensoes";
            this.comboBoxDimensoes.Size = new System.Drawing.Size(98, 21);
            this.comboBoxDimensoes.TabIndex = 1;
            this.comboBoxDimensoes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDimensoes_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox2.Location = new System.Drawing.Point(1319, 788);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(55, 21);
            this.comboBox2.TabIndex = 107;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox19.Location = new System.Drawing.Point(1135, 789);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(179, 20);
            this.textBox19.TabIndex = 106;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox3.Location = new System.Drawing.Point(1319, 814);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(55, 21);
            this.comboBox3.TabIndex = 109;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox20.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox20.Location = new System.Drawing.Point(1135, 815);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(179, 20);
            this.textBox20.TabIndex = 108;
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox4.Location = new System.Drawing.Point(1319, 840);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(55, 21);
            this.comboBox4.TabIndex = 111;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox21.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox21.Location = new System.Drawing.Point(1135, 841);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(179, 20);
            this.textBox21.TabIndex = 110;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox22.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox22.Location = new System.Drawing.Point(1135, 737);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(239, 22);
            this.textBox22.TabIndex = 112;
            this.textBox22.Text = "ORGANIZAR MACROS OU BYTES DE CONTROLE";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox5.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox5.Location = new System.Drawing.Point(1319, 918);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(55, 21);
            this.comboBox5.TabIndex = 118;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox24.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox24.Location = new System.Drawing.Point(1135, 919);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(179, 20);
            this.textBox24.TabIndex = 117;
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox6.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox6.Location = new System.Drawing.Point(1319, 892);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(55, 21);
            this.comboBox6.TabIndex = 116;
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox25.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox25.Location = new System.Drawing.Point(1135, 893);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(179, 20);
            this.textBox25.TabIndex = 115;
            // 
            // comboBox7
            // 
            this.comboBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox7.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox7.Location = new System.Drawing.Point(1319, 866);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(55, 21);
            this.comboBox7.TabIndex = 114;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox26.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox26.Location = new System.Drawing.Point(1135, 867);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(179, 20);
            this.textBox26.TabIndex = 113;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dourado",
            "Amarelo Claro",
            "Vermelho",
            "Verde",
            "Azul",
            "Cinza",
            "Laranja",
            "Magenta",
            "Verde Limão",
            "Amarelo Ouro",
            "Azeitona",
            "Chocolate",
            "Coral",
            "Prata",
            "Verde Escuro",
            "Rosa Escuro",
            "Ciano Escuro"});
            this.comboBox1.Location = new System.Drawing.Point(1319, 761);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(55, 21);
            this.comboBox1.TabIndex = 120;
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.textBox27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox27.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox27.Location = new System.Drawing.Point(1135, 762);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(179, 20);
            this.textBox27.TabIndex = 119;
            // 
            // pictureBoxMovel
            // 
            this.pictureBoxMovel.Image = global::WindowsFormsApp3.Properties.Resources.RODAPÉV2;
            this.pictureBoxMovel.Location = new System.Drawing.Point(12, 865);
            this.pictureBoxMovel.Name = "pictureBoxMovel";
            this.pictureBoxMovel.Size = new System.Drawing.Size(302, 114);
            this.pictureBoxMovel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMovel.TabIndex = 0;
            this.pictureBoxMovel.TabStop = false;
            this.pictureBoxMovel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMovel_MouseDown);
            this.pictureBoxMovel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMovel_MouseMove);
            this.pictureBoxMovel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMovel_MouseUp);
            // 
            // btnExportPng
            // 
            this.btnExportPng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnExportPng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportPng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPng.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPng.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExportPng.Image = global::WindowsFormsApp3.Properties.Resources.EXPORTAR_PNG1;
            this.btnExportPng.Location = new System.Drawing.Point(1135, 424);
            this.btnExportPng.Name = "btnExportPng";
            this.btnExportPng.Size = new System.Drawing.Size(239, 35);
            this.btnExportPng.TabIndex = 3;
            this.btnExportPng.UseVisualStyleBackColor = false;
            this.btnExportPng.Click += new System.EventHandler(this.BtnExportPng_Click);
            // 
            // picTranslatedImage
            // 
            this.picTranslatedImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.picTranslatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTranslatedImage.Location = new System.Drawing.Point(705, 68);
            this.picTranslatedImage.Name = "picTranslatedImage";
            this.picTranslatedImage.Size = new System.Drawing.Size(424, 224);
            this.picTranslatedImage.TabIndex = 6;
            this.picTranslatedImage.TabStop = false;
            // 
            // btnExportarCodec
            // 
            this.btnExportarCodec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnExportarCodec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportarCodec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCodec.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCodec.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExportarCodec.Image = global::WindowsFormsApp3.Properties.Resources.EXPORTAR_BIN2;
            this.btnExportarCodec.Location = new System.Drawing.Point(1135, 463);
            this.btnExportarCodec.Name = "btnExportarCodec";
            this.btnExportarCodec.Size = new System.Drawing.Size(239, 35);
            this.btnExportarCodec.TabIndex = 81;
            this.btnExportarCodec.UseVisualStyleBackColor = false;
            this.btnExportarCodec.Click += new System.EventHandler(this.BtnExportarCodec_Click);
            // 
            // btnTranslateWithGoogle
            // 
            this.btnTranslateWithGoogle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnTranslateWithGoogle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTranslateWithGoogle.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranslateWithGoogle.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTranslateWithGoogle.Location = new System.Drawing.Point(228, 831);
            this.btnTranslateWithGoogle.Name = "btnTranslateWithGoogle";
            this.btnTranslateWithGoogle.Size = new System.Drawing.Size(471, 28);
            this.btnTranslateWithGoogle.TabIndex = 122;
            this.btnTranslateWithGoogle.Text = "Traduzir com Google Translate";
            this.btnTranslateWithGoogle.UseVisualStyleBackColor = false;
            this.btnTranslateWithGoogle.Click += new System.EventHandler(this.BtnTranslateWithGoogle_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFolder.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSelectFolder.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 69);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(210, 32);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Pasta dos Scripts Originais";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.BtnSelectFolder_Click);
            // 
            // comboBoxScripts
            // 
            this.comboBoxScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBoxScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScripts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxScripts.ForeColor = System.Drawing.SystemColors.Info;
            this.comboBoxScripts.FormattingEnabled = true;
            this.comboBoxScripts.Location = new System.Drawing.Point(12, 106);
            this.comboBoxScripts.Name = "comboBoxScripts";
            this.comboBoxScripts.Size = new System.Drawing.Size(210, 21);
            this.comboBoxScripts.TabIndex = 1;
            this.comboBoxScripts.SelectedIndexChanged += new System.EventHandler(this.comboBoxScripts_SelectedIndexChanged);
            // 
            // btnSelectTranslatedFolder
            // 
            this.btnSelectTranslatedFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnSelectTranslatedFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectTranslatedFolder.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSelectTranslatedFolder.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSelectTranslatedFolder.Location = new System.Drawing.Point(12, 469);
            this.btnSelectTranslatedFolder.Name = "btnSelectTranslatedFolder";
            this.btnSelectTranslatedFolder.Size = new System.Drawing.Size(210, 32);
            this.btnSelectTranslatedFolder.TabIndex = 1;
            this.btnSelectTranslatedFolder.Text = "Pasta dos Scripts Traduzidos";
            this.btnSelectTranslatedFolder.UseVisualStyleBackColor = false;
            this.btnSelectTranslatedFolder.Click += new System.EventHandler(this.BtnSelectTranslatedFolder_Click);
            // 
            // comboBoxTranslatedScripts
            // 
            this.comboBoxTranslatedScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.comboBoxTranslatedScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTranslatedScripts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTranslatedScripts.ForeColor = System.Drawing.SystemColors.Info;
            this.comboBoxTranslatedScripts.FormattingEnabled = true;
            this.comboBoxTranslatedScripts.Location = new System.Drawing.Point(12, 506);
            this.comboBoxTranslatedScripts.Name = "comboBoxTranslatedScripts";
            this.comboBoxTranslatedScripts.Size = new System.Drawing.Size(210, 21);
            this.comboBoxTranslatedScripts.TabIndex = 2;
            this.comboBoxTranslatedScripts.SelectedIndexChanged += new System.EventHandler(this.comboBoxTranslatedScripts_SelectedIndexChanged);
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.textBox28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox28.Font = new System.Drawing.Font("Co Headline", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox28.Location = new System.Drawing.Point(1135, 42);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(239, 22);
            this.textBox28.TabIndex = 123;
            this.textBox28.Text = "AJUSTES DA JANELA DE PREVIEW";
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLoadFolder
            // 
            this.btnLoadFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnLoadFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadFolder.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadFolder.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLoadFolder.Location = new System.Drawing.Point(1380, 42);
            this.btnLoadFolder.Name = "btnLoadFolder";
            this.btnLoadFolder.Size = new System.Drawing.Size(172, 31);
            this.btnLoadFolder.TabIndex = 125;
            this.btnLoadFolder.Text = "Carregar Pasta";
            this.btnLoadFolder.UseVisualStyleBackColor = false;
            this.btnLoadFolder.Click += new System.EventHandler(this.BtnLoadFolder_Click);
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.Location = new System.Drawing.Point(1380, 79);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(519, 130);
            this.treeViewFiles.TabIndex = 126;
            this.treeViewFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewFiles_NodeMouseDoubleClick);
            // 
            // scintillaEditor
            // 
            this.scintillaEditor.AutoCMaxHeight = 9;
            this.scintillaEditor.AutoCOrder = ScintillaNET.Order.Custom;
            this.scintillaEditor.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.scintillaEditor.BorderStyle = ScintillaNET.BorderStyle.FixedSingle;
            this.scintillaEditor.CaretLineBackColor = System.Drawing.Color.Black;
            this.scintillaEditor.CaretLineVisible = true;
            this.scintillaEditor.LexerName = null;
            this.scintillaEditor.Location = new System.Drawing.Point(1380, 215);
            this.scintillaEditor.Name = "scintillaEditor";
            this.scintillaEditor.ScrollWidth = 1;
            this.scintillaEditor.Size = new System.Drawing.Size(519, 724);
            this.scintillaEditor.TabIndents = true;
            this.scintillaEditor.TabIndex = 0;
            this.scintillaEditor.UseRightToLeftReadingLayout = false;
            this.scintillaEditor.WrapMode = ScintillaNET.WrapMode.None;
            this.scintillaEditor.Click += new System.EventHandler(this.scintillaEditor_Click);
            // 
            // btnSalvarAsm
            // 
            this.btnSalvarAsm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnSalvarAsm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarAsm.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvarAsm.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSalvarAsm.Location = new System.Drawing.Point(1558, 42);
            this.btnSalvarAsm.Name = "btnSalvarAsm";
            this.btnSalvarAsm.Size = new System.Drawing.Size(164, 31);
            this.btnSalvarAsm.TabIndex = 127;
            this.btnSalvarAsm.Text = "Salvar .ASM";
            this.btnSalvarAsm.UseVisualStyleBackColor = false;
            this.btnSalvarAsm.Click += new System.EventHandler(this.BtnSalvarAsm_Click);
            // 
            // btnSalvarAsmComo
            // 
            this.btnSalvarAsmComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnSalvarAsmComo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarAsmComo.Font = new System.Drawing.Font("Co Headline", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvarAsmComo.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSalvarAsmComo.Location = new System.Drawing.Point(1728, 42);
            this.btnSalvarAsmComo.Name = "btnSalvarAsmComo";
            this.btnSalvarAsmComo.Size = new System.Drawing.Size(171, 31);
            this.btnSalvarAsmComo.TabIndex = 128;
            this.btnSalvarAsmComo.Text = "Salvar .ASM Como";
            this.btnSalvarAsmComo.UseVisualStyleBackColor = false;
            this.btnSalvarAsmComo.Click += new System.EventHandler(this.BtnSalvarAsmComo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1907, 990);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.pictureBoxMovel);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnExportPng);
            this.Controls.Add(this.btnNovoProjeto);
            this.Controls.Add(this.btnCarregarConfiguracao);
            this.Controls.Add(this.btnGravarConfiguracoes);
            this.Controls.Add(this.btnSalvarScriptTraduzido);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.POSICAO_TELA);
            this.Controls.Add(this.txtPreviewLabel);
            this.Controls.Add(this.txtRenderTextLabel);
            this.Controls.Add(this.txtTranslatedTextLabel);
            this.Controls.Add(this.txtOriginalTextLabel);
            this.Controls.Add(this.btnLoadReferenceImage);
            this.Controls.Add(this.btnLoadTable);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.txtOriginalText);
            this.Controls.Add(this.picTranslatedImage);
            this.Controls.Add(this.texto_renderizado_para_exportar);
            this.Controls.Add(this.btnCorDeFundo);
            this.Controls.Add(this.comboBoxCodecs);
            this.Controls.Add(this.btnExportarCodec);
            this.Controls.Add(this.numericWidth);
            this.Controls.Add(this.numericHeight);
            this.Controls.Add(this.numericHorizontalOffset);
            this.Controls.Add(this.numericVerticalOffset);
            this.Controls.Add(this.numericTextHorizontalOffset);
            this.Controls.Add(this.numericTextVerticalOffset);
            this.Controls.Add(this.numericSelectedLine);
            this.Controls.Add(this.numericLineHeight);
            this.Controls.Add(this.comboBoxDimensoes);
            this.Controls.Add(this.txtTranslatedText);
            this.Controls.Add(this.btnTranslateWithGoogle);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.comboBoxScripts);
            this.Controls.Add(this.btnSelectTranslatedFolder);
            this.Controls.Add(this.comboBoxTranslatedScripts);
            this.Controls.Add(this.btnLoadFolder);
            this.Controls.Add(this.treeViewFiles);
            this.Controls.Add(this.scintillaEditor);
            this.Controls.Add(this.btnSalvarAsm);
            this.Controls.Add(this.btnSalvarAsmComo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RTX Translation Tool";
            ((System.ComponentModel.ISupportInitialize)(this.numericTextHorizontalOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTextVerticalOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSelectedLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texto_renderizado_para_exportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizontalOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVerticalOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslatedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnExportPng;
        private System.Windows.Forms.Button btnLoadReferenceImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnLoadTable;
        private System.Windows.Forms.TextBox POSICAO_TELA;
        private TextBox textBox2;
        private TextBox textBox4;
        private PictureBox texto_renderizado_para_exportar;
        private ListBox listBox1;
        private TextBox textBox23;
        private ListBox listBox2;
        private TextBox textBox1;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private ComboBox comboBox2;
        private TextBox textBox19;
        private ComboBox comboBox3;
        private TextBox textBox20;
        private ComboBox comboBox4;
        private TextBox textBox21;
        private TextBox textBox22;
        private ComboBox comboBox5;
        private TextBox textBox24;
        private ComboBox comboBox6;
        private TextBox textBox25;
        private ComboBox comboBox7;
        private TextBox textBox26;
        private ComboBox comboBox1;
        private TextBox textBox27;
        private TextBox textBox28;
    }
}
