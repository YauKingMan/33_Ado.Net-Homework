using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            LoadCountry();
            CreateListViewColumns();

        }


        private void CreateListViewColumns()
        {

            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Customers", conn);


                    SqlDataReader dataReader = command.ExecuteReader();

                    DataTable table = dataReader.GetSchemaTable();


                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        this.listView1.Columns.Add(table.Rows[i][0].ToString());
                    }

                    this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCountry()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "select distinct Country from Customers";
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    comboBox1.Items.Add("All");

                    while (dataReader.Read())
                    {
                        comboBox1.Items.Add(dataReader["Country"]);
                    }
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    conn.Open();

                    if (comboBox1.Text == "All")
                    {
                        command.CommandText = "select * from Customers";
                    }
                    else
                    {
                        command.CommandText = $"select * from Customers where country='{this.comboBox1.Text}'";
                    }
                    listView1.Items.Clear();

                    Random r = new Random();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ListViewItem lvi = listView1.Items.Add(dataReader[0].ToString());
                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Orange;
                        }
                        else
                        {
                            lvi.BackColor = Color.LightGray;
                        }


                        for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                lvi.SubItems.Add("空值");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }

        private void detailsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }

        private void groupByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "select * from Customers order by Country";
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    listView1.Items.Clear();
                    this.listView1.ShowGroups = true;
                    string diff_country = "";
                    int count = 0;
                    while (dataReader.Read())
                    {
                        string country = dataReader["Country"].ToString();
                        string city = dataReader["City"].ToString();
                        if (country != diff_country)
                        {                           
                            ListViewGroup group = this.listView1.Groups.Add(country, country);
                            group.Tag = count;
                            group.Header = country;

                            ListViewItem lvi = listView1.Items.Add(dataReader[0].ToString());

                            Random r = new Random();
                            lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);
                            for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                            {
                                if (dataReader.IsDBNull(i))
                                {
                                    lvi.SubItems.Add("空值");
                                }
                                else
                                {
                                    lvi.SubItems.Add(dataReader[i].ToString());
                                }

                            }
                            //lvi.Group = group;


                            //this.listView1.Groups.Add(group);
                            //listV
                           


                        }
                        count++;
                        //ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());
                        //if (this.listView1.Groups[country] == null)
                        //{
                        //    ListViewGroup group = this.listView1.Groups.Add(country, country); //Add(string key, string headerText);
                        //    group.Tag = 0;
                        //    //lvi.Group = group;
                        //    group.Items.Add(lvi);
                        //}
                        //else
                        //{
                        //    ListViewGroup group = this.listView1.Groups[country];
                        //    //lvi.Group = group;
                        //    group.Items.Add(lvi);
                        //}

                    }

                    //this.listView1.Groups["USA"].Tag =
                    //this.listView1.Groups["USA"].Header =
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void customIDAscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    conn.Open();
                    if (comboBox1.Text == "All")
                    {
                        command.CommandText = "select * from Customers order by CustomerID";
                    }
                    else
                    {
                        command.CommandText = $"select * from Customers where country='{this.comboBox1.Text}' order by CustomerID";
                    }
                    Random r = new Random();
                    SqlDataReader dataReader = command.ExecuteReader();
                    listView1.Items.Clear();

                    while (dataReader.Read())
                    {
                        ListViewItem lvi = listView1.Items.Add(dataReader[0].ToString());
                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Orange;
                        }
                        else
                        {
                            lvi.BackColor = Color.LightGray;
                        }


                        for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                lvi.SubItems.Add("空值");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customIDDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    conn.Open();
                    if (comboBox1.Text == "All")
                    {
                        command.CommandText = "select * from Customers order by CustomerID DESC";
                    }
                    else
                    {
                        command.CommandText = $"select * from Customers where country='{this.comboBox1.Text}' order by CustomerID DESC";
                    }
                    Random r = new Random();
                    SqlDataReader dataReader = command.ExecuteReader();
                    listView1.Items.Clear();

                    while (dataReader.Read())
                    {
                        ListViewItem lvi = listView1.Items.Add(dataReader[0].ToString());
                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Orange;
                        }
                        else
                        {
                            lvi.BackColor = Color.LightGray;
                        }


                        for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                lvi.SubItems.Add("空值");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewGroup listView = new ListViewGroup();
            listView.Name = "Country";
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "city";
            listView.Items.Add(lvi);
            listView1.Groups.Add(listView);
        }
    }
}