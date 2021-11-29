namespace OptimalPath.Models
{
    internal interface INode
    {
        int Id { get; init; }

        int Sum { get; set; }

        bool IsVisited { get; set; }
    }
}
