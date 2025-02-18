namespace PJT2502181
{
    class DynamicArray
    {


        void Add(Object inObject)
        {
            objects[CurrentPosition] = inObject;
        }

        Object[] objects = new object[10];
        int CurrentPosition = 0;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
