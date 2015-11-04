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
using System.Diagnostics;

namespace Filyama
{
    public partial class FormAddVideo : Form
    {
        public static List<Media> medias = Database.getMediaExtensions();
        public String coverURL;
        public long coverId;
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

        private void RecursiveAddMedia(String path, List<MediaData> files)
        {
            if (files == null) files = new List<MediaData>();
            DirectoryInfo dirs = new DirectoryInfo(path);
            foreach (DirectoryInfo dir in dirs.GetDirectories())
            {
                RecursiveAddMedia(dir.Name,files);
            }
            foreach (FileInfo file in dirs.GetFiles())
            {
                int mediaB = -1;
                for (int i = 0; i < medias.Count; i++)
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
                if (mediaB != -1)
                {
                    addBinaryFile(file.FullName, file.FullName, false, true);
                }
            }
        }

        private void dataFilesClear()
        {
            for (int i = dataGridViewFiles.Rows.Count - 1; i >= 0; i--)
            {
                MediaData data = (MediaData)dataGridViewFiles.Rows[i].Cells[0].Value;
                if (!data.isSearchable)
                {
                    dataGridViewFiles.Rows.RemoveAt(i);
                }
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (vistaFolderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                TreeNode rootnode = new TreeNode(vistaFolderBrowserDialog.SelectedPath);
                if (textBoxNameOrig.Text.Equals(""))
                {
                    textBoxNameOrig.Text = Path.GetFileName(vistaFolderBrowserDialog.SelectedPath);
                }
                treeView1.Nodes.Add(rootnode);
                FillChildNodes(rootnode);
                treeView1.ExpandAll();
                textBoxFullPath.Text = vistaFolderBrowserDialog.SelectedPath;
                List<BinaryData> files = new List<BinaryData>();
                RecursiveAddMedia(treeView1.Nodes[0],true,files,"");
                dataFilesClear();
                foreach (BinaryData s in files)
                {
                    MediaData data = new MediaData(s);
                    data.isFrame = s.foto;
                    dataGridViewFiles.Rows.Add(data, null, data.isCover, data.isBinaryData(), data.isFrame, data.isThumbnails);
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
                    coverId = editFilma.coverId;
                }
                editFilma.mediafiles = Database.GetMediaDataByFilmId(editFilma.id);
                for(int i=0;i<editFilma.mediafiles.Count;i++) {
                    dataGridViewFiles.Rows.Add(editFilma.mediafiles[i], null, editFilma.mediafiles[i].isCover, editFilma.mediafiles[i].isBinaryData(), editFilma.mediafiles[i].isFrame, editFilma.mediafiles[i].isThumbnails);
                }
                if (editFilma.fullpath != null)
                {
                    TreeNode rootnode = new TreeNode(editFilma.fullpath);
                    treeView1.Nodes.Add(rootnode);
                    FillChildNodes(rootnode);
                    treeView1.ExpandAll();
                }
                textBoxFullPath.Text = editFilma.fullpath;
            }
            RefreshCategories();
            vistaFolderBrowserDialog.SelectedPath = Common.configs["main_server"];
        }

        private String CopyImage(String sourceURL,int filmId, bool cover,out string destFileNameCommonOut,bool replace = true)
        {
            destFileNameCommonOut = null;            
            if (sourceURL == null || !System.IO.File.Exists(sourceURL))
                return null;
            sourceURL = sourceURL.Substring(0,4)+sourceURL.Substring(4).Replace("\\\\", "\\").Trim();
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
            destFullPath = destFullPath.Substring(0, 4) + destFullPath.Substring(4).Replace("\\\\", "\\").Trim();
            if (sourceURL.Equals(destFullPath))
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
            CopyImage(coverURL, newFilma.id, true, out destPath);
            if (destPath != null)
             {
                    if (coverId == 0)
                    {
                        long newCoverId = Database.AddBinaryData(null, destPath, false, false, true);
                        newFilma.coverId = newCoverId;
                    }
                    else
                    {
                        newFilma.coverId = coverId;
                    }
                    
                }            
            if (!textBoxFullPath.Text.Equals(""))
            {
                newFilma.fullpath = textBoxFullPath.Text;
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
                MediaData data = (MediaData)dataGridViewFiles.Rows[i].Cells[0].Value;
                Boolean cover = (Boolean)dataGridViewFiles.Rows[i].Cells[2].Value;
                Boolean binary = (Boolean)dataGridViewFiles.Rows[i].Cells[3].Value;
                Boolean frame = (Boolean)dataGridViewFiles.Rows[i].Cells[4].Value;
                Boolean thumbnails = (Boolean)dataGridViewFiles.Rows[i].Cells[5].Value;
                data.isCover = cover;
                data.isFrame = frame;
                data.isThumbnails = thumbnails;
                if (binary)
                {
                    if (data.id == 0)
                    {
                        int mediaId = 0;
                        if (data.isOther)
                        {
                            mediaId = Database.AddMediaFile(data.fullpath, data.path);
                        }
                        else
                        {
                            mediaId=Database.AddMediaFile(null, data.path);
                        }
                        data.id = mediaId;
                    }
                    newFilma.mediafiles.Add(data);
                }
                else
                {
                    if (!cover&&(frame||thumbnails))
                    {
                        if (data.id == 0)
                        {
                            String filePath = null;
                            CopyImage(data.fullpath, newFilma.id, false, out filePath);
                            int mediaId = Database.AddBinaryData(null, filePath, thumbnails, frame, cover);
                            data.id = mediaId;
                        }                        
                    }
                    if (cover&&newFilma.coverId!=0)
                    {
                        data.id = Convert.ToInt32(newFilma.coverId);
                        data.path = destPath;
                    }
                    if (cover || frame || thumbnails)
                    {
                        newFilma.mediafiles.Add(data);
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
                if (coverId == 0)
                {
                    LoadCover(search.coverURL);
                    addBinaryFile(null, search.coverURL, true, false, true);
                }
                else
                {
                    addBinaryFile(null, search.coverURL, false, false, true);
                }
                
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
                MediaData data = (MediaData)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                if (data.fullpath != null)
                {
                    Process.Start(data.fullpath);
                }
                else
                {
                    if (data.isCover || data.isFrame || data.isThumbnails)
                    {
                        Process.Start(Application.StartupPath + data.path);
                    }
                    else
                    {
                        Process.Start(editFilma.fullpath + data.path);
                    }
                }
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                int selCheckBox = e.ColumnIndex;
                DataGridViewCheckBoxCell chkSel = senderGrid.Rows[e.RowIndex].Cells[selCheckBox] as DataGridViewCheckBoxCell;
                Boolean selectedCell = (bool)chkSel.Value;
                for (int i = 2; i < senderGrid.Columns.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = senderGrid.Rows[e.RowIndex].Cells[i] as DataGridViewCheckBoxCell;
                    chk.Value = false;
                }
                chkSel.Value = true;
                if (e.ColumnIndex == 2&&!selectedCell)
                {
                    for (int j = 0; j < dataGridViewFiles.Rows.Count; j++)
                    {
                        if (j != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell chk_row = senderGrid.Rows[j].Cells[2] as DataGridViewCheckBoxCell;
                            if ((bool)chk_row.Value == true)
                            {
                                DataGridViewCheckBoxCell chk_frame = senderGrid.Rows[j].Cells[4] as DataGridViewCheckBoxCell;
                                chk_frame.Value = true;
                            }
                            chk_row.Value = false;
                        }
                    }
                    BinaryData data = (BinaryData)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    coverId = data.id;
                    if (data.fullpath != null)
                    {
                        LoadCover(data.fullpath);
                    }
                    else
                    {
                        LoadCover(Application.StartupPath + data.path);
                    }
                }
            }
        }

        private void addBinaryFile(String path, String fullpath,Boolean cover=false,Boolean other=false,Boolean search=false)
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
                MediaData mData = new MediaData(data);
                mData.isCover = cover;
                mData.isFrame=data.foto&&!cover;
                mData.isOther = other;
                mData.isSearchable = search;
                dataGridViewFiles.Rows.Add(mData, null, cover, mData.isBinaryData(), mData.isFrame, false);
            }
        }
        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            vistaOpenFileDialog.InitialDirectory = vistaFolderBrowserDialog.SelectedPath;
            if (vistaOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                addBinaryFile(vistaOpenFileDialog.FileName, vistaOpenFileDialog.FileName,false,true);
            }
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            if (vistaFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                List<MediaData> files = new List<MediaData>();
                RecursiveAddMedia(vistaFolderBrowserDialog.SelectedPath, files);                
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                BinaryData data = new BinaryData();
                data.foto = medias[Convert.ToInt32(node.Tag)].foto;
                data.name = node.Text;
                data.path = null;
                data.fullpath = node.FullPath;    
                addBinaryFile(null, data.fullpath);
            }
        }
    }
}
