﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }


        public List<Order> Orders { get; set; }
    }
}
