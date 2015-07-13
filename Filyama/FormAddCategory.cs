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
             * 1 - cross
             * 2 - check
             * 3 - element
             * */
            for (int i = 4; i < images.Images.Count; i++)
            {
                listViewPictures.Items.Add(new ListViewItem { ImageIndex = i });
            }
        }

        public FormAddCategory(Category categoryGlobal, ImageList source)
        {
            InitializeComponent();
            images = source;
            categoryLocal = categoryGlobal;
            comboBoxParents.Items.Clear();
            comboBoxParents.Items.Add("-----"); bool findParent = false;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM category";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int index=comboBoxParents.Items.Add(r["name"].ToString());
                        if (Convert.ToInt32(r["id"]) == categoryLocal.idParent)
                        {
                            comboBoxParents.SelectedIndex = index;
                            findParent = true;
                        }
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (!findParent)
            {
                comboBoxParents.SelectedIndex = 0;
            }
            listViewPictures.LargeImageList = images;
            listViewPictures.SmallImageList = images;
            int indexImage=-1;
            if (Common.imageCategoryList.ContainsKey(categoryLocal.idImage))
            {
                indexImage = Common.imageCategoryList[categoryLocal.idImage];
            }
            for (int i = 3; i < images.Images.Count; i++)
            {
                ListViewItem item=listViewPictures.Items.Add(new ListViewItem { ImageIndex = i });                
                if (i == indexImage)
                {
                    item.Selected = true;
                }
            }
            listViewPictures.Select();
            textBoxName.Text = categoryLocal.name;
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
                Database.RefreshCategoryImages();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            categoryLocal.name = textBoxName.Text;
            if (comboBoxParents.SelectedIndex == 0)
            {
                categoryLocal.idParent = -1;
            }
            else
            {
                categoryLocal.idParent = comboBoxParents.SelectedIndex;
            }
            var indices = listViewPictures.SelectedIndices;
            int imageIndex = listViewPictures.Items[indices[0]].ImageIndex;
            categoryLocal.idImage = Common.imageCategoryList.FirstOrDefault(x => x.Value == imageIndex).Key;
        }
    }
}
