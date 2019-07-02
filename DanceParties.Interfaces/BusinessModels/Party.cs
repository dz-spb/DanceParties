﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DanceParties.Interfaces.BusinessModels
{
    public class Party
    {
        public int Id { get; set; }

        public string Dance { get; set; }

        public string Name { get; set; }      

        public DateTimeOffset DateTime { get; set; }

        public string Place { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}