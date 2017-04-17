using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineWPF.Models
{
    public class VendingItem
    {
        //properties of vendingItem's that make up the items
        public int Id { get; set;  }
        public string Name { get; set; }
        public double Price { get; set; }
        
        //Custom constructor
        public VendingItem(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
