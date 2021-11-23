using System.Collections.Generic;

namespace OptimalPath.Models
{
    internal interface IRoute<TNode, TEdge> : IEnumerable<TEdge>
        where TEdge : class, IEdge<TNode>
        where TNode : class, INode<TEdge>
    {
        TNode Origin { get; init; }

        TNode Destination { get; init; }

        IEnumerable<TEdge> Edges { get; set; }
    }
}
