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
    public partial class FormAddSeason : Form
    {
        private int serialId;

        public FormAddSeason(int serial_id)
        {
            InitializeComponent();
            this.serialId = serial_id;
        }

        private void FormAddSeason_Load(object sender, EventArgs e)
        {
            textBoxId.Text = Database.NewSeason().ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Season newSeason = new Season();
            newSeason.id = Convert.ToInt32(textBoxId.Text);
            newSeason.name = textBoxName.Text;
            newSeason.number = Convert.ToInt32(numericUpDownNumber.Value);
            Database.AddSeason(newSeason,serialId);
        }
    }
}
