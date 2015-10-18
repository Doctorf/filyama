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
    public partial class FormAddEpisode : Form
    {
        public int seasonId;
        public FormAddEpisode(int season_id)
        {
            InitializeComponent();
            this.seasonId = season_id;
        }

        private void FormAddEpisode_Load(object sender, EventArgs e)
        {
            textBoxId.Text = Database.NewEpisode().ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Episode newEpisode = new Episode();
            newEpisode.id = Convert.ToInt32(textBoxId.Text);
            newEpisode.name = textBoxName.Text;
            newEpisode.number = Convert.ToInt32(numericUpDownNumber.Value);
            Database.AddEpisode(newEpisode,seasonId);
        }
    }
}
