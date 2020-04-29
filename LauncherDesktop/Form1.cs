using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LauncherDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Global vars
        ListBox mylist = new ListBox();
        string result = string.Empty;
        bool change = false;
        string myFile = Application.StartupPath + "\\lista.txt";
        string Ver = "20.04.29";
        string TitleProgram = string.Empty;
        public class IconExtractor
        {
            [DllImport("shell32.dll", EntryPoint = "ExtractIconEx")]
            public static extern int ExtractIconExA(string lpszFile, int nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, int nIcons);

            [DllImport("user32")]
            private static extern int DestroyIcon(IntPtr hIcon);

            //Attempts to extract the small-version of the applicaiton's icon
            public static Icon ExtractIconSmall(string path)
            {
                IntPtr largeIcon = IntPtr.Zero;
                IntPtr smallIcon = IntPtr.Zero;
                ExtractIconExA(path, 0, ref largeIcon, ref smallIcon, 1);

                //Transform the bits into the icon image
                Icon returnIcon = null;
                if (smallIcon != IntPtr.Zero)
                    returnIcon = Icon.FromHandle(smallIcon);

                //clean up
                DestroyIcon(largeIcon);

                return returnIcon;
            }

            //Attempts to extract the large-version of the application's icon
            public static Icon ExtractIconLarge(string path)
            {
                IntPtr largeIcon = IntPtr.Zero;
                IntPtr smallIcon = IntPtr.Zero;
                ExtractIconExA(path, 0, ref largeIcon, ref smallIcon, 1);

                //Transform the bits into the icon image
                Icon returnIcon = null;
                if (largeIcon != IntPtr.Zero)
                    returnIcon = Icon.FromHandle(largeIcon);

                //clean up
                DestroyIcon(smallIcon);

                return returnIcon;
            }

            //Returns the large icon if found, if not the small icon
            public static Icon ExtractIcon(string path)
            {
                Icon largeIcon = ExtractIconLarge(path);

                if (largeIcon == null)
                    return ExtractIconSmall(path);
                else
                    return largeIcon;
            }
        }

        void AddFile(string filename)
        {
            string type = string.Empty;
            type = Path.GetExtension(filename);
            result = Path.GetFileNameWithoutExtension(filename);
            mylist.Items.Add(filename);
            if (type == ".exe")
            {
                Icon largeIcon = IconExtractor.ExtractIconLarge(filename);
                lista_icons.Images.Add(largeIcon.ToBitmap());
                listitens.Items.Add(result, lista_icons.Images.Count - 1);
                listitens.Items[listitens.Items.Count - 1].Group = listitens.Groups[0];
            }
            else
            {
                listitens.Items.Add(result, 0);
                listitens.Items[listitens.Items.Count - 1].Group = listitens.Groups[1];
            }

        }
        void OpenDirFile()
        {
            int indexforfile = listitens.SelectedIndices[0];
            mylist.SelectedIndex = indexforfile;
            string pasta = Path.GetDirectoryName(mylist.SelectedItem.ToString());
            System.Diagnostics.Process.Start(pasta);
        }
        void Run(bool adm)
        {
            int indexlist = listitens.SelectedIndices[0];
            mylist.SelectedIndex = indexlist;
            string arquivo = mylist.SelectedItem.ToString();
            string caminho = Path.GetDirectoryName(arquivo);
            string nome = Path.GetFileName(arquivo);
            var processInfo = new System.Diagnostics.ProcessStartInfo();
            if (adm)
            {
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
            }
            processInfo.WorkingDirectory = caminho;
            processInfo.FileName = nome;
            try
            {
                System.Diagnostics.Process.Start(processInfo);
            }
            catch
            {
                // Sem permissao
            }
        }
        void Remove()
        {
            try
            {
                int val = listitens.SelectedIndices[0];
                mylist.Items.RemoveAt(val);
                listitens.Items.RemoveAt(val);
            }
            catch { MessageBox.Show("Erro ao remover", "Nada selecionado eu acho"); }
        }
        void clearAll()
        {
            listitens.Clear();
            mylist.Items.Clear();
            Image defaulticon = lista_icons.Images[0];
            lista_icons.Images.Clear();
            lista_icons.Images.Add(defaulticon);
        }
        void SaveList()
        {
            System.IO.File.WriteAllLines(myFile, mylist.Items.OfType<string>().ToArray());
            change = false;
        }
        void loadFile()
        {

            if (File.Exists(myFile))
            {
                string[] lines = System.IO.File.ReadAllLines(myFile);
                foreach (string line in lines)
                {
                    mylist.Items.Add(line);
                    string type = Path.GetExtension(line);
                    result = Path.GetFileNameWithoutExtension(line);
                    if (type == ".exe" || type == ".EXE")
                    {
                        Icon largeIcon = IconExtractor.ExtractIconLarge(line);
                        lista_icons.Images.Add(largeIcon.ToBitmap());
                        listitens.Items.Add(result, (lista_icons.Images.Count - 1));
                        listitens.Items[listitens.Items.Count - 1].Group = listitens.Groups[0];
                    }
                    else
                    {
                        listitens.Items.Add(result, 0);
                        listitens.Items[listitens.Items.Count - 1].Group = listitens.Groups[1];
                    }

                }

            }
        }
        void changueItens()
        {
            this.Text = TitleProgram + "*";
            change = true;
        }
        void questionHide()
        {
            var ButtonsResult = MessageBox.Show("Deseja Esconder?", "Hide me", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ButtonsResult == DialogResult.Yes)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }
        bool verChange()
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
                        if (string.Compare(version, Ver) != 0)
                        {
                            return true;


                        }
                        break;

                    }

                }


            }
            return false;

        }


        private void listItens_DragDrop(object sender, DragEventArgs e)
        {
            string filename = string.Empty;
            string[] arquivos = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (arquivos != null && arquivos.Any())
                filename = arquivos.First();

            AddFile(filename);
            changueItens();
        }

        private void listItens_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void adicionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            string filename;
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                filename = abrir.FileName;
                AddFile(filename);
                changueItens();
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listitens_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void abrirLocalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDirFile();
            }
            catch
            {

            }

        }

        private void abrirLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDirFile();
            }
            catch
            {

            }
        }

        private void listitens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listitens.SelectedItems.Count > 0)
                {
                    Run(false);
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                Remove();
                changueItens();
            }
        }

        //Tipos de lista
        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listitens.View = View.SmallIcon;
        }

        private void detalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.Details;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.List;
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.Tile;
        }

        private void removerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Remove();
            changueItens();
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
            changueItens();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run(false);
            questionHide();
        }

        private void abrirComoAdmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run(true);
            questionHide();
        }

        private void listitens_DoubleClick(object sender, EventArgs e)
        {
            Run(false);
            questionHide();

        }

        private void limparListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();
            changueItens();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TitleProgram = this.Text + " v" + Ver;
            this.Text = TitleProgram;
            loadFile();
            inicializarComOOSToolStripMenuItem.Checked = Properties.Settings.Default.autoIni;
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            if (change)
            {
                var ButtonResult = MessageBox.Show("Existe alteração, deseja salvar?", "Alteração",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (ButtonResult == DialogResult.Yes)
                    SaveList();
              
            }
           
        }
       

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void esconderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
            }

        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            { notifyIcon1.Visible = false; }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        { }

        private void abrirListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(myFile);
        }

        private void salvarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveList();
        }

        private void inicializarComOOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inicializarComOOSToolStripMenuItem.Checked)
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.SetValue("LauncherApps", "\"" + Application.ExecutablePath + "\"");
                        Properties.Settings.Default.autoIni = true;

                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possivel adicionar tente novamente executando como administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.DeleteValue("LauncherApps", false);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        private void sobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("\tCriado por Sr.Shadowy @2016 @2020" + Environment.NewLine +
                "\t\tVer " + Ver + Environment.NewLine + "APP LAUNCHER inspirado e construido graças ao Smoll_iCe", "Sobre...");

        }

        private void verificarUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (verChange())
            {
                var butonsResult = MessageBox.Show("Existe uma nova versão deseja baixar?", "Nova versão disponivel", MessageBoxButtons.YesNo);
                if (butonsResult == DialogResult.Yes)
                {
                    Process.Start("https://github.com/SrShadowy/AppLauncher/releases");
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel ou você está usando a versão atual.", "versão");
            }
        }
    }
}
