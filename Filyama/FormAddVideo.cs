using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void RecursiveAddMedia(TreeNode node, List<BinaryData> files,String path)
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
                newpath = path + "\\" + node.Text;
                files.Add(data);
            }
            foreach (TreeNode newNode in node.Nodes)
            {
                RecursiveAddMedia(newNode, files,newpath);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
                treeView1.Nodes.Clear();
                //TreeNode rootnode = new TreeNode(folderBrowserDialog1.SelectedPath);
                TreeNode rootnode = new TreeNode(textBoxFullPath.Text);
                treeView1.Nodes.Add(rootnode);
                FillChildNodes(rootnode);
                treeView1.ExpandAll();
                //textBoxFullPath.Text = folderBrowserDialog1.SelectedPath;
                List<BinaryData> files = new List<BinaryData>();
                RecursiveAddMedia(treeView1.Nodes[0], files,"");
                listBoxFiles.Items.Clear();
                foreach (BinaryData s in files)
                {
                    listBoxFiles.Items.Add(s);
                }
            //}
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

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
            }

            foreach (KeyValuePair<int, Category> category in Common.categoryList)
            {
                Boolean find = false;
                if (editFilma.id != 0 && editFilma.categories != null)
                {
                    find=editFilma.categories.Contains(category.Key);
                }
                checkedListBoxCategory.Items.Add(category.Value,find);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Film newFilma = new Film();
            newFilma.id = Convert.ToInt32(textBoxNumber.Text);
            newFilma.nameOrig = textBoxNameOrig.Text;
            newFilma.nameRus = textBoxNameRus.Text;
            newFilma.dateWorld = dateTimePickerDateWorld.Value;
            newFilma.dateRus = dateTimePickerDateRus.Value;
            String destPath = Common.imagesPath + "\\" + newFilma.id.ToString() + "\\" + "cover" + Path.GetExtension(coverURL);
            string destFile = System.IO.Path.Combine(Application.StartupPath+Common.imagesPath+"\\"+newFilma.id.ToString(), "cover"+Path.GetExtension(coverURL));
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(Application.StartupPath + Common.imagesPath + "\\" + newFilma.id.ToString()))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + Common.imagesPath + "\\" + newFilma.id.ToString());
            }
            if (coverURL != null)
            {
                System.IO.File.Copy(coverURL, destFile, true);
                long coverId = Database.AddBinaryData(destPath, false, false, true);
                newFilma.coverId = coverId;
            }            
            newFilma.categories=new List<int>();            
            foreach (object itemChecked in checkedListBoxCategory.CheckedItems)
            {
                Category category = (Category)itemChecked;
                newFilma.categories.Add(category.id);
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
            if (listBoxFiles.Items.Count == 0)
                return;

            int index = listBoxFiles.IndexFromPoint(e.X, e.Y);
            BinaryData s = (BinaryData)listBoxFiles.Items[index];
            if (s.foto)
            {
                DragDropEffects dde1 = DoDragDrop(s.fullpath,
                    DragDropEffects.All);
            }
            else return;
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
            pictureBoxImage.Load(filename);
        }
        private void buttonLoadCover_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                LoadCover(openFileDialogImage.FileName);                
            }
        }
    }
}
