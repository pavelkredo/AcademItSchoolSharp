using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Graph
{
    class GraphClass
    {
        private int[,] graph;

        public GraphClass(int[,] matrix)
        {
            graph = matrix;
        }

        public void BreadthTraversal()
        {
            int length = graph.GetLength(0);
            bool[] visited = new bool[length];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < length; i++)
            {
                for (int number = 0; number < queue.Count(); number = queue.Dequeue())
                {
                    if (!visited[number])
                    {
                        visited[i] = true;

                        for (int j = 0; j < length; j++)
                        {
                            if (graph[number, j] == 1)
                            {
                                queue.Enqueue(j);
                            }
                        }
                    }
                }
            }
        }

        public void DepthTraversal(bool[] visited)
        {
            int length = graph.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;

                    for (int j = 0; j < length; j++)
                    {
                        if (graph[i, j] == 1)
                        {
                            DepthTraversal(visited);
                        }
                    }
                }
            }
        }

        public void StartDepthTraversal()
        {
            DepthTraversal(new bool[graph.GetLength(0)]);
        }
    }
}