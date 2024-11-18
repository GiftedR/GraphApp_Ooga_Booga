using System.Numerics;

namespace GraphLib
{
    public class DirectedGraph
    {
        public int vertexCount { get => activeVerticies.Count; }
        public List<Vertex> activeVerticies = new();

        public Vertex AddVertex(string label)
        {
            Vertex v = new(label);
            activeVerticies.Add(v);
            
            return v;
        }

        public D[,] CreateAdjacencyMatrix<D>()
        {
            D[,] adjMatrix = new D[activeVerticies.Count,activeVerticies.Count];

            for (int vx = 0; vx < vertexCount; vx++)
            {
                Vertex v1 = activeVerticies[vx];
                for (int vy = 0; vy < vertexCount; vy++)
                {
                    Vertex v2 = activeVerticies[vy];

                    Edge edge = v1.edges.FirstOrDefault(e => e.Child == v2);

                    if (edge != null)
                    {
                        adjMatrix[vx, vy] = (D)Convert.ChangeType(edge.Weight, typeof(D));
                    }
                }
            }

            return adjMatrix;
        }

        public void PrintMatrix()
        {
            float[,] matrix = CreateAdjacencyMatrix<float>();

            Console.Write("\t");
            for (int i = 0; i < vertexCount; i++)
            {
                Console.Write($"{activeVerticies[i].label}\t");
            }
            Console.WriteLine();
            
            for (int i = 0; i < vertexCount; i++)
            {
                Console.Write($"{activeVerticies[i].label}\t");
                for (int j = 0; j < vertexCount; j++)
                {
                    Console.Write($"[{matrix[i,j]}]\t");
                }
                Console.WriteLine();
            }
        }
    
        public void Dijkstra<D>(int start) where D: INumber<D>
        {
            // Gib Buckets
            D[,] matrix = CreateAdjacencyMatrix<D>();
            D[] distance = new D[vertexCount];
            bool[] history = new bool[vertexCount];
            D inf = (D)Convert.ChangeType(int.MaxValue, typeof(D));

            Console.WriteLine($"\nInfinity is {inf}\n");

            // Fill me buckets
            for (int i = 0; i < vertexCount; i++)
            {
                distance[i] = inf;
                history[i] = false;
            }

            distance[start] = default(D);

            for (int count = 0; count < vertexCount - 1; count++)
            {
                int u = MinDistance<D>(distance, history);

                history[u] = true;

                for (int v = 0; v < vertexCount; v++)
                {
                    if (!history[v] &&
                        matrix[u, v] != default(D) &&
                        distance[u] != inf &&
                        distance[u] + matrix[u, v] < distance[v]
                        )
                    {
                        distance[v] = distance[u] + matrix[u, v];
                    }
                }
            }

            PrintSolution(distance, vertexCount);
        }

        private void PrintSolution<D>(D[] distance, int vertexCount) where D : INumber<D>
        {
            Console.WriteLine("Vertex\t\tDistance");

            for (int i = 0;i < vertexCount;i++)
            {
                Console.WriteLine($"{activeVerticies[i].label}\t\t{distance[i]}");
            }
        }

        private int MinDistance<D>(D[] distance, bool[] history) where D : INumber<D>
        {
            D min = (D)Convert.ChangeType(int.MaxValue, typeof(D));
            int min_index = -1;

            for (int i = 0; i < vertexCount; i++)
            {
                if (!history[i] && distance[i] <= min)
                {
                    min = distance[i];
                    min_index = i;
                }
            }

            return min_index;
        }
    }
}
