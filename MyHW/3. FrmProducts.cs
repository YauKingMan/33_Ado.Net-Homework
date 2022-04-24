using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nW_DataSet1.Products);
            this.bindingSource1.DataSource = this.nW_DataSet1.Products;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.bindingNavigator1.BindingSource = this.bindingSource1;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count - 1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.label2.Text = $"{this.bindingSource1.Position + 1}/{this.bindingSource1.Count}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 0;
            bool d = int.TryParse(textBox1.Text, out a);
            int b = 0;
            bool f = int.TryParse(textBox2.Text, out b);
            if (!d || !f)
            {
                MessageBox.Show("請輸入數字");
            }
            else
            {
                int c = productsTableAdapter1.FillByUnitPrice(nW_DataSet1.Products, a, b);
                lblResult.Text = "結果" + c + "筆";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox3.Text;
            int b = productsTableAdapter1.FillByProductName(nW_DataSet1.Products, a);
            productsTableAdapter1.FillByProductName(nW_DataSet1.Products, a);
            lblResult.Text = "結果" + b + "筆";
        }
    }
}
