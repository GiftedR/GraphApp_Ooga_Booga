using GraphLib;

namespace GraphTests
{
    [TestClass]
    public class DirectedGraphTests
    {
        [TestMethod]
        public void DirectedGraph_ADD_Vertex_RETURNS_Vertex()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();
            
            // Act
            Vertex resultVertex = graph.AddVertex("Toast");
            
            // Assert
            Assert.IsInstanceOfType<Vertex> (resultVertex);
            Assert.AreEqual(resultVertex.label, "Toast");
        }

        [TestMethod]
        [DataRow("Toast", "Jam", "Hodor")]
        public void DirectedGraph_ADD_MultipleVertex_CONTAINS_EachAddedVertex(string data1, string data2, string data3)
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            // Act
            graph.AddVertex(data1);
            graph.AddVertex(data2);
            graph.AddVertex(data3);

            int result = graph.vertexCount;

            Vertex res1 = graph.activeVerticies[0];
            Vertex res2 = graph.activeVerticies[1];
            Vertex res3 = graph.activeVerticies[2];

            // Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(data1, res1.label);
            Assert.AreEqual(data2, res2.label);
            Assert.AreEqual(data3, res3.label);
        }
    }
}