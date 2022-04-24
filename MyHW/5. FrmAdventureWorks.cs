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
    public partial class FrmAdventureWorks : Form
    {
        public FrmAdventureWorks()
        {
            InitializeComponent();
        }
        private void FrmAdventureWorks_Load(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.Fill(this.adWorkDataSet11.ProductPhoto);
            this.bindingSource1.DataSource = this.adWorkDataSet11.ProductPhoto;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "LargePhoto", true);

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Select 'Year'=CONVERT(varchar(4), ModifiedDate, 20)" + "FROM Production.ProductPhoto Group by CONVERT(varchar(4), ModifiedDate, 20)", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["Year"]);

            }



        }

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count - 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.label4.Text = $"{this.bindingSource1.Position + 1}/{this.bindingSource1.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime a, b;
            DateTime.TryParse(dateTimePicker1.Text, out a);
            DateTime.TryParse(dateTimePicker2.Text, out b);
            // use DateTime.TryparseExtract if you know the format of input date                          
            productPhotoTableAdapter1.FillByModifiedDate(adWorkDataSet11.ProductPhoto, a, b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime a, b;
            DateTime.TryParse(dateTimePicker1.Text, out a);
            DateTime.TryParse(dateTimePicker2.Text, out b);
            productPhotoTableAdapter1.FillByOrderBy(adWorkDataSet11.ProductPhoto, a, b);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int a;
            //MessageBox.Show(a.ToString());
            a = Convert.ToInt32(comboBox1.SelectedItem);
            productPhotoTableAdapter1.FillByABC(adWorkDataSet11.ProductPhoto, a);
        }

    }

}
