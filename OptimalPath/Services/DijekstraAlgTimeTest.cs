using OptimalPath.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OptimalPath.Services
{
    internal class DijekstraAlgTimeTest<TNode, TEdge> : IRouteDecorator<TNode, TEdge>
        where TNode : class, INode
        where TEdge : class, IEdge<TNode>
    {
        public IRoutingService<TNode, TEdge> Service { get; init; }

        public IRoute<TNode, TEdge> ComputePath(TNode start, TNode end)
        {
            Stopwatch stopwatch = new();

            List<double> times = new();

            int n = 1000;
            
            IRoute<TNode, TEdge> route = default;
            
            for (int i = 0; i < n; i++)
            {
                stopwatch.Start();

                route = Service.ComputePath(start, end);

                stopwatch.Stop();

                times.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine(string.Join("\n", times));

            double average = times.Average();

            double devotion = Math.Sqrt( times.Sum(x => Math.Pow(x - average, 2)) / times.Count() );

            Console.WriteLine($"\taverage = {average,10:f4}\n\tdevotion = {devotion,10:f4}");

            return route;
        }
    }
}
