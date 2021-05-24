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
    public partial class DeviceForm : Form
    {
        public DeviceForm()
        {
            InitializeComponent();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            foreach (Device device in Device.ListFromFile())
            {
                dataGridView1.Rows.Add(device.Name, Convert.ToString(device.Cost),
                    device.powerSupply_voltage, device.powerSupply_current,
                    device.powerSupply_frequency, device.status_turned,
                    device.status_condition);
                comboBox1.Items.Add(device.Name);
                comboBox2.Items.Add(device.Name);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("Devices.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                new Device(
                    Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value),
                    Convert.ToString(dataGridView1.Rows[i].Cells[5].Value),
                    Convert.ToString(dataGridView1.Rows[i].Cells[6].Value)
                    ).ToFile();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            MessageBox.Show(Convert.ToString(Device.ListFromFile()[i].PriceOf(Convert.ToInt32(textBox1.Text))));
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = comboBox2.SelectedIndex;
            MessageBox.Show(Convert.ToString(Device.ListFromFile()[i].SalePrice(Convert.ToDouble(textBox2.Text))));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
