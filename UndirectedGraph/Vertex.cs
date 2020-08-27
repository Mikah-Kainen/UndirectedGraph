using System;
using System.Collections.Generic;
using System.Text;

namespace UndirectedGraph
{
    class Vertex<T>
    {
        public T Value { get; set; }

        public List<Vertex<T>> Edges;
        public int Count { get { return Edges.Count; } }

        public Vertex(T value)
        {
            Edges = new List<Vertex<T>>();
            Value = value;
        }

        public bool IsConnected(T targetValue)
        {
            foreach(Vertex<T> vertex in Edges)
            {
                if(vertex.Value.Equals(targetValue))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
