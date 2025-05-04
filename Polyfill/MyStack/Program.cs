using System;
using MyStack;
using People;
namespace Prog{
public class Program
{
    public static void Main()
    {
        MyStack<Person> arr = new MyStack<Person>();
        arr.Push(new Person("aa", 11));
        arr.Push(new Person("bb", 22));
        arr.Push(new Person("cc", 33));
        arr.Print();
        arr.Pop();
        Console.WriteLine();
        arr.Print();
        Console.WriteLine (arr.Peek());
    }
}
}
