using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Filyama
{
    public partial class Form1 : Form
    {        
        SQLiteConnection connectionLocal;
        public Form1()
        {
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("Filyama - {0}", version);
            //Добавление Категорий
            TreeNode mainNode=treeCategory.Nodes.Add("Все категории");            
            connectionLocal = new SQLiteConnection("Data Source=main.db; Version=3;");
            try
            {
                connectionLocal.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Инициализация соединения с локальной базой
            if (connectionLocal.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = connectionLocal.CreateCommand();
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
                string sql_command = "SELECT * FROM films;";
                cmd.CommandText = sql_command;
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();                    
                    while (r.Read())
                    {
                        dataGridViewFilms.Rows.Add(null, null, r["id"].ToString(), r["name"]);
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd.CommandText = "SELECT * FROM category";
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();                    
                    while (r.Read())
                    {
                        mainNode.Nodes.Add(r["name"].ToString());
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                mainNode.Expand();
            }            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            connectionLocal.Dispose();
        }
    }
}
