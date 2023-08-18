namespace week1_assignment_bmi_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("키를 입력하세요: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("몸무게를 입력하세요: ");
            int weight = int.Parse(Console.ReadLine());
            Console.WriteLine("당신의 BMI 지수는 " + (weight / (height * height * 0.0001)).ToString("N2") + " 입니다.");
        }
    }
}