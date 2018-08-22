using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabEmployeeService
{
    public class DatabaseHelper
    {
        public static string FSD_CONN_STRING = ConfigurationManager.ConnectionStrings["FSDConnection"].ConnectionString;

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> lstEmployees = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Employee", connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    lstEmployees = new List<EmployeeDTO>();

                while (reader.Read())
                {
                    lstEmployees.Add(new EmployeeDTO
                    {
                        EmployeeID = int.Parse(reader["EmployeeId"].ToString()),
                        EmployeeFirstName = reader["Employee_FName"].ToString(),
                        EmployeeLastName = reader["Employee_LName"].ToString(),
                        DepartmentID = reader["DepartmentId"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return lstEmployees;
        }

        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Employee where EmployeeId=@employeeId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@employeeId", SqlDbType.Int).Value = Convert.ToInt32(employeeId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee = new EmployeeDTO
                    {
                        EmployeeID = int.Parse(reader["EmployeeId"].ToString()),
                        EmployeeFirstName = reader["Employee_FName"].ToString(),
                        EmployeeLastName = reader["Employee_LName"].ToString(),
                        DepartmentID = reader["DepartmentId"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return employee;
        }

        public int AddEmployee(EmployeeDTO employee)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Insert into Employee([EmployeeId],[Employee_FName],[Employee_LName],[DepartmentId]) " +
                    "values (@EmployeeId, @EmployeeFName,@EmployeeLName,@DepartmentId)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = Convert.ToInt32(employee.EmployeeID);
                command.Parameters.Add("@EmployeeFName", SqlDbType.VarChar).Value = employee.EmployeeFirstName;
                command.Parameters.Add("@EmployeeLName", SqlDbType.VarChar).Value = employee.EmployeeLastName;
                command.Parameters.Add("@DepartmentId", SqlDbType.Char,2).Value = employee.DepartmentID;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int UpdateEmployee(EmployeeDTO employee)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Update Employee set [Employee_FName] = @EmployeeFName, " +
                    "[Employee_LName] = @EmployeeLName," +
                    "DepartmentId = @DepartmentId " +
                    "where EmployeeId = @EmployeeId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = Convert.ToInt32(employee.EmployeeID);
                command.Parameters.Add("@EmployeeFName", SqlDbType.VarChar).Value = employee.EmployeeFirstName;
                command.Parameters.Add("@EmployeeLName", SqlDbType.VarChar).Value = employee.EmployeeLastName;
                command.Parameters.Add("@DepartmentId", SqlDbType.Char, 2).Value = employee.DepartmentID;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int DeleteEmployee(int employeeId)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Delete from Employee where EmployeeId = @EmployeeId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = Convert.ToInt32(employeeId);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }
    }
}