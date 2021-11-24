using OptimalPath.Models;
using System.Collections.Generic;
using System.Linq;

namespace OptimalPath.Services
{
    internal class DijekstraAlg<TNode, TEdge> : IRoutingService<TNode, TEdge>
        where TNode : class, INode<TEdge>
        where TEdge : class, IEdge<TNode>
    {

        public IGraph<TNode, TEdge> Graph { private get; init; }

        public IRoute<TNode, TEdge> ComputePath(TNode start, TNode end)
        {
            start.Sum = 0;
            while (true)
            {
                var current = Min();

                if (current == default)
                    break;

                Recalculate(current);
            }

            return new Route<TNode, TEdge>()
            {
                Origin = start,
                Destination = end,
                Edges = ConstructPath(start, end)
            };
        }

        private IEnumerable<TEdge> ConstructPath(TNode start, TNode end)
        {
            TNode current = end;
            while (start != current)
            {
                TEdge edge = FindMinSum(current);
                current = edge.Output;
                yield return edge;
            }
        }

        private TEdge FindMinSum(TNode node)
        {
            var arr = node.ToArray();

            TEdge minEdge = arr[0];
            int sum = minEdge.Weigth + minEdge.Output.Sum;

            for (int i = 1; i < arr.Length; i++)
                if (sum > arr[i].Output.Sum + arr[i].Weigth)
                {
                    sum = arr[i].Output.Sum + arr[i].Weigth;
                    minEdge = arr[i];
                }

            return minEdge;
        }

        private TNode Min()
        {
            var arr = Graph.Where(x => x.IsVisited == false).ToArray();

            if (arr.Length == 0)
                return default;
            
            TNode min = arr[0];

            for (int i = 1; i < arr.Length; i++)
                if (min.Sum > arr[i].Sum)
                    min = arr[i];

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
                }
            }
        }
    }
}
