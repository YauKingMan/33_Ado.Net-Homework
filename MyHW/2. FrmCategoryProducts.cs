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

namespace MyHomeWork
{
    public partial class FrmCategoryProducts : Form
    {
        public FrmCategoryProducts()
        {
            InitializeComponent();
        }

        SqlConnection conn = null;
        void abc()
        {
            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");//連接本機路徑//SqlConnection

                conn.Open();//開始

                SqlCommand command = new SqlCommand("select categoryname from categories", conn); //建立指令 //SqlCommand

                SqlDataReader dataReader = command.ExecuteReader(); //閱讀資料  //SqlDataReader

                //dataReader.Read(); //查一筆資料 

                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["categoryname"]);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");//連接本機路徑//SqlConnection

                conn.Open();//開始

                int i = comboBox1.SelectedIndex;
                string a = comboBox1.Items[i].ToString();

                SqlCommand command = new SqlCommand("select productname from products join categories  " +
                    "on products.categoryid = categories.categoryid where categoryname = '" + a + "'"
                    , conn); //建立指令 //SqlCommand


                SqlDataReader dataReader = command.ExecuteReader(); //閱讀資料  //SqlDataReader

                this.listBox1.Items.Clear();

                //dataReader.Read(); //查一筆資料 

                while (dataReader.Read())
                {
                    listBox1.Items.Add(dataReader["productname"]);


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            //if (comboBox1.Items[0])
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());
            //MessageBox.Show(""+comboBox1.Items[0]);

        }

        private void FrmCategoryProducts_Load(object sender, EventArgs e)
        {
            abc();
        }

    }
}
