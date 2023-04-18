using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long BasicPay { get; set; }
        public long Deductions { get; set; }
        public long TaxablePay { get; set; }
        public long Incometax { get; set; }
        public long NetPay { get; set; }
    }
}
