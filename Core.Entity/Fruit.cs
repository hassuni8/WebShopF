using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Fruit
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        // allergens = new List<string>()
        public int Amount { get; set; }
        public string Contents { get; set; }
        public string imgUrl { get; set; }
    }
}
