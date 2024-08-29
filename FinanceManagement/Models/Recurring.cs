using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Models
{
    internal class Recurring
    {
        public int recurring_id { get; set; }
        public int user_id { get; set; }
        public int category_id { get; set; }
        public double amount { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string frequency { get; set; }
        public string description { get; set; }
    }
}
