using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Microsoft.Win32;

namespace Filyama
{
    public partial class Form1 : Form
    {
        public void RefreshCategory()
        {
            //Добавление Категорий
            treeCategory.Nodes.Clear(); Database.RefreshCategory();
            TreeNode mainNode = treeCategory.Nodes.Add("Все категории");
            foreach (var categoryVarElem in Common.categoryList)
            {
                Category categoryVar = categoryVarElem.Value;
                TreeNode node = mainNode.Nodes.Add(categoryVar.name);
                node.Tag = categoryVar;
                if (categoryVar.idImage != -1)
                {
                    node.ImageIndex = Common.imageCategoryList[categoryVar.idImage];
                    node.SelectedImageIndex = node.ImageIndex;
                }
            }
            mainNode.Expand();           
        }

        public void RefreshCategoryImages()
        {
            Database.RefreshCategoryImages();
            imageListCategory.Images.Clear();
            for (int i = 0; i < Common.imageCategoryList.Count; i++)
            {
                imageListCategory.Images.Add(Common.byteArrayToImage(Common.imageCategoryListData[i]));
            }                            
        }

        public void RefreshFilms()
        {
            Boolean filterCategory = false; dataGridViewFilms.Rows.Clear(); Common.films.Clear();
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                TreeNode node = treeCategory.SelectedNode;
                int indexCategory=-1;
                if (node != null && node.Tag != null)
                {
                    Category categoryVar = (Category)node.Tag;
                    if (categoryVar.id != 0)
                    {
                        filterCategory = true;
                        indexCategory = categoryVar.id;
                    }                    
                }
                string sql_command = "SELECT * FROM films;";
                if (filterCategory)
                {
                    sql_command = "SELECT DISTINCT f.* FROM films f LEFT JOIN category_films cf ON cf.id_films=f.id WHERE cf.id_category=@id_category;";
                }                
                cmd.CommandText = sql_command;
                if (filterCategory)
                {
                    cmd.Parameters.AddWithValue("@id_category", indexCategory);
                }
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int idFilms = Convert.ToInt32(r["id"]); byte[] imageFilms = null, coverFilms = null; Film selectFilm = new Film(); String categories = "";
                        //-----------Жанры
                        selectFilm.categories = new List<int>();
                        string sql_command_detail = "SELECT * FROM category_films cf LEFT JOIN category c ON c.id=cf.id_category WHERE id_films=@id_films;";
                        SQLiteCommand cmd_detail = Common.connectionLocal.CreateCommand();
                        cmd_detail.CommandText = sql_command_detail;
                        cmd_detail.Parameters.AddWithValue("@id_films", idFilms);
                        try
                        {
                            SQLiteDataReader reader_detail = cmd_detail.ExecuteReader();
                            while (reader_detail.Read())
                            {
                                categories += Convert.ToString(reader_detail["name"])+", ";
                                selectFilm.categories.Add(Convert.ToInt32(reader_detail["id"]));
                                if (reader_detail["id_image"] != DBNull.Value)
                                {
                                    int idImage = Common.imageCategoryList[Convert.ToInt32(reader_detail["id_image"])];
                                    //MessageBox.Show(imageListCategory.Images[idImage].Width + "x" + imageListCategory.Images[idImage].Height);
                                    imageFilms = Common.imageToByteArray(imageListCategory.Images[idImage]);
                                }
                            }
                            reader_detail.Close();
                        }
                        catch (SQLiteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        if (!categories.Equals("")) categories = categories.Substring(0, categories.Length - 2);
                        selectFilm.categoriesString = categories;
                        //-----------Обложка

                        if (r["id_cover"] != DBNull.Value)
                        {
                            coverFilms = Common.imageToByteArray(imageListCategory.Images[2]);
                            selectFilm.coverId = Convert.ToInt32(r["id_cover"]);
                            string sql_command_detail_cover = "SELECT url FROM binary_data WHERE id=@id;";
                            SQLiteCommand cmd_detail_cover = Common.connectionLocal.CreateCommand();
                            cmd_detail_cover.CommandText = sql_command_detail_cover;
                            cmd_detail_cover.Parameters.AddWithValue("@id", selectFilm.coverId);
                            try
                            {
                                selectFilm.coverURL = Convert.ToString(cmd_detail_cover.ExecuteScalar());
                            }
                            catch (SQLiteException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            coverFilms = Common.imageToByteArray(imageListCategory.Images[1]);
                        }
                        selectFilm.nameRus=Convert.ToString(r["name_rus"]);
                        selectFilm.nameOrig = Convert.ToString(r["name_orig"]);
                        selectFilm.id=Convert.ToInt32(r["id"]);
                        if (r["date_world"] != DBNull.Value)
                        {
                            selectFilm.dateWorld = Convert.ToDateTime(r["date_world"]);
                        } 
                        if (r["date_rus"] != DBNull.Value)
                        {
                            selectFilm.dateRus = Convert.ToDateTime(r["date_rus"]);
                        }
                        Common.films.Add(selectFilm.id, selectFilm);
                        dataGridViewFilms.Rows.Add(imageFilms, coverFilms, selectFilm.id,selectFilm.nameRus );
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CreateFolders()
        {            
            System.IO.Directory.CreateDirectory(Application.StartupPath+Common.imagesPath);            
        }
        private void AddBrowser()
        {
            String filename=System.Reflection.Assembly.GetExecutingAssembly().GetName().Name+".exe";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                if (key != null)
                {
                    key.SetValue(filename, 11001, RegistryValueKind.DWord);
                }

                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                if (key != null)
                {
                    key.SetValue(filename, 11001, RegistryValueKind.DWord);
                }
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 

        public Form1()
        {
            InitializeComponent();
            CreateFolders();
            AddBrowser();
            Common.imageCategoryList = new Dictionary<int, int>();
            Common.imageCategoryListData = new Dictionary<int, byte[]>();
            Common.films = new Dictionary<int, Film>();
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
                //SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
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
            }
            RefreshCategoryImages();
            RefreshCategory();
            RefreshFilms();
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
                RefreshCategoryImages();
                //Добавление Категорий
                if (Common.connectionLocal.State == ConnectionState.Open)
                {
                    Category categoryGlobal = formAddCategory.categoryLocal;
                    SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                    cmd.CommandText = "INSERT INTO category(name,id_parent,id_image) VALUES(@name,@id_parent,@id_image)";
                    cmd.Parameters.AddWithValue("@name",categoryGlobal.name);
                    if (categoryGlobal.idParent != -1)
                    {
                        cmd.Parameters.AddWithValue("@id_parent", categoryGlobal.idParent);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id_parent", null);
                    }
                    cmd.Parameters.AddWithValue("@id_image", categoryGlobal.idImage);
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
            TreeNode node = treeCategory.SelectedNode;
            if (node!=null && node.Tag!=null) {
                Category categoryVar = (Category)node.Tag;
                FormAddCategory formAddCategory = new FormAddCategory(categoryVar,imageListCategory);
                DialogResult dr = formAddCategory.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("Update");
                    if (Common.connectionLocal.State == ConnectionState.Open)
                    {
                        Category categoryGlobal = formAddCategory.categoryLocal;
                        SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                        cmd.CommandText = "UPDATE category SET name=@name,id_parent=@id_parent,id_image=@id_image WHERE id=@id;";
                        cmd.Parameters.AddWithValue("@id", categoryGlobal.id);
                        cmd.Parameters.AddWithValue("@name", categoryGlobal.name);
                        if (categoryGlobal.idParent != -1)
                        {
                            cmd.Parameters.AddWithValue("@id_parent", categoryGlobal.idParent);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id_parent", null);
                        }
                        cmd.Parameters.AddWithValue("@id_image", categoryGlobal.idImage);
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

        private void treeCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshFilms();
        }

        private void toolStripButtonElementAdd_Click(object sender, EventArgs e)
        {
            FormAddVideo addVideo = new FormAddVideo();
            if (addVideo.ShowDialog()==DialogResult.OK)
            {
                RefreshFilms();
            }
        }

        public static String ChangeTemplate(String input,Film selectFilm)
        {
            input = input.Replace("${films.title}", selectFilm.nameRus);
            input = input.Replace("${films.title_orig}", selectFilm.nameOrig);
            input = input.Replace("${films.cover}", Application.StartupPath+"\\"+selectFilm.coverURL);
            input = input.Replace("${films.categorys}", selectFilm.categoriesString);
            input = input.Replace("${films.year}", selectFilm.dateWorld.Year.ToString());
            input = input.Replace("${films.dateWorld}", selectFilm.dateWorld.ToString("dd-MM-yyyy"));
            input = input.Replace("${films.dateRus}", selectFilm.dateWorld.ToString("dd-MM-yyyy"));
            input = input.Replace("${films.dateRus}", selectFilm.dateWorld.ToString("dd-MM-yyyy"));
            input = input.Replace("${films.director}", "Режисер");
            input = input.Replace("${films.time}", "100 минут");
            String output = input;
            return output;
        }
        public static String AddCss(String input)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Application.StartupPath + "\\Templates\\Default\\" + "style.css");
            string style = reader.ReadToEnd();
            reader.Close();
            input = input.Replace("${html.css}", style);            
            return input;
        }
        int curRow = -1;
        private void dataGridViewFilms_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFilms.CurrentRow.Index != curRow)
            {
                curRow = dataGridViewFilms.CurrentRow.Index;
                int idFilm = Convert.ToInt32(dataGridViewFilms.Rows[curRow].Cells[2].Value);
                if (idFilm != 0)
                {
                    string template = System.IO.File.ReadAllText(Application.StartupPath + "\\Templates\\Default\\" + "Window_Film.html");
                    webBrowser1.DocumentText = AddCss(ChangeTemplate(template,Common.films[idFilm]));
                }
            }
            
        }

        private void toolStripButtonElementRemove_Click(object sender, EventArgs e)
        {
            String Message = "Вы действительно хотите удалить {0} \"{1}\"?";
            switch (tabControl1.SelectedIndex)
            {
                case 0: {
                    int idFilm = Convert.ToInt32(dataGridViewFilms.Rows[curRow].Cells[2].Value);
                    Message = String.Format(Message, "фильм", Common.films[idFilm]);
                    if (MessageBox.Show(Message, "Удаление фильма", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Database.DeleteFilm(Common.films[idFilm]);
                        RefreshFilms();
                    }
                }break;
            }
        }

        private void toolStripButtonElementEdit_Click(object sender, EventArgs e)
        {
            int idFilm = Convert.ToInt32(dataGridViewFilms.Rows[curRow].Cells[2].Value);
                if (idFilm != 0)
                {
                    FormAddVideo editVideo = new FormAddVideo(Common.films[idFilm]);
                    editVideo.ShowDialog();
                    RefreshCategory();
                    RefreshFilms();
                }
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            FormSearch fromSearch = new FormSearch();
            fromSearch.ShowDialog();
        }
    }
}
