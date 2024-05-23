using GraphLib;

DirectedGraph g = new();

Vertex a = g.AddVertex("a");
Vertex b = g.AddVertex("b");
Vertex c = g.AddVertex("c");

a.AddEdge(b, 5f).AddEdge(c, 3f);
b.AddEdge(c, 100f);

g.PrintMatrix();