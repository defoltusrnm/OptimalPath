using System.Collections;
using System.Collections.Generic;

namespace OptimalPath.Models
{
    internal class Route<TNode, TEdge> : IRoute<TNode, TEdge>
        where TNode : class, INode
        where TEdge : class, IEdge<TNode>
    {
        public TNode Origin { get; init; }
        
        public TNode Destination { get; init; }
        
        public IEnumerable<TEdge> Edges { get; set; }

        public IEnumerator<TEdge> GetEnumerator()
            => Edges.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
