namespace week1_assignment_fahrenheit_converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Celsius degree: ");
            int celcius = int.Parse(Console.ReadLine());
            Console.WriteLine("Fahrenheit Degree is {0}", (celcius * 1.8) + 32);
        }
    }
}