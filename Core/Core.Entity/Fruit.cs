using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class Fruit
    {
        public double Price { get; set; }
        public String Name { get; set; }
        public List<String> allergens { get; set; }
        public string Contents { get; set; }
        public int amoung { get; set; }
        public String imgUrl { get; set; }
        public int Id { get; set; }
    }
}
