namespace week2_assignment_print_star
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int length = 2 * 5 - 1;
            for (int i = 1; i <= length; i += 2)
            {
                int blankLength = (length - i) / 2;
                for (int j = 1; j <= blankLength; j++)
                {
                    Console.Write(" ");
                }
                for (int j = blankLength + 1; j <= length - blankLength; j++)
                {
                    Console.Write("*");
                }
                for (int j = (length - blankLength) + 1; j <= length; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}