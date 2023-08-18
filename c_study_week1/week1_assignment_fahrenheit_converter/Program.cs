namespace week1_assignment_fahrenheit_converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter Celsius degree: ");
            //int celcius = int.Parse(Console.ReadLine());
            //Console.WriteLine("Fahrenheit Degree is {0}", (celcius * 1.8) + 32);

            Console.Write("섭씨 온도를 입력하세요: ");
            int celcius = int.Parse(Console.ReadLine());
            Console.WriteLine("변환된 화씨 온도: {0}", (celcius * 9/5) + 32);
        }
    }
}