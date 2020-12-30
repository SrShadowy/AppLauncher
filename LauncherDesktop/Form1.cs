using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LauncherDesktop
{
    public partial class Form1 : Form
    {
        private readonly KeyboardHotKeys hook = new KeyboardHotKeys();

        public Form1()
        {
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed += Current_KeyPressed;
        }

        //Global vars
        private readonly ListBox mylist = new ListBox();

        private readonly ListBox rename = new ListBox();
        private readonly ListBox ConfigGroups = new ListBox();
        private readonly ListBox ConfigAdmin = new ListBox();
        private readonly ListBox MyGroups = new ListBox();

        private ListBox Macros = new ListBox();
        private ListBox Key_Macros = new ListBox();
        private static KeyboardHotKeys.ModifierKeys mkey = KeyboardHotKeys.ModifierKeys.Control | KeyboardHotKeys.ModifierKeys.Alt;
        private static Keys m_key = Keys.S;

        //Informations
        private bool change = false;

        private string result = string.Empty;
        private string TitleProgram = string.Empty;
        private bool question = false;
        private readonly string myFile = Application.StartupPath + "\\DATA.bin";
        private const string Ver = "20.12.30";
        public string NewVersion = string.Empty;

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

        //InputBox because C# dont have only VB because? I DONT KNOW
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(12, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
                value = textBox.Text;
            else
                value = string.Empty;

            return dialogResult;
        }

        // Macro Editor
        public static DialogResult ShowMacros(string title, ref ListBox Macros)
        {
            Form form = new Form();
            form.TopMost = true;
            ListBox listBox1 = new System.Windows.Forms.ListBox();
            TextBox textBox1 = new System.Windows.Forms.TextBox();
            TextBox textBox2 = new System.Windows.Forms.TextBox();
            Button button1 = new System.Windows.Forms.Button();
            Button button2 = new System.Windows.Forms.Button();
            //
            // listBox1
            //
            listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(425, 303);
            listBox1.SelectedIndexChanged += new System.EventHandler(listBox1_SelectedIndexChanged);

            foreach (string newMacro in Macros.Items)
            {
                listBox1.Items.Add(newMacro);
            }
            //
            // textBox1
            //
            textBox1.Name = "textBox1";
            textBox1.TabIndex = 0;
            textBox1.SetBounds(12, 309, 95, 20);
            //
            // textBox2
            //
            textBox2.Name = "textBox2";
            textBox2.TabIndex = 2;
            textBox2.SetBounds(115, 309, 295, 20);
            //
            // button1
            //
            button1.Location = new System.Drawing.Point(245, 340);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(81, 25);
            button1.TabIndex = 3;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.DialogResult = DialogResult.OK;
            //
            // button2
            //
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new System.Drawing.Point(331, 340);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(81, 25);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.ClientSize = new System.Drawing.Size(425, 366);
            form.Controls.Add(button2);
            form.Controls.Add(button1);
            form.Controls.Add(textBox2);
            form.Controls.Add(textBox1);
            form.Controls.Add(listBox1);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Name = "Form1";
            form.Text = title;

            void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    var abc = listBox1.Items[listBox1.SelectedIndex].ToString();
                    textBox1.Text = abc.Split(' ')[0];
                    textBox2.Text = abc.Remove(0, textBox1.Text.Length + 1);
                }
            }

            form.AcceptButton = button1;

            form.CancelButton = button2;

            var dialogResult = form.ShowDialog();
            if (dialogResult != DialogResult.OK) return dialogResult;

            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items[listBox1.SelectedIndex] = textBox1.Text + ' ' + textBox2.Text;
            }
            Macros = listBox1;

            return dialogResult;
        }

        public struct tkeys
        {
            public Keys x;
            public bool shift;
            public bool control;
            public bool alt;
        }

        // Register Keys?
        public static DialogResult RegisterKeys(KeyboardHotKeys hook, ref ListBox saveThis)
        {
            var form = new Form();
            var btn_ok = new Button();
            var btn_cancel = new Button();
            var pn_blank = new Panel();
            var lb_keys = new Label();
            var btn_Record = new Button();

            //Form
            form.SuspendLayout();
            form.Text = "Editar hotkeys";
            form.ClientSize = new System.Drawing.Size(405, 100);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.TopMost = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.KeyDown += new KeyEventHandler(KeyDown);
            form.KeyUp += new KeyEventHandler(KeyUp);

            var Tkeys = new tkeys();

            void TextKeys(string text, bool incOrDec)
            {
                if (incOrDec)
                {
                    if (lb_keys.Text.Contains(text))
                    {
                        //contnue? or break?
                    }
                    else if (lb_keys.Text.Length > 0)
                    {
                        lb_keys.Text += "+ " + text;
                    }
                    else
                        lb_keys.Text = text;
                }
                else
                {
                    if (lb_keys.Text.Contains(text))
                    {
                        string removeText = lb_keys.Text.Contains("+ " + text) ? lb_keys.Text.Replace("+ " + text, string.Empty) : lb_keys.Text.Replace(text, string.Empty);
                        lb_keys.Text = removeText;
                    }
                }
            }

            void KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.ShiftKey:
                        TextKeys("shift", false);
                        Tkeys.shift = false;
                        break;

                    case Keys.ControlKey:
                        TextKeys("control", false);
                        Tkeys.control = false;
                        break;

                    case Keys.Menu:
                        TextKeys("alt", false);
                        Tkeys.alt = false;
                        break;

                    default:
                        TextKeys(Convert.ToString(e.KeyCode), false);
                        Tkeys.x = 0;
                        break;
                }
            }

            void KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.ShiftKey:
                        Tkeys.shift = true;
                        TextKeys("shift", true);
                        break;

                    case Keys.ControlKey:
                        TextKeys("control", true);
                        Tkeys.control = true;
                        break;

                    case Keys.Menu:
                        TextKeys("alt", true);
                        Tkeys.alt = true;
                        break;

                    default:
                        TextKeys(Convert.ToString(e.KeyCode), true);
                        Tkeys.x = e.KeyCode;
                        break;
                }
            }

            //button OK
            btn_ok.Text = "Ok";
            btn_ok.Location = new Point(10, 70);
            btn_ok.Size = new Size(80, 25);
            btn_ok.Click += new EventHandler(ok_isOk);
            //button Cancel
            btn_cancel.Text = "Cancel";
            btn_cancel.Location = new Point(320, 70);
            btn_cancel.Size = new Size(80, 25);

            //Painel
            pn_blank.Size = new Size(400, 50);
            pn_blank.BackColor = Color.White;
            pn_blank.Location = new Point(12, 12);
            pn_blank.Controls.Add(lb_keys);
            pn_blank.Controls.Add(btn_Record);
            pn_blank.Visible = false;

            //label
            lb_keys.Text = mkey.ToString() + "+" + m_key.ToString();
            lb_keys.AutoSize = true;
            lb_keys.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lb_keys.Location = new Point(7, 7);
            lb_keys.Size = new Size(195, 25);

            //button record
            btn_Record.Text = "Editar macro";
            btn_Record.Location = new Point(275, 10);
            btn_Record.Size = new Size(125, 35);
            btn_Record.Click += new EventHandler(click_record);

            form.Controls.Add(btn_cancel);
            form.Controls.Add(btn_ok);
            form.Controls.Add(pn_blank);
            form.Controls.Add(lb_keys);
            form.Controls.Add(btn_Record);
            form.ResumeLayout(false);

            void click_record(object sender, EventArgs e)
            {
                if (form.KeyPreview)
                {
                    btn_Record.Text = "Editar Tecla";
                    //tm_record.Stop();
                    form.KeyPreview = false;
                }
                else
                {
                    lb_keys.Text = string.Empty;
                    btn_Record.Text = "Parar de gravar";
                    //tm_record.Start();
                    form.KeyPreview = true;
                }
            }

            form.AcceptButton = btn_ok;
            form.CancelButton = btn_cancel;
            var dialogResult = form.ShowDialog();

            void ok_isOk(object sender, EventArgs e)
            {
                form.DialogResult = DialogResult.OK;
            }

            if (dialogResult == DialogResult.OK)
            {
                hook.UnresgistHotKey();

                uint modeKey = 0;
                if (Tkeys.alt)
                    modeKey += 1;
                if (Tkeys.control)
                    modeKey += 2;
                if (Tkeys.shift)
                    modeKey += 4;

                saveThis.Items.Add(Tkeys.x.ToString());
                saveThis.Items.Add(modeKey.ToString());

                if (Tkeys.alt || Tkeys.control || Tkeys.shift)
                    hook.RegisterHotKey((KeyboardHotKeys.ModifierKeys)modeKey, Tkeys.x);
            }

            return dialogResult;
        }

        //Functions
        private void AddFile(string filename)
        {
            result = Path.GetFileNameWithoutExtension(filename);
            mylist.Items.Add(filename);
            Icon largeIcon = IconExtractor.ExtractIconLarge(filename);
            if (largeIcon != null)
            {
                lista_icons.Images.Add(largeIcon.ToBitmap());
                listitens.Items.Add(result, lista_icons.Images.Count - 1);
            }
            else
                listitens.Items.Add(result, 0);
        }

        private void OpenDirFile()
        {
            int indexforfile = listitens.SelectedIndices[0];
            mylist.SelectedIndex = indexforfile;
            string arquivo = mylist.SelectedItem.ToString();
            arquivo = arquivo.Split('|')[0];
            string[] ExistIconEx = arquivo.Split(';');
            arquivo = ExistIconEx[0];
            string pasta = Path.GetDirectoryName(arquivo);
            System.Diagnostics.Process.Start(pasta);
        }

        private void Run(bool adm)
        {
            int indexlist = listitens.SelectedIndices[0];
            mylist.SelectedIndex = indexlist;

            string arquivo = mylist.SelectedItem.ToString();
            string[] ExistIconEx = arquivo.Split(';');
            arquivo = ExistIconEx[0].Split('|')[0];
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
                // don't have permission
            }
        }

        private void Remove()
        {
            try
            {
                var val = listitens.SelectedIndices[0];
                try
                {
                    ConfigGroups.Items.RemoveAt(ConfigGroups.FindString(val.ToString()));
                }
                catch
                {
                    //don't have group
                }
                try
                {
                    ConfigAdmin.Items.RemoveAt(ConfigAdmin.FindString(val.ToString()));
                }
                catch
                {
                    //don't have config admin
                }

                mylist.Items.RemoveAt(val);
                listitens.Items.RemoveAt(val);
            }
            catch { }
        }

        private void ClearAll()
        {
            listitens.Clear();
            mylist.Items.Clear();
            Image defaulticon = lista_icons.Images[0];
            lista_icons.Images.Clear();
            lista_icons.Images.Add(defaulticon);
        }

        private void SaveList()
        {
            Properties.Settings.Default.Save();
            System.IO.File.WriteAllLines(myFile, mylist.Items.OfType<string>().ToArray());
            System.IO.File.AppendAllLines(myFile, MyGroups.Items.OfType<string>().ToArray());
            System.IO.File.AppendAllLines(myFile, ConfigAdmin.Items.OfType<string>().ToArray());
            System.IO.File.AppendAllLines(myFile, ConfigGroups.Items.OfType<string>().ToArray());
            System.IO.File.AppendAllLines(myFile, Macros.Items.OfType<string>().ToArray());
            System.IO.File.AppendAllLines(myFile, Key_Macros.Items.OfType<string>().ToArray());

            this.Text = TitleProgram;
            change = false;
        }

        private void LoadFile(string myFile)
        {
            //Saves
            _ = ConfigGroups.Items.Add("<ITENS_G>");
            _ = ConfigAdmin.Items.Add("<ITENS_C>");
            _ = MyGroups.Items.Add("<GROUPS>");
            _ = Macros.Items.Add("<MACROS>");
            _ = Key_Macros.Items.Add("<K_M>");

            if (File.Exists(myFile))
            {
                bool config_itens = false;
                bool AD_Groups = false;
                bool groups = false;
                bool admins = false;
                bool macros = false;
                bool k_m = false;
                string[] lines = System.IO.File.ReadAllLines(myFile);
                for (int i = 0; i < lines.Count(); ++i)
                {
                    if (string.CompareOrdinal(lines[i], "<GROUPS>") == 0)
                    {
                        AD_Groups = true;
                        continue;
                    }
                    if (string.CompareOrdinal(lines[i], "<ITENS_G>") == 0)
                    {
                        groups = true;
                        AD_Groups = false;
                        continue;
                    }
                    if (string.CompareOrdinal(lines[i], "<ITENS_C>") == 0)
                    {
                        AD_Groups = false;
                        groups = false;
                        admins = true;
                        continue;
                    }
                    if (string.CompareOrdinal(lines[i], "<MACROS>") == 0)
                    {
                        config_itens = false;
                        AD_Groups = false;
                        groups = false;
                        admins = false;
                        macros = true;
                        continue;
                    }
                    if (string.CompareOrdinal(lines[i], "<K_M>") == 0)
                    {
                        k_m = true;
                        continue;
                    }

                    if ((string.CompareOrdinal(lines[i], string.Empty) == 0))
                        continue;

                    if (!groups && !admins && !AD_Groups && !config_itens && !macros)
                    {
                        var FileAndIconEx = lines[i].Split(';');
                        var FileRename = new string[2];
                        FileRename = lines[i].Split('|');
                        if (FileRename.Length > 1)
                        {
                            FileAndIconEx = FileRename[0].Split(';');
                            FileRename[0] = result;
                            result = FileRename[1];
                        }
                        if (!File.Exists(FileAndIconEx[0]))
                        {
                            wARNINGToolStripMenuItem.Visible = true;

                            MessageBox.Show(FileAndIconEx[0]);
                            wARNINGToolStripMenuItem.DropDownItems.Add(FileAndIconEx[0]);
                            continue;
                        }
                        mylist.Items.Add(lines[i]);

                        Icon largeIcon = null;

                        if (FileRename.Length > 1)
                            result = Path.GetFileNameWithoutExtension(FileRename[1]);
                        else
                            result = Path.GetFileNameWithoutExtension(FileAndIconEx[0]);

                        if (FileAndIconEx.Length > 1)
                            largeIcon = IconExtractor.ExtractIconLarge(FileAndIconEx[1]);
                        else
                            largeIcon = IconExtractor.ExtractIconLarge(lines[i].Split('|')[0]); // if does have or not

                        if (largeIcon != null)
                        {
                            lista_icons.Images.Add(largeIcon.ToBitmap());
                            listitens.Items.Add(result, (lista_icons.Images.Count - 1));
                        }
                        else
                            listitens.Items.Add(result, 0);

                        //result = FileRename[0];
                    }
                    else if (AD_Groups)
                    {
                        var header = lines[i];
                        if (string.CompareOrdinal(header, "''") != 0)
                        {
                            var newgroups = new ListViewGroup
                            {
                                Header = header,
                                HeaderAlignment = HorizontalAlignment.Center
                            };

                            MyGroups.Items.Add(header);
                            listitens.Groups.Add(newgroups);
                            (cms_viewer.Items[4] as ToolStripMenuItem).DropDownItems.Add(header);
                            removerGrupoToolStripMenuItem.DropDownItems.Add(header);

                            /* ADD ON CONTEXT MENU GROUPS AND FUNCTION */
                            cm_itens.Items.Add(header);
                            (cm_itens.Items[cm_itens.Items.Count - 1] as ToolStripMenuItem).DropDownItemClicked += cm_itemsDropItems;
                        }
                    }
                    else if (groups)
                    {
                        try
                        {
                            string[] file_groups = new string[2];
                            ConfigGroups.Items.Add(lines[i]);
                            file_groups = lines[i].Split(':');
                            for (int x = 0; x < listitens.Groups.Count; ++x)
                            {
                                if (string.Compare(listitens.Groups[x].Header, file_groups[1]) == 0)
                                {
                                    int ItemTextIndex = listitens.Items.IndexOf(listitens.FindItemWithText(file_groups[0]));
                                    //int ItemTextIndex = listitens.Items.IndexOf(listitens.FindItemWithText(file_groups[0]));
                                    listitens.Items[ItemTextIndex].Group = listitens.Groups[x];

                                    /* ADD ON CONTEXT GROUPS ITEMS */
                                    (cm_itens.Items[x] as ToolStripMenuItem).DropDownItems.Add(file_groups[0],
                                        lista_icons.Images[listitens.Items[ItemTextIndex].ImageIndex]);
                                }
                            }
                        }
                        catch { }
                    }
                    else if (admins)
                    {
                        try
                        {
                            ConfigAdmin.Items.Add(lines[i]);
                            var file_admin = lines[i].Split(':');
                            listitens.Items[listitens.Items.IndexOf(
                                listitens.FindItemWithText(file_admin[0]))].ForeColor = Color.Green;
                            listitens.Items[listitens.Items.IndexOf(
                                listitens.FindItemWithText(file_admin[0]))].Checked = true;
                        }
                        catch
                        { }
                    }
                    else if (macros)
                    {
                        try
                        {
                            if (k_m)
                            {
                                Key_Macros.Items.Add(lines[i]);
                                uint ts_key = 0;
                                char c_key;
                                c_key = lines[i].ToCharArray()[0];
                                bool convert = uint.TryParse(lines[i], out ts_key);

                                if (convert)
                                    mkey = (KeyboardHotKeys.ModifierKeys)ts_key;
                                else if (c_key != 0)
                                    m_key = (Keys)c_key;
                            }
                            else
                                Macros.Items.Add(lines[i]);
                        }
                        catch { }
                    }
                }
            }

            var dft = true;
            for (int itemIndex = 0; itemIndex < listitens.Items.Count; ++itemIndex)
            {
                if (listitens.Items[itemIndex].Group != null) continue;
                //if exit default add
                if (dft)
                {
                    dft = false;
                    cm_itens.Items.Add("Default");
                }
                // add itens on default
                (cm_itens.Items[cm_itens.Items.Count - 1] as ToolStripMenuItem).DropDownItems.Add(listitens.Items[itemIndex].Text,
                    lista_icons.Images[listitens.Items[itemIndex].ImageIndex]);
            }
            hook.RegisterHotKey(mkey, m_key);
            cm_itens.Items.Add("Sair");
        }

        private void ChangueItens()
        {
            this.Text = TitleProgram + "*";
            change = true;
        }

        private void QuestionHide()
        {
            if (!question)
            {
                question = true;
                var ButtonsResult = MessageBox.Show("Deseja Esconder?", "Hide me", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ButtonsResult == DialogResult.Yes)
                    escondeAoAbrirAlgoToolStripMenuItem.Checked = true;
            }
            if (escondeAoAbrirAlgoToolStripMenuItem.Checked)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private bool VerChange()
        {
            var request = WebRequest.Create("https://github.com/SrShadowy/AppLauncher/tags");
            var response = request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                var splitResponse = responseFromServer.Split('<');
                string version;

                foreach (string lines in splitResponse)
                {
                    if (lines.Contains(@"a href=""/SrShadowy/AppLauncher/releases/tag/"))
                    {
                        version = lines.Replace(@"a href=""/SrShadowy/AppLauncher/releases/tag/v", "");
                        version = version.Remove(8);
                        if (string.CompareOrdinal(version, Ver) == 0)
                        {
                            NewVersion = version;
                            return false;
                        }
                        else if (string.CompareOrdinal(version, Ver) != 0)
                        {
                            NewVersion = version;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private int find_string(string txt, ListBox search)
        {
            for (int i = 0; i < search.Items.Count; ++i)
            {
                var lbString = search.Items[i].ToString();
                if (lbString.Contains(txt))
                    return i;
            }
            return ListBox.NoMatches;
        }

        private void ChangeGroup(string newGroup)
        {
            var itemIndex = listitens.Items.IndexOf(listitens.SelectedItems[0]);
            int removeAt = find_string(listitens.Items[itemIndex].Text, ConfigGroups);
            while (removeAt != ListBox.NoMatches)
            {
                ConfigGroups.Items.RemoveAt(removeAt);
                removeAt = find_string(listitens.Items[itemIndex].Text, ConfigGroups);
            }
            ConfigGroups.Items.Add(newGroup);
        }

        private void RemoveGroup(int index)
        {
            for (int x = 0; x < listitens.Groups.Count; ++x)
            {
                MessageBox.Show(MyGroups.Items[index + 1].ToString());
                if (string.CompareOrdinal(listitens.Groups[x].Header, MyGroups.Items[index + 1].ToString()) == 0)
                {
                    listitens.Groups.RemoveAt(x);
                    break;
                }
            }
            MyGroups.Items.RemoveAt(index + 1);
            moverParaOGrupoToolStripMenuItem.DropDownItems.RemoveAt(index);
            removerGrupoToolStripMenuItem.DropDownItems.RemoveAt(index);
        }

        private void Pesquisa()
        {
            if (this.MinimizeBox)
                WindowState = FormWindowState.Normal;

            if (!this.Focused)
            {
                this.TopMost = true;
                this.TopMost = false;
            }

            string Seach = string.Empty;
            if (DialogResult.OK == InputBox("Pesquisar", "Digite [MACRO] [OQUE QUERO]", ref Seach))
            {
                if (Seach.Split(' ').Length > 1)
                {
                    string getArg = Seach.Split(' ')[0];

                    Seach = Seach.Remove(0, getArg.Length + 1);

                    foreach (string ps in Macros.Items)
                    {
                        if (ps.Contains(getArg))
                        {
                            Seach = ps.Remove(0, getArg.Length + 1) + Seach;
                            Process.Start(Seach);
                            WindowState = FormWindowState.Minimized;
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Use a seguinte sintaxy [MACRO] [OQUE QUER PESQUISAR] exemplo: '-google bolas de futebool'", "Sintaxy incorreta");
            }
        }

        private void Current_KeyPressed(object sender, KeyboardHotKeys.KeyPressedEventArgs e)
        {
            Pesquisa();
        }

        // ***** ANYWAY FUNCTIONS ************
        private DateTime _lastCheckTime = DateTime.Now;

        private double _frameCount = 0;

        // called every once in a while
        private double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            double count = Interlocked.Exchange(ref _frameCount, 10);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
        }

        //Lists
        private void ListItens_DragDrop(object sender, DragEventArgs e)
        {
            string filename = string.Empty;
            if (e.Data.GetData(DataFormats.FileDrop) is string[] arquivos && arquivos.Any())
                filename = arquivos.First();

            AddFile(filename);
            ChangueItens();
        }

        private void ListItens_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void AdicionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            string filename;
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                filename = abrir.FileName;
                AddFile(filename);
                ChangueItens();
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Listitens_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_viewer.Show(Cursor.Position);
            }
        }

        private void AbrirLocalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDirFile();
            }
            catch
            {
            }
        }

        private void AbrirLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDirFile();
            }
            catch
            {
            }
        }

        private void Listitens_KeyDown(object sender, KeyEventArgs e)
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
                ChangueItens();
            }
        }

        //types of list
        private void SmallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.LargeIcon;
        }

        private void SmallIconsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listitens.View = View.SmallIcon;
        }

        private void DetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.Details;
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.List;
        }

        private void TitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listitens.View = View.Tile;
        }

        private void RemoverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Remove();
            ChangueItens();
        }

        private void RemoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
            ChangueItens();
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run(false);
            QuestionHide();
        }

        private void AbrirComoAdmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run(true);
            QuestionHide();
        }

        private void Listitens_DoubleClick(object sender, EventArgs e)
        {
            Run(listitens.Items[listitens.Items.IndexOf(listitens.SelectedItems[0])].Checked);
            QuestionHide();
        }

        private void LimparListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
            ChangueItens();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath)).Length > 1)
            {
                MessageBox.Show("Não pode mais de um APPLAUNCHER aberto!");
                Close();
            }

            TitleProgram = this.Text + " v" + Ver;
            this.Text = TitleProgram;

            //Joken
            if (DateTime.Today.Day == 1 && DateTime.Today.Month == 4)
            {
                MessageBox.Show("Sua licença fico obsoleta porfavor atualize a licença do nosso programa", "licença expirou",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                var key = string.Empty;
                var Resolt = InputBox("INSIRA A KEY", "Insira o codigo da key:", ref key);
                if (Resolt == DialogResult.OK)
                {
                    MessageBox.Show("LICENÇA INVALIDA!");
                }
                this.Text += " =*EXPIRADO!*= ";
            }

            LoadFile(myFile);
            using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                var KeyOsInicialization = key.GetValue("LauncherApps");
                inicializarComOOSToolStripMenuItem.Checked = (KeyOsInicialization != null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (change)
            {
                var ButtonResult = MessageBox.Show("Existe alteração, deseja salvar?", "Alteração",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (ButtonResult == DialogResult.Yes)
                    SaveList();
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowDialog();
            WindowState = FormWindowState.Normal;
            Focus();
        }

        private void EsconderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Estamos aqui na barra basta clica para abrir novamente :)";
            notifyIcon1.ShowBalloonTip(1);
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
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

        private void AbrirListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(myFile))
                Process.Start("notepad", myFile);
        }

        private void SalvarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveList();
        }

        private void InicializarComOOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inicializarComOOSToolStripMenuItem.Checked)
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.SetValue("LauncherApps", "\"" + Application.ExecutablePath + "\"");
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

        private void SobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("\tCriado por Sr.Shadowy @2016 @2020" + Environment.NewLine +
                "\t\tVer " + Ver + Environment.NewLine + "APP LAUNCHER inspirado e construido graças ao Smoll_iCe", "Sobre...");
        }

        private void VerificarUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerChange())
            {
                var butonsResult = MessageBox.Show("Existe uma nova versão deseja baixar?", "Nova versão disponivel", MessageBoxButtons.YesNo);
                if (butonsResult == DialogResult.Yes)
                {
                    File.WriteAllText(Application.StartupPath + @"\dat.bin", NewVersion + Environment.NewLine + Ver);
                    if (File.Exists(Application.StartupPath + @"\update.exe"))
                    {
                        var processInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = (Application.StartupPath + @"\update.exe"),
                            UseShellExecute = true,
                            Verb = "runas",
                            Arguments = NewVersion + ' ' + Ver
                        };
                        Process.Start(processInfo);
                    }
                    else
                    {
                        Process.Start("https://github.com/SrShadowy/AppLauncher/releases/");
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel ou você está usando a versão atual.", "versão");
                File.WriteAllText("dat.bin", NewVersion + Environment.NewLine + NewVersion);
            }
        }

        private void Cm_itens_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.CompareOrdinal("Sair", e.ClickedItem.Text) == 0)
            {
                Close();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            /* if (WindowState == FormWindowState.Minimized)
            {
            }*/
        }

        private void cm_itemsDropItems(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show(e.ClickedItem.Text);
            var index = listitens.Items.IndexOf(listitens.FindItemWithText(e.ClickedItem.Text));
            try
            {
                listitens.Items[index].Selected = true;
                Run(false);
            }
            catch
            {
            }
            cm_itens.Close();
        }

        private void AdicionarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = string.Empty;

            var NewGroup = new ListViewGroup();

            var resultDialog = InputBox("Novo grupo", "Insira o nome do grupo", ref x);
            if (resultDialog == DialogResult.OK)
            {
                NewGroup.Header = x;
                NewGroup.HeaderAlignment = HorizontalAlignment.Center;
                listitens.Groups.Add(NewGroup);
                (cms_viewer.Items[4] as ToolStripMenuItem)?.DropDownItems.Add(listitens.Groups[listitens.Groups.Count - 1].Header);
                MyGroups.Items.Add(x);
                ChangueItens();
            }
        }

        private void MoverParaOGrupoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = moverParaOGrupoToolStripMenuItem.DropDown.Items.IndexOf(e.ClickedItem);
            var itemIndex = listitens.Items.IndexOf(listitens.SelectedItems[0]);
            listitens.Items[itemIndex].Group = listitens.Groups[index];
            string newGroup = listitens.Items[itemIndex].Text + ":" + listitens.Groups[index];
            ChangeGroup(newGroup);
            ChangueItens();
        }

        private void RemoverGrupoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int indx = removerGrupoToolStripMenuItem.DropDownItems.IndexOf(e.ClickedItem);
            editarToolStripMenuItem.HideDropDown();
            var diagResult = MessageBox.Show("Tem certeza que deseja excluir o grupo: " + removerGrupoToolStripMenuItem.DropDownItems[indx].Text,
                "Excluir grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (diagResult == DialogResult.Yes)
                RemoveGroup(indx);

            ChangueItens();
        }

        private void DefinirComoADMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemIndex = listitens.Items.IndexOf(listitens.SelectedItems[0]);
            listitens.Items[itemIndex].Checked = !listitens.Items[itemIndex].Checked;
            int removeAt = ConfigAdmin.FindString(listitens.Items[itemIndex].Text);
            if (removeAt > 0)
                ConfigAdmin.Items.RemoveAt(removeAt);

            if (listitens.Items[itemIndex].Checked)
                ConfigAdmin.Items.Add(listitens.Items[itemIndex].Text + ":" + Convert.ToInt32(listitens.Items[itemIndex].Checked));

            ChangueItens();
            if (listitens.Items[itemIndex].Checked)
                listitens.Items[itemIndex].ForeColor = Color.Red;
            else
                listitens.Items[itemIndex].ForeColor = Color.Black;
        }

        private void ImportaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            var dialogResult = file.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    LoadFile(file.FileName);
                    ChangueItens();
                }
                catch
                {
                }
            }
        }

        private void desligarLigarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmr_func.Enabled = desligarLigarToolStripMenuItem.Checked;
        }

        private void definirIconeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            file.Filter = "Icones|*.ico|Todos arquivos|*.*";
            var diag = file.ShowDialog();
            if (diag == DialogResult.OK)
            {
                Icon largeIcon = IconExtractor.ExtractIconLarge(file.FileName);
                if (largeIcon != null)
                {
                    int index = listitens.SelectedItems[0].Index;
                    string arq = mylist.Items[index].ToString();
                    string[] IconEx = arq.Split(';');
                    string[] file_rename = arq.Split('|');

                    if (IconEx.Length > 1)
                        mylist.Items[index] = IconEx[0] + ";" + file.FileName;
                    else if (file_rename.Length > 1)
                        mylist.Items[index] = file_rename[0] + ";" + file.FileName + "|" + file_rename[1];
                    else
                        mylist.Items[index] += ";" + file.FileName;

                    lista_icons.Images.Add(largeIcon.ToBitmap());
                    listitens.SelectedItems[0].ImageIndex = (lista_icons.Images.Count - 1);
                    ChangueItens();
                }
                else
                    MessageBox.Show("Erro não foi possivel extrair o icone do arquivo", "ERRO ICON", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void renomeiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newname = string.Empty;

            DialogResult rest = InputBox("Renomeia item", "novo nome", ref newname);

            if (rest == DialogResult.OK && newname != string.Empty)
            {
                int index = listitens.SelectedItems[0].Index;
                string arq = mylist.Items[index].ToString();
                string[] Rename = arq.Split('|');

                if (Rename.Length > 1)
                    mylist.Items[index] = Rename[0] + "|" + newname;
                else
                    mylist.Items[index] += "|" + newname;

                var itemIndex = listitens.Items.IndexOf(listitens.SelectedItems[0]);

                bool havegroups = false;
                for (int groups = 0; groups < listitens.Groups.Count; ++groups)
                {
                    if (listitens.Groups[groups] == listitens.Items[index].Group)
                    {
                        havegroups = true;
                        break;
                    }
                }

                int removeAt = ConfigGroups.FindStringExact(listitens.Items[itemIndex].Text);
                while (removeAt != ListBox.NoMatches)
                {
                    ConfigGroups.Items.RemoveAt(removeAt);
                    removeAt = ConfigGroups.FindStringExact(listitens.Items[itemIndex].Text);
                }

                listitens.SelectedItems[0].Text = newname;
                if (havegroups)
                {
                    string newGroup = listitens.SelectedItems[0].Text + ":" + listitens.SelectedItems[0].Group.Header;
                    ChangeGroup(newGroup);
                }

                ChangueItens();
            }
            else if (rest == DialogResult.OK && newname == string.Empty)
            {
                int index = listitens.SelectedItems[0].Index;
                var itemIndex = listitens.Items.IndexOf(listitens.SelectedItems[0]);
                string arq = mylist.Items[index].ToString().Split('|')[0];
                mylist.Items[index] = arq;

                bool havegroups = false;
                for (int groups = 0; groups < listitens.Groups.Count; ++groups)
                {
                    if (listitens.Groups[groups] == listitens.Items[index].Group)
                    {
                        havegroups = true;
                        break;
                    }
                }

                int removeAt = ConfigGroups.FindStringExact(listitens.Items[itemIndex].Text);
                while (removeAt != ListBox.NoMatches)
                {
                    ConfigGroups.Items.RemoveAt(removeAt);
                    removeAt = ConfigGroups.FindStringExact(listitens.Items[itemIndex].Text);
                }

                listitens.SelectedItems[0].Text = Path.GetFileNameWithoutExtension(arq.Split(';')[0]);
                string newGroup = String.Empty;

                if (havegroups)
                {
                    newGroup = listitens.SelectedItems[0].Text + ":" + listitens.SelectedItems[0].Group.Header;
                    ChangeGroup(newGroup);
                }

                ChangueItens();
            }
        }

        //Joke functions
        private void timer1_Tick(object sender, EventArgs e)
        {
            string fpss = GetFps().ToString("N1");

            if (mostrarHorasToolStripMenuItem.Checked && mostrarFPSToolStripMenuItem.Checked)
                this.Text = TitleProgram + " FPS[" + fpss + "]  Horas (" + _lastCheckTime.Hour + ":" + _lastCheckTime.Minute + ":" + _lastCheckTime.Second + ")";
            else
            if (mostrarFPSToolStripMenuItem.Checked)
                this.Text = TitleProgram + " FPS[" + fpss + "] ";
            else
            if (mostrarHorasToolStripMenuItem.Checked)
                this.Text = TitleProgram + "  " + _lastCheckTime.Hour + " : " + _lastCheckTime.Minute + " : " + _lastCheckTime.Second;
            else
                this.Text = TitleProgram;
        }

        private void wARNINGToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            outrosToolStripMenuItem.HideDropDown();

            DialogResult Msg_warning = MessageBox.Show("Esse programa não foi encontrado deseja procura-lo?", "Error", MessageBoxButtons.YesNo);
            if (Msg_warning == DialogResult.Yes)
            {
                var file = new OpenFileDialog();
                file.Filter = Path.GetFileNameWithoutExtension(e.ClickedItem.Text) + "|*" + Path.GetExtension(e.ClickedItem.Text);

                var dialogResult = file.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        LoadFile(file.FileName);
                        ChangueItens();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void criarMacroDePesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Pesquisa = string.Empty;
            string Arg = string.Empty;

            if (DialogResult.OK == InputBox("Criar macro", "Escolha o site para o macro", ref Pesquisa))
            {
                if (DialogResult.OK == InputBox("Criar macro", "escolha o argumento de pesquisa", ref Arg))
                {
                    Macros.Items.Add(Arg + " " + Pesquisa);
                    ChangueItens();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                Pesquisa();
        }

        private void editarMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowMacros("Editor de macro", ref Macros))
                ChangueItens();
        }

        private void hotkeyMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Key_Macros.Items.Clear();
            _ = Key_Macros.Items.Add("<K_M>");
            if (RegisterKeys(hook, ref Key_Macros) == DialogResult.OK)
                ChangueItens();
        }
    }
}