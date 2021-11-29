namespace OptimalPath.Models
{
    internal class Node : INode
    {
        private static int _globalId = 1;

        public Node()
        {
            Id = _globalId++;
        }

        public int Id { get; init; }

        public int Sum { get; set; }
            = int.MaxValue;

        public int Count { get; set; }

        public bool IsVisited { get; set; }
            = false;

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
