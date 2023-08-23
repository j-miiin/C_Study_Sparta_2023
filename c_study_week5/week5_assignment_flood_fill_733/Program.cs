namespace week5_assignment_flood_fill_733
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] ground = new int[3][];
            ground[0] = new int[] { 1, 1, 1 };
            ground[1] = new int[] { 1, 1, 0 };
            ground[2] = new int[] { 1, 0, 1 };

            Solution.FloodFill(ground, 1, 1, 2);
            foreach (int[] i in ground)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }

        public class Solution
        {
            static int[] dx = { -1, 1, 0, 0 };
            static int[] dy = { 0, 0, -1, 1 };
            static Queue<int[]> queue = new Queue<int[]>();
            static bool[,] visited;

            public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
            {
                visited = new bool[image.Length, image[0].Length];
                int curColor = image[sr][sc];

                image[sr][sc] = color;
                visited[sr, sc] = true;
                queue.Enqueue(new int[] { sr, sc });

                while (queue.Count > 0)
                {
                    int[] curPos = queue.Dequeue();
                    int curX = curPos[0];
                    int curY = curPos[1];

                    for (int i = 0; i < 4; i++)
                    {
                        int nextX = curX + dx[i];
                        int nextY = curY + dy[i];

                        if (nextX < 0 || nextY < 0 || nextX >= image.Length || nextY >= image[0].Length) continue;

                        if (!visited[nextX, nextY] && image[nextX][nextY] == curColor)
                        {
                            visited[nextX, nextY] = true;
                            image[nextX][nextY] = color;
                            queue.Enqueue(new int[] { nextX, nextY });
                        }
                    }
                }
                return image;
            }
        }
    }
}