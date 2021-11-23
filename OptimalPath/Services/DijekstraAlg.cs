using OptimalPath.Models;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Services
{
    internal class DijekstraAlg<TNode, TEdge> : IRoutingService<TNode, TEdge>
        where TNode : class, INode<TEdge>
        where TEdge : class, IEdge<TNode>
    {

        private TNode _minNode;

        private int _sum = 0;

        private IEnumerable<TNode> _nodes
            = Enumerable.Empty<TNode>();
        
        public IGraph<TNode, TEdge> Graph { private get; init; }

        public IRoute<TNode, TEdge> ComputePath(TNode start, TNode end)
        {
            _minNode = start;

            _minNode.Sum = 0;

            while (Graph.Nodes.Any(x => !x.IsVisited))
            {
                var current = Min();

                Recalculate(current);
            }

            Route<TNode, TEdge> route = new()
            {
                Origin = start,
                Destination = end,
                Edges = ConstructPath(start, end)
            };

            return route;
        }

        private IEnumerable<TEdge> ConstructPath(TNode start, TNode end)
        {
            _sum = end.Sum;
            
            TNode current = end;
            while (start != current)
            {
                current = FindMinSum(current, out TEdge minEdge);
                yield return minEdge;
            }
        }

        private TNode FindMinSum(TNode node, out TEdge minEdge)
        {
            var arr = node.ToArray();

            TNode min = default;
            minEdge = default;
            int sum = int.MaxValue;

            foreach (TEdge edge in arr)
                if (sum > edge.Output.Sum + edge.Weigth)
                {
                    sum = edge.Output.Sum + edge.Weigth;
                    min = edge.Output;
                    minEdge = edge;
                }

            return min;
        }

        private TNode Min()
        {
            var arr = Graph.Nodes.Where(x => x.IsVisited == false).ToArray();

            TNode min = arr[0];

            foreach (var node in arr)
                if (min.Sum > node.Sum)
                    min = node;

            return min;
        }

        private void Recalculate(TNode node)
        {
            node.IsVisited = true;
            
            foreach (TEdge edge in node)
            {
                int sum = node.Sum + edge.Weigth;

                if (edge.Output.Sum > sum)
                {
                    edge.Output.Sum = sum;
                    edge.Output.IsVisited = false;
                    _minNode = edge.Output;

                    System.Console.WriteLine($"{node.Id} : {edge.Output.Id} : {edge.Output.Sum}");
                }

                if (edge.Output.Sum < _minNode.Sum)
                    _minNode = edge.Output;
            }
        }
    }
}
