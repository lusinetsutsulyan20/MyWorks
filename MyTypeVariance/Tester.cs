using IReadBoxNamespace;
using IWriteBoxNamespace;
namespace TesterNamespace
{
    public class Tester
    {
        public static void ReadTester<T>(IReadBox<T> readBox)
        {
            Console.WriteLine(readBox[0]);
        }

        public static void WriteTester<T> (IWriteBox<T> writeBox, T item)
        {
            writeBox.Add(item);
        }
    }
}