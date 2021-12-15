using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AODEmployeePayRoll
{
    class Operations
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = "Server = (localdb)\\MSSQLLocalDB; Database = payroll_service; Trusted_Connection = true";
            con = new SqlConnection(constr);
        }
        //To Add Employee details    
        public bool AddEmployee(Employee obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddPayRoleServices", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Emp_name", obj.Emp_name);
            com.Parameters.AddWithValue("@salary", obj.salary);
            com.Parameters.AddWithValue("@start", obj.start);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);
            com.Parameters.AddWithValue("@Deductions", obj.Deductions);
            com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
            com.Parameters.AddWithValue("@IncomeTax", obj.IncomeTax);
            com.Parameters.AddWithValue("@NetPay", obj.NetPay);
            com.Parameters.AddWithValue("@gender", obj.gender);
            com.Parameters.AddWithValue("@EmployeePhone", obj.EmployeePhone);
            com.Parameters.AddWithValue("@EmployeeAddress", obj.EmployeeAddress);
            com.Parameters.AddWithValue("@EmployeeDepartment", obj.EmployeeDepartment);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
