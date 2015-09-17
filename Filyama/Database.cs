using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Filyama
{
    class Database
    {
        public static void RefreshCategoryImages()
        {
            Common.imageCategoryList.Clear(); Common.imageCategoryListData.Clear();
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM category_images";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader(); int index = 0;
                    while (r.Read())
                    {
                        byte[] data = (byte[])r["value"];
                        Common.imageCategoryList.Add(Convert.ToInt32(r["id"]), index);
                        Common.imageCategoryListData.Add(index++, data);       
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RefreshCategory()
        {
            //Добавление Категорий
            Common.categoryList = new Dictionary<int, Category>();
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
                        if (r["id_image"] != DBNull.Value)
                        {
                            categoryVar.idImage = Convert.ToInt32(r["id_image"]);
                        }
                        else
                        {
                            categoryVar.idImage = -1;
                        }

                        if (r["id_parent"] != DBNull.Value)
                        {
                            categoryVar.idParent = Convert.ToInt32(r["id_parent"]);
                        }
                        else
                        {
                            categoryVar.idParent = -1;
                        }                        
                        Common.categoryList.Add(categoryVar.id, categoryVar);
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static int NewObject(String table)
        {
            int newRow = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT MAX(id)+1 FROM "+table;
                try
                {
                    Object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        newRow = Convert.ToInt32(result);
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newRow;
        }

        public static int NewFilms()
        {
            return NewObject("films");
        }

        public static int NewSerial()
        {            
            return NewObject("serials");
        }

        public static int NewSeason()
        {
            return NewObject("seasons");
        }

        public static int NewEpisode()
        {
            return NewObject("episodes");
        }

        public static List<Media> getMediaExtensions()
        {
            List<Media> medias = new List<Media>();
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM file_extensions";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        Media newMedia = new Media();
                        newMedia.name = Convert.ToString(r["name"]);
                        newMedia.filter = Convert.ToString(r["filter"]);
                        newMedia.foto = Convert.ToBoolean(r["foto"]);
                        medias.Add(newMedia);
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return medias;
        }

        public static long AddBinaryData(String url,bool isThumbnails,bool isFrame,bool isCover)
        {
            long lastId = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO binary_data(url,is_thumbnails,is_frame,is_cover) VALUES(@url,@is_thumbnails,@is_frame,@is_cover);";
                cmd.Parameters.Add(new SQLiteParameter("@url", url));
                cmd.Parameters.Add(new SQLiteParameter("@is_thumbnails", isThumbnails));
                cmd.Parameters.Add(new SQLiteParameter("@is_frame", isFrame));
                cmd.Parameters.Add(new SQLiteParameter("@is_cover", isCover));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                string sql = @"select last_insert_rowid()";
                cmd.CommandText = sql;
                lastId = (long)cmd.ExecuteScalar();
            }
            return lastId;
        }

        public static void AddFilm(Film newFilm) {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO films(id,name_orig,name_rus,date_world,date_rus) VALUES(@id,@name_orig,@name_rus,@date_world,@date_rus);";
                cmd.Parameters.Add(new SQLiteParameter("@id",newFilm.id));
                cmd.Parameters.Add(new SQLiteParameter("@name_orig", newFilm.nameOrig));
                cmd.Parameters.Add(new SQLiteParameter("@name_rus", newFilm.nameRus));
                cmd.Parameters.Add(new SQLiteParameter("@date_world", newFilm.dateWorld));
                cmd.Parameters.Add(new SQLiteParameter("@date_rus", newFilm.dateRus));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //-------Категории
                cmd.CommandText = "INSERT INTO category_films(id_films,id_category) VALUES(@id_films,@id_category);";
                cmd.Parameters.Add(new SQLiteParameter("@id_films",newFilm.id));
                foreach (int id_category in newFilm.categories)
                {
                    cmd.Parameters.Add(new SQLiteParameter("@id_category", id_category));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //--------Обложка
                if (newFilm.coverId != 0)
                {
                    cmd.CommandText = "INSERT INTO binary_data_films(id_films,id_binary_data) VALUES(@id_films,@id_binary_data);";
                    cmd.Parameters.Add(new SQLiteParameter("@id_films", newFilm.id));
                    cmd.Parameters.Add(new SQLiteParameter("@id_binary_data", newFilm.coverId));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                    cmd.CommandText = "UPDATE films SET id_cover=@id_cover WHERE id=@id;";
                    cmd.Parameters.Add(new SQLiteParameter("@id", newFilm.id));
                    cmd.Parameters.Add(new SQLiteParameter("@id_cover", newFilm.coverId));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        private static void DeleteObject(String table,int id)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "DELETE FROM "+table+" WHERE id=@id;";
                cmd.Parameters.Add(new SQLiteParameter("@id", id));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteFilm(Film deleteFilm)
        {
            DeleteObject("films", deleteFilm.id);            
        }

        public static void DeleteSerial(Serial deleteSerial)
        {
            DeleteObject("serials", deleteSerial.id);
        }

        public static void DeleteSeason(Season deleteSeason)
        {
            DeleteObject("seasons", deleteSeason.id);
        }

        public static void DeleteEpisode(Episode deleteEpisode)
        {
            DeleteObject("episodes", deleteEpisode.id);
        }

        public static void UpdateFilm(Film oldFilm,Film newFilm)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                //--------Основная информация
                cmd.CommandText = "UPDATE films SET "; int countSet = 0;
                if (!oldFilm.nameOrig.Equals(newFilm.nameOrig))
                {
                    countSet++;
                    cmd.CommandText += "name_orig=@name_orig,";
                    cmd.Parameters.Add(new SQLiteParameter("@name_orig", newFilm.nameOrig));
                }
                if (!oldFilm.nameRus.Equals(newFilm.nameRus))
                {
                    countSet++;
                    cmd.CommandText += "name_rus=@name_rus,";
                    cmd.Parameters.Add(new SQLiteParameter("@name_rus", newFilm.nameRus));
                }
                if (!oldFilm.dateWorld.Equals(newFilm.dateWorld))
                {
                    countSet++;
                    cmd.CommandText += "date_world=@date_world,";
                    cmd.Parameters.Add(new SQLiteParameter("@date_world", newFilm.dateWorld));
                }
                if (!oldFilm.dateRus.Equals(newFilm.dateRus))
                {
                    countSet++;
                    cmd.CommandText += "date_rus=@date_rus,";
                    cmd.Parameters.Add(new SQLiteParameter("@date_rus", newFilm.dateRus));
                }
                if (countSet > 0)
                {
                    cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                }
                cmd.CommandText += " WHERE id=@id";
                cmd.Parameters.Add(new SQLiteParameter("@id", newFilm.id));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //--------Жанры
                var removeGenre = oldFilm.categories.Except(newFilm.categories).ToList();
                foreach (int removeCategory in removeGenre)
                {
                    Database.removeCategoryFromFilm(removeCategory, newFilm.id);
                }
                var addGenre = newFilm.categories.Except(oldFilm.categories).ToList();
                foreach (int addCategory in addGenre)
                {
                    Database.addCategoryToiFilm(addCategory, newFilm.id);
                }
            }
        }

        public static long AddCategory(String name,int idParent,int idImage) {
            long lastId = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {                
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO category(name,id_parent,id_image) VALUES(@name,@id_parent,@id_image)";
                cmd.Parameters.AddWithValue("@name", name);
                if (idParent != -1)
                {
                    cmd.Parameters.AddWithValue("@id_parent", idParent);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_parent", null);
                }
                if (idImage != -1)
                {
                    cmd.Parameters.AddWithValue("@id_image", idImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_image", null);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                string sql = @"select last_insert_rowid()";
                cmd.CommandText = sql;
                lastId = (long)cmd.ExecuteScalar();
            }
            return lastId;
        }

        public static void removeCategoryFromFilm(int idCategory, int idFilm)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "DELETE FROM category_films WHERE id_films=@id_films AND id_category=@id_category";
                cmd.Parameters.AddWithValue("@id_films", idFilm);
                cmd.Parameters.AddWithValue("@id_category", idCategory);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void addCategoryToiFilm(int idCategory, int idFilm)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO category_films(id_films,id_category) VALUES(@id_films,@id_category)";
                cmd.Parameters.AddWithValue("@id_films", idFilm);
                cmd.Parameters.AddWithValue("@id_category", idCategory);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RefreshSerials()
        {
            Common.serials = new Dictionary<int, Serial>();
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT * FROM serials";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        Serial serial = new Serial();
                        serial.id = Convert.ToInt32(r["id"]);
                        serial.name = Convert.ToString(r["name"]);
                        serial.seasons = new List<Season>();
                        SQLiteCommand cmd_seasons = Common.connectionLocal.CreateCommand();
                        cmd_seasons.CommandText = "SELECT * FROM season_serial INNER JOIN seasons ON seasons.id=season_serial.id_season WHERE id_serial=@id_serial";
                        cmd_seasons.Parameters.AddWithValue("@id_serial", serial.id);
                        try
                        {
                            SQLiteDataReader r_seasons = cmd_seasons.ExecuteReader();
                            while (r_seasons.Read())
                            {                                
                                Season season = new Season();
                                season.id = Convert.ToInt32(r_seasons["id"]);
                                season.parent_id = serial.id;
                                if (r_seasons["number"] != DBNull.Value)
                                {
                                    season.number = Convert.ToInt32(r_seasons["number"]);
                                }
                                season.name = Convert.ToString(r_seasons["name"]);
                                season.episodes = new List<Episode>();
                                SQLiteCommand cmd_episodes = Common.connectionLocal.CreateCommand();
                                cmd_episodes.CommandText = "SELECT * FROM episode_season INNER JOIN episodes ON episodes.id=episode_season.id_episode WHERE id_season=@id_season";
                                cmd_episodes.Parameters.AddWithValue("@id_season", season.id);
                                try
                                {
                                    SQLiteDataReader r_episodes = cmd_episodes.ExecuteReader();
                                    while (r_episodes.Read())
                                    {                                        
                                        Episode episode=new Episode();
                                        episode.id = Convert.ToInt32(r_episodes["id"]);
                                        episode.parent_id = season.id;
                                        if (r_episodes["number"] != DBNull.Value)
                                        {
                                            episode.number = Convert.ToInt32(r_episodes["number"]);
                                        }
                                        episode.name = Convert.ToString(r_episodes["name"]);
                                        season.episodes.Add(episode);
                                    }
                                }
                                catch (SQLiteException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                serial.seasons.Add(season);
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Common.serials.Add(serial.id, serial);

                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }            
        }

        public static void AddSerail(Serial serial)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO serials(name) VALUES(@name)";
                cmd.Parameters.AddWithValue("@name", serial.name);                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void AddSeason(Season season,int serialId)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO seasons(name,number) VALUES(@name,@number)";
                cmd.Parameters.AddWithValue("@name", season.name);
                cmd.Parameters.AddWithValue("@number", season.number);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd.CommandText = "INSERT INTO season_serial(id_season,id_serial) VALUES(@id_season,@id_serial)";
                cmd.Parameters.AddWithValue("@id_season", season.id);
                cmd.Parameters.AddWithValue("@id_serial", serialId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void AddEpisode(Episode episode,int seasonId)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO episodes(name,number) VALUES(@name,@number)";
                cmd.Parameters.AddWithValue("@name", episode.name);
                cmd.Parameters.AddWithValue("@number", episode.number);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd.CommandText = "INSERT INTO episode_season(id_episode,id_season) VALUES(@id_episode,@id_season)";
                cmd.Parameters.AddWithValue("@id_episode", episode.id);
                cmd.Parameters.AddWithValue("@id_season", seasonId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static int FindPerson(Person person)
        {
            int id = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT id FROM [persons] WHERE ImdbId=@ImdbId LIMIT 1;";
                cmd.Parameters.AddWithValue("@ImdbId", person.ImdbId);
                try
                {
                    Object idPerson=cmd.ExecuteScalar();
                    if (idPerson != null)
                    {
                        id = (int)idPerson;
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return id;
        }

        public static int AddPerson(Person person)
        {
            int id = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "INSERT INTO persons(name,birthday,ImdbId) VALUES(@name,@birthday,@ImdbId)";
                cmd.Parameters.AddWithValue("@name", person.name);
                cmd.Parameters.AddWithValue("@birthday", person.birthday);
                cmd.Parameters.AddWithValue("@ImdbId", person.ImdbId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                string sql = @"select last_insert_rowid()";
                cmd.CommandText = sql;
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return id;
        }
    }
}
