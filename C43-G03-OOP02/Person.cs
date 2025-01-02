namespace C43_G03_OOP02;

internal struct Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }

    public int Age { get; }
}