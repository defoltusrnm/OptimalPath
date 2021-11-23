using System.Collections.Generic;

namespace OptimalPath.Models
{
    internal interface INode
    {
        int Id { get; init; }

        int Sum { get; set; }

        bool IsVisited { get; set; }
    }

    internal interface INode<TEdge> : INode, IEnumerable<TEdge>
        where TEdge : class, IEdge
    {
        IEnumerable<TEdge> Edges { get; set; }
    }
}
