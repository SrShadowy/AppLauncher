using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace UpdateToolsv1
{
    public partial class fm_update : Form
    {
        readonly string actualVersion = string.Empty;
        string NewVersion;
        string url;
        string newFile;
        public fm_update(string[] args)
        {
            InitializeComponent();

            if (args.Length != 0)
            {

                NewVersion = args[0];
                actualVersion = args[1];
            }

        }

        bool callingArgs()
        {
            //If Launcher Apps oppend he
            if ( string.Compare(  actualVersion, string.Empty) != 0 && string.Compare( NewVersion, string.Empty) != 0)
            {
                newFile = Application.StartupPath + @"\\LauncherDesktop v" + NewVersion + ".exe";
                url = "https://github.com/SrShadowy/AppLauncher/releases/download/v" + NewVersion + "/LauncherDesktop.exe";
                lbl_info.Text = "Versão localizada: " + NewVersion + " Versão que possui " + actualVersion;
                BeginDownload();
                return false;
            }
            else if (File.Exists(Application.StartupPath + @"\dat.bin")) // Else check if file dat exist
            {
                string[] lines = File.ReadAllLines(Application.StartupPath + @"\dat.bin");
                string AcVersion = lines[0];
                string AnotherLine = lines[1];
                lbl_info.Text = "Versão localizada: " + AcVersion + " Versão anterior " + AnotherLine;
                link_Restauration.Visible = true;
                link_update.Visible = true;
                return false;
            }else //If no calling update or file dont exist
            {
                lbl_info.Text = "Não foi possivel obter informações";
                link_update.Visible = true;
                return true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            callingArgs();

        }

        //Controls
        private void btn_down_Click(object sender, EventArgs e)
        {
            BeginDownload();
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {

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
                //Error on rename
            }

            Close();
        }

        //.....Version obsolete link
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\LD.exe.old"))
            {
                var resultdialog = MessageBox.Show("Você tem certeza que deseja retroceder uma versão?", 
                    "Retroceder Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(resultdialog == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Application.StartupPath + "\\LauncherDesktop.exe");
                        File.Move(Application.StartupPath + "\\LD.exe.old", Application.StartupPath + "\\LauncherDesktop.exe");
                        MessageBox.Show("Substituição com sucesso", "Sucesso");
                    }
                    catch
                    {
                        //Error
                    }
                    
                }
            }
        }

        //.....Online verification and replacement
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                        break;
                    }
                }
                newFile = Application.StartupPath + @"\LauncherDesktop v" + NewVersion + ".exe";
                url = "https://github.com/SrShadowy/AppLauncher/releases/download/v" + NewVersion + "/LauncherDesktop.exe";

                lbl_info.Text = "Versão localizada: " + NewVersion;
                if (File.Exists(Application.StartupPath + @"\dat.bin"))
                {
                    string[] lines = File.ReadAllLines(Application.StartupPath + @"\dat.bin");
                    string AnotherLine = lines[1];
                    lbl_info.Text = "Versão localizada: " + NewVersion + " Versão anterior " + AnotherLine;
                    link_Restauration.Visible = true;
                }
                btn_down.Text = "Baixar nova versão";
                btn_down.Visible = true;
            }

        }

        /*DOWNLOAD PROGRESS*/
        void BeginDownload()
        {
            WebClient downloaded = new WebClient();
            downloaded.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            downloaded.DownloadFileCompleted += new AsyncCompletedEventHandler(ProgressEnd);
            downloaded.DownloadFileAsync(new Uri(url), newFile);
        }


        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pb_download.Value = e.ProgressPercentage;
            this.Text = "fazendo download: " + ((e.BytesReceived / 1024f)).ToString() + "kb /" + ((e.TotalBytesToReceive / 1024f)).ToString() + " kb";
        }
        private void ProgressEnd(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                lbl_info.Text = "Concluido você pode fecha essa versão fico obsoleta";
                btn_update.Enabled = true;
                btn_update.Visible = true;

                if (File.Exists(Application.StartupPath + @"\LD.exe.old"))
                    File.Delete(Application.StartupPath + @"\LD.exe.old");
            }
            catch
            {
                lbl_info.Text = "Ops, algo deu errado, mas você pode tentar denovo, ou ir no site e baixar manualmente ";
                Process.Start("https://github.com/SrShadowy/AppLauncher/releases");
                btn_down.Visible = true;
                btn_site.Visible = true;
            }
        }
    }
}
