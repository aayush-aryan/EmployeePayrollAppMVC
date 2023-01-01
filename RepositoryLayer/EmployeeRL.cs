using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer
{
   public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;
        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddEmployee(EmployeeModel emp)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    cmd.Parameters.AddWithValue("@Profileimage", emp.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", emp.Notes);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees(int? id)
        {
            try
            {
                EmployeeModel emp = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    string sqlQuery = "SELECT * FROM tblEmployeeInfo WHERE EmpId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        emp.EmpName = Convert.ToString(rdr["EmpName"]);
                        emp.Profileimage = Convert.ToString(rdr["Profileimage"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        emp.Notes = Convert.ToString(rdr["Notes"]);
                    }
                }
                return (IEnumerable<EmployeeModel>)emp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> listemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();

                        emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        emp.EmpName= Convert.ToString(rdr["EmpName"]);
                        emp.Profileimage = Convert.ToString(rdr["Profileimage"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        emp.Notes = Convert.ToString(rdr["Notes"]);

                        listemployee.Add(emp);
                    }
                    con.Close();
                }
                return listemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel emp = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    string sqlQuery = "SELECT * FROM EMPTable WHERE EmpId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        emp.EmpName = Convert.ToString(rdr["EmpName"]);
                        emp.Profileimage = Convert.ToString(rdr["Profileimage"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        emp.Notes = Convert.ToString(rdr["Notes"]);
                    }
                }
                return emp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateEmployee(EmployeeModel emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BzEmployeeMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    cmd.Parameters.AddWithValue("@Profileimage", emp.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", emp.Notes); 
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
