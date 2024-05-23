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

        public D?[,] CreateAdjacencyMatrix<D>()
        {
            D?[,] adjMatrix = new D?[activeVerticies.Count,activeVerticies.Count];

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
    }
}
