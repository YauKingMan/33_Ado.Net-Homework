
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmHomeWork : Form
    {
        public FrmHomeWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 100;
            int b = 66;
            int c = 77;
            if (a > b && a > c)
            {
                lblResult.Text = "3個數的最大值為:" + a;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] nums = { 33, 4, 5, 11, 222, 34 };
            int odd = 0;
            int even = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 1)
                {
                    odd += 1;
                }
                else
                {
                    even += 1;
                }
                lblResult.Text = "int[]" + "\n奇數有:" + odd + "個" + "\n偶數有:" + even + "個";
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk" };
            string longname = "aaa";
            for (int i = 0; i < names.Length; i++)
            {
                if (longname.Length < names[i].Length)
                {
                    longname = names[i];
                }
            }
            lblResult.Text = "string[]最長名字為:" + longname;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("請輸入數字");
            }
            else
            {
                int input = Convert.ToInt32(textBox4.Text);
                int odd;
                int even;

                if (input % 2 == 1)
                {
                    odd = input;
                    lblResult.Text = odd + "為單數";
                }
                else
                {
                    even = input;
                    lblResult.Text = even + "為雙數";
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 };
            int max = scores.Max();
            int min = scores[0];
            string a = "";
            for (int i = 0; i < scores.Length; i++)
            {
                if (min > scores[i])
                {
                    min = scores[i];
                }
                a = a + scores[i] + ",";
            }

            lblResult.Text = "int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 }" +
            "\n最大值為:" + max + "\n最小值為:" + min;
            //MessageBox.Show("Max = " + max);

            //Array.Sort(scores);
            //MessageBox.Show("Max =" + scores[scores.Length - 1]);

            //================================

            //Point[] points = new Point[3];
            //points[0].X = 3;
            //points[0].Y = 4;
            ////System.InvalidOperationException: '無法比較陣列中的兩個元素。'

            //Array.Sort(points);

            //=================================


        }

        int MyMinScore(int[] nums)
        {
            return 10;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lblResult.Text = "結果";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string output = ""; //用來儲存要輸出的資料
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    output += "" + i + "*" + j + "=" + (i * j).ToString().PadLeft(2, ' ') + " ";
                }
                output += "\r\n"; //每印完一列，進行跳行(r:return, n:new line)
            }
            lblResult.Text = output; //將output內容輸出到label上
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "bbb", "ccc", "Mary", "Tom", "Carry" };
            string a = "";
            int C_c_nums = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains("c") || names[i].Contains("C"))
                {
                    C_c_nums += 1;
                }
                a = a + names[i] + ",";
                lblResult.Text = "string名字:" + a + "\n C和c的字樣有:" + C_c_nums;
            }

        }
        void my_max(params int[] arr)
        {
            int max = 0;
            string a = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
                a = a + arr[i] + ",";
                lblResult.Text = "int[] scores " + a + "\n最大值為:" + max;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {

            int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 };
            my_max(scores);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int d = 100;
            lblResult.Text = "100的二進位為:" + Convert.ToString(d, 2);
        }




        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("請輸入數值");
            }
            else
            {
                int tb1 = Convert.ToInt32(textBox1.Text);
                int tb2 = Convert.ToInt32(textBox2.Text);
                int tb3 = Convert.ToInt32(textBox3.Text);
                int a = 0;
                int b = tb3 - 1;
                for (int i = tb1; i <= tb2; i = i + tb3)
                {
                    a += i;
                }
                lblResult.Text = tb1 + " 到 " + tb2 + " 相隔 " + b + "\n加總為 " + a;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("請輸入數值");
            }
            else
            {
                int tb1 = Convert.ToInt32(textBox1.Text);
                int tb2 = Convert.ToInt32(textBox2.Text);
                int tb3 = Convert.ToInt32(textBox3.Text);
                int i = tb1;
                int a = 0;
                int b = tb3 - 1;
                while (i <= tb2)
                {
                    a += i;
                    i = i + tb3;
                }
                lblResult.Text = tb1 + " 到 " + tb2 + " 相隔 " + b + "\n加總為 " + a;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("請輸入數值");
            }
            else
            {
                int tb1 = Convert.ToInt32(textBox1.Text);
                int tb2 = Convert.ToInt32(textBox2.Text);
                int tb3 = Convert.ToInt32(textBox3.Text);
                int i = tb1;
                int a = 0;
                int b = tb3 - 1;
                do
                {
                    a += i;
                    i = i + tb3;

                } while (i <= tb2);
                lblResult.Text = tb1 + " 到 " + tb2 + " 相隔 " + b + "\n加總為 " + a;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int[] randomBall = new int[6];
            //產生亂數初始值
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                //隨機產生1~49
                randomBall[i] = rnd.Next(1, 50);

                for (int j = 0; j < i; j++)
                {
                    //檢查號碼是否重複
                    while (randomBall[j] == randomBall[i])
                    {
                        j = 0;
                        //重新產生，存回陣列，亂數產生的範圍是1~49
                        randomBall[i] = rnd.Next(1, 50);
                    }
                }
                lblResult.Text = "樂透結果為:" + randomBall[0] + " " + randomBall[1] + " " + randomBall[2] + " "
                                 + randomBall[3] + " " + randomBall[4] + " " + randomBall[5];

            }
        }
    }
}
