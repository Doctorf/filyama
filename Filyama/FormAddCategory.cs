using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Filyama
{
    public partial class FormAddCategory : Form
    {
        public Category categoryLocal;
        private ImageList images;

        public FormAddCategory(ImageList source)
        {
            InitializeComponent();
            images = source;
            categoryLocal = new Category();
            comboBoxParents.Items.Clear();
            comboBoxParents.Items.Add("-----");
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM category";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                       comboBoxParents.Items.Add(r["name"].ToString());
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            comboBoxParents.SelectedIndex = 0;
            listViewPictures.LargeImageList = images;
            listViewPictures.SmallImageList = images;
            /* Reserved images
             * 0 - folder
             * */
            for (int i = 1; i < images.Images.Count; i++)
            {
                listViewPictures.Items.Add(new ListViewItem { ImageIndex = i });
            }
        }

        private void buttonLoadPicture_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr==DialogResult.OK) {
                byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
                Image image = Image.FromFile(openFileDialog1.FileName);
                images.Images.Add(image);
                int index = images.Images.Count;
                SQLiteCommand command = Common.connectionLocal.CreateCommand();
                command.CommandText = "INSERT INTO category_images (value) VALUES (@image)";                
                command.Parameters.Add("@image", DbType.Binary, data.Length).Value = data;
                command.ExecuteNonQuery();
                for (int i = 0; i < listViewPictures.Items.Count; i++)
                {
                    listViewPictures.Items[i].Selected = false;
                }
                listViewPictures.Items.Add(new ListViewItem { ImageIndex = index - 1 }).Selected = true;
                listViewPictures.Select();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            categoryLocal.name = textBoxName.Text;
            categoryLocal.idParent = comboBoxParents.SelectedIndex;
        }
    }
}
