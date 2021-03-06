﻿namespace Filyama
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowserFilm = new System.Windows.Forms.WebBrowser();
            this.dataGridViewFilms = new System.Windows.Forms.DataGridView();
            this.ColumntCategory = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumntExistImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNameFilm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelCategory = new System.Windows.Forms.Label();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.treeCategory = new System.Windows.Forms.TreeView();
            this.imageListCategory = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowserSerial = new System.Windows.Forms.WebBrowser();
            this.labelSerials = new System.Windows.Forms.Label();
            this.buttonDeleteSerials = new System.Windows.Forms.Button();
            this.buttonEditSerials = new System.Windows.Forms.Button();
            this.buttonAddSerials = new System.Windows.Forms.Button();
            this.treeViewListSerials = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteAnime = new System.Windows.Forms.Button();
            this.buttonEditAnime = new System.Windows.Forms.Button();
            this.buttonAddAnime = new System.Windows.Forms.Button();
            this.treeAnime = new System.Windows.Forms.TreeView();
            this.webBrowserAnime = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonElementEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonElementAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonElementRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.saveZipFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openZipFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilms)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1228, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.webBrowserFilm);
            this.tabPage1.Controls.Add(this.dataGridViewFilms);
            this.tabPage1.Controls.Add(this.labelCategory);
            this.tabPage1.Controls.Add(this.buttonDeleteCategory);
            this.tabPage1.Controls.Add(this.buttonEditCategory);
            this.tabPage1.Controls.Add(this.buttonAddCategory);
            this.tabPage1.Controls.Add(this.treeCategory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1220, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabFilms";
            // 
            // webBrowserFilm
            // 
            this.webBrowserFilm.Location = new System.Drawing.Point(594, 3);
            this.webBrowserFilm.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserFilm.Name = "webBrowserFilm";
            this.webBrowserFilm.Size = new System.Drawing.Size(618, 485);
            this.webBrowserFilm.TabIndex = 6;
            // 
            // dataGridViewFilms
            // 
            this.dataGridViewFilms.AllowUserToAddRows = false;
            this.dataGridViewFilms.AllowUserToDeleteRows = false;
            this.dataGridViewFilms.AllowUserToResizeRows = false;
            this.dataGridViewFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumntCategory,
            this.ColumntExistImage,
            this.ColumnId,
            this.ColumnNameFilm});
            this.dataGridViewFilms.Location = new System.Drawing.Point(183, 3);
            this.dataGridViewFilms.Name = "dataGridViewFilms";
            this.dataGridViewFilms.ReadOnly = true;
            this.dataGridViewFilms.RowHeadersVisible = false;
            this.dataGridViewFilms.Size = new System.Drawing.Size(405, 485);
            this.dataGridViewFilms.TabIndex = 5;
            this.dataGridViewFilms.SelectionChanged += new System.EventHandler(this.dataGridViewFilms_SelectionChanged);
            // 
            // ColumntCategory
            // 
            this.ColumntCategory.HeaderText = "Category";
            this.ColumntCategory.Name = "ColumntCategory";
            this.ColumntCategory.ReadOnly = true;
            // 
            // ColumntExistImage
            // 
            this.ColumntExistImage.FillWeight = 50F;
            this.ColumntExistImage.HeaderText = "Cover";
            this.ColumntExistImage.Name = "ColumntExistImage";
            this.ColumntExistImage.ReadOnly = true;
            this.ColumntExistImage.Width = 50;
            // 
            // ColumnId
            // 
            this.ColumnId.FillWeight = 30F;
            this.ColumnId.HeaderText = "№";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 30;
            // 
            // ColumnNameFilm
            // 
            this.ColumnNameFilm.HeaderText = "Название";
            this.ColumnNameFilm.Name = "ColumnNameFilm";
            this.ColumnNameFilm.ReadOnly = true;
            this.ColumnNameFilm.Width = 210;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(117, 18);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(60, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Категории";
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.BackgroundImage = global::Filyama.Properties.Resources.Minus;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(70, 6);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(25, 25);
            this.buttonDeleteCategory.TabIndex = 3;
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEditCategory.BackgroundImage")));
            this.buttonEditCategory.Location = new System.Drawing.Point(39, 6);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(25, 25);
            this.buttonEditCategory.TabIndex = 2;
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.BackgroundImage = global::Filyama.Properties.Resources.Plus;
            this.buttonAddCategory.Location = new System.Drawing.Point(8, 6);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(25, 25);
            this.buttonAddCategory.TabIndex = 1;
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // treeCategory
            // 
            this.treeCategory.ImageIndex = 0;
            this.treeCategory.ImageList = this.imageListCategory;
            this.treeCategory.Location = new System.Drawing.Point(8, 37);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.SelectedImageIndex = 0;
            this.treeCategory.Size = new System.Drawing.Size(169, 451);
            this.treeCategory.TabIndex = 0;
            this.treeCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCategory_AfterSelect);
            // 
            // imageListCategory
            // 
            this.imageListCategory.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListCategory.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListCategory.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.webBrowserSerial);
            this.tabPage2.Controls.Add(this.labelSerials);
            this.tabPage2.Controls.Add(this.buttonDeleteSerials);
            this.tabPage2.Controls.Add(this.buttonEditSerials);
            this.tabPage2.Controls.Add(this.buttonAddSerials);
            this.tabPage2.Controls.Add(this.treeViewListSerials);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1220, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabTVShows";
            // 
            // webBrowserSerial
            // 
            this.webBrowserSerial.Location = new System.Drawing.Point(248, 11);
            this.webBrowserSerial.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSerial.Name = "webBrowserSerial";
            this.webBrowserSerial.Size = new System.Drawing.Size(956, 469);
            this.webBrowserSerial.TabIndex = 5;
            // 
            // labelSerials
            // 
            this.labelSerials.AutoSize = true;
            this.labelSerials.Location = new System.Drawing.Point(172, 16);
            this.labelSerials.Name = "labelSerials";
            this.labelSerials.Size = new System.Drawing.Size(52, 13);
            this.labelSerials.TabIndex = 4;
            this.labelSerials.Text = "Сериалы";
            // 
            // buttonDeleteSerials
            // 
            this.buttonDeleteSerials.BackgroundImage = global::Filyama.Properties.Resources.Minus;
            this.buttonDeleteSerials.Location = new System.Drawing.Point(76, 13);
            this.buttonDeleteSerials.Name = "buttonDeleteSerials";
            this.buttonDeleteSerials.Size = new System.Drawing.Size(25, 25);
            this.buttonDeleteSerials.TabIndex = 3;
            this.buttonDeleteSerials.UseVisualStyleBackColor = true;
            this.buttonDeleteSerials.Click += new System.EventHandler(this.buttonDeleteSerials_Click);
            // 
            // buttonEditSerials
            // 
            this.buttonEditSerials.BackgroundImage = global::Filyama.Properties.Resources.edit_25;
            this.buttonEditSerials.Location = new System.Drawing.Point(45, 12);
            this.buttonEditSerials.Name = "buttonEditSerials";
            this.buttonEditSerials.Size = new System.Drawing.Size(25, 25);
            this.buttonEditSerials.TabIndex = 2;
            this.buttonEditSerials.UseVisualStyleBackColor = true;
            // 
            // buttonAddSerials
            // 
            this.buttonAddSerials.BackgroundImage = global::Filyama.Properties.Resources.Plus;
            this.buttonAddSerials.Location = new System.Drawing.Point(14, 13);
            this.buttonAddSerials.Name = "buttonAddSerials";
            this.buttonAddSerials.Size = new System.Drawing.Size(25, 25);
            this.buttonAddSerials.TabIndex = 1;
            this.buttonAddSerials.UseVisualStyleBackColor = true;
            this.buttonAddSerials.Click += new System.EventHandler(this.buttonAddSerials_Click);
            // 
            // treeViewListSerials
            // 
            this.treeViewListSerials.Location = new System.Drawing.Point(14, 44);
            this.treeViewListSerials.Name = "treeViewListSerials";
            this.treeViewListSerials.Size = new System.Drawing.Size(224, 436);
            this.treeViewListSerials.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.buttonDeleteAnime);
            this.tabPage3.Controls.Add(this.buttonEditAnime);
            this.tabPage3.Controls.Add(this.buttonAddAnime);
            this.tabPage3.Controls.Add(this.treeAnime);
            this.tabPage3.Controls.Add(this.webBrowserAnime);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1220, 496);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabAnime";
            // 
            // buttonDeleteAnime
            // 
            this.buttonDeleteAnime.BackgroundImage = global::Filyama.Properties.Resources.Minus;
            this.buttonDeleteAnime.Location = new System.Drawing.Point(79, 6);
            this.buttonDeleteAnime.Name = "buttonDeleteAnime";
            this.buttonDeleteAnime.Size = new System.Drawing.Size(25, 25);
            this.buttonDeleteAnime.TabIndex = 4;
            this.buttonDeleteAnime.UseVisualStyleBackColor = true;
            // 
            // buttonEditAnime
            // 
            this.buttonEditAnime.BackgroundImage = global::Filyama.Properties.Resources.edit_25;
            this.buttonEditAnime.Location = new System.Drawing.Point(48, 6);
            this.buttonEditAnime.Name = "buttonEditAnime";
            this.buttonEditAnime.Size = new System.Drawing.Size(25, 25);
            this.buttonEditAnime.TabIndex = 3;
            this.buttonEditAnime.UseVisualStyleBackColor = true;
            // 
            // buttonAddAnime
            // 
            this.buttonAddAnime.BackgroundImage = global::Filyama.Properties.Resources.Plus;
            this.buttonAddAnime.Location = new System.Drawing.Point(17, 6);
            this.buttonAddAnime.Name = "buttonAddAnime";
            this.buttonAddAnime.Size = new System.Drawing.Size(25, 25);
            this.buttonAddAnime.TabIndex = 2;
            this.buttonAddAnime.UseVisualStyleBackColor = true;
            // 
            // treeAnime
            // 
            this.treeAnime.Location = new System.Drawing.Point(17, 41);
            this.treeAnime.Name = "treeAnime";
            this.treeAnime.Size = new System.Drawing.Size(227, 435);
            this.treeAnime.TabIndex = 1;
            // 
            // webBrowserAnime
            // 
            this.webBrowserAnime.Location = new System.Drawing.Point(351, 13);
            this.webBrowserAnime.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAnime.Name = "webBrowserAnime";
            this.webBrowserAnime.Size = new System.Drawing.Size(848, 463);
            this.webBrowserAnime.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.recordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1228, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveZipToolStripMenuItem,
            this.pushToolStripMenuItem,
            this.preferenseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load zip";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveZipToolStripMenuItem
            // 
            this.saveZipToolStripMenuItem.Name = "saveZipToolStripMenuItem";
            this.saveZipToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveZipToolStripMenuItem.Text = "Save zip";
            this.saveZipToolStripMenuItem.Click += new System.EventHandler(this.saveZipToolStripMenuItem_Click);
            // 
            // pushToolStripMenuItem
            // 
            this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
            this.pushToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pushToolStripMenuItem.Text = "Push zip";
            // 
            // preferenseToolStripMenuItem
            // 
            this.preferenseToolStripMenuItem.Name = "preferenseToolStripMenuItem";
            this.preferenseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preferenseToolStripMenuItem.Text = "Preferense";
            this.preferenseToolStripMenuItem.Click += new System.EventHandler(this.preferenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDatabase,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonElementEdit,
            this.toolStripButtonElementAdd,
            this.toolStripButtonElementRemove,
            this.toolStripButtonFind,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1228, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDatabase
            // 
            this.toolStripButtonDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDatabase.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDatabase.Image")));
            this.toolStripButtonDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDatabase.Name = "toolStripButtonDatabase";
            this.toolStripButtonDatabase.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDatabase.Text = "toolStripButton1";
            this.toolStripButtonDatabase.ToolTipText = "Database";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "toolStripButton1";
            this.toolStripButtonSave.ToolTipText = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonElementEdit
            // 
            this.toolStripButtonElementEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonElementEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonElementEdit.Image")));
            this.toolStripButtonElementEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonElementEdit.Name = "toolStripButtonElementEdit";
            this.toolStripButtonElementEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonElementEdit.Text = "toolStripButton1";
            this.toolStripButtonElementEdit.ToolTipText = "Edit";
            this.toolStripButtonElementEdit.Click += new System.EventHandler(this.toolStripButtonElementEdit_Click);
            // 
            // toolStripButtonElementAdd
            // 
            this.toolStripButtonElementAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonElementAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonElementAdd.Image")));
            this.toolStripButtonElementAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonElementAdd.Name = "toolStripButtonElementAdd";
            this.toolStripButtonElementAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonElementAdd.Text = "toolStripButton1";
            this.toolStripButtonElementAdd.ToolTipText = "Add";
            this.toolStripButtonElementAdd.Click += new System.EventHandler(this.toolStripButtonElementAdd_Click);
            // 
            // toolStripButtonElementRemove
            // 
            this.toolStripButtonElementRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonElementRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonElementRemove.Image")));
            this.toolStripButtonElementRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonElementRemove.Name = "toolStripButtonElementRemove";
            this.toolStripButtonElementRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonElementRemove.Text = "toolStripButton1";
            this.toolStripButtonElementRemove.ToolTipText = "Remove";
            this.toolStripButtonElementRemove.Click += new System.EventHandler(this.toolStripButtonElementRemove_Click);
            // 
            // toolStripButtonFind
            // 
            this.toolStripButtonFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFind.Image")));
            this.toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFind.Name = "toolStripButtonFind";
            this.toolStripButtonFind.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFind.Text = "toolStripButton1";
            this.toolStripButtonFind.Click += new System.EventHandler(this.toolStripButtonFind_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(250, 25);
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // saveZipFileDialog
            // 
            this.saveZipFileDialog.DefaultExt = "zip";
            this.saveZipFileDialog.FileName = "backup";
            this.saveZipFileDialog.Filter = "Zip file|*.zip";
            this.saveZipFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openZipFileDialog
            // 
            this.openZipFileDialog.DefaultExt = "zip";
            this.openZipFileDialog.Filter = "Zip file|*.zip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 574);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fylyama - 0.0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilms)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView treeCategory;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.WebBrowser webBrowserFilm;
        private System.Windows.Forms.DataGridView dataGridViewFilms;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabase;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonElementEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonElementAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonElementRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonFind;
        private System.Windows.Forms.ToolStripMenuItem pushToolStripMenuItem;
        private System.Windows.Forms.Label labelSerials;
        private System.Windows.Forms.Button buttonDeleteSerials;
        private System.Windows.Forms.Button buttonEditSerials;
        private System.Windows.Forms.Button buttonAddSerials;
        private System.Windows.Forms.TreeView treeViewListSerials;
        private System.Windows.Forms.ToolStripMenuItem preferenseToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListCategory;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.DataGridViewImageColumn ColumntCategory;
        private System.Windows.Forms.DataGridViewImageColumn ColumntExistImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNameFilm;
        private System.Windows.Forms.ToolStripMenuItem saveZipToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveZipFileDialog;
        private System.Windows.Forms.OpenFileDialog openZipFileDialog;
        private System.Windows.Forms.WebBrowser webBrowserSerial;
        private System.Windows.Forms.WebBrowser webBrowserAnime;
        private System.Windows.Forms.Button buttonDeleteAnime;
        private System.Windows.Forms.Button buttonEditAnime;
        private System.Windows.Forms.Button buttonAddAnime;
        private System.Windows.Forms.TreeView treeAnime;
    }
}

