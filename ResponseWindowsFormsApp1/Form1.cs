using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponseWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                Graphics Red = panel1.CreateGraphics();
                Random rnd = new Random();

                for (int i = 0; i < 100; i++)
                {
                    int x = rnd.Next(panel1.Height);
                    int y = rnd.Next(panel1.Width);
                    Red.DrawRectangle(Pens.Red, x, y, 20, 20);
                    Thread.Sleep(100);

                }
            }).Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task tt2 = new Task(() =>
            {
                Graphics Red = panel2.CreateGraphics();
                Random rnd = new Random();

                for (int i = 0; i < 100; i++)
                {
                    int x = rnd.Next(panel2.Height);
                    int y = rnd.Next(panel2.Width);
                    Red.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(100);

                }
            });

            tt2.Start();
        }
    }
}
