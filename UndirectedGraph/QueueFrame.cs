using System;
using System.Collections.Generic;
using System.Text;

namespace UndirectedGraph
{
    class QueueFrame<T>
    {
        public bool wasVisisted;
        public Vertex<T> Vertex;

        public QueueFrame(Vertex<T> vertex)
        {
            wasVisisted = false;
            this.Vertex = vertex;
        }
    }
}
