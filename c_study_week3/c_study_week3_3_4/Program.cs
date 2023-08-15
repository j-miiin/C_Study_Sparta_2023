namespace c_study_week3_3_4
{
    internal class Program
    {
        // out 키워드 예시
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        // ref 키워드 예시
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b= temp;
        }

        static void Main(string[] args)
        {
            int quotient, remainder;
            Divide(7, 3, out quotient, out remainder);
            Console.WriteLine($"{quotient}, {remainder}");

            int x = 1, y = 3;
            Swap(ref x, ref y);
            Console.WriteLine($"{x}, {y}");
        }
    }
}