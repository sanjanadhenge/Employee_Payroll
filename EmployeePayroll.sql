--UC1
Create Database payroll_service;
Use payroll_service;

--UC2
Create table employee_payroll
(
ID int Primary Key identity(1,1),
Name VarChar(30),
Salary Bigint,
StartDate Date
)

--UC3
Insert into employee_payroll(Name,Salary, StartDate) values('Sanjana','10000','2021-07-15');
Insert into employee_payroll(Name,Salary, StartDate) values('Radha','20000','2021-07-16');
Insert into employee_payroll(Name,Salary, StartDate) values('Rutuja','30000','2021-07-17');
Insert into employee_payroll(Name,Salary, StartDate) values('Smita','40000','2021-07-18');
Insert into employee_payroll(Name,Salary, StartDate) values('Pranali','50000','2021-07-19');

--UC4
Select * from employee_payroll;

--UC5
Select * from employee_payroll where StartDate between cast('2021-07-16'as Date)and CURRENT_TIMESTAMP;

--UC6
Alter table employee_payroll add Gender varchar (1);

Update employee_payroll set Gender='F' where Name='Sanjana';
Update employee_payroll set Gender='F' where Name='Radha';
Update employee_payroll set Gender='F' where Name='Rutuja';
Update employee_payroll set Gender='F' where Name='Smita';
Update employee_payroll set Gender='F' where Name='Pranali';
--UC7
select SUM(Salary) from employee_payroll where Gender ='F' Group by Gender;
select Gender,AVG(salary) from employee_payroll Group by Gender;
select MIN(Salary) from employee_payroll where Gender='F';
select Max(Salary) from employee_payroll where Gender='F';
Select COUNT(*) from employee_payroll Group by Gender;

--UC8
Alter table employee_payroll add Phone varchar (10),Address VarChar(100);
Alter table employee_payroll add Department VarChar(20);
--UC9
Alter table employee_payroll add BasicPay Bigint,Deduction Bigint,TaxeblePay Bigint,Incometax Bigint,NetPay Bigint;
Update employee_payroll set Phone='9568135', Address='MH',BasicPay='500',Deduction = '600',TaxeblePay='700',Incometax='670',NetPay='980' where Name='Sanjana';
Update employee_payroll set Phone='9843954',Address='Delhi', BasicPay='500',Deduction = '600',TaxeblePay='700',Incometax='670',NetPay='980' where Name='Radha';
Update employee_payroll set Phone='9568135', Address='MH',BasicPay='500',Deduction = '600',TaxeblePay='700',Incometax='670',NetPay='980' where Name='Rutuja';
Update employee_payroll set Phone='9843954',Address='Delhi', BasicPay='500',Deduction = '600',TaxeblePay='700',Incometax='670',NetPay='980' where Name='Smita';
Update employee_payroll set Phone='9568135', Address='MH',BasicPay='500',Deduction = '600',TaxeblePay='700',Incometax='670',NetPay='980' where Name='Pranali';


--UC10
Alter table employee_payroll add Department VarChar(20);
Insert into employee_payroll(Name,Salary, StartDate,Gender,Phone,Address,BasicPay,Deduction,TaxeblePay,Incometax,NetPay,Department) values('Terissa','10000','2021-07-15','F','95984562','MH','1000','500','600','800','900','Sales');
Insert into employee_payroll(Name,Salary, StartDate,Gender,Phone,Address,BasicPay,Deduction,TaxeblePay,Incometax,NetPay,Department) values('Terissa','10000','2021-07-15','F','95984562','MH','1000','500','600','800','900','Marketing');

--UC11
Alter table employee_payroll drop column Department;
Create table Department
(
ID int Primary Key identity(1,1),
DeptName VarChar(20),
EmpID int foreign key REFERENCES employee_payroll(ID)
);

Insert into Department(DeptName,EmpID) values('sales',1);
Insert into Department(DeptName,EmpID) values('Marketing',1);
select * from Department;

--UC11
--ER Diagram
Go
Create Procedure AddEmployee
(
@Name Varchar(30),
@Salary Bigint,
@StartDate Date,
@Gender Varchar(1),
@Phone VarChar(10),
@Address VarChar(100),
@BasicPay Bigint,
@Deduction Bigint,
@TaxeblePay Bigint,
@Incometax Bigint,
@NetPay Bigint

)
as
begin
Insert into employee_payroll values(@Name,@Salary,@StartDate,@Gender,@Phone,@Address,@BasicPay,@Deduction ,@TaxeblePay ,@Incometax ,@NetPay )
End;

Go
Create Procedure DeleteEmployee
(
@ID int
)
as
begin
Delete from employee_payroll where ID=@ID;
End;
Go
Create Procedure UpdateEmp
(
@EmpId int,
@Salary Bigint
)
as
begin
Update employee_payroll set Salary=@Salary where ID = @EmpId
End;

