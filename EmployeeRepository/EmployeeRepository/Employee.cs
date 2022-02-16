namespace Repository;

public struct Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int Age { get; set; }
    public double Height { get; set; }
    public DateTime Birthday { get; set; }
    public string BirthdayPlace { get; set; }

    public Employee(int id, string fullName, int age, double height, DateTime birthday, string birthdayPlace)
    {
        FullName = fullName;
        Id = id;
        Age = age;
        Height = height;
        Birthday = birthday;
        BirthdayPlace = birthdayPlace;
    }
}