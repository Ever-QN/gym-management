using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymApplication.Data
{
    public class BillingInfo
    {
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string MembershipPlan { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
