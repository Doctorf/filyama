namespace Filyama
{
    partial class FormPreference
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
            this.dataGridViewConfigs = new System.Windows.Forms.DataGridView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ColumnConfigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfigValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfigs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConfigs
            // 
            this.dataGridViewConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnConfigName,
            this.ColumnConfigValue});
            this.dataGridViewConfigs.Location = new System.Drawing.Point(33, 17);
            this.dataGridViewConfigs.Name = "dataGridViewConfigs";
            this.dataGridViewConfigs.Size = new System.Drawing.Size(520, 319);
            this.dataGridViewConfigs.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(22, 343);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(178, 37);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(220, 342);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(172, 37);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ColumnConfigName
            // 
            this.ColumnConfigName.HeaderText = "Name";
            this.ColumnConfigName.Name = "ColumnConfigName";
            // 
            // ColumnConfigValue
            // 
            this.ColumnConfigValue.HeaderText = "Value";
            this.ColumnConfigValue.Name = "ColumnConfigValue";
            this.ColumnConfigValue.Width = 350;
            // 
            // FormPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 397);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridViewConfigs);
            this.Name = "FormPreference";
            this.Text = "FormPreference";
            this.Load += new System.EventHandler(this.FormPreference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfigs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewConfigs;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfigValue;
    }
}