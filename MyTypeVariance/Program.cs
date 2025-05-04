using IReadBoxNamespace;
using IWriteBoxNamespace;
using MyListNamespace;
using TesterNamespace;
using DogNamespace;
using AnimalNamespace;

namespace MyProg
{
    public class Program
    {
        public static void Main()
        {
            MyList <int> arr = new MyList<int>();
            arr.Add(3);
            arr.Add(4);

            Tester.WriteTester(arr, 5);
            Tester.ReadTester(arr);

            var myList = new MyList<Dog>();
            Tester.WriteTester(myList, new Dog());
            Tester.ReadTester<Animal>(myList); 
        }
    }
}