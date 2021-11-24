using OptimalPath.Models;
using System;
using System.Diagnostics;

namespace OptimalPath.Services
{
    internal class DijekstraAlgTimeTest<TNode, TEdge> : IRouteDecorator<TNode, TEdge>
        where TNode : class, INode<TEdge>
        where TEdge : class, IEdge<TNode>
    {
        public IRoutingService<TNode, TEdge> Service { get; init; }

        public IRoute<TNode, TEdge> ComputePath(TNode start, TNode end)
        {
            Stopwatch stopwatch = new();
            
            stopwatch.Start();

            var route = Service.ComputePath(start, end);

            stopwatch.Stop();

            Console.WriteLine($"alg time: {stopwatch.ElapsedMilliseconds} ms ; {stopwatch.Elapsed.TotalMilliseconds} ms; {stopwatch.ElapsedTicks}");

            return route;
        }
    }
}
