using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************************************************************
***********************************************************************************
* @file ce100_hw5_algo_lib_cs *
* @author Ömer Ensar CENGİZ *
* @date 27 May 2022 * 
*
* @brief <b> hw-5 Functions </b> *
*
* HW-5 Sample Lib Functions *
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
***********************************************************************************
***********************************************************************************/

namespace ce100_hw5_algo_lib_cs
{
    public class Class1
    {
        //ICYCLIC

        /**
        *
        *	  @name   ICYCLIC (Graph Cycle Detection)
        *
        *	  @brief Print Graph Cycle Detection
        *
        *	  Graph Cycle Detection
        *
        *	  @param  [in] i [\b int]  i
        *	  
        **/

        public class Graph1
        {

            public readonly int V;
            public readonly List<List<int>> adj;

            public Graph1(int V)
            {
                this.V = V;
                adj = new List<List<int>>(V);

                for (int i = 0; i < V; i++)
                    adj.Add(new List<int>());
            }


            public bool isCyclicUtil(int i, bool[] visited,
                                            bool[] recStack)
            {
                if (recStack[i])
                    return true;

                if (visited[i])
                    return false;

                visited[i] = true;

                recStack[i] = true;
                List<int> children = adj[i];

                foreach (int c in children)
                    if (isCyclicUtil(c, visited, recStack))
                        return true;

                recStack[i] = false;

                return false;
            }


            public void addEdge(int sou, int dest)
            {
                adj[sou].Add(dest);
            }



            public bool isCyclic()
            {
                bool[] visited = new bool[V];
                bool[] recStack = new bool[V];

                for (int i = 0; i < V; i++)

                    if (isCyclicUtil(i, visited, recStack))
                    {
                        return true;
                    }

                return false;
            }
        }



        //KRUSKAL

        /**
        *
        *	  @name   KRUSKAL (Minimum Spanning Tree)
        *
        *	  @brief Minimum Spanning Tree
        *
        *	  Minimum Spanning Tree
        *
        *	  @param  [in] v [\b int]  v
        *	  
        *	  @param  [in] e [\b int]  e
        *	  
        *	  @param  [in] i [\b int]  i
        *	  
        *	  @param  [in] a [\b int]  a
        *	  
        *	  @param  [in] b [\b int]  b
        *	  
        **/

        public class Graph2
        {
            public class Edge : IComparable<Edge>
            {
                public int s, d, w;

                public int CompareTo(Edge compareEdge)
                {
                    return this.w - compareEdge.w;
                }
            }

            public class subset
            {
                public int parent, rank;
            };

            public int V, E;
            public Edge[] edge;

            public Graph2(int v, int e)
            {
                V = v;
                E = e;
                edge = new Edge[E];
                for (int i = 0; i < e; ++i)
                    edge[i] = new Edge();
            }

            public int find(subset[] subset, int i)
            {
                if (subset[i].parent != i)
                    subset[i].parent
                        = find(subset, subset[i].parent);

                return subset[i].parent;
            }

            public void Union(subset[] subset, int a, int b)
            {
                int xroot = find(subset, a);
                int yroot = find(subset, b);


                if (subset[xroot].rank < subset[yroot].rank)
                    subset[xroot].parent = yroot;
                else if (subset[xroot].rank > subset[yroot].rank)
                    subset[yroot].parent = xroot;

                else
                {
                    subset[yroot].parent = xroot;
                    subset[xroot].rank++;
                }
            }

            public string KruskalMST()
            {
                string MSTresult = "";
                Edge[] result = new Edge[V];
                int e = 0;
                int i = 0;
                for (i = 0; i < V; ++i)
                    result[i] = new Edge();

                Array.Sort(edge);

                subset[] subsets = new subset[V];
                for (i = 0; i < V; ++i)
                    subsets[i] = new subset();

                for (int v = 0; v < V; ++v)
                {
                    subsets[v].parent = v;
                    subsets[v].rank = 0;
                }

                i = 0;

                while (e < V - 1)
                {
                    Edge next_edge = new Edge();
                    next_edge = edge[i++];

                    int x = find(subsets, next_edge.s);
                    int y = find(subsets, next_edge.d);


                    if (x != y)
                    {
                        result[e++] = next_edge;
                        Union(subsets, x, y);
                    }
                }

                MSTresult += "(source --> destination = weight)\r\n";

                for (i = 0; i < e; ++i)
                {
                    MSTresult += "(" + result[i].s + " --> " + result[i].d + " = " + result[i].w + ")\r\n";

                }
                return MSTresult;

            }
        }



        //BELLMAN-FORD

        /**
        *
        *	  @name   BELLMAN-FORD (Single Source Shortest Path)
        *
        *	  @brief Single Source Shortest Path
        *
        *	  Single Source Shortest Path
        *
        *	  @param  [in] v [\b int]  v
        *	  
        *	  @param  [in] e [\b int]  e
        *	  
        *	  @param  [in] s [\b int]  s
        *	  
        **/

        public class Graph3
        {
            public class Edge
            {
                public int s, d, w;
                public Edge()
                {
                    s = d = w = 0;
                }
            };

            public int V, E;
            public Edge[] edge;

            public Graph3(int v, int e)
            {
                V = v;
                E = e;
                edge = new Edge[e];
                for (int i = 0; i < e; ++i)
                    edge[i] = new Edge();
            }


            public static string BellmanFord(Graph3 graph, int s)
            {
                string result = "";
                int V = graph.V, E = graph.E;
                int[] dist = new int[V];


                for (int i = 0; i < V; ++i)
                {
                    dist[i] = int.MaxValue;
                }
                dist[s] = 0;

                for (int i = 1; i < V; ++i)
                {
                    for (int j = 0; j < E; ++j)
                    {
                        int u = graph.edge[j].s;
                        int v = graph.edge[j].d;
                        int weight = graph.edge[j].w;
                        if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                            dist[v] = dist[u] + weight;
                    }
                }

                for (int j = 0; j < E; ++j)
                {
                    int u = graph.edge[j].s;
                    int v = graph.edge[j].d;
                    int weight = graph.edge[j].w;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        Console.WriteLine("Graph contains negative weight cycle");

                    }
                }
                result += "(Vertex --> Distance from Source) ";
                for (int i = 0; i < V; ++i)
                {
                    result += "(" + i + " --> " + dist[i] + "), ";
                }
                return result.Remove(result.Length - 2);
            }


        }



        //FORD-FULKERSON

        /**
        *
        *	  @name   FORD-FULKERSON (Max-Flow)
        *
        *	  @brief Max-Flow
        *
        *	  Max-Flow
        *
        *	  @param  [in] a [\b int]  a
        *	  
        *	  @param  [in] b [\b int]  b
        *	  
        **/

        public class MaxFlow
        {


            public static readonly int V = 6;

            public static bool bfs(int[,] Graphr, int a, int b, int[] parent)
            {
                bool[] visited = new bool[V];
                for (int i = 0; i < V; ++i)
                    visited[i] = false;

                List<int> queue = new List<int>();
                queue.Add(a);
                visited[a] = true;
                parent[a] = -1;

                while (queue.Count != 0)
                {
                    int u = queue[0];
                    queue.RemoveAt(0);

                    for (int v = 0; v < V; v++)
                    {
                        if (visited[v] == false
                            && Graphr[u, v] > 0)
                        {
                            if (v == b)
                            {
                                parent[v] = u;
                                return true;
                            }
                            queue.Add(v);
                            parent[v] = u;
                            visited[v] = true;
                        }
                    }
                }

                return false;
            }

            public static int fordFulkerson(int[,] graph, int a, int b)
            {
                int u, v;

                int[,] rGraph = new int[V, V];

                for (u = 0; u < V; u++)
                    for (v = 0; v < V; v++)
                        rGraph[u, v] = graph[u, v];


                int[] parent = new int[V];

                int max_flow = 0;

                while (bfs(rGraph, a, b, parent))
                {
                    int path_flow = int.MaxValue;
                    for (v = b; v != a; v = parent[v])
                    {
                        u = parent[v];
                        path_flow
                            = Math.Min(path_flow, rGraph[u, v]);
                    }

                    for (v = b; v != a; v = parent[v])
                    {
                        u = parent[v];
                        rGraph[u, v] -= path_flow;
                        rGraph[v, u] += path_flow;
                    }

                    max_flow += path_flow;
                }

                return max_flow;
            }

        }
    }
}
