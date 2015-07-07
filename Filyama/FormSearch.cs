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

namespace Filyama
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.Default;
                var doc = new HtmlAgilityPack.HtmlDocument();
                //doc.LoadHtml(client.DownloadString("http://m.kinopoisk.ru/search/" + HttpUtility.UrlEncode(textBoxNameSearch.Text) + "/view/movie/"));
                doc.LoadHtml(client.DownloadString("http://m.kinopoisk.ru/search/" + HttpUtility.UrlEncode("Need FOr Speed") + "/view/movie/"));
                HtmlNode node = doc.DocumentNode.SelectNodes("//div[@class='block search']")[0];
                foreach (HtmlNode node2 in node.SelectNodes(".//span"))
                {
                    foreach (HtmlNode nodeA in node2.SelectNodes(".//a"))
                    {
                        String value = nodeA.InnerText; string attributeValue = nodeA.GetAttributeValue("href", "");
                        String[] values = value.Split(',');
                        String year = null;
                        String name = null;
                        if (values != null && values.Length >= 2)
                        {
                            year = values[values.Length-1].Trim();
                            for (int i = 0; i < values.Length - 1; i++)
                            {
                                name += values[i] + ",";
                            }
                            name = name.Substring(0, name.Length - 1);
                        }
                        else
                        {
                            name = value;
                        }
                        dataGridView1.Rows.Add(year, name,attributeValue);
                    }
                }                    
            }         
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedCells.Count > 0)
         {
             int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

             DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];  

              string uri = Convert.ToString(selectedRow.Cells[2].Value);
              LoadFilm(uri);
              tabControl1.SelectedIndex = 1;

         }
            
        }

        private void LoadFilm(String uri)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.Default;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(client.DownloadString(uri));
                HtmlNodeCollection node = doc.DocumentNode.SelectNodes("//div[@id='content']");
                int a = 1;
                a++;
                /*foreach (HtmlNode nodeB in node.SelectNodes(".//b"))
                {
                    textBox1.Text = nodeB.InnerText;                    
                }*/
            }         
        }
    }
}
