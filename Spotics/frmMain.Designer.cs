namespace Spotics
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.labelAtualmente = new System.Windows.Forms.Label();
            this.labelTocando = new System.Windows.Forms.Label();
            this.buttonTocando = new System.Windows.Forms.Button();
            this.textBoxLetra = new System.Windows.Forms.TextBox();
            this.buttonCarregar = new System.Windows.Forms.Button();
            this.buttonMais = new System.Windows.Forms.Button();
            this.buttonMenos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAtualmente
            // 
            this.labelAtualmente.AutoSize = true;
            this.labelAtualmente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtualmente.Location = new System.Drawing.Point(15, 20);
            this.labelAtualmente.Name = "labelAtualmente";
            this.labelAtualmente.Size = new System.Drawing.Size(147, 18);
            this.labelAtualmente.TabIndex = 0;
            this.labelAtualmente.Text = "Tocando atualmente:";
            // 
            // labelTocando
            // 
            this.labelTocando.Location = new System.Drawing.Point(168, 24);
            this.labelTocando.Name = "labelTocando";
            this.labelTocando.Size = new System.Drawing.Size(253, 13);
            this.labelTocando.TabIndex = 1;
            // 
            // buttonTocando
            // 
            this.buttonTocando.Location = new System.Drawing.Point(16, 50);
            this.buttonTocando.Name = "buttonTocando";
            this.buttonTocando.Size = new System.Drawing.Size(65, 23);
            this.buttonTocando.TabIndex = 2;
            this.buttonTocando.Text = "Atualizar";
            this.buttonTocando.UseVisualStyleBackColor = true;
            this.buttonTocando.Click += new System.EventHandler(this.ButtonTocando_Click);
            // 
            // textBoxLetra
            // 
            this.textBoxLetra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLetra.Location = new System.Drawing.Point(16, 89);
            this.textBoxLetra.Multiline = true;
            this.textBoxLetra.Name = "textBoxLetra";
            this.textBoxLetra.ReadOnly = true;
            this.textBoxLetra.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLetra.Size = new System.Drawing.Size(405, 327);
            this.textBoxLetra.TabIndex = 3;
            // 
            // buttonCarregar
            // 
            this.buttonCarregar.Location = new System.Drawing.Point(87, 50);
            this.buttonCarregar.Name = "buttonCarregar";
            this.buttonCarregar.Size = new System.Drawing.Size(75, 23);
            this.buttonCarregar.TabIndex = 4;
            this.buttonCarregar.Text = "Carregar";
            this.buttonCarregar.UseVisualStyleBackColor = true;
            this.buttonCarregar.Click += new System.EventHandler(this.ButtonCarregar_Click);
            // 
            // buttonMais
            // 
            this.buttonMais.Location = new System.Drawing.Point(354, 49);
            this.buttonMais.Name = "buttonMais";
            this.buttonMais.Size = new System.Drawing.Size(31, 23);
            this.buttonMais.TabIndex = 5;
            this.buttonMais.Text = "+";
            this.buttonMais.UseVisualStyleBackColor = true;
            this.buttonMais.Click += new System.EventHandler(this.ButtonMais_Click);
            // 
            // buttonMenos
            // 
            this.buttonMenos.Location = new System.Drawing.Point(391, 49);
            this.buttonMenos.Name = "buttonMenos";
            this.buttonMenos.Size = new System.Drawing.Size(30, 23);
            this.buttonMenos.TabIndex = 6;
            this.buttonMenos.Text = "-";
            this.buttonMenos.UseVisualStyleBackColor = true;
            this.buttonMenos.Click += new System.EventHandler(this.ButtonMenos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desenvolvido por Alcides Dias";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 470);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMenos);
            this.Controls.Add(this.buttonMais);
            this.Controls.Add(this.buttonCarregar);
            this.Controls.Add(this.textBoxLetra);
            this.Controls.Add(this.buttonTocando);
            this.Controls.Add(this.labelTocando);
            this.Controls.Add(this.labelAtualmente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAtualmente;
        private System.Windows.Forms.Label labelTocando;
        private System.Windows.Forms.Button buttonTocando;
        private System.Windows.Forms.TextBox textBoxLetra;
        private System.Windows.Forms.Button buttonCarregar;
        private System.Windows.Forms.Button buttonMais;
        private System.Windows.Forms.Button buttonMenos;
        private System.Windows.Forms.Label label1;
    }
}

