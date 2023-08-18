namespace week1_assignment_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your two numbers: ");
            //string[] answer = Console.ReadLine().Split(' ');
            //int num1 = int.Parse(answer[0]);
            //int num2 = int.Parse(answer[1]);

            //Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
            //Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
            //Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
            //Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
            //Console.WriteLine("{0} % {1} = {2}", num1, num2, num1 % num2);

            Console.Write("첫 번째 수를 입력하세요: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("두 번째 수를 입력하세요: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("더하기: {0}", num1 + num2);
            Console.WriteLine("빼기: {0}", num1 - num2);
            Console.WriteLine("곱하기: {0}", num1 * num2);
            Console.WriteLine("나누기: {0}", (float)num1 / num2);
        }
    }
}