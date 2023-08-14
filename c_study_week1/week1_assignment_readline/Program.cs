namespace week1_assignment_readline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name and age: ");
            string[] answer = Console.ReadLine().Split(' ');
            string name = answer[0];
            int age = int.Parse(answer[1]);
            Console.WriteLine($"name: {name}, age: {age}");
        }
    }
}