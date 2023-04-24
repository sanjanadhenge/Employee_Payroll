using System;
using System.Collections.Generic;
using System.Data;
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
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Select an Option \n 1.Get Records \n 2.Add Employee \n 3.Delete Employee \n 4.Update Employee Data \n 5.Get Employees in Particular Range \n 6.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        operation.GetAllRecords();
                        break;
                    case 2:
                        Employee employee = new Employee();
                        {
                            employee.Name = "Revati";
                            employee.Salary = 50000;
                            employee.StartDate = DateTime.Now;
                            employee.Gender = "F";
                            employee.Phone = "9852244";
                            employee.Address = "Delhi";
                            employee.BasicPay = 700;
                            employee.Deductions = 200;
                            employee.TaxablePay = 700;
                            employee.Incometax = 800;
                            employee.NetPay = 700;

                        }
                        operation.AddEmployee(employee);
                        break;
                    case 3:
                        operation.DeleteEmployee(10);
                        break;
                    case 4:
                        operation.UpdateEmployee("Terisa", 30000);
                        break;
                    case 5:
                        Console.WriteLine("Enter start date");
                        DateTime fromDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter End date");
                        DateTime ToDate = DateTime.Parse(Console.ReadLine());
                        operation.GetEmployeeInParticularRange(fromDate, ToDate);
                        break;
                    case 6:
                        flag = false;
                        break;
                }
            }
        }
    }
}
