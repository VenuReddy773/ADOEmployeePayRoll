using System;
using System.Collections.Generic;
using System.Text;

namespace AODEmployeePayRoll
{
    class Employee
    {
        public int emp_id { get; set; }
        public string Emp_name { get; set; }
        public double salary { get; set; }
        public DateTime start { get; set; }
        public double  BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public char gender { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeDepartment { get; set; }
    }
}
