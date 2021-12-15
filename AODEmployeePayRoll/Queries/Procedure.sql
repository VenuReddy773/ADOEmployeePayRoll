create procedure AddPayRoleServices
(
	@Emp_name varchar(100),
	@salary double precision,
	@start date,
	@BasicPay float,
	@Deductions float,
	@TaxablePay float,
	@IncomeTax float,
	@NetPay float,
	@gender varchar(1),
	@EmployeePhone varchar(20),
	@EmployeeAddress varchar(100),
	@EmployeeDepartment varchar(50)
)
as 
begin try
insert into employee_payroll values(@Emp_name,@salary,@start,@BasicPay,@Deductions,@TaxablePay,@IncomeTax,@NetPay,@gender,@EmployeePhone,@EmployeeAddress,@EmployeeDepartment)

end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch



create procedure DeletePayRoleService
(
	@emp_id int
)
as 
begin try
delete from employee_payroll where emp_id=@emp_id 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch


select * from employee_payroll 

exec DeletePayRoleServices 1


create procedure GetPayRoleService
as 
begin try
select * from employee_payroll  
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch


create procedure UpdatePayRoleService
(
	@emp_id int,
	@Emp_name varchar(100),
	@BasicPay float
)
as 
begin try
update employee_payroll set BasicPay=@BasicPay where emp_id =@emp_id  
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch


