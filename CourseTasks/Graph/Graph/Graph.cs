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
            bool[] visited = new bool[length];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            visited[0] = true;

            while (queue.Count != 0)
            {
                int number = queue.Dequeue();
                action(number);

                for (int i = 0; i < length; i++)
                {
                    if (graph[number, i] == 1)
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            queue.Enqueue(i);
                        }
                    }
                }

                for (int i = 0; i < length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                        break;
                    }
                }
            }
        }

        private void StartDepthTraversal(int startVertex, bool[] visited, Action<int> action)
        {
            if (!visited[startVertex])
            {
                action(startVertex);
                visited[startVertex] = true;
            }

            int length = graph.GetLength(0);

            for (int i = startVertex; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (graph[i, j] == 1)
                    {
                        if (!visited[j])
                        {
                            StartDepthTraversal(j, visited, action);
                        }
                    }
                }
            }

            for (int i = startVertex; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!visited[j])
                    {
                        StartDepthTraversal(j, visited, action);
                    }
                }
            }
        }

        public void DepthTraversal(Action<int> action)
        {
            StartDepthTraversal(0, new bool[graph.GetLength(0)], action);
        }
    }
}