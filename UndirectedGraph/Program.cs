using System;
using System.Collections.Generic;

namespace UndirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            //graph.AddVertex(5);
            //graph.AddVertex(26);
            //graph.AddVertex(89);
            //graph.AddVertex(12);
            //bool istrue = graph.Connect(12, 89);
            //bool isfalse = graph.Connect(89, 12);
            //graph.Connect(12, 26);
            //graph.Connect(5, 12);
            //graph.Connect(89, 5);
            //bool shouldfalse = graph.Disconnect(5, 26);
            //bool shouldtrue = graph.Disconnect(12, 89);
            //graph.RemoveVertex(12);

            graph.AddVertex(5);
            graph.AddVertex(25);
            graph.AddVertex(32);
            graph.AddVertex(23);
            graph.AddVertex(86);
            graph.Connect(5, 25);
            graph.Connect(25, 32);
            graph.Connect(5, 23);
            graph.Connect(5, 86);
            graph.Connect(32, 86);
            graph.AddVertex(100);
            graph.Connect(86, 100);

            List<int> list = graph.DeapthFirst(5);
            var listq = graph.BreathFirst(5);

            var dfs = graph.DFS(5);
        }
    }
}
