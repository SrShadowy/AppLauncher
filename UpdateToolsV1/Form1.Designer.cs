namespace UpdateToolsv1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_site = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_info = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(136, 76);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(181, 42);
            this.btn_update.TabIndex = 0;
            this.btn_update.Text = "Fecha e abrir nova versão";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // btn_site
            // 
            this.btn_site.Location = new System.Drawing.Point(12, 76);
            this.btn_site.Name = "btn_site";
            this.btn_site.Size = new System.Drawing.Size(118, 42);
            this.btn_site.TabIndex = 1;
            this.btn_site.Text = "Abrir site";
            this.btn_site.UseVisualStyleBackColor = true;
            this.btn_site.Visible = false;
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(325, 76);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(118, 42);
            this.btn_down.TabIndex = 2;
            this.btn_down.Text = "Tenta download novamente";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(431, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(12, 48);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(103, 13);
            this.lbl_info.TabIndex = 4;
            this.lbl_info.Text = "Obtendo informação";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(317, 48);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Restaurar versão anterior";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 131);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_site);
            this.Controls.Add(this.btn_update);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "UPDATE TOOLS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_site;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

