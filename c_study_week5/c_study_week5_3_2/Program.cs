namespace c_study_week5_3_2
{
    internal class Program
    {
        static int V = 6;

        static void Dijkstra(int[,] graph, int start)
        {
            int[] distance = new int[V];
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[start] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && distance[v] <= minDistance)
                    {
                        minDistance = distance[v];
                        minIndex = v;
                    }
                }

                visited[minIndex] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[minIndex, v] != 0 
                        && distance[minIndex] != int.MaxValue && distance[minIndex] + graph[minIndex, v] < distance[v])
                    {
                        distance[v] = distance[minIndex] + graph[minIndex, v];
                    }
                }
            }

            Console.WriteLine("정점\t거리");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"{i}\t{distance[i]}");
            }
        }

        static void Main(string[] args)
        {
            int[,] graph = {
            { 0, 4, 0, 0, 0, 0 },
            { 4, 0, 8, 0, 0, 0 },
            { 0, 8, 0, 7, 0, 4 },
            { 0, 0, 7, 0, 9, 14 },
            { 0, 0, 0, 9, 0, 10 },
            { 0, 0, 4, 14, 10, 0 }
        };

            int start = 0; // 시작 정점

            Dijkstra(graph, start);
        }
    }
}