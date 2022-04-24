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
    public partial class TryTreeView : Form
    {
        public TryTreeView()
        {
            InitializeComponent();
            LoadDataToYTreeView();
        }


        private void LoadDataToYTreeView()
        {
            using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
            {

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select CategoryName,CategoryID from Categories";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    treeView1.Nodes.Clear();
                    

                    while (dataReader.Read())
                    {
                        string CategoryName = dataReader["CategoryName"].ToString();
                        string catrgoryid = dataReader["CategoryID"].ToString();
                                      
                    }
                    command.CommandText = $"select ProductName from Products ";
                    SqlDataReader dataReader1 = command.ExecuteReader();
                    while (dataReader1.Read())
                    {

                    }
                    
                    TreeNode treeNode_1 = new TreeNode();
                    //treeNode_1.Text = CategoryName;
                    TreeNode treeNode_2 = new TreeNode();
                    //treeNode_2.Text = dataReader1["ProductName"].ToString();
                    treeNode_1.Nodes.Add(treeNode_2);
                    treeView1.Nodes.Add(treeNode_1);


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
