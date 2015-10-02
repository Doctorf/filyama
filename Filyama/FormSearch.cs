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
using TMDbLib.Objects.People;
using TMDbLib.Objects.TvShows;


namespace Filyama
{
    public partial class FormSearch : Form
    {
        public String originTitle = "";
        public String rusTitle;
        public DateTime dateWorld;
        public DateTime dateRus;
        public DateTime firstAirDate, lastAirDate;
        public List<String> genres = new List<string>();
        public String coverURL = "";
        public List<Cast> casts = new List<Cast>();
        public List<Season> seasons = new List<Season>();

        public FormSearch()
        {
            InitializeComponent();
        }

        private void Search()
        {
            if (radioButton1.Checked)
            {
                LoadFilms(textBoxNameSearch.Text);
            }
            else
            {
                LoadSerials(textBoxNameSearch.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (dataGridViewFindingFilms.SelectedCells.Count > 0)
         {
             int selectedrowindex = dataGridViewFindingFilms.SelectedCells[0].RowIndex;

             DataGridViewRow selectedRow = dataGridViewFindingFilms.Rows[selectedrowindex];  

              string uri = Convert.ToString(selectedRow.Cells[2].Value);
              if (radioButton1.Checked)
              {
                  LoadFilm(uri);
                  tabControl1.SelectedIndex = 1;
              }
              else
              {
                  LoadSerial(uri);
                  tabControl1.SelectedIndex = 2;
              }

         }
            
        }

        public String getImage(TMDbClient client,String filepath)
        {
            if (filepath != null)
            {
                Uri poster = client.GetImageUrl("original", filepath);
                string filename = System.IO.Path.GetFileName(poster.LocalPath);
                String newFile = System.IO.Path.GetTempPath() + "\\" + filename;
                using (var clientPoster = new WebClient())
                {
                    clientPoster.DownloadFile(poster, newFile);
                }
                return newFile;
            }
            else return null;
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
                checkedListBoxGenreFilm.Items.Add(Common.format(genre.Name),true);
            }
            //String ut= client.Config.Images.PosterSizes.First();
            //String path = movie.PosterPath;
                        
            coverURL = getImage(client, movie.PosterPath);
            pictureBox1.Load(coverURL);

            //----------Cast            
            TMDbLib.Objects.Movies.Credits resp = client.GetMovieCredits(Convert.ToInt32(id));
            listBoxCast.Items.Clear();
            foreach (TMDbLib.Objects.Movies.Cast cast in resp.Cast)
            {                
                Cast newCast = new Cast();
                newCast.character = cast.Character;
                TMDbLib.Objects.People.Person newPerson = client.GetPerson(cast.Id);
                Person person = new Person();
                person.name = newPerson.Name;
                person.birthday = newPerson.Birthday ?? default(DateTime);
                person.ImdbId = newPerson.ImdbId;
                if (newPerson.ProfilePath != null)
                {
                    person.image = Image.FromFile(getImage(client, newPerson.ProfilePath));
                }
                newCast.person = person;
                listBoxCast.Items.Add(newCast);
            }

        }
        private void LoadFilms(String uri)
        {
            TMDbClient client = new TMDbClient(APIKeys.theMovieDB);
            SearchContainer<SearchMovie> results = client.SearchMovie(uri, "ru");

            //Console.WriteLine("Got {0} of {1} results", results.Results.Count, results.TotalResults);
            dataGridViewFindingFilms.Rows.Clear(); checkedListBoxGenreFilm.Items.Clear();
            foreach (SearchMovie result in results.Results){
                //Console.WriteLine(result.Title);
                String year = null;
                if (result.ReleaseDate != null)
                {
                    year = result.ReleaseDate.Value.Year.ToString();
                }
                dataGridViewFindingFilms.Rows.Add(year,result.Title,result.Id);
            }
        }

        private void LoadSerial(String id)
        {
            TMDbClient client = new TMDbClient(APIKeys.theMovieDB);
            client.GetConfig();
            TvShow serial = client.GetTvShow(Convert.ToInt32(id),TvShowMethods.Undefined,"ru");

            Console.WriteLine("Show name: {0}", serial.Name);
            textBoxSerialTitleOrigin.Text = serial.OriginalName;
            textBoxSerialTitleRus.Text = serial.Name;
            dateTimePickerSerialFirstAirDate.Value = serial.FirstAirDate ?? default(DateTime);
            dateTimePickerSerialLastAirDate.Value = serial.LastAirDate ?? default(DateTime);
            foreach (Genre genre in serial.Genres)
            {
                checkedListBoxGenreSerial.Items.Add(Common.format(genre.Name), true);
            }

            coverURL = getImage(client, serial.PosterPath);
            pictureBox2.Load(coverURL);
            listBoxSeasons.Items.Clear();
            foreach (TvSeason season in serial.Seasons)
            {
                Season newSeason = new Season();
                newSeason.name=season.Name;
                newSeason.number=season.SeasonNumber;
                newSeason.episodes = new List<Episode>();
                TvSeason  getSeason=client.GetTvSeason(Convert.ToInt32(id), season.SeasonNumber, TvSeasonMethods.Undefined, "ru");
                foreach (TvEpisode episode in getSeason.Episodes)
                {
                    Episode newEpisode = new Episode();
                    newEpisode.name = episode.Name;
                    newEpisode.number = episode.EpisodeNumber;                    
                    newSeason.episodes.Add(newEpisode);
                }
                listBoxSeasons.Items.Add(newSeason);
            }
        }

        private void LoadSerials(String uri)
        {
            TMDbClient client = new TMDbClient(APIKeys.theMovieDB);
            SearchContainer<SearchTv> results = client.SearchTvShow(uri);

            Console.WriteLine("Got {0} of {1} results", results.Results.Count, results.TotalResults);
            dataGridViewFindingFilms.Rows.Clear(); checkedListBoxGenreFilm.Items.Clear();
            foreach (var result in results.Results)
            {
                Console.WriteLine(result.Name);
                String year = null;                
                dataGridViewFindingFilms.Rows.Add(year, result.Name, result.Id);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            originTitle = textBoxTitleOrigin.Text;
            rusTitle = textBoxTitleRus.Text;
            dateWorld = dateTimePickerDateWorld.Value;
            dateRus = dateTimePickerDateRus.Value;
            foreach (object itemChecked in checkedListBoxGenreFilm.CheckedItems)
            {
                genres.Add((String)itemChecked);
            }
            foreach(var castItem in listBoxCast.Items)
            {
                casts.Add((Cast)castItem);
            }
        }

        private void textBoxNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void buttonAddSerial_Click(object sender, EventArgs e)
        {
            originTitle = textBoxSerialTitleOrigin.Text;
            rusTitle = textBoxSerialTitleRus.Text;
            firstAirDate = dateTimePickerSerialFirstAirDate.Value;
            lastAirDate = dateTimePickerSerialLastAirDate.Value;
            foreach (object itemChecked in checkedListBoxGenreSerial.CheckedItems)
            {                
                genres.Add((String)itemChecked);
            }
            foreach (var seasonItem in listBoxSeasons.Items)
            {
                seasons.Add((Season)seasonItem);
            }
        }
    }
}
