using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Web;

using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Movies;
namespace Filyama
{
    public partial class FormSearch : Form
    {
        public String originTitle = "";
        public String rusTitle;
        public DateTime dateWorld;
        public DateTime dateRus;
        public List<String> genres = new List<string>();
        public String coverURL = "";

        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFilms(textBoxNameSearch.Text);      
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (dataGridViewFindingFilms.SelectedCells.Count > 0)
         {
             int selectedrowindex = dataGridViewFindingFilms.SelectedCells[0].RowIndex;

             DataGridViewRow selectedRow = dataGridViewFindingFilms.Rows[selectedrowindex];  

              string uri = Convert.ToString(selectedRow.Cells[2].Value);
              LoadFilm(uri);
              tabControl1.SelectedIndex = 1;

         }
            
        }

        private void LoadFilm(String id)
        {
            TMDbClient client = new TMDbClient(APIKeys.theMovieDB);
            client.GetConfig();
            Movie movie = client.GetMovie(id, "ru");

            Console.WriteLine("Movie name: {0}", movie.Title);
            textBoxTitleOrigin.Text = movie.OriginalTitle;
            textBoxTitleRus.Text = movie.Title;
            dateTimePickerDateWorld.Value = movie.ReleaseDate ?? default(DateTime);
            foreach (Genre genre in movie.Genres)
            {
                checkedListBox1.Items.Add(Common.format(genre.Name),true);
            }
            //String ut= client.Config.Images.PosterSizes.First();
            //String path = movie.PosterPath;
            
            Uri poster = client.GetImageUrl("original",movie.PosterPath);
            string filename= System.IO.Path.GetFileName(poster.LocalPath);
            String newCover = System.IO.Path.GetTempPath() + "\\" + filename;
            using (var clientPoster = new WebClient())
            {
                clientPoster.DownloadFile(poster, newCover);
                coverURL = newCover;
            }
            pictureBox1.Load(newCover);

        }
        private void LoadFilms(String uri)
        {
            TMDbClient client = new TMDbClient(APIKeys.theMovieDB);
            SearchContainer<SearchMovie> results = client.SearchMovie(uri, "ru");

            Console.WriteLine("Got {0} of {1} results", results.Results.Count, results.TotalResults);
            dataGridViewFindingFilms.Rows.Clear(); checkedListBox1.Items.Clear();
            foreach (SearchMovie result in results.Results){
                Console.WriteLine(result.Title);
                String year = null;
                if (result.ReleaseDate != null)
                {
                    year = result.ReleaseDate.Value.Year.ToString();
                }
                dataGridViewFindingFilms.Rows.Add(year,result.Title,result.Id);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            originTitle = textBoxTitleOrigin.Text;
            rusTitle = textBoxTitleRus.Text;
            dateWorld = dateTimePickerDateWorld.Value;
            dateRus = dateTimePickerDateRus.Value;
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                genres.Add((String)itemChecked);
            }
        }

        private void textBoxNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadFilms(textBoxNameSearch.Text);   
            }
        }
    }
}
