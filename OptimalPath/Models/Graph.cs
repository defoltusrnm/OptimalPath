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

        public IEnumerable<Edge> Edges { get; private set; }
            = Enumerable.Empty<Edge>();

        public void AddEdge(Node nodeA, Node nodeB, int weigth)
        {
            Edge edge = new()
            {
                Input = nodeA,
                Output = nodeB,
                Weigth = weigth
            };

            Edges = Edges.Append(edge);

            TryAdd(nodeA);
            TryAdd(nodeB);
        }

        public IEnumerator<Node> GetEnumerator()
            => Nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void TryAdd(Node node)
            => Nodes = !Nodes.Contains(node) ? Nodes.Append(node) : Nodes;

    }
}
