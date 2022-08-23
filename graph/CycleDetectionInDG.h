#include <iostream>
#include <queue>
#include <vector>

using namespace std;

// Cycle detection in Directed Graph
class CycleDetectionInDG {
   public:
    bool usingBFS(vector<vector<int>>& edges, int n) {
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

        if (zeroInDegree.empty()) {
            return true;
        }

        vector<int> topoSort;

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

        return topoSort.size() != n;
    }

   public:
    bool usingDFS(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
        }

        vector<int> visited(n, 0);
        vector<int> dfsVisited(n, 0);

        for (int node = 0; node < n; node++) {
            bool hasCycle = cycleDFS(adjList, node, dfsVisited, visited);
            if (hasCycle) {
                return true;
            }
        }

        return false;
    }

   private:
    bool cycleDFS(vector<vector<int>>& adjList, int node, vector<int>& dfsVisited, vector<int>& visited) {
        visited[node] = 1;
        dfsVisited[node] = 1;

        for (int adj : adjList[node]) {
            if (visited[adj] == 0) {
                if (cycleDFS(adjList, adj, dfsVisited, visited)) {
                    return true;
                }
            } else if (dfsVisited[adj] == 1) {
                return true;
            }
        }

        // Back track the dfsVisited.
        dfsVisited[node] = 0;
        return false;
    }
};