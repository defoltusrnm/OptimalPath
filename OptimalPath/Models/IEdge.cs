namespace OptimalPath.Models
{
    internal interface IEdge
    {
        int Id { get; init; }

        int Weigth { get; init; }
    }

    internal interface IEdge<TNode> : IEdge
        where TNode : class, INode
    {
        TNode Input { get; init; }

        TNode Output { get; init; }
    }
}
