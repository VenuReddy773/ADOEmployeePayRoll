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
        public List<Employee> EmpList = new List<Employee>();
        public List<Employee> GetAllEmployees()
        {
            connection();

            SqlCommand com = new SqlCommand("GetPayRoleService", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee
                    {

                        emp_id = Convert.ToInt32(dr["emp_id"]),
                        Emp_name = Convert.ToString(dr["Emp_name"]),
                        salary = Convert.ToDouble(dr["salary"]),
                        start = Convert.ToDateTime(dr["start"]),
                        BasicPay = Convert.ToDouble(dr["BasicPay"]),
                        Deductions = Convert.ToDouble(dr["Deductions"]),
                        TaxablePay = Convert.ToDouble(dr["TaxablePay"]),
                        IncomeTax = Convert.ToDouble(dr["IncomeTax"]),
                        NetPay = Convert.ToDouble(dr["NetPay"]),
                        gender = Convert.ToChar(dr["gender"]),
                        EmployeePhone = Convert.ToString(dr["EmployeePhone"]),
                        EmployeeAddress = Convert.ToString(dr["EmployeeAddress"]),
                        EmployeeDepartment = Convert.ToString(dr["EmployeeDepartment"])
                    }
                    );
            }
            return EmpList;
        }
        public void Display()
        {
            foreach (var item in EmpList)
            {
                Console.WriteLine("\nName\tsalary\tstartDate\t\tEmplyeePhone\tEmployeeDept\n");
                Console.WriteLine(item.Emp_name + "\t" + item.salary + "\t" + item.start + "\t" + item.EmployeePhone + "\t" + item.EmployeeDepartment);
            }
        }
    }
}
