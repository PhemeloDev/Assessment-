using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTest.Models
{
    public class CoinDTO : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set ; }   

    }
}
