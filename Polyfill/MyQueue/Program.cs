using System;
using System.Runtime.CompilerServices;
using MyQueue;
using People;
namespace Prog{

public class Program
{
    public static void Main()
    {
        Queue<Person> people = new Queue<Person>();

        people.Enqueue(new Person("aa", 11));
        people.Enqueue(new Person("bb", 22));
        people.Dequeue();
        foreach (var item in people)
        {
            Console.WriteLine(item);
        }
    }
}
}
