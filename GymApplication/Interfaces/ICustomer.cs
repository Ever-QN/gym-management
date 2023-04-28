using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApplication.Interfaces
{
	interface ICustomer
	{
		int CustomerId { get; set; }
		string CustomerFirst { get; set; }
		string CustomerLast { get; set; }
		string CustomerEmail { get; set; }
		string CustomerPhone { get; set; }
		string CustomerMember { get; set; }

	}
}
