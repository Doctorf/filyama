using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Filyama
{
    public partial class Form1 : Form
    {        
        public void RefreshCategory()
        {
            //Добавление Категорий
            treeCategory.Nodes.Clear();
            TreeNode mainNode = treeCategory.Nodes.Add("Все категории");            
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM category";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        Category categoryVar = new Category();
                        categoryVar.id = Convert.ToInt32(r["id"]);
                        categoryVar.name = Convert.ToString(r["name"]);
                        categoryVar.idImage = Convert.ToInt32(r["id_image"]);
                        if (r["id_parent"] != DBNull.Value)
                        {
                            categoryVar.idParent = Convert.ToInt32(r["id_parent"]);
                        }
                        TreeNode node=mainNode.Nodes.Add(categoryVar.name);
                        node.Tag = categoryVar;                        
                        node.ImageIndex = Common.imageCategoryList[categoryVar.idImage];
                        node.SelectedImageIndex = node.ImageIndex;
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                mainNode.Expand();
            }
        }

        public void RefreshCategoryImages()
        {
            imageListCategory.Images.Clear(); Common.imageCategoryList.Clear();
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM category_images";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        byte[] data = (byte[])r["value"];
                        Common.imageCategoryList.Add(Convert.ToInt32(r["id"]), imageListCategory.Images.Count);
                        imageListCategory.Images.Add(Common.byteArrayToImage(data));
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Form1()
        {
            InitializeComponent(); Common.imageCategoryList = new Dictionary<int, int>();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("Filyama - {0}", version);            
            Common.connectionLocal = new SQLiteConnection("Data Source=main.db; Version=3;");
            try
            {
                Common.connectionLocal.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Инициализация соединения с локальной базой
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                /*string sql_command_create = "DROP TABLE IF EXISTS films;"
                  + "CREATE TABLE films("
                  + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                  + "name TEXT); ";*/
                /*string sql_command_create = "DROP TABLE IF EXISTS category;"
                  + "CREATE TABLE category("
                  + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                  + "name TEXT,"
                  + "id_parent INTEGER); "
                  + "INSERT INTO category(name) VALUES('Боевик');";
                cmd.CommandText = sql_command_create;
                cmd.ExecuteNonQuery();*/
                /*string sql_command_create = "DROP TABLE IF EXISTS category_images;"
                  + "CREATE TABLE category_images("
                  + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                  + "value BLOB);";                  
                cmd.CommandText = sql_command_create;
                cmd.ExecuteNonQuery();*/
                /*string sql_command_create = "DROP TABLE IF EXISTS category_films;"
                  + "CREATE TABLE category_films("
                  + "id_films INTEGER, "
                  + "id_category INTEGER,"
                  + "FOREIGN KEY(id_films) REFERENCES films(id),"
                  + " FOREIGN KEY(id_category) REFERENCES category(id));"
                  + "INSERT INTO category_films VALUES(1,1)";
                cmd.CommandText = sql_command_create;
                cmd.ExecuteNonQuery();*/
                string sql_command = "SELECT * FROM films;";
                cmd.CommandText = sql_command;
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();                    
                    while (r.Read())
                    {
                        dataGridViewFilms.Rows.Add(null, null, r["id"].ToString(), r["name"]);
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                RefreshCategoryImages();
                RefreshCategory();               
            }            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.connectionLocal.Dispose();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory=new FormAddCategory(imageListCategory);
            DialogResult dr = formAddCategory.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("Create");
                //Добавление Категорий
                if (Common.connectionLocal.State == ConnectionState.Open)
                {
                    Category categoryGlobal = formAddCategory.categoryLocal;
                    SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                    cmd.CommandText = "INSERT INTO category(name,id_parent) VALUES(@name,@id_parent)";
                    cmd.Parameters.AddWithValue("@name",categoryGlobal.name);
                    cmd.Parameters.AddWithValue("@id_parent", categoryGlobal.idParent);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                RefreshCategory();
            }
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory = new FormAddCategory(imageListCategory);
            DialogResult dr = formAddCategory.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("Update");
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            TreeNode node = treeCategory.SelectedNode;
            Category categoryVar = (Category)node.Tag;
            DialogResult dr=MessageBox.Show(String.Format("Remove '{0}' category?",categoryVar.name));
            if (dr == DialogResult.OK)
            {
                if (Common.connectionLocal.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                    cmd.CommandText = "DELETE FROM category WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", categoryVar.id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                RefreshCategory();
            }
        }
    }
}
