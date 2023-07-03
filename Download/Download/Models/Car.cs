using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download.Models
{
    public class Car
    {
        private string Make { get; set; }
        private string Model { get; set; }
        private uint Year { get; set; }
        private uint HP { get; set; }

        public Car(string make, string model, uint year, uint hp)
        {
            Make = make;
            Model = model;
            Year = year;
            HP = hp;
        }

        public override string ToString()
        {
            return Make;
        }
    }
}
