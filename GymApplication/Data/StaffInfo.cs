using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApplication.Data
{
    public class StaffInfo
    {
        [PrimaryKey, AutoIncrement]
        public int StaffId { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPhoneNumber { get; set; }
        public string StaffPosition { get; set; }
        public string StaffHireDate { get; set; }
        public string StaffSalary { get; set; }
    }
}
