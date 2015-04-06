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
    }
}
