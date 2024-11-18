using GraphLib;

DirectedGraph gwaph = new();

Vertex a = gwaph.AddVertex("a");
Vertex b = gwaph.AddVertex("b");
Vertex c = gwaph.AddVertex("c");
Vertex d = gwaph.AddVertex("d");
Vertex e = gwaph.AddVertex("e");
Vertex f = gwaph.AddVertex("f");
Vertex g = gwaph.AddVertex("g");

a.AddEdge(b, 7.0f).AddEdge(c, 3.0f).AddEdge(d, 7.0f);
b.AddEdge(c, 1.0f);
c.AddEdge(e, 32f).AddEdge(f, 3f);
d.AddEdge(e, 2f).AddEdge(g, 1f);
e.AddEdge(f, 9f);
g.AddEdge(f, 7f);

Console.WriteLine("Index\tLabel");
for (int i = 0; i < gwaph.vertexCount; i++)
{
    Console.WriteLine($"{i}\t{gwaph.activeVerticies[i].label}");
}

gwaph.PrintMatrix();

Console.WriteLine();

gwaph.Dijkstra<float>(2);