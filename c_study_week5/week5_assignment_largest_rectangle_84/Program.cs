namespace week5_assignment_largest_rectangle_84
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.LargestRectangleArea(new int[] { 1, 1 }));
        }

        public class Solution
        {
            public static int LargestRectangleArea(int[] heights)
            {
                int[] left = GetFirstSmallerIndexArray(heights, true);
                Array.Reverse(heights);
                int[] right = GetFirstSmallerIndexArray(heights, false);
                Array.Reverse(heights);
                Array.Reverse(right);

                int maxArea = 0;
                for (int i = 0; i < heights.Length; i++)
                {
                    int curArea = (right[i] - left[i] - 1) * heights[i];
                    if (curArea > maxArea) maxArea = curArea;
                }

                return maxArea;
            }

            public static int[] GetFirstSmallerIndexArray(int[] target, bool isLeft)
            {
                int length = target.Length;
                Stack<int> stack = new Stack<int>();
                int[] result = new int[length];

                for (int i = 0; i < length; i++)
                {
                    while (stack.Count > 0)
                    {
                        int idx = stack.Peek();
                        if (target[idx] >= target[i])
                        {
                            stack.Pop();
                        }
                        else break;
                    }
                    int resultIdx = (stack.Count == 0) ? -1 : stack.Peek();
                    result[i] = (isLeft) ? resultIdx : (length - 1 - resultIdx);
                    stack.Push(i);
                }
                return result;
            }
        }
    }
}