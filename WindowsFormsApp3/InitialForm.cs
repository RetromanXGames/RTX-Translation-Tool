﻿namespace WindowsFormsApp3
{
    partial class InitialForm
    {
        private System.Windows.Forms.Button btnCarregarConfiguracao; // Add this missing field declaration

        private void InitializeComponent()
        {
            this.btnCarregarConfiguracao = new System.Windows.Forms.Button(); // Initialize the button
            this.btnNovoProjeto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNovoProjeto
            // 
            this.btnNovoProjeto.Location = new System.Drawing.Point(50, 30);
            this.btnNovoProjeto.Name = "btnNovoProjeto";
            this.btnNovoProjeto.Size = new System.Drawing.Size(150, 40);
            this.btnNovoProjeto.TabIndex = 0;
            this.btnNovoProjeto.Text = "Novo Projeto";
            this.btnNovoProjeto.UseVisualStyleBackColor = true;
            this.btnNovoProjeto.Click += new System.EventHandler(this.btnNovoProjeto_Click);
            // 
            // btnCarregarConfiguracao
            // 
            this.btnCarregarConfiguracao.Location = new System.Drawing.Point(50, 80);
            this.btnCarregarConfiguracao.Name = "btnCarregarConfiguracao";
            this.btnCarregarConfiguracao.Size = new System.Drawing.Size(150, 40);
            this.btnCarregarConfiguracao.TabIndex = 1;
            this.btnCarregarConfiguracao.Text = "Carregar Configuração";
            this.btnCarregarConfiguracao.UseVisualStyleBackColor = true;
            this.btnCarregarConfiguracao.Click += new System.EventHandler(this.btnCarregarConfiguracao_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.btnCarregarConfiguracao);
            this.Controls.Add(this.btnNovoProjeto);
            this.Name = "InitialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem-vindo";
            this.ResumeLayout(false);
        }
    }
}
