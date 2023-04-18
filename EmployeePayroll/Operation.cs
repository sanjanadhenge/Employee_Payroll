using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class Operation
    {
        public static string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service";
        SqlConnection connection = new SqlConnection(connectionstring);
        public void GetAllRecords()
        {
           
                Employee employee = new Employee();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from  employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.CommandType = System.Data.CommandType.Text;
                    this.connection.Open();
                    SqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            employee.ID = read.GetInt32(0);
                            employee.Name = read.GetString(1);
                            employee.Salary = read.GetInt64(2);
                            employee.StartDate = read.GetDateTime(3);
                            employee.Gender = read.GetString(4);
                            employee.Phone = read.GetString(5);
                            employee.Address = read.GetString(6);
                            employee.BasicPay = read.GetInt64(7);
                            employee.Deductions = read.GetInt64(8);
                            employee.TaxablePay = read.GetInt64(9);
                            employee.Incometax = read.GetInt64(10);
                            employee.NetPay = read.GetInt64(11);
                            Console.WriteLine(employee.ID + "\n" + employee.Name + "\n" + employee.Salary + "\n" + employee.StartDate + "\n" + employee.Gender + "\n" + employee.Phone + "\n" + employee.Address + "\n" + employee.BasicPay + "\n" + employee.Deductions + "\n" + employee.TaxablePay + "\n" + employee.Incometax + "\n" + employee.NetPay);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Records avaible");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
               
            
          

        }
    }
}
