using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        class FordFulkerson
        {
            private int V; // Количество вершин в графе

            public FordFulkerson(int v)
            {
                V = v;
            }

            // Метод для нахождения максимального потока
            private bool BFS(int[,] rGraph, int s, int t, int[] parent)
            {
                bool[] visited = new bool[V];
                for (int i = 0; i < V; ++i)
                {
                    visited[i] = false;
                }

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(s);
                visited[s] = true;
                parent[s] = -1;

                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();

                    for (int v = 0; v < V; v++)
                    {
                        if (visited[v] == false && rGraph[u, v] > 0)
                        {
                            queue.Enqueue(v);
                            parent[v] = u;
                            visited[v] = true;
                        }
                    }
                }

                return (visited[t] == true);
            }

            // Метод для нахождения максимального потока от источника s к стоку t
            public int MaxFlow(int[,] graph, int s, int t)
            {
                int u, v;
                int[,] rGraph = new int[V, V];
                for (u = 0; u < V; u++)
                {
                    for (v = 0; v < V; v++)
                    {
                        rGraph[u, v] = graph[u, v];
                    }
                }

                int[] parent = new int[V];
                int maxFlow = 0;

                while (BFS(rGraph, s, t, parent))
                {
                    int pathFlow = int.MaxValue;
                    for (v = t; v != s; v = parent[v])
                    {
                        u = parent[v];
                        pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                    }

                    for (v = t; v != s; v = parent[v])
                    {
                        u = parent[v];
                        rGraph[u, v] -= pathFlow;
                        rGraph[v, u] += pathFlow;
                    }

                    maxFlow += pathFlow;
                }

                return maxFlow;
            }

            // Пример использования
            public static void Main()
            {
                // Пример графа в виде матрицы пропускных способностей
                int[,] graph = new int[,]
                {
                {0, 16, 13, 0, 0, 0},
                {0, 0, 10, 12, 0, 0},
                {0, 4, 0, 0, 14, 0},
                {0, 0, 9, 0, 0, 20},
                {0, 0, 0, 7, 0, 4},
                {0, 0, 0, 0, 0, 0}
                };

                FordFulkerson ff = new FordFulkerson(6);
                int source = 0;
                int sink = 5;
                Console.WriteLine("Максимальный поток: " + ff.MaxFlow(graph, source, sink));

                Console.Read();
            }
        }

    }
}
