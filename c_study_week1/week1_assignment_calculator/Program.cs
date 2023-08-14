namespace week1_assignment_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your two numbers: ");
            string[] answer = Console.ReadLine().Split(' ');
            int num1 = int.Parse(answer[0]);
            int num2 = int.Parse(answer[1]);

            Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
            Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
            Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
            Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
            Console.WriteLine("{0} % {1} = {2}", num1, num2, num1 % num2);
        }
    }
}