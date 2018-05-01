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

            while (queue.Count != 0)
            {
                int number = queue.Dequeue();

                for (int i = 0; i < length; i++)
                {
                    if (graph[number, i] == 1)
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            action(i);
                            queue.Enqueue(i);
                        }
                    }
                }

                for (int i = 0; i < length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        action(i);
                        queue.Enqueue(i);
                        break;
                    }
                }
            }
        }

        private void StartDepthTraversal(bool[] visited, Action<int> action)
        {
            int length = graph.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (graph[i, j] == 1)
                    {
                        if (!visited[j])
                        {
                            visited[j] = true;
                            action(j);
                            StartDepthTraversal(visited, action);
                        }
                    }

                }
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!visited[j])
                    {
                        visited[j] = true;
                        action(j);
                        StartDepthTraversal(visited, action);
                    }
                }
            }
        }

        public void DepthTraversal(Action<int> action)
        {
            StartDepthTraversal(new bool[graph.GetLength(0)], action);
        }
    }
}