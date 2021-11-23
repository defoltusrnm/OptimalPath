namespace OptimalPath.Models
{
    internal class Edge : IEdge<Node>
    {
        private static int _globalId = 1;

        public Edge()
        {
            Id = _globalId++;
        }

        public Node Input { get; init; }

        public Node Output { get; init; }

        public int Id { get; init; }

        public int Weigth { get; init; }

        public override string ToString()
        {
            return $"{Input} - {Output}";
        }
    }
}
