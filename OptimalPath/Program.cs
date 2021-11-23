using OptimalPath.Models;
using OptimalPath.Services;
using System;

namespace OptimalPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node a = new Node();
            Node b = new Node();
            Node c = new Node();
            Node d = new Node();
            Node e = new Node();
            Node f = new Node();
            Node g = new Node();

            Graph gr = new Graph();

            gr.AddEdge(a, b, 22);
            gr.AddEdge(a, c, 33);
            gr.AddEdge(a, d, 61);
            gr.AddEdge(b, c, 47);
            gr.AddEdge(b, e, 93);
            gr.AddEdge(c, d, 11);
            gr.AddEdge(c, e, 79);
            gr.AddEdge(c, f, 63);
            gr.AddEdge(d, f, 41);
            gr.AddEdge(e, f, 17);
            gr.AddEdge(e, g, 58);
            gr.AddEdge(f, g, 84);

            IRoutingService<Node, Edge> alg = new DijekstraAlg<Node, Edge>()
            {
                Graph = gr
            };

            alg = new DijekstraAlgTimeTest<Node, Edge>
            {
                Service = alg
            };

            Console.WriteLine(string.Join("; ", alg.ComputePath(a, g)));
        }
    }
}
