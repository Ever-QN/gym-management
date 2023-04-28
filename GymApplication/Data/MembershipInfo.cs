using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GymApplication.Data
{
    public class MembershipInfo : CustomerInfo
    {
		public string MembershipType { get; set; }
	}
}
