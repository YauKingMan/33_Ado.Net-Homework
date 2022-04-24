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
    public partial class Quiz_TreeView : Form
    {
        public Quiz_TreeView()
        {
            InitializeComponent();
            LoadDataToYTreeView();
            LoadDataToDateGridView();

        }

        private void LoadDataToDateGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from Customers where city ='{this.treeView1.Text}'";
                    command.Connection = conn;

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.dataGridView1.DataSource = dataReader.Read();
                    while (dataReader.Read())
                    {

                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataToYTreeView()
        {
            using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
            {

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select Country,'count'=count(*) from customers " +
                                          "group by Country";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    treeView1.Nodes.Clear();

                    while (dataReader.Read())
                    {
                        string Country = dataReader["Country"].ToString();
                        TreeNode treeNode_1 = new TreeNode();
                        treeNode_1.Text = Country;
                        treeView1.Nodes.Add(treeNode_1);

                        using (SqlConnection conn1 = new SqlConnection(Settings.Default.NorthwindConnection))
                        {
                            SqlCommand command1 = new SqlCommand();
                            command1.CommandText = $"select distinct city from Customers where country = '{Country}'";
                            command1.Connection = conn1;
                            conn1.Open();
                            SqlDataReader dataReader1 = command1.ExecuteReader();
                            while (dataReader1.Read())
                            {
                                string City = dataReader1["City"].ToString();
                                TreeNode treeNode_2 = new TreeNode();
                                treeNode_2.Text = City;
                                treeNode_1.Nodes.Add(treeNode_2);
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                label1.Text = "";
            }
            else
            {
                string _city = e.Node.Text;

                using (SqlConnection conn2 = new SqlConnection(Settings.Default.NorthwindConnection))
                {
                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = $"select * from Customers where city ='{_city}'";
                    command2.Connection = conn2;
                    conn2.Open();
                    SqlDataReader dataReader2 = command2.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader2);
                    dataGridView1.DataSource = dt;
                    int i = dataGridView1.Rows.Count - 1;
                    label1.Text = "共" + i + "個 '" + _city + "' Customers";
                }
            
            }
        }
    }
}
