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
    public partial class FrmDataSet_結構 : Form
    {
        public FrmDataSet_結構()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nW_DataSet1.Categories);
            this.dataGridView4.DataSource = this.nW_DataSet1.Categories;

            this.productsTableAdapter1.Fill(this.nW_DataSet1.Products);
            this.dataGridView5.DataSource = this.nW_DataSet1.Products;

            this.customersTableAdapter1.Fill(this.nW_DataSet1.Customers);
            this.dataGridView6.DataSource = this.nW_DataSet1.Customers;

            listBox2.Items.Clear();
            for (int i = 0; i < nW_DataSet1.Tables.Count; i++)
            {
                DataTable table = nW_DataSet1.Tables[i];
                listBox2.Items.Add(table.TableName);

                string a = "";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    a += $"{table.Columns[j].ColumnName,-60}";
                }

                listBox2.Items.Add(a);


                for (int x = 0; x < table.Rows.Count; x++)
                {
                    string b = "";
                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        b += $"{table.Rows[x][y].ToString(),-60}";

                    }
                    listBox2.Items.Add(b);
                }

                listBox2.Items.Add("======================================================================================");
            }
        }


        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nW_DataSet1.Products.Rows[0]["ProductName"].ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            nW_DataSet1.Products.WriteXml("Products.xml", XmlWriteMode.WriteSchema);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            nW_DataSet1.Products.ReadXml("Products.xml");
            dataGridView5.DataSource = nW_DataSet1.Products;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel1Collapsed = !this.splitContainer2.Panel1Collapsed;
        }
    }
}
