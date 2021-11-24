using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Models
{
    internal class Graph : IGraph<Node, Edge>
    {
        private int _count = 0;

        private int _visitedCount = 0;
        
        public bool IsAllVisited => _visitedCount == _count;

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

            bool isExistsA = Nodes.Contains(nodeA);
            bool isExistsB = Nodes.Contains(nodeB);

            Nodes = !isExistsA ? Nodes.Append(nodeA) : Nodes;
            Nodes = !isExistsB ? Nodes.Append(nodeB) : Nodes;

            Edges = Edges.Append(edgeLeft);

            _count += !isExistsA ? 1 : 0;
            _count += !isExistsB ? 1 : 0;
        }

        public IEnumerator<Edge> GetEnumerator()
            => Edges.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
