using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Models
{
    internal class Graph : IGraph<Node, Edge>
    {
        public IEnumerable<Edge> Edges { get; private set; }
            = Enumerable.Empty<Edge>();

        public IEnumerable<Node> Nodes { get; private set; }
            = Enumerable.Empty<Node>();

        public void AddEdge(Node nodeA, Node nodeB, int weigth)
        {
            Edge edgeLeft = new()
            {
                Input = nodeA,
                Output = nodeB,
                Weigth = weigth
            };

            Edge edgeRigth = new()
            {
                Input = nodeB,
                Output = nodeA,
                Weigth = weigth
            };

            nodeA.Edges = nodeA.Edges.Append(edgeLeft);
            nodeB.Edges = nodeB.Edges.Append(edgeRigth);

            Nodes = Nodes.Append(nodeA).Append(nodeB);
            Edges = Edges.Append(edgeLeft);
        }

        public IEnumerator<Edge> GetEnumerator()
            => Edges.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
