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
    public partial class FormPreference : Form
    {
        public FormPreference()
        {
            InitializeComponent();
        }

        private void FormPreference_Load(object sender, EventArgs e)
        {
            dataGridViewConfigs.Rows.Clear();
            foreach (KeyValuePair<string, string> entry in Common.configs)
            {
                dataGridViewConfigs.Rows.Add(entry.Key, entry.Value);
            }
        }
    }
}
