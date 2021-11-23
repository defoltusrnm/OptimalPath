using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Models
{
    internal class Node : INode<Edge>
    {
        private static int _globalId = 1;

        public Node()
        {
            Id = _globalId++;
        }

        public IEnumerable<Edge> Edges { get; set; }
            = Enumerable.Empty<Edge>();

        public int Id { get; init; }

        public int Sum { get; set; }
            = int.MaxValue;

        public int Count { get; set; }

        public bool IsVisited { get; set; }
           = false;

        public IEnumerator<Edge> GetEnumerator()
            => Edges.GetEnumerator();

        public override string ToString()
        {
            return $"{Id}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
