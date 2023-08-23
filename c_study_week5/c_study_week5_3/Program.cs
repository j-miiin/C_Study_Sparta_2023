namespace c_study_week5_3
{
    internal class Program
    {
        public class Graph
        {
            private int V;
            private List<int>[] adj;

            public Graph(int V)
            {
                this.V = V;
                adj = new List<int>[V];
                for (int i = 0; i < V; i++)
                {
                    adj[i] = new List<int>();
                }
            }

            public void AddEdge(int v, int w)
            {
                adj[v].Add(w);
            }

            public void DFS(int v)
            {
                bool[] visited = new bool[V];
                DFSUtil(v, visited);
            }

            private void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;
                Console.Write($"{v} ");

                foreach (int n in adj[v])
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, visited);
                    }
                }
            }

            public void BFS(int v)
            {
                bool[] visited = new bool[V];
                Queue<int> queue = new Queue<int> ();

                visited[v] = true;
                queue.Enqueue(v);

                while (queue.Count > 0)
                {
                    int n = queue.Dequeue();
                    Console.Write($"{n} ");

                    foreach (int m in adj[n])
                    {
                        if (!visited[m])
                        {
                            visited[m] = true;
                            queue.Enqueue(m);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Graph graph = new Graph(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            Console.WriteLine("DFS travelsal: ");
            graph.DFS(0);
            Console.WriteLine();

            Console.WriteLine("BFS travelsal: ");
            graph.BFS(0);
            Console.WriteLine();
        }
    }
}