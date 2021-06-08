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

namespace OOP.Lab_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string path = "PC.bin";

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    bw.Seek(0, SeekOrigin.End);
                    bw.Write(Convert.ToInt32(textBoxNum.Text));
                    bw.Write(comboBoxType.Text);
                    bw.Write(textBoxProc.Text);
                    bw.Write(Convert.ToInt32(textBoxMem.Text));
                    bw.Write(Convert.ToInt32(textBoxHDD.Text));
                    bw.Write(dateTimePicker1.Text);
                    if(radioButtonHasInter.Checked)
                        bw.Write(true);
                    else
                        bw.Write(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add("PC");
            comboBoxType.Items.Add("Laptop");
        }

        private void buttonShow_Click(object sender, EventArgs e) =>  new Form2().Show();

        private void buttonSelect_Click(object sender, EventArgs e) => new Form3().Show();

        private void buttonToTXT_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    File.Delete("PC.txt");
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {

                        int number = br.ReadInt32();
                        string type = br.ReadString();
                        string processor = br.ReadString();
                        int memory = br.ReadInt32();
                        int HDDsize = br.ReadInt32();
                        string date = br.ReadString();
                        bool hasInternet = br.ReadBoolean();
                        if (hasInternet == true && type == "PC" && HDDsize > 1)
                        {
                            using (StreamWriter sr = new StreamWriter("PC.txt", true))
                            {
                                sr.WriteLine($"{number} {type} {processor} {memory} {HDDsize} {date} {hasInternet}");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }
        }
    }
}
