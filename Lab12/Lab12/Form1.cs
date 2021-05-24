using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        //public static List<Product> products = new List<Product>();
        //public static List<Device> devices = new List<Device>();
        //public static List<Device2> devices2 = new List<Device2>();


        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton3.Checked = true;
        }
        
        private void Device_Click(object sender, EventArgs e)
        {

        }

        private void Product_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Activate();

        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Fill all fields");
                    return;
                }

                Product product = new Product();
                product.Name = textBox1.Text;
                product.Cost = Convert.ToDouble(textBox2.Text);
                product.Type = textBox3.Text;
                
                //products.Add(product);

                product.ToFile();
            }
            else if(radioButton2.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" ||
                    textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Fill all fields");
                    return;
                }

                Device device = new Device();
                device.Name = textBox1.Text;
                device.Cost = Convert.ToDouble(textBox2.Text);
                device.powerSupply_voltage = Convert.ToInt32(textBox4.Text);
                device.powerSupply_current = Convert.ToInt32(textBox5.Text);
                device.powerSupply_frequency = Convert.ToInt32(textBox6.Text);
                if(radioButton3.Checked == true)
                    device.status_turned = "on"; 
                else if(radioButton4.Checked == true)
                    device.status_turned = "off";

                switch (comboBox1.SelectedIndex)
                {
                    case 0: device.status_condition = "New"; break;
                    case 1: device.status_condition = "Second-hand"; break;
                    case 2: device.status_condition = "Broken"; break;
                    default: device.status_condition = string.Empty; break;
                }

                //devices.Add(device);

                device.ToFile();
            }
            else if(radioButton5.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" ||
                    textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" ||
                    textBox8.Text == "" || textBox9.Text == "")
                {
                    MessageBox.Show("Fill all fields");
                    return;
                }

                Device2 device2 = new Device2();
                device2.Name = textBox1.Text;
                device2.Cost = Convert.ToDouble(textBox2.Text);
                device2.powerSupply_voltage = Convert.ToInt32(textBox4.Text);
                device2.powerSupply_current = Convert.ToInt32(textBox5.Text);
                device2.powerSupply_frequency = Convert.ToInt32(textBox6.Text);
                if (radioButton3.Checked == true)
                    device2.status_turned = "on";
                else if (radioButton4.Checked == true)
                    device2.status_turned = "off";

                switch (comboBox1.SelectedIndex)
                {
                    case 0: device2.status_condition = "New"; break;
                    case 1: device2.status_condition = "Second-hand"; break;
                    case 2: device2.status_condition = "Broken"; break;
                    default: device2.status_condition = string.Empty; break;
                }

                device2.dimention_length = Convert.ToDouble(textBox7.Text);
                device2.dimention_height = Convert.ToDouble(textBox8.Text);
                device2.dimention_width = Convert.ToDouble(textBox9.Text);

                //devices2.Add(device2);

                device2.ToFile();
            }


            TextBox[] textboxes = { textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8, textBox9 };
            foreach(TextBox box in textboxes)
            {
                box.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            groupBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            groupBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeviceForm deviceForm = new DeviceForm();
            deviceForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            groupBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Device2Form device2Form = new Device2Form();
            device2Form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
