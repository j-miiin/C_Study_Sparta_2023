namespace c_study_week4_4_3_2
{
    internal class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Func<int, int, int> addFunc = Add;
            int result = addFunc(3, 5);
            Console.WriteLine("결과: " + result);

            Action<string> printAction = PrintMessage;
            printAction("Hello, World");
        }
    }
}