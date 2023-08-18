namespace week2_assignment_find_max_min_value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5];
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("숫자를 입력하세요: ");
                nums[i] = int.Parse(Console.ReadLine());

                if (nums[i] < minValue) minValue = nums[i];
                if (nums[i] > maxValue) maxValue = nums[i];
            }

            Console.WriteLine("최대값: " + maxValue);
            Console.WriteLine("최소값: " + minValue);
        }
    }
}