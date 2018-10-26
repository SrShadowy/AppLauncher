using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
namespace AL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //-----------------Variaveis globais ----------------
        ListBox mylist = new ListBox();
        string result;
        //---------------------------------------------------

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

       private void executar(bool adm)
        {
            int indexlist = listView1.SelectedIndices[0];
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
            catch {
                // Sem permissao
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {    
                string[] x = System.IO.File.ReadAllLines(Application.StartupPath + "\\lista.txt");
                int y = 0;
                for (int i = 1; i <= x.Length; i++)
                {
                    mylist.Items.Add(x[y]);
                    Icon largeIcon = IconExtractor.ExtractIconLarge(x[y]);
                    imageList1.Images.Add(largeIcon.ToBitmap());
                    int index = imageList1.Images.Count - 1;
                    result = Path.GetFileNameWithoutExtension(x[y]);
                    listView1.Items.Add(result, index);
                    y++;
                }
            }
            catch { }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                executar(false);  
            }
            catch
            {
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                executar(false);
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    executar(false);
                }
            }
            if(e.KeyCode == Keys.Delete)
            {
                int val = listView1.SelectedIndices[0];
                mylist.Items.RemoveAt(val);
                listView1.Items.RemoveAt(val);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            executar(false);
        }

        private void executarComoAdminsitradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executar(true);
        }

        private void detalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void iconesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string filename;
            string[] arquivos = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (arquivos != null && arquivos.Any())
            mylist.Items.Add(arquivos.First());
            int max = mylist.Items.Count - 1;
            filename = mylist.Items[max].ToString();
            Icon largeIcon = IconExtractor.ExtractIconLarge(filename);
            MessageBox.Show(filename, "Arquivo adicionado");
            imageList1.Images.Add(largeIcon.ToBitmap());
            int index = imageList1.Images.Count - 1;
            listView1.Items.Add(Path.GetFileNameWithoutExtension(arquivos.First().ToString()), index);
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + "\\lista.txt");
                for (int i = 0; i <= mylist.Items.Count; i++)
                {
                    var x = File.AppendText(Application.StartupPath + "\\lista.txt");
                    x.WriteLine(mylist.Items[i]);
                    x.Close();
                }
            }
            catch { }
        }

        private void abrirLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indexforfile = listView1.SelectedIndices[0];
            mylist.SelectedIndex = indexforfile;
            string pasta = Path.GetDirectoryName(mylist.SelectedItem.ToString());
            System.Diagnostics.Process.Start(pasta);
        }

        private void explorarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int indexforfile = listView1.SelectedIndices[0];
                mylist.SelectedIndex = indexforfile;
                string pasta = Path.GetDirectoryName(mylist.SelectedItem.ToString());
                System.Diagnostics.Process.Start(pasta);
            }
            catch {
                //Nenhum item selecionado
            }
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            string filename;
           if( abrir.ShowDialog() == DialogResult.OK)
            {
                filename = abrir.FileName;
                Icon largeIcon = IconExtractor.ExtractIconLarge(filename);
                imageList1.Images.Add(largeIcon.ToBitmap());
                result = Path.GetFileNameWithoutExtension(filename);
                mylist.Items.Add(filename);
                listView1.Items.Add(result, imageList1.Images.Count - 1);
            }
        }

        private void limparListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mylist.Items.Clear();
            listView1.Clear();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int val = listView1.SelectedIndices[0];
                mylist.Items.RemoveAt(val);
                listView1.Items.RemoveAt(val);
            }
            catch { MessageBox.Show("Erro ao remover", "Erros e Erros..."); }
        }

        private void sobreOProgramarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa criado em 26 de outubro 2018 applaucher", "sobre");
        }

        private void apagarItemDaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int val = listView1.SelectedIndices[0];
            mylist.Items.RemoveAt(val);
            listView1.Items.RemoveAt(val);
        }
    }
}
