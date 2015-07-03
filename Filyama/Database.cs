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
        public static int NewFilms()
        {
            int newRow = -1;
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "SELECT MAX(id)+1 FROM films";
                try
                {
                    Object result= cmd.ExecuteScalar();
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
                    string sql = @"select last_insert_rowid()";
                    cmd.CommandText = sql;
                    long lastIdCover = (long)cmd.ExecuteScalar();
                    cmd.CommandText = "UPDATE films SET id_cover=@id_cover WHERE id=@id;";
                    cmd.Parameters.Add(new SQLiteParameter("@id", newFilm.id));
                    cmd.Parameters.Add(new SQLiteParameter("@id_cover", lastIdCover));
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

        public static void DeleteFilm(Film deleteFilm)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
                cmd.CommandText = "DELETE FROM films WHERE id=@id;";
                cmd.Parameters.Add(new SQLiteParameter("@id",deleteFilm.id));                
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
        public static void UpdateFilm(Film oldFilm,Film newFilm)
        {
            if (Common.connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = Common.connectionLocal.CreateCommand();
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
            }
        }
    }
}
