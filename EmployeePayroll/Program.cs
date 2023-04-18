using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class Program
    {
      public static void Main(string[] args)
        {
            Operation operation = new Operation();
            operation.GetAllRecords();
        }
    }
}
