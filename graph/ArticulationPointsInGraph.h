#include <vector>

using namespace std;

// Articulation Points/ Cut Vertices/ Critical Nodes
// Sample input: vector<vector<int>> edges = {{1, 2}, {1, 4}, {2, 3}, {3, 4}, {4, 5}, {5, 6}, {6, 7}, {6, 9}, {7, 8},
// {9, 8}, {8, 10}, {10, 11}, {11, 12}, {10, 12}};
// Articulation points are those nodes whose removal splits the graph into more components.
class ArticulationPoints {
   public:
    vector<int> find(vector<vector<int>>& edges, int n) {
        vector<vector<int>> adjList(n + 1);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            adjList[edge[1]].push_back(edge[0]);
        }

        vector<int> visited(n + 1, 0);
        vector<int> tin(n + 1, 0);
        vector<int> lowestTin(n + 1, 0);
        vector<int> articulationPoints(n + 1, 0);

        for (int node = 0; node <= n; node++) {
            int timer = 1;
            if (visited[node] == 0) {
                findDFS(adjList, node, -1, visited, tin, lowestTin, timer, articulationPoints);
            }
        }

        vector<int> points;
        for (int index = 0; index <= n; index++) {
            if (articulationPoints[index] == 1) {
                points.push_back(index);
            }
        }

        return points;
    }

   private:
    void findDFS(vector<vector<int>>& adjList, int node, int parent,
                 vector<int>& visited, vector<int>& tin, vector<int>& lowestTin, int& timer,
                 vector<int>& articulationPoints) {
        visited[node] = 1;
        tin[node] = lowestTin[node] = timer++;

        int child = 0;
        for (int adj : adjList[node]) {
            if (adj == parent) {
                continue;
            }

            if (visited[adj] == 0) {
                findDFS(adjList, adj, node, visited, tin, lowestTin, timer, articulationPoints);

                // Update the lowest time of insertion
                lowestTin[node] = min(lowestTin[node], lowestTin[adj]);

                if (lowestTin[adj] >= tin[node] && parent != -1) {
                    articulationPoints[node] = 1;
                }

                child++;
            } else {
                lowestTin[node] = min(lowestTin[node], tin[adj]);
            }
        }

        if (parent == -1 && child > 1) {
            articulationPoints[node] = 1;
        }
    }
};