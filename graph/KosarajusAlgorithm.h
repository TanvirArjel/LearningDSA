#include <stack>
#include <vector>

using namespace std;

// Kosaraju's algorithm
// This is to find the strongly connected components in directed graph.
// Three steps to find the strongly connected components using Kosaraju's algorithm.
// 1. Find the DFS order of the graph
// 2. Transpose or invert the graph
// 3. Do DFS on the transposed graph according to the original DFS order.
// Sample Input : vector<vector<int>> edges3 = {{0, 1}, {1, 2}, {2, 0}, {1, 3}, {3, 4}, {4, 5}, {5, 3}};
class KosarajusAlgorithm {
   public:
    vector<vector<int>> findSCC(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
        }

        vector<int> visited(n, 0);
        stack<int> dfsOrder;
        for (int node = 0; node < n; node++) {
            if (visited[node] == 0) {
                storeOrgDFSOrder(adjList, node, visited, dfsOrder);
            }
        }

        // Transpose the graph
        vector<vector<int>> transposeGraph(n);
        for (vector<int> edge : edges) {
            transposeGraph[edge[1]].push_back(edge[0]);
        }

        // Do DFS on the transpose graph
        vector<vector<int>> result;
        std::fill(visited.begin(), visited.end(), 0);

        while (!dfsOrder.empty()) {
            int node = dfsOrder.top();
            dfsOrder.pop();
            if (visited[node] == 0) {
                vector<int> component;
                kosarajuDFS(transposeGraph, node, visited, component);
                result.push_back(component);
            }
        }

        return result;
    }

   public:
    void kosarajuDFS(vector<vector<int>>& adjList, int node, vector<int>& visited, vector<int>& component) {
        visited[node] = 1;
        component.push_back(node);

        for (int adj : adjList[node]) {
            if (visited[adj] == 0) {
                kosarajuDFS(adjList, adj, visited, component);
            }
        }
    }

   public:
    void storeOrgDFSOrder(vector<vector<int>>& adjList, int node, vector<int>& visited, stack<int>& dfsOrder) {
        visited[node] = 1;
        for (int adj : adjList[node]) {
            if (visited[adj] == 0) {
                storeOrgDFSOrder(adjList, adj, visited, dfsOrder);
            }
        }

        dfsOrder.push(node);
    }
};
