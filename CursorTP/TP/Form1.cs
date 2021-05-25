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

namespace TP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);

            Random x = new Random();
            Random y = new Random();

            while (true)
            {
                int yy = y.Next(1, 1100);
                Thread.Sleep(10);
                
                Cursor.Position = new Point(x.Next(1, 2200), yy);
            }

            

            this.Close();
            
        }
    }
}
