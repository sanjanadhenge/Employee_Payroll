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
        public void AddEmployee(Employee employee)
        {
            using (this.connection)
            {

                SqlCommand command = new SqlCommand("AddEmployee", this.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Phone", employee.Phone);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                command.Parameters.AddWithValue("@Deduction", employee.Deductions);
                command.Parameters.AddWithValue("@TaxeblePay", employee.TaxablePay);
                command.Parameters.AddWithValue("@IncomeTax", employee.Incometax);
                command.Parameters.AddWithValue("@NetPay", employee.NetPay);
                this.connection.Open();
                var result = command.ExecuteNonQuery();
                this.connection.Close();
                if (result != 0)
                {
                    Console.WriteLine("Employee Added Sucessfully");
                }
                else
                {
                    Console.WriteLine("Employee Added UnSucessfully");
                }

            }
        }
        public void DeleteEmployee(int id)
        {
            using (this.connection)
            {

                SqlCommand command = new SqlCommand("DeleteEmployee", this.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                this.connection.Open();
                var result = command.ExecuteNonQuery();
                this.connection.Close();
                if (result != 0)
                {
                    Console.WriteLine("Employee deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine("Employee deleted UnSucessfully");
                }


            }
        }
    }
}
