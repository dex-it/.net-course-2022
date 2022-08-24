using Models;


var Emp = new Employee("Elon", "Musk",12512);
Console.WriteLine($"Name: {Emp.fname},Last name:{Emp.l_name},Unique ID:{Emp.id}");
Console.WriteLine(Employee.updEmp("Elon","Musk"));

