using MyHomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyHW
{
    public partial class LoadDataToYTreeView : Form
    {
        public LoadDataToYTreeView()
        {
            InitializeComponent();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmHomeWork frm_1 = new FrmHomeWork();
            frm_1.MdiParent = this;
            frm_1.Parent = splitContainer2.Panel2;
            frm_1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_1);
            frm_1.Show();
            frm_1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmCategoryProducts frm_2 = new FrmCategoryProducts();
            frm_2.MdiParent = this;
            frm_2.Parent = splitContainer2.Panel2;
            frm_2.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_2);
            frm_2.Show();
            frm_2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmProducts frm_3 = new FrmProducts();
            frm_3.MdiParent = this;
            frm_3.Parent = splitContainer2.Panel2;
            frm_3.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_3);
            frm_3.Show();
            frm_3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmDataSet_結構 frm_4 = new FrmDataSet_結構();
            frm_4.MdiParent = this;
            frm_4.Parent = splitContainer2.Panel2;
            frm_4.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_4);
            frm_4.Show();
            frm_4.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmAdventureWorks frm_5 = new FrmAdventureWorks();
            frm_5.MdiParent = this;
            frm_5.Parent = splitContainer2.Panel2;
            frm_5.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_5);
            frm_5.Show();
            frm_5.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmLogon frm_7_7 = new FrmLogon();
            frm_7_7.MdiParent = this;
            frm_7_7.Parent = splitContainer2.Panel2;
            frm_7_7.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_7_7);
            frm_7_7.Show();
            frm_7_7.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmCustomers frm_7 = new FrmCustomers();
            frm_7.MdiParent = this;
            frm_7.Parent = splitContainer2.Panel2;
            frm_7.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_7);
            frm_7.Show();
            frm_7.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            FrmMyAlbum_V1 frm_6 = new FrmMyAlbum_V1();
            frm_6.MdiParent = this;
            frm_6.Parent = splitContainer2.Panel2;
            frm_6.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(frm_6);
            frm_6.Show();
            frm_6.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            splitContainer2.Panel2.Controls.Clear();
            this.IsMdiContainer = true;
            Quiz_TreeView quiz = new Quiz_TreeView();
            quiz.MdiParent = this;
            quiz.Parent = splitContainer2.Panel2;
            quiz.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(quiz);
            quiz.Show();
            quiz.BringToFront();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.LightBlue;         
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
    }
}
