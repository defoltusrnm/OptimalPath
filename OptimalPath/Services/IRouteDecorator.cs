using OptimalPath.Models;

namespace OptimalPath.Services
{
    internal interface IRouteDecorator<TNode, TEdge> : IRoutingService<TNode, TEdge>
        where TNode : class, INode
        where TEdge : class, IEdge<TNode>
    {
        IRoutingService<TNode, TEdge> Service { get; }
    }
}
