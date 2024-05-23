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

        public Vertex AddEdge(Vertex child, float weight)
        {
            edges.Add(new Edge() { Parent = this, Child = child, Weight = weight });

            if(!child.edges.Exists(e => e.Parent == child && e.Child == this))
            {
                child.AddEdge(this, weight);
            }

            return this;
        }
    }
}