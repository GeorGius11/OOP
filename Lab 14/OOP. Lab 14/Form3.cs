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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(Form1.path, FileMode.Open)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {

                        int number = br.ReadInt32();
                        string type = br.ReadString();
                        string processor = br.ReadString();
                        int memory = br.ReadInt32();
                        int HDDsize = br.ReadInt32();
                        string date = br.ReadString();
                        bool hasInternet = br.ReadBoolean();
                        if (type == "Laptop" && memory > 4)
                        {
                            dataGridView1.Rows.Add(
                                number,
                                type,
                                processor,
                                memory,
                                HDDsize,
                                date,
                                hasInternet);
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
