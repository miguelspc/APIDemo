using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Models
{
    public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public double USD { get; set; }
        public double GTQ { get; set; }
    }
}
