using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interface;

namespace WpfApp2.Model
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price:C}";
        }
    }
}