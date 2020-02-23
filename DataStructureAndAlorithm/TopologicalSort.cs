using System;
using System.Collections.Generic;

namespace DataStructureAndAlgorithm
{

    public class TopologicalSort
    {
        public static void DoTopologicalSort()
        {
            // create a graph here
            Graph graph = new Graph();

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 6);

            graph.AddEdge(3, 4);
            graph.AddEdge(3, 1);

            graph.AddEdge(4, 5);

            graph.AddEdge(6, 2);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 5);

            // print the vertices in topologically sorted order
            graph.PrintTopoSortedNodes();
        }
    }

    public class GraphNode
    {
        public int NodeId;
        public GraphNode NextNode;

        public GraphNode(int id)
        {
            NodeId = id;
        }
    }

    public class Graph
    {
        private List<GraphNode> _nodeList = new List<GraphNode>();

        // adding edge from id1 to id2
        // if either of these does not exist then create and add
        public void AddEdge(int node1Id, int node2Id)
        {
            GraphNode node1 = _nodeList.Find(n => n.NodeId == node1Id);
            GraphNode node2 = _nodeList.Find(n => n.NodeId == node2Id);

            if (node1 == null)
            {
                node1 = new GraphNode(node1Id);
                _nodeList.Add(node1);
            }

            if (node2 == null)
            {
                node2 = new GraphNode(node2Id);
                _nodeList.Add(node2);
            }

            GraphNode temp = new GraphNode(node2Id); // These three lines is the crucial part of this algorithm
            temp.NextNode = node1.NextNode;
            node1.NextNode = temp;
        }


        public void PrintTopoSortedNodes()
        {
            Dictionary<int, int> nodeInDegrees = new Dictionary<int, int>();
            List<GraphNode> zeroDegreeNodes = new List<GraphNode>();
            List<GraphNode> nodes = this._nodeList;

            // this for loop counts the in-degrees for all nodes.
            // adds nodes having in-degree > 0 to in-Degrees dictionary 
            for (int i = 0; i < nodes.Count; i++)
            {
                GraphNode currentNode = nodes[i];
                GraphNode nextNode = currentNode.NextNode;
                while (nextNode != null)
                {
                    int count = nodeInDegrees.ContainsKey(nextNode.NodeId) ? nodeInDegrees[nextNode.NodeId] : 0;
                    nodeInDegrees[nextNode.NodeId] = count + 1;
                    nextNode = nextNode.NextNode;
                }
            }

            // nodes which are not added to in-degree hashtable have in-degree = 0
            // create zeroDegree list of such nodes
            for (int i = 0; i < nodes.Count; i++)
            {
                GraphNode graphNode = nodes[i];

                // nodes with zero indegree would not be in the dictionary 
                // since they are not in anyone's neighbor list
                if (!nodeInDegrees.ContainsKey(graphNode.NodeId))
                {
                    zeroDegreeNodes.Add(graphNode);
                }

            }

            // take out a node from zeroDegree list
            // print that node, remove all out-edges associated with it and update zeroDegree list.
            while (zeroDegreeNodes.Count > 0)
            {
                GraphNode currentNode = zeroDegreeNodes[0];
                zeroDegreeNodes.RemoveAt(0);

                // print topo sort: output! 
                Console.WriteLine(currentNode.NodeId);

                GraphNode nextNode = currentNode.NextNode;
                // update the in-degree for all the neighbors of the current vertex
                while (nextNode != null)
                {
                    int prevInDegree = nodeInDegrees[nextNode.NodeId];

                    nodeInDegrees[nextNode.NodeId] = prevInDegree - 1;
                    if (prevInDegree == 1)
                    {
                        GraphNode zeroDegreeNode = _nodeList.Find(x => x.NodeId == nextNode.NodeId);
                        zeroDegreeNodes.Add(zeroDegreeNode);
                    }
                    nextNode = nextNode.NextNode;
                }
            }

        }

    }
}
