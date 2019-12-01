﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.DataEntities
{
    public class Concert
    {
        public int Id { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Tour Tour { get; set; }
    }
}
