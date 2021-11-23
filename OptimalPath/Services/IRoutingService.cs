using OptimalPath.Models;

namespace OptimalPath.Services
{
    internal interface IRoutingService<TNode, TEdge>
        where TNode : class, INode<TEdge>
        where TEdge : class, IEdge<TNode>
    {
        IRoute<TNode, TEdge> ComputePath(TNode start, TNode end);
    }
}
