using System.Text.Json;


namespace Repository;

public struct EmployeeRepository
{
    //public List<Employee> Employees { get; set; }
    private string _path;

    public EmployeeRepository(string path)
    {
        _path = path;
        using (StreamWriter stream = new StreamWriter(path, true)) {}
    }

    public List<Employee> GetAll()
    {
        try
        {
            var jsonString = File.ReadAllText(_path);
            var result = new List<Employee>();
            if (!String.IsNullOrEmpty(jsonString))
            {
                result = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            }

            if (result != null)
            {
                return result;
            }
            return new List<Employee>();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error");
            throw;
        }
    }

    public Employee GetById(int id)
    {
        try
        {
            var result = GetAll().First(x => x.Id == id);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Not found");
            throw;
        }
        

    }
    public bool Create(Employee employee)
    {
        try
        {
            var jsonString = File.ReadAllText(_path);
            var data = new List<Employee>();
            if (!String.IsNullOrEmpty(jsonString))
            {
                data = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            }

            data.Add(employee);
            
            var serializedString = JsonSerializer.Serialize(data);
            File.Delete(_path);
            File.WriteAllText(_path, serializedString);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public bool Update(int id, Employee employee)
    {
        try
        {
            var jsonString = File.ReadAllText(_path);
            var data = new List<Employee>();
            if (!String.IsNullOrEmpty(jsonString))
            {
                data = JsonSerializer.Deserialize<List<Employee>>(jsonString);

            }

            var k = data.IndexOf(data.Find(x => x.Id == id));
            data[k] = employee;

            var serializedString = JsonSerializer.Serialize(data);
            File.Delete(_path);
            File.WriteAllText(_path, serializedString);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    public bool Delete(int id)
    {
        try
        {
            var jsonString = File.ReadAllText(_path);
            var data = new List<Employee>();
            if (!String.IsNullOrEmpty(jsonString))
            {
                data = JsonSerializer.Deserialize<List<Employee>>(jsonString);
                var k = data.IndexOf(data.Find(x => x.Id == id));

                data.Remove(data[k]);
                var serializedString = JsonSerializer.Serialize(data);
                File.Delete(_path);
                File.WriteAllText(_path, serializedString);
                return true;
            }
            else
            {
                return false;
            }


            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }


    }
}