using System.Collections.Generic;

namespace OptimalPath.Models
{
    internal interface IGraph<TNode, TEdge> : IEnumerable<TNode>
        where TEdge : class, IEdge<TNode>
        where TNode : class, INode<TEdge>
    {
        
        IEnumerable<TNode> Nodes { get; }

        void AddEdge(TNode nodeA, TNode nodeB, int weigth);
    }
}
