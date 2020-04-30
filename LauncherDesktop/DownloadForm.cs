using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace LauncherDesktop
{
    public partial class DownloadForm : Form
    {
        readonly Form1 nInformation;
        public DownloadForm(Form1 fm1)
        {
            InitializeComponent();
            nInformation = fm1;
        }
        //informações
        string NewVersion;
        string url;
        string newFile;
        private void DownloadForm_Load(object sender, EventArgs e)
        {
            NewVersion = nInformation.NewVersion;
            newFile = Application.StartupPath + @"\\LauncherDesktop v" + NewVersion + ".exe";
            url = "https://github.com/SrShadowy/AppLauncher/releases/download/v" + NewVersion + "/LauncherDesktop.exe";
            BeginDownload();
        }

        void BeginDownload()
        {
            WebClient downloaded = new WebClient();
            downloaded.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            downloaded.DownloadFileCompleted += new AsyncCompletedEventHandler(ProgressEnd);
            downloaded.DownloadFileAsync(new Uri(url), newFile);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           progressBar1.Value = e.ProgressPercentage;
           this.Text = "fazendo download: " +  ((e.BytesReceived / 1024f)).ToString() + "kb /" + (( e.TotalBytesToReceive  / 1024f)).ToString() + " kb";
        }
        private void ProgressEnd(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                lbl_info.Text = "Concluido você pode fecha essa versão fico obsoleta";
                btn_closeAll.Enabled = true; 
                btn_closeAll.Visible = true;
            }
            catch
            {
                lbl_info.Text = "Ops, algo deu errado, mas você pode tentar denovo, ou ir no site e baixar manualmente ";
                Process.Start("https://github.com/SrShadowy/AppLauncher/releases");
                btn_download.Visible = true;
                btn_site.Visible = true;
            } 
        }
        private void Btn_download_Click(object sender, EventArgs e)
        {
            BeginDownload();
        }

        private void Btn_closeAll_Click(object sender, EventArgs e)
        {
            Process.Start(newFile);
            nInformation.Close();
        }
    }
}
