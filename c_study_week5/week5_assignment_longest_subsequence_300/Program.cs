namespace week5_assignment_longest_subsequence_300
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 }));
        }

        public class Solution
        {
            public static int LengthOfLIS(int[] nums)
            {
                int[] longestSub = new int[nums.Length];

                for (int i = 0; i < nums.Length; i++)
                {
                    longestSub[i] = 1;
                    for (int j = 0; j <= i - 1; j++)
                    {
                        if ((nums[j] < nums[i]) && (longestSub[j] + 1 > longestSub[i]))
                        {
                            longestSub[i] = longestSub[j] + 1;
                        }
                    }
                }

                return longestSub.Max();
            }
        }
    }
}