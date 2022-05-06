using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmMyAlbum_V1 : Form
    {
        //搖滾區
        int i = 0;
        Form_ShowImage frm_ShowImage = null;
        PictureBox picturebox = null;
        string cityname = "";

        public FrmMyAlbum_V1()
        {
            InitializeComponent();           
            FillDateGrillView();
            CallLinkLabel();
            Create_Combox();
        }

        private void Create_Combox()
        {
            photoCategoryTableAdapter1.Fill(worldDataSet1.PhotoCategory);

            for (int i = 0; i < worldDataSet1.PhotoCategory.Rows.Count; i++)
            {
                comboBox1.Items.Add(worldDataSet1.PhotoCategory[i].CategoryName);
              
            }
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
                LinkLabel linklabel = new LinkLabel();
                linklabel.Text = worldDataSet1.PhotoCategory.Rows[i]["CategoryName"].ToString();
                linklabel.Left = 5;
                linklabel.Top = 30 * i;
                linklabel.Tag = i;
                linklabel.Click += linklabel_click;
                this.splitContainer2.Panel1.Controls.Add(linklabel);
            }
        }

        private void linklabel_click(object sender, EventArgs e)
        {
            cityname = ((LinkLabel)sender).Text;
            photosTableAdapter1.FillByJoin(worldDataSet1.Photos, ((LinkLabel)sender).Text);
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < worldDataSet1.Photos.Rows.Count; i++)
            {
                PictureBox picturebox = new PictureBox();       
                byte[] bytes = worldDataSet1.Photos[i].Picture;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                picturebox.Image = Image.FromStream(ms);
                picturebox.Width = 150;
                picturebox.Height = 150;
                picturebox.Tag = i;
                picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel1.Controls.Add(picturebox);
                picturebox.Click += picturebox_Click;
            }
            //this.photoCategoryTableAdapter1.FillByCategoryName(this.worldDataSet1.PhotoCategory, x.Text);
            //int CategoryID = Convert.ToInt32(worldDataSet1.PhotoCategory.Rows[0]["CategoryID"]);
            //this.photosTableAdapter1.FillByCategoryID(this.worldDataSet1.Photos, CategoryID);
            //this.dataGridView1.DataSource = this.worldDataSet11.Pic;
        }

        private void picturebox_Click(object sender, EventArgs e)
        {

            frm_ShowImage = new Form_ShowImage();
            i = (int)(((PictureBox)sender).Tag);
            picturebox = new PictureBox();
            picturebox.Image = ((PictureBox)sender).Image;
            showImage();
        }

        private void showImage()
        {
            picturebox.Dock = DockStyle.Fill;
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            frm_ShowImage.Controls.Clear();
            frm_ShowImage.Controls.Add(picturebox);
            frm_ShowImage.Show();
            frm_ShowImage.BringToFront();
        }

        void AddPbFormat(PictureBox pb)
        {
            pb.Width = 150;
            pb.Height = 150;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            this.flowLayoutPanel2.Controls.Add(pb);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            photosTableAdapter1.FillByJoin(worldDataSet1.Photos, comboBox1.Text);
            this.flowLayoutPanel2.Controls.Clear();
            for (int i = 0; i < worldDataSet1.Photos.Rows.Count; i++)
            {
                byte[] bytes = worldDataSet1.Photos[i].Picture;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromStream(ms);
                AddPbFormat(pb);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "請選擇城市")
            {
                MessageBox.Show("請先選擇城市");
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    photoCategoryTableAdapter1.FillByCategoryName(worldDataSet2.PhotoCategory, comboBox1.Text);
                    string folderName = folderBrowserDialog1.SelectedPath;
                    foreach (string files in Directory.GetFiles(folderName))
                    {
                        Image image = Image.FromFile(files);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = ms.GetBuffer();
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(files);
                        AddPbFormat(pb);
                    }
                }
            }
        }

       
    }
}
