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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            foreach (Product product in Product.ProdListFromFile())
            {
                dataGridView1.Rows.Add(product.Name, Convert.ToString(product.Cost), product.Type);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("Products.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                new Product(
                    Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                    Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)
                    ).ToFile();
                //Form1.products[i].Name = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                //Form1.products[i].Cost = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                //Form1.products[i].Type = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            }
            
            //foreach (var item in dataGridView1.Rows)
            //{
            //    new Product(
            //        Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
            //        Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
            //        Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)
            //        ).ToFile();
            //}
        }
    }
}
