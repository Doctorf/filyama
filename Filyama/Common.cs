using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Filyama
{
    public struct Category
    {
        public int id;
        public String name;
        public int idParent;
        public int idImage;

        public override string ToString()
        {
            return name;
        }
        public static bool operator ==(Category c1, Category c2)
        {
            return c1.name.Equals(c2.name);
        }

        public static bool operator !=(Category c1, Category c2)
        {
            return !c1.name.Equals(c2.name);
        }
    }

    public struct Media
    {
        public String name;
        public String filter;
        public Boolean foto;

        public override string ToString()
        {
            return name;
        }
    }

    public struct BinaryData
    {
        public int id;
        public String path;
        public String fullpath;
        public String name;
        public Boolean foto;

        public override string ToString()
        {
            return path;
        }
    }

    public struct Film
    {
        public int id;
        //------Отображание
        public String nameOrig;
        public String nameRus;        
        public String coverURL;
        public String categoriesString;
        public DateTime dateWorld;
        public DateTime dateRus;
        public List<Cast> casts;

        //------Сохранение в БД
        public long coverId;
        public List<int> categories;
        public List<long> mediafiles;

        public override string ToString()
        {
            String output = nameRus;
            if (!nameOrig.Equals(""))
            {
                output+="("+nameOrig+")";
            }
            if (dateWorld != default(DateTime))
            {
                output+="["+dateWorld.Year+"]";
            }
            return output;
        }
    }

    public struct Serial
    {
        public int id;
        public String name;
        public List<Season> seasons;
    }

    public struct Season
    {
        public int id;
        public int parent_id;
        public int number;
        public String name;
        public List<Episode> episodes;
        public override string ToString()
        {
            return String.Format("{0} season '{1}'", number, name);
        }
    }

    public struct Episode
    {
        public int id;
        public int parent_id;
        public int number;
        public String name;
        public override string ToString()
        {
            return String.Format("episode {0} '{1}'", number, name);
        }
    }

    public struct Person
    {
        public int id;
        public String ImdbId;
        public String biography;
        public DateTime birthday;
        public DateTime deathday;
        public String name;
        public String place_of_birth;
        public Image image;
    }

    public struct Cast
    {
        public int id;        
        public Person person;
        public String character;
        public override string ToString()
        {
            return String.Format("{0} as '{1}'", person.name, character);
        }
    }

    class Common
    {
        static public SQLiteConnection connectionLocal;

        static public String imagesPath="\\images\\films\\";
        static public int indexElement = 4;

        static public Dictionary<int, int> imageCategoryList;
        static public Dictionary<int, Category> categoryList;
        static public Dictionary<int, byte[]> imageCategoryListData;
        static public Dictionary<int, Film> films;
        static public Dictionary<int, Serial> serials;
        static public Dictionary<string, string> configs;

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] imageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public static byte[] GetBytes(SQLiteDataReader reader)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }

        public static String format(String source)
        {
            if (String.IsNullOrEmpty(source))
                throw new ArgumentException("String not found!");
            return source.First().ToString().ToUpper() + source.Substring(1);
        }

        public static void ShowError(String error_string, params string[] values)
        {
            MessageBox.Show(String.Format(error_string, values), "Error in application", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
