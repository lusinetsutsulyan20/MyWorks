using System;
using System.Collections;
using System.Runtime.CompilerServices;
using MyArray;
using People;
namespace Prog{
public class Program
{
    public static void Main()
    {
        MyArrayList arr = new MyArrayList();
        Person p1 = new Person("aaa", 11);
        Person p2 = new Person("bbb", 22);
        Person p3 = new Person("ccc", 33);
        Person p4 = new Person("ddd", 44);
        Person p5 = new Person("eee", 55);

        arr.Add(p1);
        arr.Add(p2);
        arr.Add(p4);
        arr.Add(p5);
        
        arr[2] =  p3;
        arr.Print();
        Console.WriteLine();

        int ind = arr.BinarySearch(p1, new CompareByAge());
        Console.WriteLine(ind);
        // arr.Insert(3,p4);
        // arr.Print();

        // Console.WriteLine(arr.Contains(p1));

        // Console.WriteLine(arr[2].ToString());

        // arr.Remove(p2)
        // ;
        // Console.WriteLine(arr[1].ToString());
        // Console.WriteLine();
        // arr.Print();

        // arr.Add(5);
        // arr.Add(3);
        // arr.Add("SDf");
        // arr.Print();
        // arr.RemoveAt(0);
        // // Console.WriteLine(arr[1]);
        // arr.Insert(5, 9);
        // arr.Print();
        // Console.WriteLine (arr.Contains(9));
        // Console.WriteLine (arr.Contains("Svc"));

        // MyArrayList[] people = new MyArrayList[2](){
        //     new() = ("Anna", 15),
        //     new Person("Ani", 22)
        // }
        

        // arr.Add(p1);
        // arr.Add(p2);
        // arr.Print();
    }
}   
}
