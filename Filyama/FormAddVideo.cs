﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Filyama
{
    public partial class FormAddVideo : Form
    {
        public static List<Media> medias = Database.getMediaExtensions();
        public String coverURL;
        public Film editFilma;
        public Boolean newFilm = false;

        public FormAddVideo()
        {
            InitializeComponent();
            newFilm = true;
        }

        public FormAddVideo(Film editFilm)
        {
            InitializeComponent();
            this.Text = "Редактирование фильма";
            editFilma = editFilm;
        }
        void FillChildNodes(TreeNode node)
        {
            try
            {
                DirectoryInfo dirs = new DirectoryInfo(node.FullPath);
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    TreeNode newnode = new TreeNode(dir.Name);
                    node.Nodes.Add(newnode);
                    FillChildNodes(newnode);
                }
                foreach (FileInfo file in dirs.GetFiles())
                {
                    int mediaB = -1;
                    for (int i=0;i<medias.Count;i++)                        
                    {
                        Media media = medias[i];
                        foreach (String mediaFilter in media.filter.Split(','))
                        {
                            if (string.Equals(file.Extension, mediaFilter, StringComparison.CurrentCultureIgnoreCase))
                            {
                                mediaB = i;
                            }
                        }
                    }
                    if (mediaB!=-1)
                    {
                        TreeNode newnode = new TreeNode(file.Name);
                        newnode.Tag = mediaB;
                        node.Nodes.Add(newnode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void buttonCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecursiveAddMedia(TreeNode node,Boolean rootNode,List<BinaryData> files,String path)
        {
            if (files == null) files = new List<BinaryData>();
            String newpath = "";
            if (node.Tag != null)
            {
                BinaryData data = new BinaryData();
                data.foto = medias[Convert.ToInt32(node.Tag)].foto;
                data.name = node.Text;
                data.path = path + "\\" + node.Text;
                data.fullpath = node.FullPath;                
                files.Add(data);
            }
            foreach (TreeNode newNode in node.Nodes)
            {
                if (!rootNode)
                {
                    newpath = path + "\\" + node.Text;
                }
                RecursiveAddMedia(newNode,false,files,newpath);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (vistaFolderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                TreeNode rootnode = new TreeNode(vistaFolderBrowserDialog.SelectedPath);
                //TreeNode rootnode = new TreeNode(textBoxFullPath.Text);
                treeView1.Nodes.Add(rootnode);
                FillChildNodes(rootnode);
                treeView1.ExpandAll();
                textBoxFullPath.Text = vistaFolderBrowserDialog.SelectedPath;
                List<BinaryData> files = new List<BinaryData>();
                RecursiveAddMedia(treeView1.Nodes[0],true,files,"");
                dataGridViewFiles.Rows.Clear();
                foreach (BinaryData s in files)
                {
                    bool frame = s.foto;
                    bool media = !s.foto;
                    dataGridViewFiles.Rows.Add(s, null, false, media, frame, false);
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void RefreshCategories()
        {
            Database.RefreshCategory();
           
                checkedListBoxCategory.Items.Clear();
                foreach (KeyValuePair<int, Category> category in Common.categoryList)
                {
                    Boolean find = false;
                    if (editFilma.id != 0 && editFilma.categories != null)
                    {
                        find = editFilma.categories.Contains(category.Key);
                    }
                    checkedListBoxCategory.Items.Add(category.Value, find);
                }            
        }

        private void RefreshCategories(List<String> newCategories)
        {
            Database.RefreshCategory();

            checkedListBoxCategory.Items.Clear();
            foreach (KeyValuePair<int, Category> category in Common.categoryList)
            {
                Boolean find = false;
                if (newCategories != null)
                {
                    find = newCategories.Contains(category.Value.name);
                }
                checkedListBoxCategory.Items.Add(category.Value, find);
            }
        }
        private void FormAddVideo_Load(object sender, EventArgs e)
        {
            checkedListBoxCategory.Items.Clear();
            if (editFilma.id ==0)
            {
                textBoxNumber.Text = Convert.ToString(Database.NewFilms());
            }
            else
            {
                textBoxNumber.Text = editFilma.id.ToString();
                textBoxNameOrig.Text = editFilma.nameOrig;
                textBoxNameRus.Text = editFilma.nameRus;
                if (editFilma.dateWorld != default(DateTime))
                {
                    dateTimePickerDateWorld.Value = editFilma.dateWorld;
                }
                if (editFilma.dateRus!= default(DateTime))
                {
                    dateTimePickerDateRus.Value = editFilma.dateRus;
                }
                if (editFilma.coverURL != null)
                {
                    LoadCover(Application.StartupPath + "\\" + editFilma.coverURL);
                }
                editFilma.mediafiles = Database.GetMediaDataByFilmId(editFilma.id);
                for(int i=0;i<editFilma.mediafiles.Count;i++) {
                    dataGridViewFiles.Rows.Add(editFilma.mediafiles[i], null, editFilma.mediafiles[i].isCover, null, editFilma.mediafiles[i].isFrame, editFilma.mediafiles[i].isThumbnails);
                }
            }
            RefreshCategories();
            vistaFolderBrowserDialog.SelectedPath = Common.configs["main_server"];
        }

        private String CopyImage(String sourceURL,int filmId, bool cover,out string destFileNameCommonOut,bool replace = true)
        {
            String destFileName = null; ;
            if (cover)
            {
                destFileName = "cover" + Path.GetExtension(sourceURL);
            }
            else
            {
                destFileName = Path.GetFileName(sourceURL);
            }
            String CommonPath=Common.imagesPath + "\\" + Convert.ToString(filmId) + "\\";
            destFileNameCommonOut = CommonPath + destFileName;
            String destPath = Application.StartupPath + CommonPath;
            String destFullPath = destPath + destFileName;
            destFullPath = destFullPath.Replace("\\\\", "\\").Trim();
            if (sourceURL == null || !System.IO.File.Exists(sourceURL) && sourceURL.Equals(destFullPath))
                return null;
            if (!System.IO.Directory.Exists(destPath))
            {
                System.IO.Directory.CreateDirectory(destPath);
            }
            System.IO.File.Copy(sourceURL, destFullPath, replace);
            return destFullPath;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Film newFilma = new Film();
            newFilma.id = Convert.ToInt32(textBoxNumber.Text);
            newFilma.nameOrig = textBoxNameOrig.Text;
            newFilma.nameRus = textBoxNameRus.Text;
            newFilma.dateWorld = dateTimePickerDateWorld.Value;
            newFilma.dateRus = dateTimePickerDateRus.Value;
            String destPath = null;
            CopyImage(coverURL, newFilma.id, true,out destPath);
            if (destPath!=null)
            {
                long coverId = Database.AddBinaryData(destPath, false, false, true);
                newFilma.coverId = coverId;
            }            
            //--------Категории фильма
            newFilma.categories=new List<int>();            
            foreach (object itemChecked in checkedListBoxCategory.CheckedItems)
            {
                Category category = (Category)itemChecked;
                newFilma.categories.Add(category.id);
            }
            //-------Медиа файлы
            newFilma.mediafiles = new List<MediaData>();
            for (int i = 0; i < dataGridViewFiles.Rows.Count;i++ )
            {
                BinaryData data = (BinaryData)dataGridViewFiles.Rows[i].Cells[0].Value;
                Boolean cover = (Boolean)dataGridViewFiles.Rows[i].Cells[2].Value;
                Boolean frame = (Boolean)dataGridViewFiles.Rows[i].Cells[4].Value;
                Boolean thumbnails = (Boolean)dataGridViewFiles.Rows[i].Cells[5].Value;
                if (!data.foto)
                {
                    long mediaId = Database.AddMediaFile(data.path);
                    //newFilma.mediafiles.Add(mediaId);
                }
                else
                {
                    if (!cover&&(frame||thumbnails))
                    {
                        String filePath = null;
                        CopyImage(data.fullpath, newFilma.id, false, out filePath);
                        long mediaId = Database.AddBinaryData(filePath, thumbnails, frame, cover);
                        //newFilma.mediafiles.Add(mediaId);
                    }
                }
            }
            if (newFilm)
            {
                Database.AddFilm(newFilma);
            }
            else
            {
                Database.UpdateFilm(editFilma, newFilma);
            }
        }

        private void listBoxFiles_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (listBoxFiles.Items.Count == 0)
                return;

            int index = listBoxFiles.IndexFromPoint(e.X, e.Y);
            BinaryData s = (BinaryData)listBoxFiles.Items[index];
            if (s.foto)
            {
                DragDropEffects dde1 = DoDragDrop(s.fullpath,
                    DragDropEffects.All);
                listBoxFiles.Items.RemoveAt(index);
            }
            else return;*/
        }

        private void pictureBoxImage_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(
                    DataFormats.StringFormat);
                LoadCover(str);
            }
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void LoadCover(String filename)
        {
            coverURL = filename;
            try
            {
                if (File.Exists(filename))
                {
                    pictureBoxImage.Load(filename);                    
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void buttonLoadCover_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                LoadCover(openFileDialogImage.FileName);                
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            if (DialogResult.OK==search.ShowDialog())
            {
                textBoxNameOrig.Text = search.originTitle;
                textBoxNameRus.Text = search.rusTitle;
                dateTimePickerDateWorld.Value = search.dateWorld;
                dateTimePickerDateRus.Value = search.dateRus;
                foreach (int i in checkedListBoxCategory.CheckedIndices)
                {
                    checkedListBoxCategory.SetItemCheckState(i, CheckState.Unchecked);
                }
                foreach (String newCategory in search.genres)
                {
                    int findCategory = -1; int index = -1;
                    foreach (object itemChecked in checkedListBoxCategory.Items)
                    {
                        Category category = (Category)itemChecked; index++;
                        if (newCategory.Equals(category.name))
                        {
                            findCategory = category.id; break;
                        }
                    }
                    if (findCategory == -1)
                    {
                        long idCategory=Database.AddCategory(newCategory, -1, Common.indexElement);                      
                    };
                }
                listViewCast.Clear(); imageListPerson.Images.Clear(); int ind = 0;
                foreach (Cast cast in search.casts)
                {
                    Person people = cast.person;
                    people.id=Database.FindPerson(people);
                    if (people.id==-1)
                    {
                        people.id = Database.AddPerson(people);
                    }
                    Cast newCast = new Cast();
                    newCast.person = people;
                    newCast.character = cast.character;
                    if (people.image != null)
                    {
                        imageListPerson.Images.Add(people.image);
                    }
                    listViewCast.Items.Add(newCast.ToString(), ind++);
                }
                LoadCover(search.coverURL);
                addBinaryFile(null, search.coverURL, true);
                RefreshCategories(search.genres);
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void dataGridViewFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                BinaryData data = (BinaryData)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                Process.Start(data.fullpath);
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                int selCheckBox = e.ColumnIndex;
                for (int i = 2; i < senderGrid.Columns.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = senderGrid.Rows[e.RowIndex].Cells[i] as DataGridViewCheckBoxCell;
                    chk.Value = false;
                }
                DataGridViewCheckBoxCell chkSel = senderGrid.Rows[e.RowIndex].Cells[selCheckBox] as DataGridViewCheckBoxCell;
                chkSel.Value = true;
                if (e.ColumnIndex == 2)
                {
                    BinaryData data = (BinaryData)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    LoadCover(data.fullpath);
                }
            }
        }

        private void addBinaryFile(String path, String fullpath,Boolean cover=false)
        {
            int mediaB = -1;
            for (int i = 0; i < medias.Count; i++)
            {
                Media media = medias[i];
                foreach (String mediaFilter in media.filter.Split(','))
                {
                    if (string.Equals(Path.GetExtension(fullpath), mediaFilter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        mediaB = i;
                    }
                }
            }
            if (mediaB != -1)
            {
                BinaryData data = new BinaryData();
                data.foto = medias[mediaB].foto;
                data.name = Path.GetFileName(fullpath);
                if (path != null)
                {
                    data.path = path;    
                }
                else
                {
                    data.path = data.name;
                }
                data.fullpath = fullpath;
                bool frame = data.foto&&!cover;
                bool media = !data.foto;
                dataGridViewFiles.Rows.Add(data, null, cover, media, frame, false);
            }
        }
        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            vistaOpenFileDialog.InitialDirectory = vistaFolderBrowserDialog.SelectedPath;
            if (vistaOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                addBinaryFile(null, vistaOpenFileDialog.FileName);
            }
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            if (vistaFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                TreeNode rootnode = new TreeNode(vistaFolderBrowserDialog.SelectedPath);
                //TreeNode rootnode = new TreeNode(textBoxFullPath.Text);
                treeView1.Nodes.Add(rootnode);
                FillChildNodes(rootnode);
                treeView1.ExpandAll();
                textBoxFullPath.Text = vistaFolderBrowserDialog.SelectedPath;
                List<BinaryData> files = new List<BinaryData>();
                RecursiveAddMedia(treeView1.Nodes[0], true, files, "");
                dataGridViewFiles.Rows.Clear();
                foreach (BinaryData s in files)
                {
                    bool frame = s.foto;
                    bool media = !s.foto;
                    dataGridViewFiles.Rows.Add(s, null, false, media, frame, false);
                }
            }
        }
    }
}
