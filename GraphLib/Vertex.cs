namespace GraphLib
{
    public class Vertex
    {
        public string label { get; set; }
        public List<Edge> edges = new();

        public Vertex(string lbl) 
        { 
            label = lbl;
        }

        public void AddEdge(Vertex child, float weight)
        {
            Edge edge = new Edge() { Parent = this, Child = child, Weight = weight };

            edges.Add(edge);
        }
    }
}