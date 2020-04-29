namespace LauncherDesktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("EXE", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("OUTROS", System.Windows.Forms.HorizontalAlignment.Center);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esconderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLocalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.limparListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeVisualizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicializarComOOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificarUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lista_icons = new System.Windows.Forms.ImageList(this.components);
            this.listitens = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirComoAdmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Launcher Apps";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.outrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(342, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirListaToolStripMenuItem,
            this.esconderToolStripMenuItem,
            this.salvarListaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "&Arquivos";
            // 
            // abrirListaToolStripMenuItem
            // 
            this.abrirListaToolStripMenuItem.Name = "abrirListaToolStripMenuItem";
            this.abrirListaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.abrirListaToolStripMenuItem.Text = "Abrir Lista";
            this.abrirListaToolStripMenuItem.Click += new System.EventHandler(this.abrirListaToolStripMenuItem_Click);
            // 
            // esconderToolStripMenuItem
            // 
            this.esconderToolStripMenuItem.Name = "esconderToolStripMenuItem";
            this.esconderToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.esconderToolStripMenuItem.Text = "Esconder";
            this.esconderToolStripMenuItem.Click += new System.EventHandler(this.esconderToolStripMenuItem_Click);
            // 
            // salvarListaToolStripMenuItem
            // 
            this.salvarListaToolStripMenuItem.Name = "salvarListaToolStripMenuItem";
            this.salvarListaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.salvarListaToolStripMenuItem.Text = "Salvar lista";
            this.salvarListaToolStripMenuItem.Click += new System.EventHandler(this.salvarListaToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem1,
            this.abrirLocalToolStripMenuItem1,
            this.removerToolStripMenuItem1,
            this.limparListaToolStripMenuItem,
            this.tipoDeVisualizaçãoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // adicionarToolStripMenuItem1
            // 
            this.adicionarToolStripMenuItem1.Name = "adicionarToolStripMenuItem1";
            this.adicionarToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.adicionarToolStripMenuItem1.Text = "Adicionar";
            this.adicionarToolStripMenuItem1.Click += new System.EventHandler(this.adicionarToolStripMenuItem1_Click);
            // 
            // abrirLocalToolStripMenuItem1
            // 
            this.abrirLocalToolStripMenuItem1.Name = "abrirLocalToolStripMenuItem1";
            this.abrirLocalToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.abrirLocalToolStripMenuItem1.Text = "Abrir Local";
            this.abrirLocalToolStripMenuItem1.Click += new System.EventHandler(this.abrirLocalToolStripMenuItem1_Click);
            // 
            // removerToolStripMenuItem1
            // 
            this.removerToolStripMenuItem1.Name = "removerToolStripMenuItem1";
            this.removerToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.removerToolStripMenuItem1.Text = "Remover";
            this.removerToolStripMenuItem1.Click += new System.EventHandler(this.removerToolStripMenuItem1_Click);
            // 
            // limparListaToolStripMenuItem
            // 
            this.limparListaToolStripMenuItem.Name = "limparListaToolStripMenuItem";
            this.limparListaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.limparListaToolStripMenuItem.Text = "Limpar Lista";
            this.limparListaToolStripMenuItem.Click += new System.EventHandler(this.limparListaToolStripMenuItem_Click);
            // 
            // tipoDeVisualizaçãoToolStripMenuItem
            // 
            this.tipoDeVisualizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem1,
            this.listToolStripMenuItem,
            this.titleToolStripMenuItem});
            this.tipoDeVisualizaçãoToolStripMenuItem.Name = "tipoDeVisualizaçãoToolStripMenuItem";
            this.tipoDeVisualizaçãoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tipoDeVisualizaçãoToolStripMenuItem.Text = "Tipo de visualização";
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Checked = true;
            this.smallIconsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem.Text = "Large Icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem1
            // 
            this.smallIconsToolStripMenuItem1.Name = "smallIconsToolStripMenuItem1";
            this.smallIconsToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem1.Text = "Small Icons";
            this.smallIconsToolStripMenuItem1.Click += new System.EventHandler(this.smallIconsToolStripMenuItem1_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.titleToolStripMenuItem.Text = "Title";
            this.titleToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripMenuItem_Click);
            // 
            // outrosToolStripMenuItem
            // 
            this.outrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicializarComOOSToolStripMenuItem,
            this.verificarUpdateToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.outrosToolStripMenuItem.Name = "outrosToolStripMenuItem";
            this.outrosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.outrosToolStripMenuItem.Text = "&Outros";
            // 
            // inicializarComOOSToolStripMenuItem
            // 
            this.inicializarComOOSToolStripMenuItem.CheckOnClick = true;
            this.inicializarComOOSToolStripMenuItem.Name = "inicializarComOOSToolStripMenuItem";
            this.inicializarComOOSToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.inicializarComOOSToolStripMenuItem.Text = "Inicializar com o O.S";
            this.inicializarComOOSToolStripMenuItem.Click += new System.EventHandler(this.inicializarComOOSToolStripMenuItem_Click);
            // 
            // verificarUpdateToolStripMenuItem
            // 
            this.verificarUpdateToolStripMenuItem.Name = "verificarUpdateToolStripMenuItem";
            this.verificarUpdateToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.verificarUpdateToolStripMenuItem.Text = "Verificar update";
            this.verificarUpdateToolStripMenuItem.Click += new System.EventHandler(this.verificarUpdateToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click_1);
            // 
            // lista_icons
            // 
            this.lista_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lista_icons.ImageStream")));
            this.lista_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.lista_icons.Images.SetKeyName(0, "757093_document_512x512.png");
            // 
            // listitens
            // 
            this.listitens.AllowDrop = true;
            this.listitens.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "EXE";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "OUTROS";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup2.Name = "listViewGroup2";
            this.listitens.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listitens.HideSelection = false;
            this.listitens.LargeImageList = this.lista_icons;
            this.listitens.Location = new System.Drawing.Point(0, 24);
            this.listitens.MultiSelect = false;
            this.listitens.Name = "listitens";
            this.listitens.Size = new System.Drawing.Size(342, 214);
            this.listitens.SmallImageList = this.lista_icons;
            this.listitens.TabIndex = 2;
            this.listitens.UseCompatibleStateImageBehavior = false;
            this.listitens.DragDrop += new System.Windows.Forms.DragEventHandler(this.listItens_DragDrop);
            this.listitens.DragOver += new System.Windows.Forms.DragEventHandler(this.listItens_DragOver);
            this.listitens.DoubleClick += new System.EventHandler(this.listitens_DoubleClick);
            this.listitens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listitens_KeyDown);
            this.listitens.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listitens_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.abrirComoAdmToolStripMenuItem,
            this.abrirLocalToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 92);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // abrirComoAdmToolStripMenuItem
            // 
            this.abrirComoAdmToolStripMenuItem.Name = "abrirComoAdmToolStripMenuItem";
            this.abrirComoAdmToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.abrirComoAdmToolStripMenuItem.Text = "Abrir como Adm";
            this.abrirComoAdmToolStripMenuItem.Click += new System.EventHandler(this.abrirComoAdmToolStripMenuItem_Click);
            // 
            // abrirLocalToolStripMenuItem
            // 
            this.abrirLocalToolStripMenuItem.Name = "abrirLocalToolStripMenuItem";
            this.abrirLocalToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.abrirLocalToolStripMenuItem.Text = "Abrir local";
            this.abrirLocalToolStripMenuItem.Click += new System.EventHandler(this.abrirLocalToolStripMenuItem_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 238);
            this.Controls.Add(this.listitens);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher APPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ImageList lista_icons;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ListView listitens;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeVisualizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirLocalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem limparListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirComoAdmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esconderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicializarComOOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificarUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
    }
}

