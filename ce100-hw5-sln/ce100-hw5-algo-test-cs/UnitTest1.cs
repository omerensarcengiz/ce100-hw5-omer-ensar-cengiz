using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce100_hw5_algo_lib_cs;
using static ce100_hw5_algo_lib_cs.Class1;

namespace ce100_hw5_algo_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Graph_Cycle_Detection_test1()
        {
            Graph1 graph = new Graph1(4);
            graph.addEdge(1, 0);
            graph.addEdge(2, 2);
            graph.addEdge(0, 2);
            graph.addEdge(2, 0);
            graph.addEdge(1, 3);
            graph.addEdge(2, 3);

            bool result = true;

            Assert.AreEqual(graph.isCyclic(), result);
        }

        [TestMethod]
        public void Graph_Cycle_Detection_test2()
        {
            Graph1 graph = new Graph1(5);
            graph.addEdge(1, 0);
            graph.addEdge(2, 2);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);
            bool result = true;

            Assert.AreEqual(graph.isCyclic(), result);
        }

        [TestMethod]
        public void Graph_Cycle_Detection_test3()
        {
            Graph1 graph = new Graph1(3);
            graph.addEdge(0, 1);
            graph.addEdge(1, 2);
            graph.addEdge(0, 2);

            bool expected = false;

            Assert.AreEqual(graph.isCyclic(), expected);
        }

        [TestMethod]
        public void Minimum_Spanning_Tree_test1()
        {
            int V = 4;
            int E = 5;
            Graph2 graph = new Graph2(V, E);

            // add edge 0-1
            graph.edge[0].s = 0;
            graph.edge[0].d = 1;
            graph.edge[0].w = 10;

            // add edge 0-2
            graph.edge[1].s = 0;
            graph.edge[1].d = 2;
            graph.edge[1].w = 6;

            // add edge 0-3
            graph.edge[2].s = 0;
            graph.edge[2].d = 3;
            graph.edge[2].w = 5;

            // add edge 1-3
            graph.edge[3].s = 1;
            graph.edge[3].d = 3;
            graph.edge[3].w = 15;

            // add edge 2-3
            graph.edge[4].s = 2;
            graph.edge[4].d = 3;
            graph.edge[4].w = 4;

            string result = "(source --> destination = weight)\r\n" +
                "(2 --> 3 = 4)\r\n" +
                "(0 --> 3 = 5)\r\n" +
                "(0 --> 1 = 10)\r\n";

            Assert.AreEqual(graph.KruskalMST(), result);
        }

        [TestMethod]
        public void Minimum_Spanning_Tree_test2()
        {
            int V = 5;
            int E = 6;
            Graph2 graph = new Graph2(V, E);

            // add edge 1-3
            graph.edge[0].s = 1;
            graph.edge[0].d = 3;
            graph.edge[0].w = 5;

            // add edge 2-4
            graph.edge[1].s = 2;
            graph.edge[1].d = 4;
            graph.edge[1].w = 7;

            // add edge 2-1
            graph.edge[2].s = 2;
            graph.edge[2].d = 1;
            graph.edge[2].w = 2;

            // add edge 3-2
            graph.edge[3].s = 3;
            graph.edge[3].d = 2;
            graph.edge[3].w = 3;

            // add edge 0-3
            graph.edge[4].s = 0;
            graph.edge[4].d = 3;
            graph.edge[4].w = 3;

            // add edge 4-0
            graph.edge[5].s = 4;
            graph.edge[5].d = 0;
            graph.edge[5].w = 12;

            string result = "(source --> destination = weight)\r\n" +
                "(2 --> 1 = 2)\r\n" +
                "(3 --> 2 = 3)\r\n" +
                "(0 --> 3 = 3)\r\n" +
                "(2 --> 4 = 7)\r\n";

            Assert.AreEqual(graph.KruskalMST(), result);
        }

        [TestMethod]
        public void Minimum_Spanning_Tree_test3()
        {
            int V = 6;
            int E = 8;
            Graph2 graph = new Graph2(V, E);

            // add edge 0-1
            graph.edge[0].s = 0;
            graph.edge[0].d = 1;
            graph.edge[0].w = 1;

            // add edge 1-2
            graph.edge[1].s = 1;
            graph.edge[1].d = 2;
            graph.edge[1].w = 10;

            // add edge 1-3
            graph.edge[2].s = 1;
            graph.edge[2].d = 3;
            graph.edge[2].w = 15;

            // add edge 2-3
            graph.edge[3].s = 2;
            graph.edge[3].d = 3;
            graph.edge[3].w = 11;

            // add edge 0-5
            graph.edge[4].s = 0;
            graph.edge[4].d = 5;
            graph.edge[4].w = 14;

            // add edge 4-5
            graph.edge[5].s = 4;
            graph.edge[5].d = 5;
            graph.edge[5].w = 9;

            // add edge 3-4
            graph.edge[6].s = 3;
            graph.edge[6].d = 4;
            graph.edge[6].w = 6;

            // add edge 2-5
            graph.edge[7].s = 2;
            graph.edge[7].d = 5;
            graph.edge[7].w = 2;





            string result = "(source --> destination = weight)\r\n" +
                "(0 --> 1 = 1)\r\n" +
                "(2 --> 5 = 2)\r\n" +
                "(3 --> 4 = 6)\r\n" +
                "(4 --> 5 = 9)\r\n" +
                "(1 --> 2 = 10)\r\n";

            Assert.AreEqual(graph.KruskalMST(), result);
        }

        [TestMethod]
        public void Single_Source_Shortest_Path_test1()
        {
            int V = 5;
            int E = 6;

            Graph3 graph = new Graph3(V, E);

            // add edge 0-1
            graph.edge[0].s = 0;
            graph.edge[0].d = 1;
            graph.edge[0].w = -3;

            // add edge 0-4 
            graph.edge[1].s = 0;
            graph.edge[1].d = 4;
            graph.edge[1].w = -5;

            // add edge 1-2 
            graph.edge[2].s = 1;
            graph.edge[2].d = 2;
            graph.edge[2].w = 2;

            // add edge 2-3 
            graph.edge[3].s = 2;
            graph.edge[3].d = 3;
            graph.edge[3].w = -3;

            // add edge 3-4 
            graph.edge[4].s = 3;
            graph.edge[4].d = 4;
            graph.edge[4].w = 2;

            // add edge 3-1 
            graph.edge[4].s = 3;
            graph.edge[4].d = 1;
            graph.edge[4].w = -3;



            string result = "(Vertex --> Distance from Source)" +
                " (0 --> 0)," +
                " (1 --> -19)," +
                " (2 --> -13)," +
                " (3 --> -16)," +
                " (4 --> -5)";


            Assert.AreEqual(Graph3.BellmanFord(graph, 0), result);
        }

        [TestMethod]
        public void Single_Source_Shortest_Path_test2()
        {
            int V = 5;
            int E = 7;

            Graph3 graph = new Graph3(V, E);

            // add edge 0-3
            graph.edge[0].s = 0;
            graph.edge[0].d = 3;
            graph.edge[0].w = 1;

            // add edge 0-1 
            graph.edge[1].s = 0;
            graph.edge[1].d = 1;
            graph.edge[1].w = 2;

            // add edge 1-4 
            graph.edge[2].s = 1;
            graph.edge[2].d = 4;
            graph.edge[2].w = 3;

            // add edge 3-2 
            graph.edge[3].s = 3;
            graph.edge[3].d = 2;
            graph.edge[3].w = 2;

            // add edge 0-4 
            graph.edge[4].s = 0;
            graph.edge[4].d = 4;
            graph.edge[4].w = 8;

            // add edge 1-2 
            graph.edge[5].s = 1;
            graph.edge[5].d = 2;
            graph.edge[5].w = 2;

            string result = "(Vertex --> Distance from Source) " +
                "(0 --> 0), " +
                "(1 --> 2), " +
                "(2 --> 3), " +
                "(3 --> 1), " +
                "(4 --> 5)";

            Assert.AreEqual(Graph3.BellmanFord(graph, 0), result);
        }

        [TestMethod]
        public void Single_Source_Shortest_Path_test3()
        {
            int V = 5;
            int E = 8;

            Graph3 graph = new Graph3(V, E);

            // add edge 0-1
            graph.edge[0].s = 0;
            graph.edge[0].d = 1;
            graph.edge[0].w = -1;

            // add edge 0-2 
            graph.edge[1].s = 0;
            graph.edge[1].d = 2;
            graph.edge[1].w = -8;

            // add edge 1-2 
            graph.edge[2].s = 1;
            graph.edge[2].d = 2;
            graph.edge[2].w = -5;

            // add edge 1-3 
            graph.edge[3].s = 1;
            graph.edge[3].d = 3;
            graph.edge[3].w = -11;

            // add edge 1-4 
            graph.edge[4].s = 1;
            graph.edge[4].d = 4;
            graph.edge[4].w = -3;

            // add edge 3-2 
            graph.edge[5].s = 3;
            graph.edge[5].d = 2;
            graph.edge[5].w = -7;

            // add edge 3-1 
            graph.edge[6].s = 3;
            graph.edge[6].d = 1;
            graph.edge[6].w = -14;

            // add edge 4-3 
            graph.edge[7].s = 4;
            graph.edge[7].d = 3;
            graph.edge[7].w = -9;


            string result = "(Vertex --> Distance from Source) " +
                "(0 --> 0), " +
                "(1 --> -101)," +
                " (2 --> -94), " +
                "(3 --> -88), " +
                "(4 --> -79)";

            Assert.AreEqual(Graph3.BellmanFord(graph, 0), result);
        }

        [TestMethod]
        public void Max_Flow_test1()
        {
            int[,] graph = new int[,] {
            { 0, 16, 13, 0, 0, 0 },
            { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },
            { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },
            { 0, 0, 0, 0, 0, 0 }
            };
            MaxFlow m = new MaxFlow();
            int a = 0;
            int b = 5;
            int result = 23;

            Assert.AreEqual(MaxFlow.fordFulkerson(graph, a, b), result);
        }

        [TestMethod]
        public void Max_Flow_test2()
        {
            int[,] graph = new int[,] {
            { 0, 7, 1, 11, 19, 0 },
            { 0, 1, 2, 3, 4, 0 },
            { 0, 4, 0, 0, 14, 6 },
            { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 2, 7, 6, 4 },
            { 1, 0, 1, 0, 1, 0 }
            };
            MaxFlow m = new MaxFlow();
            int a = 0;
            int b = 5;
            int result = 30;

            Assert.AreEqual(MaxFlow.fordFulkerson(graph, a, b), result);
        }

        [TestMethod]
        public void Max_Flow_test3()
        {
            int[,] graph = new int[,] {
            { 0, 8, 18, 0, 0, 0 },
            { 0, 0, 6, 12, 0, 0 },
            { 0, 1, 0, 5, 19, 0 },
            { 0, 0, 7, 0, 0, 29 },
            { 0, 0, 0, 4, 0, 9 },
            { 0, 2, 0, 0, 5, 0 }
            };
            MaxFlow m = new MaxFlow();
            int a = 0;
            int b = 5;
            int result = 26;

            Assert.AreEqual(MaxFlow.fordFulkerson(graph, a, b), result);
        }
    }
}
