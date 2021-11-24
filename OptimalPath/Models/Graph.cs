using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Models
{
    internal class Graph : IGraph<Node, Edge>
    {
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

            Edge edgeRigth = InvertEdge(edgeLeft);

            nodeA.Edges = nodeA.Edges.Append(edgeLeft);
            nodeB.Edges = nodeB.Edges.Append(edgeRigth);

            TryAdd(nodeA);
            TryAdd(nodeB);
        }

        public IEnumerator<Node> GetEnumerator()
            => Nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private Edge InvertEdge(Edge edge)
            => new Edge()
            {
                Input = edge.Output,
                Output = edge.Input,
                Weigth = edge.Weigth
            };

        private void TryAdd(Node node)
            => Nodes = !Nodes.Contains(node) ? Nodes.Append(node) : Nodes;

    }
}
