using System.Collections;
namespace People{
public class Person 
{
    public string Name {get; private set;}
    public int Age {get; private set;}
    public Person (string name,  int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} is {Age} years old";
    }
}
public class CompareByAge : IComparer
{
    public int Compare (object obj1, object obj2)
    {
        Person person1 = obj1 as Person;
        Person person2 = obj2 as Person;
        if (person1 == null || person2 == null)
        {
            throw new ArgumentException("Both arguments must be of type Person.");
        }
        if (person1.Age == person2.Age) 
            return 0;
        else if (person1.Age > person2.Age)
            return -1;
        else 
            return 1;
    }
}
}   
