namespace LauncherDesktop
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_info = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_closeAll = new System.Windows.Forms.Button();
            this.btn_site = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 28);
            this.progressBar1.TabIndex = 0;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(12, 43);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(124, 13);
            this.lbl_info.TabIndex = 2;
            this.lbl_info.Text = "Preciso obter informação";
            // 
            // btn_download
            // 
            this.btn_download.Enabled = false;
            this.btn_download.Location = new System.Drawing.Point(345, 57);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(162, 42);
            this.btn_download.TabIndex = 3;
            this.btn_download.Text = "Tentar baixar novamente";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Visible = false;
            this.btn_download.Click += new System.EventHandler(this.Btn_download_Click);
            // 
            // btn_closeAll
            // 
            this.btn_closeAll.Enabled = false;
            this.btn_closeAll.Location = new System.Drawing.Point(152, 57);
            this.btn_closeAll.Name = "btn_closeAll";
            this.btn_closeAll.Size = new System.Drawing.Size(187, 42);
            this.btn_closeAll.TabIndex = 4;
            this.btn_closeAll.Text = "Fecha tudo e abrir a nova Versão";
            this.btn_closeAll.UseVisualStyleBackColor = true;
            this.btn_closeAll.Visible = false;
            this.btn_closeAll.Click += new System.EventHandler(this.Btn_closeAll_Click);
            // 
            // btn_site
            // 
            this.btn_site.Location = new System.Drawing.Point(12, 59);
            this.btn_site.Name = "btn_site";
            this.btn_site.Size = new System.Drawing.Size(134, 42);
            this.btn_site.TabIndex = 5;
            this.btn_site.Text = "Abrir site";
            this.btn_site.UseVisualStyleBackColor = true;
            this.btn_site.Visible = false;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 111);
            this.Controls.Add(this.btn_site);
            this.Controls.Add(this.btn_closeAll);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadForm";
            this.Text = "DOWNLOADED";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_closeAll;
        private System.Windows.Forms.Button btn_site;
    }
}