using System;

namespace UndirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(5);
            graph.AddVertex(26);
            graph.AddVertex(89);
            graph.AddVertex(12);
            bool istrue = graph.Connect(12, 89);
            bool isfalse = graph.Connect(89, 12);
            graph.Connect(12, 26);
            graph.Connect(5, 12);
            graph.Connect(89, 5);
            bool shouldfalse = graph.Disconnect(5, 26);
            bool shouldtrue = graph.Disconnect(12, 89);
            graph.RemoveVertex(12);
        }
    }
}
