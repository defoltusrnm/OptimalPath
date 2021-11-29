using System.Collections.Generic;

namespace OptimalPath.Models
{
    internal interface IGraph<TNode, TEdge> : IEnumerable<TNode>
        where TEdge : class, IEdge<TNode>
        where TNode : class, INode
    {
        
        IEnumerable<TNode> Nodes { get; }

        IEnumerable<TEdge> Edges { get; }

        void AddEdge(TNode nodeA, TNode nodeB, int weigth);
    }
}
