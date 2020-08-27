using System;
using System.Collections.Generic;
using System.Text;

namespace UndirectedGraph
{
    class Graph<T>
    {
        public List<Vertex<T>> Vertexes;
        public int Count { get { return Vertexes.Count; } }

        public Graph()
        {
            Vertexes = new List<Vertex<T>>();
        }

        public Vertex<T> FindVertex(T value)
        {
            foreach (Vertex<T> vertex in Vertexes)
            {
                if(vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }

        public bool AddVertex(T targetValue)
        {
            if(FindVertex(targetValue) != null)
            {
                return false;
            }
            Vertexes.Add(new Vertex<T>(targetValue));
            return true;
        }

        public bool DisconnectAll(T targetValue)
        {
            Vertex<T> targetVertex = FindVertex(targetValue);
            if(targetVertex == null)
            {
                return false;
            }

            int start = targetVertex.Edges.Count - 1;
            for(int i = start; i >= 0; i --)
            {
                Disconnect(targetValue, targetVertex.Edges[i].Value);
            }
            return true;
        }

        public bool RemoveVertex(T targetValue)
        {
            if(!DisconnectAll(targetValue))
            {
                return false;
            }
            Vertex<T> targetVertex = FindVertex(targetValue);
            return Vertexes.Remove(targetVertex);
        }

        public bool Connect(T value1, T value2)
        {
            Vertex<T> vertex1 = FindVertex(value1);
            if (vertex1 == null || vertex1.IsConnected(value2))
            {
                return false;
            }
            Vertex<T> vertex2 = FindVertex(value2);
            if(vertex2 == null)
            {
                return false;
            }

            vertex1.Edges.Add(vertex2);
            vertex2.Edges.Add(vertex1);
            return true;
        }

        public bool Disconnect(T value1, T value2)
        {
            Vertex<T> vertex1 = FindVertex(value1);
            if(vertex1 == null || !vertex1.IsConnected(value2))
            {
                return false;
            }
            Vertex<T> vertex2 = FindVertex(value2);
            if(vertex2 == null)
            {
                return false;
            }

            vertex1.Edges.Remove(vertex2);
            vertex2.Edges.Remove(vertex1);
            return true;
        }

        public bool AreConnected(T value1, T value2)
        {
            Vertex<T> vertex1 = FindVertex(value1);
            if(vertex1 == null)
            {
                return false;
            }
            return vertex1.IsConnected(value2);
        }
    }
}
