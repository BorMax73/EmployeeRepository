using Repository;

EmployeeRepository repository = new EmployeeRepository("repository.txt");
repository.Create(new Employee(1, "ww", 1, 12.0, DateTime.Now, "w2wwe"));
repository.Create(new Employee(2, "ww", 2, 13.0, DateTime.Now, "w4wwe"));
repository.Create(new Employee(3, "ww", 3, 14.0, DateTime.Now, "www2e"));

foreach (var VARIABLE in repository.GetAll())
{
    Console.WriteLine(VARIABLE.Id);
}
Console.WriteLine(repository.GetById(1).Age);

repository.Update(1,
    new Employee(1, "ww", 12222, 12.0, DateTime.Now, "weqeqeqeqweqeqeqe"));
Console.WriteLine(repository.GetById(1).Age);
repository.Delete(2);
foreach (var VARIABLE in repository.GetAll())
{
    Console.WriteLine(VARIABLE.Id);
}
