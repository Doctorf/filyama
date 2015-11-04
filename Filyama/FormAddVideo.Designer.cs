namespace Filyama
{
    partial class FormAddVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddVideo));
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxFullPath = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textBoxNameRus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNameOrig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonLoadCover = new System.Windows.Forms.Button();
            this.checkedListBoxCategory = new System.Windows.Forms.CheckedListBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonCancel2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.labeldateWorld = new System.Windows.Forms.Label();
            this.dateTimePickerDateWorld = new System.Windows.Forms.DateTimePicker();
            this.labelDateRus = new System.Windows.Forms.Label();
            this.dateTimePickerDateRus = new System.Windows.Forms.DateTimePicker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listViewCast = new System.Windows.Forms.ListView();
            this.imageListPerson = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.ColumnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBinary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFrame = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnThumbnails = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vistaFolderBrowserDialog = new Ookii.Dialogs.VistaFolderBrowserDialog();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.vistaOpenFileDialog = new Ookii.Dialogs.VistaOpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageMedia = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageMedia.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(17, 284);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(29, 13);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Path";
            // 
            // textBoxFullPath
            // 
            this.textBoxFullPath.Location = new System.Drawing.Point(52, 284);
            this.textBoxFullPath.Name = "textBoxFullPath";
            this.textBoxFullPath.ReadOnly = true;
            this.textBoxFullPath.Size = new System.Drawing.Size(225, 20);
            this.textBoxFullPath.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(456, 368);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(46, 25);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // textBoxNameRus
            // 
            this.textBoxNameRus.Location = new System.Drawing.Point(86, 96);
            this.textBoxNameRus.Name = "textBoxNameRus";
            this.textBoxNameRus.Size = new System.Drawing.Size(152, 20);
            this.textBoxNameRus.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name Russia";
            // 
            // textBoxNameOrig
            // 
            this.textBoxNameOrig.Location = new System.Drawing.Point(86, 57);
            this.textBoxNameOrig.Name = "textBoxNameOrig";
            this.textBoxNameOrig.Size = new System.Drawing.Size(152, 20);
            this.textBoxNameOrig.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name original";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(438, 52);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(91, 23);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonLoadCover
            // 
            this.buttonLoadCover.Location = new System.Drawing.Point(438, 18);
            this.buttonLoadCover.Name = "buttonLoadCover";
            this.buttonLoadCover.Size = new System.Drawing.Size(91, 23);
            this.buttonLoadCover.TabIndex = 12;
            this.buttonLoadCover.Text = "Load";
            this.buttonLoadCover.UseVisualStyleBackColor = true;
            this.buttonLoadCover.Click += new System.EventHandler(this.buttonLoadCover_Click);
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(279, 18);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(134, 214);
            this.checkedListBoxCategory.TabIndex = 11;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(66, 31);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.ReadOnly = true;
            this.textBoxNumber.Size = new System.Drawing.Size(152, 20);
            this.textBoxNumber.TabIndex = 10;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(2, 34);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(44, 13);
            this.labelNumber.TabIndex = 9;
            this.labelNumber.Text = "Number";
            // 
            // buttonCancel2
            // 
            this.buttonCancel2.Location = new System.Drawing.Point(12, 491);
            this.buttonCancel2.Name = "buttonCancel2";
            this.buttonCancel2.Size = new System.Drawing.Size(106, 39);
            this.buttonCancel2.TabIndex = 8;
            this.buttonCancel2.Text = "Cancel";
            this.buttonCancel2.UseVisualStyleBackColor = true;
            this.buttonCancel2.Click += new System.EventHandler(this.buttonCancel1_Click);
            // 
            // button5
            // 
            this.button5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button5.Location = new System.Drawing.Point(546, 502);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 40);
            this.button5.TabIndex = 7;
            this.button5.Text = "Finish";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // labeldateWorld
            // 
            this.labeldateWorld.AutoSize = true;
            this.labeldateWorld.Location = new System.Drawing.Point(6, 134);
            this.labeldateWorld.Name = "labeldateWorld";
            this.labeldateWorld.Size = new System.Drawing.Size(58, 13);
            this.labeldateWorld.TabIndex = 21;
            this.labeldateWorld.Text = "DateWorld";
            // 
            // dateTimePickerDateWorld
            // 
            this.dateTimePickerDateWorld.Location = new System.Drawing.Point(89, 134);
            this.dateTimePickerDateWorld.Name = "dateTimePickerDateWorld";
            this.dateTimePickerDateWorld.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerDateWorld.TabIndex = 22;
            // 
            // labelDateRus
            // 
            this.labelDateRus.AutoSize = true;
            this.labelDateRus.Location = new System.Drawing.Point(8, 179);
            this.labelDateRus.Name = "labelDateRus";
            this.labelDateRus.Size = new System.Drawing.Size(47, 13);
            this.labelDateRus.TabIndex = 23;
            this.labelDateRus.Text = "Date rus";
            // 
            // dateTimePickerDateRus
            // 
            this.dateTimePickerDateRus.Location = new System.Drawing.Point(92, 173);
            this.dateTimePickerDateRus.Name = "dateTimePickerDateRus";
            this.dateTimePickerDateRus.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerDateRus.TabIndex = 24;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 10);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(240, 246);
            this.treeView1.TabIndex = 25;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // listViewCast
            // 
            this.listViewCast.LargeImageList = this.imageListPerson;
            this.listViewCast.Location = new System.Drawing.Point(11, 228);
            this.listViewCast.Name = "listViewCast";
            this.listViewCast.Size = new System.Drawing.Size(234, 168);
            this.listViewCast.SmallImageList = this.imageListPerson;
            this.listViewCast.TabIndex = 27;
            this.listViewCast.UseCompatibleStateImageBehavior = false;
            // 
            // imageListPerson
            // 
            this.imageListPerson.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListPerson.ImageSize = new System.Drawing.Size(50, 75);
            this.imageListPerson.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFilename,
            this.ColumnView,
            this.ColumnCover,
            this.ColumnBinary,
            this.ColumnFrame,
            this.ColumnThumbnails});
            this.dataGridViewFiles.Location = new System.Drawing.Point(20, 322);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersVisible = false;
            this.dataGridViewFiles.Size = new System.Drawing.Size(430, 118);
            this.dataGridViewFiles.TabIndex = 28;
            this.dataGridViewFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellContentClick);
            // 
            // ColumnFilename
            // 
            this.ColumnFilename.FillWeight = 250F;
            this.ColumnFilename.HeaderText = "Filename";
            this.ColumnFilename.Name = "ColumnFilename";
            this.ColumnFilename.ReadOnly = true;
            this.ColumnFilename.Width = 250;
            // 
            // ColumnView
            // 
            this.ColumnView.FillWeight = 50F;
            this.ColumnView.HeaderText = "View";
            this.ColumnView.Name = "ColumnView";
            this.ColumnView.Width = 50;
            // 
            // ColumnCover
            // 
            this.ColumnCover.FillWeight = 30F;
            this.ColumnCover.HeaderText = "Cv.";
            this.ColumnCover.Name = "ColumnCover";
            this.ColumnCover.Width = 30;
            // 
            // ColumnBinary
            // 
            this.ColumnBinary.FillWeight = 30F;
            this.ColumnBinary.HeaderText = "Bn.";
            this.ColumnBinary.Name = "ColumnBinary";
            this.ColumnBinary.Width = 30;
            // 
            // ColumnFrame
            // 
            this.ColumnFrame.FillWeight = 30F;
            this.ColumnFrame.HeaderText = "Fr.";
            this.ColumnFrame.Name = "ColumnFrame";
            this.ColumnFrame.Width = 30;
            // 
            // ColumnThumbnails
            // 
            this.ColumnThumbnails.FillWeight = 30F;
            this.ColumnThumbnails.HeaderText = "Th.";
            this.ColumnThumbnails.Name = "ColumnThumbnails";
            this.ColumnThumbnails.Width = 30;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(532, 343);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(60, 19);
            this.buttonAddFile.TabIndex = 29;
            this.buttonAddFile.Text = "Add File";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(542, 385);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(66, 25);
            this.buttonAddFolder.TabIndex = 30;
            this.buttonAddFolder.Text = "Add Folder";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // vistaOpenFileDialog
            // 
            this.vistaOpenFileDialog.Filter = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMedia);
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 485);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.textBoxNumber);
            this.tabPageMain.Controls.Add(this.labelNumber);
            this.tabPageMain.Controls.Add(this.textBoxNameOrig);
            this.tabPageMain.Controls.Add(this.label1);
            this.tabPageMain.Controls.Add(this.buttonLoadCover);
            this.tabPageMain.Controls.Add(this.buttonSearch);
            this.tabPageMain.Controls.Add(this.checkedListBoxCategory);
            this.tabPageMain.Controls.Add(this.listViewCast);
            this.tabPageMain.Controls.Add(this.textBoxNameRus);
            this.tabPageMain.Controls.Add(this.label2);
            this.tabPageMain.Controls.Add(this.dateTimePickerDateWorld);
            this.tabPageMain.Controls.Add(this.labeldateWorld);
            this.tabPageMain.Controls.Add(this.dateTimePickerDateRus);
            this.tabPageMain.Controls.Add(this.labelDateRus);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(689, 459);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageMedia
            // 
            this.tabPageMedia.Controls.Add(this.panel1);
            this.tabPageMedia.Controls.Add(this.dataGridViewFiles);
            this.tabPageMedia.Controls.Add(this.buttonAddFolder);
            this.tabPageMedia.Controls.Add(this.treeView1);
            this.tabPageMedia.Controls.Add(this.textBoxFullPath);
            this.tabPageMedia.Controls.Add(this.buttonLoad);
            this.tabPageMedia.Controls.Add(this.buttonAddFile);
            this.tabPageMedia.Controls.Add(this.labelPath);
            this.tabPageMedia.Location = new System.Drawing.Point(4, 22);
            this.tabPageMedia.Name = "tabPageMedia";
            this.tabPageMedia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMedia.Size = new System.Drawing.Size(689, 459);
            this.tabPageMedia.TabIndex = 1;
            this.tabPageMedia.Text = "Media";
            this.tabPageMedia.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.pictureBoxImage);
            this.panel1.Location = new System.Drawing.Point(326, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 294);
            this.panel1.TabIndex = 31;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBoxImage.Location = new System.Drawing.Point(18, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(197, 257);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 13;
            this.pictureBoxImage.TabStop = false;
            // 
            // FormAddVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 543);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonCancel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddVideo";
            this.Text = "FormAddVideo";
            this.Load += new System.EventHandler(this.FormAddVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageMedia.ResumeLayout(false);
            this.tabPageMedia.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxFullPath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCancel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Button buttonLoadCover;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.TextBox textBoxNameRus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNameOrig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labeldateWorld;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateWorld;
        private System.Windows.Forms.Label labelDateRus;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateRus;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listViewCast;
        private System.Windows.Forms.ImageList imageListPerson;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private Ookii.Dialogs.VistaFolderBrowserDialog vistaFolderBrowserDialog;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonAddFolder;
        private Ookii.Dialogs.VistaOpenFileDialog vistaOpenFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilename;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCover;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnBinary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFrame;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnThumbnails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageMedia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}