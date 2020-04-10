using Numpy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace p1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
            asc.resizeFont(this, chart1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int a_time = 2;
            //int a_round = 3;
            //var a_threshold = 0.5;
            var t_r_rand = np.random.randint(1,10000) ;
            var th_rand = np.random.rand();


            if (this.textBox1.Text == null)
                this.textBox1.Text = t_r_rand.ToString();
            if (this.textBox2.Text == null)
                this.textBox2.Text = t_r_rand.ToString();
            if (this.textBox3.Text == null)
                this.textBox3.Text = th_rand.ToString();


            int a_time = Convert.ToInt32(this.textBox1.Text);
            int a_round = Convert.ToInt32(this.textBox2.Text);
            var a_threshold = Convert.ToDouble(this.textBox3.Text);

            int b_time = Convert.ToInt32(this.textBox4.Text);
            int b_round = Convert.ToInt32(this.textBox5.Text);
            var b_threshold = Convert.ToDouble(this.textBox6.Text);

            var a_coin = np.random.rand(a_round, a_time);
            var b_coin = np.random.rand(b_round, b_time);

            int[] a_count = new int[a_round];
            int[] b_count = new int[b_round];

            for (int i = 0; i < a_round; i++) {
                var data = a_coin[i].GetData<double>();
                a_count[i] = 0;
                for (int j = 0; j < a_time; j++){
                    if (data[j] <= a_threshold){ 
                        data[j] = 1;
                        a_count[i] += 1;
                    } 
                }
            }

            for (int i = 0; i < b_round; i++)
            {
                var data = b_coin[i].GetData<double>();
                b_count[i] = 0;
                for (int j = 0; j < b_time; j++)
                {
                    if (data[j] <= b_threshold)
                    {
                        data[j] = 1;
                        b_count[i] += 1;
                    }
                }
            }

            List<int> x1 = new List<int>();
            List<int> y1 = new List<int>();
            List<int> x2 = new List<int>();
            List<int> y2 = new List<int>();

            foreach (var i in a_count.GroupBy(c => c)){
                x1.Add(i.Key);
                y1.Add(i.Count());
            }

            foreach (var i in b_count.GroupBy(c => c))
            {
                x2.Add(i.Key);
                y2.Add(i.Count());
            }


            chart1.Series.Clear();
            Series c1 = new Series("coin1");
            chart1.Series.Add(c1);
            Series c2 = new Series("coin2");
            chart1.Series.Add(c2);
            for (int i=0 ; i < x1.Count() ; i++){
               chart1.Series[0].Points.AddXY(x1[i], y1[i]);
            }
            for (int i = 0; i < x2.Count(); i++)
            {
                chart1.Series[1].Points.AddXY(x2[i], y2[i]);
            }


            //string str_a_coin = Convert.ToString(a_coin);
            //string str_a_count = Convert.ToString(count);

            // MessageBox.Show(str_a_coin, "Title");
            // MessageBox.Show(str_a_coin, "Title");
            // label4.Text = str_a_coin;
            // label5.Text = str_a_count;
            //Console.WriteLine("--------count----------");
            //for (int i = 0; i < a_round; i++)
            //{
            //    Console.WriteLine(count[i]);
            //}

            //Console.WriteLine(count[1]);
            //Console.WriteLine(count[2]);

        }
    }
}
