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

        public List<T> DFS(T val)
        {
            List<T> list = new List<T>();

            var node = FindVertex(val);

            if (node == null)
            {
                return list;
            }

            var visited = new List<Vertex<T>>();

            dfsRecursive(node, list, visited);



            return list;
        }

        public List<T> BreathFirst(T value)
        {
                List<T> returnList = new List<T>();
                Vertex<T> currentVertex = FindVertex(value);

                if (currentVertex == null)
                {
                    return null;
                }
                List<Vertex<T>> wasVisited = new List<Vertex<T>>();
                Queue<Vertex<T>> vertices = new Queue<Vertex<T>>();
                vertices.Enqueue(currentVertex);

                while (vertices.Count != 0 && currentVertex != null)
                {
                    if (!wasVisited.Contains(currentVertex))
                    {
                        returnList.Add(currentVertex.Value);
                        wasVisited.Add(currentVertex);
                    }

                    foreach (Vertex<T> edge in currentVertex.Edges)
                    {
                        if (!wasVisited.Contains(edge))
                        {
                            vertices.Enqueue(edge);
                        }
                    }

                    currentVertex = vertices.Dequeue();
                }

                return returnList;
        }

        public List<T> DeapthFirst(T value)
        {
            List<T> returnList = new List<T>();
            Vertex<T> currentVertex = FindVertex(value);

            if(currentVertex == null)
            {
                return null;
            }
            List<Vertex<T>> wasVisited = new List<Vertex<T>>();
            Stack<Vertex<T>> vertices = new Stack<Vertex<T>>();
            vertices.Push(currentVertex);

            while(vertices.Count != 0 && currentVertex != null)
            {
                if(!wasVisited.Contains(currentVertex))
                {
                    returnList.Add(currentVertex.Value);
                    wasVisited.Add(currentVertex);
                }

                foreach(Vertex<T> edge in currentVertex.Edges)
                {
                    if(!wasVisited.Contains(edge))
                    {
                        vertices.Push(edge);
                    }
                }
                List<Vertex<T>> stackStuff = new List<Vertex<T>>();
                foreach(Vertex<T> edge in currentVertex.Edges)
                {
                    if(!wasVisited.Contains(edge))
                    {
                        stackStuff.Add(vertices.Pop());
                    }
                }
                foreach(Vertex<T> vertex in stackStuff)
                {
                    vertices.Push(vertex);
                }

                currentVertex = vertices.Pop();
            }

            return returnList;
        }

        private void dfsRecursive(Vertex<T> node, List<T> list, List<Vertex<T>> visited)
        {
            if (node == null)
            {
                return;
            }

            if (!visited.Contains(node))
            {
                list.Add(node.Value);
                visited.Add(node);
            }

            foreach (var neighbor in node.Edges)
            {
                if (!visited.Contains(neighbor))
                {
                    dfsRecursive(neighbor, list, visited);
                }
            }
        }


        public List<T> ShortestPathBfs(T startingValue, T targetValue)
        {
            Vertex<T> startingVertex = FindVertex(startingValue);
            if(startingVertex == null)
            {
                return null;
            }

            List<T> returnList = new List<T>();
            List<Vertex<T>> wasVisited = new List<Vertex<T>>();
            Vertex<T>[] parents = new Vertex<T>[Vertexes.Count];

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.Enqueue(startingVertex);
            
            Vertex<T> currentVertex = startingVertex;
            parents[Vertexes.IndexOf(startingVertex)] = null;
            do
            {
                if (!wasVisited.Contains(currentVertex))
                {
                    wasVisited.Add(currentVertex);
                    returnList.Add(currentVertex.Value);
                }

                foreach (Vertex<T> edge in currentVertex.Edges)
                {
                    if (!wasVisited.Contains(edge))
                    {
                        queue.Enqueue(edge);
                        parents[Vertexes.IndexOf(edge)] = currentVertex;
                    }
                }

                currentVertex = queue.Dequeue();
            } while (!currentVertex.Value.Equals(targetValue) && queue.Count > 0 && currentVertex != null);

            returnList.Clear();
            while(currentVertex != null)
            {
                returnList.Add(currentVertex.Value);
                currentVertex = parents[Vertexes.IndexOf(currentVertex)];
            }
            return returnList;
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
