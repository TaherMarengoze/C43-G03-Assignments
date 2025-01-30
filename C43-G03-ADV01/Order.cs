using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_ADV01
{
    public class Order
    {
        public Order(int id, string sku, double price)
        {
            Id = id;
            Sku = sku;
            Price = price;
        }


        public int Id { get; }

        public string Sku { get; }

        public double Price { get; }

        public override string ToString()
        {
            return $"{Id}: {Sku} @{Price:C}";
        }
    }
}
