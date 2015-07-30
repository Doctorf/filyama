using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filyama
{
    public partial class FormAddSerial : Form
    {
        public FormAddSerial()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Serial newSerial = new Serial();
            newSerial.name = textBoxName.Text;
            Database.AddSerail(newSerial);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            search.ShowDialog();
        }

        private void FormAddSerial_Load(object sender, EventArgs e)
        {
            textBoxId.Text = Database.NewSerial().ToString();
        }
    }
}
