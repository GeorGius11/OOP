using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Device2 : Device
    {
        public struct Dimentions
        {
            public double length;
            public double height;
            public double width;
        };

        Dimentions dimention;

        public Device2()
        {
        }

        public Device2(string name, double cost, int voltage, int current,
            int frequency, string turned, string condition, double length, double height, double width)
            : base(name, cost, voltage, current, frequency, turned, condition)
        {
            dimention.length = length;
            dimention.height = height;
            dimention.width = width;
        }

        public Dimentions dimentions
        {
            get { return dimention; }
            set { dimention = value; }
        }

        public double dimention_length
        {
            get { return dimention.length; }
            set { dimention.length = value; }
        }

        public double dimention_height
        {
            get { return dimention.height; }
            set { dimention.height = value; }
        }

        public double dimention_width
        {
            get { return dimention.width; }
            set { dimention.width = value; }
        }

        public double volume()
        {
            return dimention.height * dimention.length * dimention.width;
        }

        public override double PriceOf(int n)
        {
            return cost * n;
        }

        public override double SalePrice(double sale)
        {
            return (cost - cost * (sale / 200));
        }

        public override string Info()
        {
            return base.Info() + $"Dimentions: length = {dimention.length}, height = {dimention.height}, width = {dimention.width}\n";
        }

        public override void ToFile()
        {


            FileStream fs = new FileStream("Devices2.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{name} {cost} {powerSup.voltage} {powerSup.current} " +
                $"{powerSup.frequency} {stat.turned} {stat.condition} {dimention.length} {dimention.height} {dimention.width}");
            sw.Close();
            fs.Close();

        }

        public  static new List<Device2> ListFromFile()
        {
            List<Device2> devices2 = new List<Device2>();
            string[] s = File.ReadAllLines("Devices2.txt");

            foreach (var item in s)
            {
                devices2.Add(new Device2(
                    item.Split(' ')[0],
                    Double.Parse(item.Split(' ')[1]),
                    int.Parse(item.Split(' ')[2]),
                    int.Parse(item.Split(' ')[3]),
                    int.Parse(item.Split(' ')[4]),
                    item.Split(' ')[5],
                    item.Split(' ')[6],
                    Double.Parse(item.Split(' ')[7]),
                    Double.Parse(item.Split(' ')[8]),
                    Double.Parse(item.Split(' ')[9])
                    ));
            }

            return devices2;
        }
    }
}
