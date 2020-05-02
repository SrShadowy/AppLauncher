using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace UpdateToolsv1
{
    public partial class Form1 : Form
    {
        readonly string actualVersion = string.Empty;
        public Form1(string[] args)
        {

            InitializeComponent();

            if (args.Length != 0)
                actualVersion = args[0];
        }
        string NewVersion;
        string url;
        string newFile;

        bool VerChange()
        {
            WebRequest request = WebRequest.Create("https://github.com/SrShadowy/AppLauncher/tags");
            WebResponse response = request.GetResponse();


            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                string[] splitResponse = responseFromServer.Split('<');
                string version;

                foreach (string lines in splitResponse)
                {
                    if (lines.Contains(@"a href=""/SrShadowy/AppLauncher/releases/tag/"))
                    {
                        version = lines.Replace(@"a href=""/SrShadowy/AppLauncher/releases/tag/v", "");
                        version = version.Remove(8);
                        NewVersion = version;
                        return true;
                    }
                }
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckVersions();
            
        }

        void CheckVersions()
        {
            if (File.Exists("dat.bin"))
            {
                string[] lines = File.ReadAllLines("dat.bin");
                NewVersion = lines[0];
                string AnotherLine = lines[1];
                if (string.Compare(NewVersion, actualVersion) == 0)
                {
                    lbl_info.Text = ("Aparentemente você está com a versão atualizada: " + NewVersion + ", " +
               actualVersion);
                    linkLabel1.Visible = true;
                }
                else if (string.Compare(NewVersion, AnotherLine) == 0)
                {
                    lbl_info.Text = ("Aparentemente você está com a versão atualizada: " + NewVersion + ", " +
              actualVersion);
                    linkLabel1.Visible = true;
                }
                else {
                    newFile = Application.StartupPath + @"\\LauncherDesktop v" + NewVersion + ".exe";
                    url = "https://github.com/SrShadowy/AppLauncher/releases/download/v" + NewVersion + "/LauncherDesktop.exe";
                    lbl_info.Text = "Versão localizada: " + NewVersion;
                    BeginDownload();
                }
                   

               
            }
            else if (VerChange())
            {
                newFile = Application.StartupPath + @"\\LauncherDesktop v" + NewVersion + ".exe";
                url = "https://github.com/SrShadowy/AppLauncher/releases/download/v" + NewVersion + "/LauncherDesktop.exe";
                lbl_info.Text = "Versão localizada: " + NewVersion;
            }
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
            this.Text = "fazendo download: " + ((e.BytesReceived / 1024f)).ToString() + "kb /" + ((e.TotalBytesToReceive / 1024f)).ToString() + " kb";
        }
        private void ProgressEnd(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                lbl_info.Text = "Concluido você pode fecha essa versão fico obsoleta";
                btn_update.Enabled = true;
                btn_update.Visible = true;
                if (File.Exists("LD.exe.old"))
                    File.Delete("LD.exe.old");
            }
            catch
            {
                lbl_info.Text = "Ops, algo deu errado, mas você pode tentar denovo, ou ir no site e baixar manualmente ";
                Process.Start("https://github.com/SrShadowy/AppLauncher/releases");
                btn_down.Visible = true;
                btn_site.Visible = true;
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            File.WriteAllText("dat.bin", NewVersion + Environment.NewLine + NewVersion);
            string oldForNewFile = "\\LauncherDesktop.exe";
            Process[] nprocess = Process.GetProcessesByName("LauncherDesktop");
            foreach (Process pc in nprocess)
            {
                pc.Kill();
            }
            try
            {
                File.Move(Application.StartupPath + oldForNewFile, Application.StartupPath + "\\LD.exe.old");
                Thread.Sleep(100);
                File.Move(newFile, Application.StartupPath + oldForNewFile);
                Process.Start(Application.StartupPath + oldForNewFile);
            }
            catch
            {
                //Ocorreu algum erro ao renomeia
            }

            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists("LD.exe.old"))
            {
                var resultdialog = MessageBox.Show("Você tem certeza que deseja retroceder uma versão?", 
                    "Retroceder Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(resultdialog == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Application.StartupPath + "\\LauncherDesktop.exe");
                        File.Move(Application.StartupPath + "\\LD.exe.old", Application.StartupPath + "\\LauncherDesktop.exe");
                    }
                    catch
                    {
                        //Error
                    }
                    

                }

            }
               

        }
    }
}
