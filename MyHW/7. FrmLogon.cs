using MyHW;
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

namespace MyHomeWork
{
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("請先輸入帳號/密碼");
            }
            else
            {
                try
                {
                    string userid = UsernameTextBox.Text;
                    string password = PasswordTextBox.Text;
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "InsertMember";
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userid;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("帳號申請成功!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string userName = this.UsernameTextBox.Text;
            string password = this.PasswordTextBox.Text;
            
            if (userName == "" || password == "")
            {
                MessageBox.Show("請先輸入帳號/密碼");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnection))
                    {

                        SqlCommand command = new SqlCommand();
                        command.CommandText = "LogonMember";
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                        command.Connection = conn;

                        conn.Open();
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            MessageBox.Show("會員登入成功");
                            this.Hide();
                            LoadDataToYTreeView f = new LoadDataToYTreeView();
                            f.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("查無此用戶，請先申請帳號");
                        }
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
