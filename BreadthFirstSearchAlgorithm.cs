using System;
using System.Collections.Generic;

namespace BreadthFirstSearchAlgorithm
{
    public class BreadthFirstSearchAlgorithm 
    {
        public static void Main(string[] args)
        {
            int n = 11;
            Graph g = new Graph(n);

            g.addEdge(1, 2);
            g.addEdge(1, 3);
            g.addEdge(2, 4);
            g.addEdge(3, 5);
            g.addEdge(3, 6);
            g.addEdge(4, 7);
            g.addEdge(5, 7);
            g.addEdge(5, 8);
            g.addEdge(5, 6);
            g.addEdge(8, 9);
            g.addEdge(9, 10);
            g.BFS();

/* You can find the image of the example graph here - https://i.imgur.com/Y3qYUct.png */
        }
    }

    class Graph
    {
        public Graph(int v)
        {
            vertices = v;
            adj = new List<int>[v]; // index list
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>(); // vertex's adjacent vertices list
                /*  ex.:
                 *  1 -- 2,3,
                 *  2 -- 4
                 *  3 -- 5, 6
                 *  etc. 
                 */
            }
        }

        public void addEdge(int c, int v)
        {
            adj[c].Add(v);
        }

        public void BFS()
        {
            int v = 1;
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            visited[v] = true;

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                Console.Write(v + " ");
                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
            Console.WriteLine();
        }

        private int vertices;
        private List<int>[] adj;
    }
}
