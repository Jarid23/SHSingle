using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tip_Calculator.Models
{
    public class TipCalculator
    {
        public decimal? Bill { get; set; }
        public decimal? TipPercent { get; set; }
        public decimal TipAmount { get; set; }
    }
}