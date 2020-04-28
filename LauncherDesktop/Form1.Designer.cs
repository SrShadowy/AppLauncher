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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("EXE", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("OUTROS", System.Windows.Forms.HorizontalAlignment.Center);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lista_icons = new System.Windows.Forms.ImageList(this.components);
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listitens = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeVisualizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLocalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.limparListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirComoAdmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esconderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notIcon";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(342, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esconderToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // lista_icons
            // 
            this.lista_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lista_icons.ImageStream")));
            this.lista_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.lista_icons.Images.SetKeyName(0, "757093_document_512x512.png");
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // listitens
            // 
            this.listitens.AllowDrop = true;
            this.listitens.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup3.Header = "EXE";
            listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "OUTROS";
            listViewGroup4.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup4.Name = "listViewGroup2";
            this.listitens.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listitens.HideSelection = false;
            this.listitens.LargeImageList = this.lista_icons;
            this.listitens.Location = new System.Drawing.Point(0, 24);
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
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // tipoDeVisualizaçãoToolStripMenuItem
            // 
            this.tipoDeVisualizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallIconsToolStripMenuItem,
            this.detalhesToolStripMenuItem,
            this.smallIconsToolStripMenuItem1,
            this.listToolStripMenuItem,
            this.titleToolStripMenuItem});
            this.tipoDeVisualizaçãoToolStripMenuItem.Name = "tipoDeVisualizaçãoToolStripMenuItem";
            this.tipoDeVisualizaçãoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoDeVisualizaçãoToolStripMenuItem.Text = "Tipo de visualização";
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Checked = true;
            this.smallIconsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smallIconsToolStripMenuItem.Text = "Large Icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // detalhesToolStripMenuItem
            // 
            this.detalhesToolStripMenuItem.Name = "detalhesToolStripMenuItem";
            this.detalhesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detalhesToolStripMenuItem.Text = "Details";
            this.detalhesToolStripMenuItem.Click += new System.EventHandler(this.detalhesToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem1
            // 
            this.smallIconsToolStripMenuItem1.Name = "smallIconsToolStripMenuItem1";
            this.smallIconsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.smallIconsToolStripMenuItem1.Text = "Small Icons";
            this.smallIconsToolStripMenuItem1.Click += new System.EventHandler(this.smallIconsToolStripMenuItem1_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.titleToolStripMenuItem.Text = "Title";
            this.titleToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripMenuItem_Click);
            // 
            // abrirLocalToolStripMenuItem1
            // 
            this.abrirLocalToolStripMenuItem1.Name = "abrirLocalToolStripMenuItem1";
            this.abrirLocalToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.abrirLocalToolStripMenuItem1.Text = "Abrir Local";
            this.abrirLocalToolStripMenuItem1.Click += new System.EventHandler(this.abrirLocalToolStripMenuItem1_Click);
            // 
            // removerToolStripMenuItem1
            // 
            this.removerToolStripMenuItem1.Name = "removerToolStripMenuItem1";
            this.removerToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.removerToolStripMenuItem1.Text = "Remover";
            this.removerToolStripMenuItem1.Click += new System.EventHandler(this.removerToolStripMenuItem1_Click);
            // 
            // limparListaToolStripMenuItem
            // 
            this.limparListaToolStripMenuItem.Name = "limparListaToolStripMenuItem";
            this.limparListaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limparListaToolStripMenuItem.Text = "Limpar Lista";
            this.limparListaToolStripMenuItem.Click += new System.EventHandler(this.limparListaToolStripMenuItem_Click);
            // 
            // adicionarToolStripMenuItem1
            // 
            this.adicionarToolStripMenuItem1.Name = "adicionarToolStripMenuItem1";
            this.adicionarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.adicionarToolStripMenuItem1.Text = "Adicionar";
            this.adicionarToolStripMenuItem1.Click += new System.EventHandler(this.adicionarToolStripMenuItem1_Click);
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
            // esconderToolStripMenuItem
            // 
            this.esconderToolStripMenuItem.Name = "esconderToolStripMenuItem";
            this.esconderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.esconderToolStripMenuItem.Text = "Esconder";
            this.esconderToolStripMenuItem.Click += new System.EventHandler(this.esconderToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem detalhesToolStripMenuItem;
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
    }
}

