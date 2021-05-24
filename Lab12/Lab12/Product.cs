using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Product : Abstract
    {
        string name;
        double cost;
        string type;

        public Product()
        {
        }

        public Product(string name, double cost, string type)
        {
            this.name = name;
            this.cost = cost;
            this.type = type;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override double PriceOf(int n)
        {
            return cost * n;
        }

        public override string Info()
        {
            return $"Name: {name}, cost: {cost}, type: {type}";
        }

        public void ToFile()
        {
            //File.AppendText("Products.txt").WriteLine($"{name}||||||| {cost} {type}");

            FileStream fs = new FileStream("Products.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{name} {cost} {type}");
            sw.Close();
            fs.Close();
            
        }

        public static List<Product> ProdListFromFile()
        {
            List<Product> products = new List<Product>();
            string[] s = File.ReadAllLines("Products.txt");

            foreach (var item in s)
            {
                products.Add(new Product(item.Split(' ')[0], Double.Parse(item.Split(' ')[1]), item.Split(' ')[2]));
            }

            return products;
        }
    }
}
