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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddVideo));
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxFullPath = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxNameRus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNameOrig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 343);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(29, 13);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Path";
            // 
            // textBoxFullPath
            // 
            this.textBoxFullPath.Location = new System.Drawing.Point(62, 343);
            this.textBoxFullPath.Name = "textBoxFullPath";
            this.textBoxFullPath.ReadOnly = true;
            this.textBoxFullPath.Size = new System.Drawing.Size(225, 20);
            this.textBoxFullPath.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(305, 337);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(46, 25);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // textBoxNameRus
            // 
            this.textBoxNameRus.Location = new System.Drawing.Point(99, 64);
            this.textBoxNameRus.Name = "textBoxNameRus";
            this.textBoxNameRus.Size = new System.Drawing.Size(152, 20);
            this.textBoxNameRus.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name Russia";
            // 
            // textBoxNameOrig
            // 
            this.textBoxNameOrig.Location = new System.Drawing.Point(99, 38);
            this.textBoxNameOrig.Name = "textBoxNameOrig";
            this.textBoxNameOrig.Size = new System.Drawing.Size(152, 20);
            this.textBoxNameOrig.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name original";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(18, 170);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(241, 147);
            this.listBoxFiles.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(507, 38);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Search";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(278, 6);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(197, 257);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 13;
            this.pictureBoxImage.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(507, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Load";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(507, 79);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(134, 214);
            this.checkedListBoxCategory.TabIndex = 11;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(99, 6);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.ReadOnly = true;
            this.textBoxNumber.Size = new System.Drawing.Size(152, 20);
            this.textBoxNumber.TabIndex = 10;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(15, 6);
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
            this.labeldateWorld.Location = new System.Drawing.Point(16, 98);
            this.labeldateWorld.Name = "labeldateWorld";
            this.labeldateWorld.Size = new System.Drawing.Size(58, 13);
            this.labeldateWorld.TabIndex = 21;
            this.labeldateWorld.Text = "DateWorld";
            // 
            // dateTimePickerDateWorld
            // 
            this.dateTimePickerDateWorld.Location = new System.Drawing.Point(99, 98);
            this.dateTimePickerDateWorld.Name = "dateTimePickerDateWorld";
            this.dateTimePickerDateWorld.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerDateWorld.TabIndex = 22;
            // 
            // labelDateRus
            // 
            this.labelDateRus.AutoSize = true;
            this.labelDateRus.Location = new System.Drawing.Point(15, 130);
            this.labelDateRus.Name = "labelDateRus";
            this.labelDateRus.Size = new System.Drawing.Size(47, 13);
            this.labelDateRus.TabIndex = 23;
            this.labelDateRus.Text = "Date rus";
            // 
            // dateTimePickerDateRus
            // 
            this.dateTimePickerDateRus.Location = new System.Drawing.Point(99, 124);
            this.dateTimePickerDateRus.Name = "dateTimePickerDateRus";
            this.dateTimePickerDateRus.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerDateRus.TabIndex = 24;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(15, 369);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(626, 116);
            this.treeView1.TabIndex = 25;
            // 
            // FormAddVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 543);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBoxNameRus);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labeldateWorld);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFullPath);
            this.Controls.Add(this.labelDateRus);
            this.Controls.Add(this.textBoxNameOrig);
            this.Controls.Add(this.dateTimePickerDateRus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.dateTimePickerDateWorld);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonCancel2);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.checkedListBoxCategory);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddVideo";
            this.Text = "FormAddVideo";
            this.Load += new System.EventHandler(this.FormAddVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxFullPath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonCancel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListBox listBoxFiles;
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
    }
}