namespace c_study_week2_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] map = new int[5, 5]
            {
                {1, 1, 0, 1, 1 },
                {1, 0, 1, 0, 0 },
                {1, 1, 0, 1, 1 },
                {0, 1, 1, 1, 0 },
                {1, 0, 1, 0, 1 },
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (map[i,j] == 1)
                    {
                        Console.Write("■");
                    } else
                    {
                        Console.Write("□");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}