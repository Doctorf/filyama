namespace Filyama
{
    partial class FormSearch
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSourceFilm = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewFindingFilms = new System.Windows.Forms.DataGridView();
            this.Год = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.href = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxNameSearch = new System.Windows.Forms.TextBox();
            this.labelNameSearch = new System.Windows.Forms.Label();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkedListBoxGenreFilm = new System.Windows.Forms.CheckedListBox();
            this.dateTimePickerDateRus = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerDateWorld = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTitleRus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTitleOrigin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageDataSerial = new System.Windows.Forms.TabPage();
            this.checkedListBoxGenreSerial = new System.Windows.Forms.CheckedListBox();
            this.labelCast = new System.Windows.Forms.Label();
            this.listBoxCast = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSourceFilm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFindingFilms)).BeginInit();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageDataSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSourceFilm);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageDataSerial);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSourceFilm
            // 
            this.tabPageSourceFilm.Controls.Add(this.comboBox1);
            this.tabPageSourceFilm.Controls.Add(this.groupBox1);
            this.tabPageSourceFilm.Controls.Add(this.buttonDetail);
            this.tabPageSourceFilm.Controls.Add(this.buttonSearch);
            this.tabPageSourceFilm.Controls.Add(this.dataGridViewFindingFilms);
            this.tabPageSourceFilm.Controls.Add(this.textBoxNameSearch);
            this.tabPageSourceFilm.Controls.Add(this.labelNameSearch);
            this.tabPageSourceFilm.Location = new System.Drawing.Point(4, 22);
            this.tabPageSourceFilm.Name = "tabPageSourceFilm";
            this.tabPageSourceFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSourceFilm.Size = new System.Drawing.Size(629, 432);
            this.tabPageSourceFilm.TabIndex = 0;
            this.tabPageSourceFilm.Text = "Поиск";
            this.tabPageSourceFilm.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "theMovieOrg"});
            this.comboBox1.Location = new System.Drawing.Point(139, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(16, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(123, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "serialAnime";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Film";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonDetail
            // 
            this.buttonDetail.Location = new System.Drawing.Point(499, 13);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(119, 40);
            this.buttonDetail.TabIndex = 6;
            this.buttonDetail.Text = "Show detail";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(353, 13);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(130, 40);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewFindingFilms
            // 
            this.dataGridViewFindingFilms.AllowUserToAddRows = false;
            this.dataGridViewFindingFilms.AllowUserToDeleteRows = false;
            this.dataGridViewFindingFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFindingFilms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Год,
            this.Название,
            this.href});
            this.dataGridViewFindingFilms.Location = new System.Drawing.Point(16, 133);
            this.dataGridViewFindingFilms.Name = "dataGridViewFindingFilms";
            this.dataGridViewFindingFilms.ReadOnly = true;
            this.dataGridViewFindingFilms.RowHeadersVisible = false;
            this.dataGridViewFindingFilms.Size = new System.Drawing.Size(538, 266);
            this.dataGridViewFindingFilms.TabIndex = 4;
            // 
            // Год
            // 
            this.Год.HeaderText = "Year";
            this.Год.Name = "Год";
            this.Год.ReadOnly = true;
            // 
            // Название
            // 
            this.Название.HeaderText = "Name";
            this.Название.Name = "Название";
            this.Название.ReadOnly = true;
            this.Название.Width = 250;
            // 
            // href
            // 
            this.href.HeaderText = "href";
            this.href.Name = "href";
            this.href.ReadOnly = true;
            this.href.Visible = false;
            // 
            // textBoxNameSearch
            // 
            this.textBoxNameSearch.Location = new System.Drawing.Point(16, 47);
            this.textBoxNameSearch.Name = "textBoxNameSearch";
            this.textBoxNameSearch.Size = new System.Drawing.Size(301, 20);
            this.textBoxNameSearch.TabIndex = 3;
            this.textBoxNameSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNameSearch_KeyDown);
            // 
            // labelNameSearch
            // 
            this.labelNameSearch.AutoSize = true;
            this.labelNameSearch.Location = new System.Drawing.Point(13, 22);
            this.labelNameSearch.Name = "labelNameSearch";
            this.labelNameSearch.Size = new System.Drawing.Size(53, 13);
            this.labelNameSearch.TabIndex = 2;
            this.labelNameSearch.Text = "Name film";
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.listBoxCast);
            this.tabPageData.Controls.Add(this.labelCast);
            this.tabPageData.Controls.Add(this.pictureBox1);
            this.tabPageData.Controls.Add(this.buttonAdd);
            this.tabPageData.Controls.Add(this.checkedListBoxGenreFilm);
            this.tabPageData.Controls.Add(this.dateTimePickerDateRus);
            this.tabPageData.Controls.Add(this.label6);
            this.tabPageData.Controls.Add(this.dateTimePickerDateWorld);
            this.tabPageData.Controls.Add(this.label5);
            this.tabPageData.Controls.Add(this.textBoxTitleRus);
            this.tabPageData.Controls.Add(this.label4);
            this.tabPageData.Controls.Add(this.textBoxTitleOrigin);
            this.tabPageData.Controls.Add(this.label3);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(685, 375);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Фильм";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(480, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdd.Location = new System.Drawing.Point(550, 310);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(127, 50);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add information";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // checkedListBoxGenreFilm
            // 
            this.checkedListBoxGenreFilm.FormattingEnabled = true;
            this.checkedListBoxGenreFilm.Location = new System.Drawing.Point(336, 27);
            this.checkedListBoxGenreFilm.Name = "checkedListBoxGenreFilm";
            this.checkedListBoxGenreFilm.Size = new System.Drawing.Size(101, 124);
            this.checkedListBoxGenreFilm.TabIndex = 8;
            // 
            // dateTimePickerDateRus
            // 
            this.dateTimePickerDateRus.Location = new System.Drawing.Point(81, 149);
            this.dateTimePickerDateRus.Name = "dateTimePickerDateRus";
            this.dateTimePickerDateRus.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateRus.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // dateTimePickerDateWorld
            // 
            this.dateTimePickerDateWorld.Location = new System.Drawing.Point(85, 113);
            this.dateTimePickerDateWorld.Name = "dateTimePickerDateWorld";
            this.dateTimePickerDateWorld.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateWorld.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // textBoxTitleRus
            // 
            this.textBoxTitleRus.Location = new System.Drawing.Point(86, 74);
            this.textBoxTitleRus.Name = "textBoxTitleRus";
            this.textBoxTitleRus.ReadOnly = true;
            this.textBoxTitleRus.Size = new System.Drawing.Size(174, 20);
            this.textBoxTitleRus.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // textBoxTitleOrigin
            // 
            this.textBoxTitleOrigin.Location = new System.Drawing.Point(86, 38);
            this.textBoxTitleOrigin.Name = "textBoxTitleOrigin";
            this.textBoxTitleOrigin.ReadOnly = true;
            this.textBoxTitleOrigin.Size = new System.Drawing.Size(174, 20);
            this.textBoxTitleOrigin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // tabPageDataSerial
            // 
            this.tabPageDataSerial.Controls.Add(this.checkedListBoxGenreSerial);
            this.tabPageDataSerial.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataSerial.Name = "tabPageDataSerial";
            this.tabPageDataSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataSerial.Size = new System.Drawing.Size(629, 432);
            this.tabPageDataSerial.TabIndex = 2;
            this.tabPageDataSerial.Text = "Сериал";
            this.tabPageDataSerial.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxGenreSerial
            // 
            this.checkedListBoxGenreSerial.FormattingEnabled = true;
            this.checkedListBoxGenreSerial.Location = new System.Drawing.Point(17, 76);
            this.checkedListBoxGenreSerial.Name = "checkedListBoxGenreSerial";
            this.checkedListBoxGenreSerial.Size = new System.Drawing.Size(317, 184);
            this.checkedListBoxGenreSerial.TabIndex = 9;
            // 
            // labelCast
            // 
            this.labelCast.AutoSize = true;
            this.labelCast.Location = new System.Drawing.Point(20, 183);
            this.labelCast.Name = "labelCast";
            this.labelCast.Size = new System.Drawing.Size(35, 13);
            this.labelCast.TabIndex = 11;
            this.labelCast.Text = "label1";
            // 
            // listBoxCast
            // 
            this.listBoxCast.FormattingEnabled = true;
            this.listBoxCast.Location = new System.Drawing.Point(25, 213);
            this.listBoxCast.Name = "listBoxCast";
            this.listBoxCast.Size = new System.Drawing.Size(285, 147);
            this.listBoxCast.TabIndex = 12;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 401);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSourceFilm.ResumeLayout(false);
            this.tabPageSourceFilm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFindingFilms)).EndInit();
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageDataSerial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSourceFilm;
        private System.Windows.Forms.DataGridView dataGridViewFindingFilms;
        private System.Windows.Forms.TextBox textBoxNameSearch;
        private System.Windows.Forms.Label labelNameSearch;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.TextBox textBoxTitleOrigin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTitleRus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateWorld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateRus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenreFilm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Год;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn href;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPageDataSerial;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenreSerial;
        private System.Windows.Forms.Label labelCast;
        private System.Windows.Forms.ListBox listBoxCast;
    }
}