namespace week1_assignment_bmi_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your weight and height: ");
            string[] answer = Console.ReadLine().Split(' ');
            int weight = int.Parse(answer[0]); 
            int height = int.Parse(answer[1]);
            Console.WriteLine("Your BMI is " + (weight / (height * height * 0.0001)).ToString("N2"));
        }
    }
}