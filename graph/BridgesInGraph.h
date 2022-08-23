#include <vector>

using namespace std;

// Sample inputs :vector<vector<int>> edges = {{1, 2}, {1, 4}, {2, 3}, {3, 4}, {4, 5}, {5, 6}, {6, 7}, {6, 9},
// {7, 8}, {9, 8}, {8, 10}, {10, 11}, {11, 12}, {10, 12}};
// Bridges are those edges whose removal splits the graph into more components.
// Bridge Edges/ Cut Edges/ Critical Edges
class BridgesInGraph {
   public:
    vector<vector<int>> find(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n + 1);
        for (auto edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            adjList[edge[1]].push_back(edge[0]);
        }

        vector<vector<int>> result;

        vector<int> visited(n + 1, 0);
        vector<int> tin(n + 1, 0);
        vector<int> lowestTin(n + 1, 0);

        for (int node = 1; node <= n; node++) {
            int timer = 1;
            if (visited[node] == 0) {
                dfs(adjList, -1, node, visited, tin, lowestTin, timer, result);
            }
        }

        return result;
    }

   private:
    void dfs(vector<vector<int>> adjList, int parent, int node, vector<int>& visited,
             vector<int>& tin, vector<int>& lowestTin, int& timer, vector<vector<int>>& result) {
        visited[node] = 1;
        tin[node] = lowestTin[node] = timer++;

        for (int adj : adjList[node]) {
            if (adj == parent) {
                continue;
            }

            if (visited[adj] == 0) {
                dfs(adjList, node, adj, visited, tin, lowestTin, timer, result);

                // Update the lowest time of insertion
                lowestTin[node] = min(lowestTin[node], lowestTin[adj]);

                // If the adj has the greater lowest time insertion than the current's tin then this is a bridge
                if (lowestTin[adj] > tin[node]) {
                    result.push_back({node, adj});
                }

            } else {
                // If already visited then update the lowest time of insertion.
                lowestTin[node] = min(lowestTin[node], lowestTin[adj]);
            }
        }
    }
};