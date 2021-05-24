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

namespace Lab12
{
    public partial class Device2Form : Form
    {
        public Device2Form()
        {
            InitializeComponent();
        }

        private void Device2Form_Load(object sender, EventArgs e)
        {
            foreach (Device2 device2 in Device2.ListFromFile())
            {
                dataGridView1.Rows.Add(device2.Name, Convert.ToString(device2.Cost),
                    device2.powerSupply_voltage, device2.powerSupply_current,
                    device2.powerSupply_frequency, device2.status_turned,
                    device2.status_condition, device2.dimention_length, 
                    device2.dimention_height, device2.dimention_width, 
                    Convert.ToString(device2.volume()));
                    comboBox1.Items.Add(device2.Name);
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("Devices2.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                new Device2(
                    Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value),
                    Convert.ToString(dataGridView1.Rows[i].Cells[5].Value),
                    Convert.ToString(dataGridView1.Rows[i].Cells[6].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value)
                    ).ToFile();


                //Form1.devices2[i].dimention_length = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                //Form1.devices2[i].dimention_height = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                //Form1.devices2[i].dimention_width = Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            MessageBox.Show(Convert.ToString(Device2.ListFromFile()[i].PriceOf(Convert.ToInt32(textBox1.Text))));
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
