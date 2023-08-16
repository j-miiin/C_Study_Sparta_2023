namespace c_study_week4_4_3
{
    internal class Program
    {
        delegate void MyDelegate(string message);

        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message);
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }

        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            myDelegate("Hello");
        }
    }
}