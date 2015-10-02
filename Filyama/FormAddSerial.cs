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
        private List<Season> seasons = new List<Season>();
        public FormAddSerial()
        {
            InitializeComponent();
        }

        private void refreshTree()
        {
            treeViewSeasons.Nodes.Clear();
            foreach (var season in seasons)
            {
                TreeNode seasonNode = treeViewSeasons.Nodes.Add(season.ToString());
                foreach (var episode in season.episodes)
                {
                    seasonNode.Nodes.Add(episode.ToString());
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Serial newSerial = new Serial();
            newSerial.name = textBoxName.Text;
            newSerial.seasons = seasons;
            Database.AddSerail(newSerial);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            if (search.ShowDialog() == DialogResult.OK)
            {
                textBoxName.Text = search.originTitle;
                pictureBox1.Load(search.coverURL);
                seasons = search.seasons;
                refreshTree();
            }
        }

        private void FormAddSerial_Load(object sender, EventArgs e)
        {
            textBoxId.Text = Database.NewSerial().ToString();
        }
    }
}
