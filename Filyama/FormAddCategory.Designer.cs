namespace Filyama
{
    partial class FormAddCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddCategory));
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelParent = new System.Windows.Forms.Label();
            this.comboBoxParents = new System.Windows.Forms.ComboBox();
            this.listViewPictures = new System.Windows.Forms.ListView();
            this.labelPicture = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLoadPicture = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(83, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Наименование";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(109, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Location = new System.Drawing.Point(13, 56);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(55, 13);
            this.labelParent.TabIndex = 2;
            this.labelParent.Text = "Родитель";
            // 
            // comboBoxParents
            // 
            this.comboBoxParents.FormattingEnabled = true;
            this.comboBoxParents.Location = new System.Drawing.Point(109, 56);
            this.comboBoxParents.Name = "comboBoxParents";
            this.comboBoxParents.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParents.TabIndex = 3;
            // 
            // listViewPictures
            // 
            this.listViewPictures.Location = new System.Drawing.Point(8, 117);
            this.listViewPictures.Name = "listViewPictures";
            this.listViewPictures.Size = new System.Drawing.Size(375, 141);
            this.listViewPictures.TabIndex = 4;
            this.listViewPictures.UseCompatibleStateImageBehavior = false;
            this.listViewPictures.View = System.Windows.Forms.View.SmallIcon;
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.Location = new System.Drawing.Point(13, 91);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(115, 13);
            this.labelPicture.TabIndex = 5;
            this.labelPicture.Text = "Список изображений";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(8, 264);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(110, 34);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(134, 264);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 34);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonLoadPicture
            // 
            this.buttonLoadPicture.Location = new System.Drawing.Point(298, 84);
            this.buttonLoadPicture.Name = "buttonLoadPicture";
            this.buttonLoadPicture.Size = new System.Drawing.Size(75, 30);
            this.buttonLoadPicture.TabIndex = 8;
            this.buttonLoadPicture.Text = "Загрузить";
            this.buttonLoadPicture.UseVisualStyleBackColor = true;
            this.buttonLoadPicture.Click += new System.EventHandler(this.buttonLoadPicture_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = ".\\";
            // 
            // FormAddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 308);
            this.Controls.Add(this.buttonLoadPicture);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelPicture);
            this.Controls.Add(this.listViewPictures);
            this.Controls.Add(this.comboBoxParents);
            this.Controls.Add(this.labelParent);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddCategory";
            this.Text = "Добавление категории";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.ComboBox comboBoxParents;
        private System.Windows.Forms.ListView listViewPictures;
        private System.Windows.Forms.Label labelPicture;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLoadPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}