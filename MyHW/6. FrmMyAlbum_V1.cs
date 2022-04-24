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
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();           
            FillDateGrillView();
            CallLinkLabel();
        }
        private void FillDateGrillView()
        {
            this.photoCategoryTableAdapter1.Fill(this.worldDataSet1.PhotoCategory);
            //this.dataGridView1.DataSource = this.worldDataSet1.World;
        }

        private void CallLinkLabel()
        {
            for (int i = 0; i < worldDataSet1.PhotoCategory.Rows.Count; i++)
            {
                LinkLabel x = new LinkLabel();
                x.Text = worldDataSet1.PhotoCategory.Rows[i]["CategoryName"].ToString();
                x.Left = 5;
                x.Top = 30 * i;
                x.Tag = i;
                x.Click += X_Click;
                this.splitContainer2.Panel1.Controls.Add(x);
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            LinkLabel x = (LinkLabel)sender;
            this.photoCategoryTableAdapter1.FillByCategoryName(this.worldDataSet1.PhotoCategory, x.Text);
            int CategoryID = Convert.ToInt32(worldDataSet1.PhotoCategory.Rows[0]["CategoryID"]);
            this.photosTableAdapter1.FillByCategoryID(this.worldDataSet1.Photos, CategoryID);
            //this.dataGridView1.DataSource = this.worldDataSet11.Pic;
        }

    }
}
