#include <queue>
#include <vector>

using namespace std;

class ShortestPathInUnitWeightGraph {
    vector<int> find(vector<vector<int>> edges, int n, int src, bool isDirected = true) {
        // Build the adjacency list
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            if (isDirected == false) {
                adjList[edge[1]].push_back(edge[0]);
            }
        }

        vector<int> dist(n, INT_MAX);
        queue<int> queue;
        queue.push(src);
        dist[src] = 0;

        while (!queue.empty()) {
            int current = queue.front();
            queue.pop();

            for (int adj : adjList[current]) {
                if (dist[current] + 1 < dist[adj]) {
                    dist[adj] = dist[current] + 1;
                    queue.push(adj);
                }
            }
        }

        return dist;
    }
};