using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GymApplication.Data
{
    public class CustomerInfo : Interfaces.ICustomer
	{
		[PrimaryKey, AutoIncrement]
		public int CustomerId { get; set; }
		public string CustomerFirst { get; set; }
		public string CustomerLast { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerMember { get; set; }
	}
}
