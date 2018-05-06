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
            queue.Enqueue(0);

            bool[] visited = new bool[length];

            while (queue.Count > 0)
            {
                int element = queue.Dequeue();

                if (!visited[element])
                {
                    visited[element] = true;

                    action(element);

                    for (int i = 0; i < length; i++)
                    {
                        if (graph[element, i] == 1)
                        {
                            queue.Enqueue(i);
                        }
                    }

                    continue;
                }

                for (int i = 0; i < length; i++)
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                        break;
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
                    if (graph[vertex, i] == 1)
                    {
                        StartDepthTraversal(i, visited, action);
                    }
                }

                for (int i = 0; i < visited.Length; i++)
                {
                    StartDepthTraversal(i, visited, action);
                }
            }
        }

        public void DepthTraversal(Action<int> action)
        {
            StartDepthTraversal(0, new bool[graph.GetLength(0)], action);
        }
    }
}