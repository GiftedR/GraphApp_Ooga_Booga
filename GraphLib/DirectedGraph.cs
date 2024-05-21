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
    }
}
