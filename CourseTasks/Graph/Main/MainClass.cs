﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Graph;

namespace Graph.Main
{
    class MainClass
    {
        static void Main(string[] args)
        {
            /*int[,] matrix = {
                { 0, 1, 0, 0, 0, 1, 1},
                { 1, 0, 0, 1, 1, 1, 0},
                { 0, 0, 0, 1, 0, 0, 1},
                { 0, 1, 1, 0, 1, 0, 0},
                { 0, 1, 0, 1, 0, 0, 0},
                { 1, 1, 0, 0, 0, 0, 0},
                { 1, 0, 1, 0, 0, 0, 0}
            }; */

            int[,] matrix = {
                { 0, 1, 0, 0, 0, 1, 1},
                { 1, 0, 0, 0, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 0, 0, 0, 0, 0},
                { 1, 1, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0}
            };

            Graph.Graph graph = new Graph.Graph(matrix);

            graph.BreadthTraversal(Console.WriteLine);
        }
    }
}
