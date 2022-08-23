#include <vector>

using namespace std;

class GraphColoring {
   public:
    bool canColor(vector<vector<int>>& edges, int n, int m) {
        vector<vector<int>> adjList(n);
        for (auto edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            adjList[edge[1]].push_back(edge[0]);
        }

        vector<int> nodeColors(n, 0);

        for (int node = 0; node < n; node++) {
            if (nodeColors[node] == 0) {
                if (canColor(adjList, node, n, m, nodeColors) == false) {
                    return false;
                }
            }
        }

        return true;
    }

   private:
    bool canColor(vector<vector<int>>& adjList, int node, int n, int m, vector<int>& nodeColors) {
        if (node == n) {
            return true;
        }

        // try out all colors for the current node
        for (int i = 1; i <= m; i++) {
            if (isValidColor(adjList, node, i, nodeColors)) {
                nodeColors[node] = i;

                bool isPossible = canColor(adjList, node + 1, n, m, nodeColors);
                if (isPossible) {
                    return true;
                }
                // Backtrack
                nodeColors[node] = 0;
            }
        }

        return false;
    }

   private:
    // Graph coloring algorithm
    bool isValidColor(vector<vector<int>>& adjList, int node, int color, vector<int>& nodeColors) {
        for (int neighbour : adjList[node]) {
            if (nodeColors[neighbour] == color) {
                return false;
            }
        }

        return true;
    }
};