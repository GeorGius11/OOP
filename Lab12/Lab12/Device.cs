using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Device : Abstract
    {
        protected string name;
        protected double cost;
        public struct PowerSupply
        {
            public int voltage;
            public int current;
            public int frequency;
        };

        public struct Status
        {
            public string turned;
            public string condition;
        };

        protected PowerSupply powerSup;
        protected Status stat;

        public Device()
        {
        }

        public Device(string name, double cost, int voltage,
            int current, int frequency, string turned, string condition)
        {
            this.name = name;
            this.cost = cost;
            powerSup.voltage = voltage;
            powerSup.current = current;
            powerSup.frequency = frequency;
            stat.turned = turned;
            stat.condition = condition;
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

        public PowerSupply powerSupply
        {
            get { return powerSup; }
            set { powerSup = value; }
        }

        public int powerSupply_voltage
        {
            get { return powerSup.voltage; }
            set { powerSup.voltage = value; }
        }

        public int powerSupply_current
        {
            get { return powerSup.current; }
            set { powerSup.current = value; }
        }

        public int powerSupply_frequency
        {
            get { return powerSup.frequency; }
            set { powerSup.frequency = value; }
        }

        public Status status
        {
            get { return stat; }
            set { stat = value; }
        }

        public string status_turned
        {
            get { return stat.turned; }
            set { stat.turned = value; }
        }

        public string status_condition
        {
            get { return stat.condition; }
            set { stat.condition = value; }
        }

        public override double PriceOf(int n)
        {
            return cost * n;
        }

        public virtual double SalePrice(double sale)
        {
            return (cost - cost * (sale / 100));
        }

        public override string Info()
        {
            return $"Name: {name}, cost: {cost}\nPower supply:\nVoltage = {powerSup.voltage}, current = {powerSup.current}, " +
                $"frequency = {powerSup.frequency}\nStatus: Turned {stat.turned}, condition: {stat.condition}\n";
        }

        public virtual void ToFile()
        {
        

            FileStream fs = new FileStream("Devices.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{name} {cost} {powerSup.voltage} {powerSup.current} " +
                $"{powerSup.frequency} {stat.turned} {stat.condition}");
            sw.Close();
            fs.Close();

        }

        public  static  List<Device> ListFromFile()
        {
            List<Device> devices = new List<Device>();
            string[] s = File.ReadAllLines("Devices.txt");

            foreach (var item in s)
            {
                devices.Add(new Device(
                    item.Split(' ')[0], 
                    Double.Parse(item.Split(' ')[1]), 
                    int.Parse(item.Split(' ')[2]),
                    int.Parse(item.Split(' ')[3]),
                    int.Parse(item.Split(' ')[4]),
                    item.Split(' ')[5],
                    item.Split(' ')[6]
                    ));
            }

            return devices;
        }
    }
}
