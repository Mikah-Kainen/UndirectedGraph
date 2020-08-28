using System;
using System.Collections.Generic;
using System.Text;

namespace UndirectedGraph
{
    class QueueFrame<T>
    {
        public bool wasVisited;
        public Vertex<T> Vertex;

        public QueueFrame(Vertex<T> vertex)
        {
            wasVisited = false;
            this.Vertex = vertex;
        }
    }
}
