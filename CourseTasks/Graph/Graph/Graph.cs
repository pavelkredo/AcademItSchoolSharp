using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Graph
{
    class Graph
    {
        private int[,] graph;

        public Graph(int[,] matrix)
        {
            graph = matrix;
        }

        public void BreadthTraversal(Action<int> action)
        {
            int length = graph.GetLength(0);

            if (length == 0)
            {
                return;
            }

            Queue<int> queue = new Queue<int>();

            bool[] visited = new bool[length];

            for (int i = 0; i < length; i++)
            {
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int element = queue.Dequeue();

                    if (!visited[element])
                    {
                        visited[element] = true;

                        action(element);

                        for (int j = 0; j < length; j++)
                        {
                            if (graph[element, j] == 1)
                            {
                                queue.Enqueue(j);
                            }
                        }

                        continue;
                    }
                }
            }
        }

        private void StartDepthTraversal(int vertex, bool[] visited, Action<int> action)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                action(vertex);

                for (int i = 0; i < visited.Length; i++)
                {
                    if (graph[vertex, i] == 1 && !visited[i])
                    {
                        StartDepthTraversal(i, visited, action);
                    }
                }
            }
        }

        public void DepthTraversal(Action<int> action)
        {
            int length = graph.GetLength(0);

            if (length == 0)
            {
                return;
            }

            bool[] visited = new bool[length];

            for (int i = 0; i < length; i++)
            {
                if (!visited[i])
                {
                    StartDepthTraversal(i, visited, action);
                }
            }
        }
    }
}