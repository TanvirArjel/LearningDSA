#include <queue>
#include <stack>
#include <vector>

using namespace std;

// Topological sort for DAG(Directed Acyclic Graph). If there is cycle then there will no topo sort
class TopologicalSort {
   public:
    vector<int> findUsingBFS(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n);
        vector<int> inDegree(n, 0);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            inDegree[edge[1]]++;
        }

        queue<int> zeroInDegree;
        for (int i = 0; i < n; i++) {
            if (inDegree[i] == 0) {
                zeroInDegree.push(i);
            }
        }

        vector<int> topoSort;

        if (zeroInDegree.empty()) {
            return topoSort;
        }

        while (!zeroInDegree.empty()) {
            int current = zeroInDegree.front();
            zeroInDegree.pop();
            topoSort.push_back(current);

            for (int adj : adjList[current]) {
                inDegree[adj]--;
                if (inDegree[adj] == 0) {
                    zeroInDegree.push(adj);
                }
            }
        }

        if (topoSort.size() != n) {
            return vector<int>{};
        }

        return topoSort;
    }

   public:
    vector<int> findUsingDFS(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n);

        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
        }

        vector<int> visited(n, 0);
        vector<int> dfsVisited(n, 0);
        vector<int> topoSort;
        for (int node = 0; node < n; node++) {
            if (visited[node] == 0) {
                if (dfs(adjList, node, visited, dfsVisited, topoSort)) {
                    return vector<int>{};
                }
            }
        }

        reverse(topoSort.begin(), topoSort.end());
        return topoSort;
    }

   private:
    bool dfs(vector<vector<int>>& adjList, int node, vector<int>& visited, vector<int>& dfsVisited, vector<int>& topoSort) {
        visited[node] = 1;
        dfsVisited[node] = 1;

        for (int adj : adjList[node]) {
            if (visited[adj] == 0) {
                // Return true if cycle is detected.
                if (dfs(adjList, adj, visited, dfsVisited, topoSort)) {
                    return true;
                }
            } else if (dfsVisited[adj] == 1) {
                return true;
            }
        }

        // The node will be executed last in the DFS will in the last in the top sort and that'w why it will be added in the stack first;
        topoSort.push_back(node);
        dfsVisited[node] = 0;
        return false;
    }
};