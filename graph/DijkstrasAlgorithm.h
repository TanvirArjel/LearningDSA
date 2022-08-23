#include <queue>
#include <vector>

using namespace std;

// Dijkstra's shortest path algorithm is used for finding shortest path from a source node to all other nodes in a weighted graph.
class DijkstrasAlgorithm {
   public:
    vector<int> findShortestPath(vector<vector<int>> edges, int n, int src, bool isDirected = true) {
        // Build the adjacency list
        vector<vector<pair<int, int>>> adjList(n);

        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back({edge[1], edge[2]});
            if (isDirected == false) {
                adjList[edge[1]].push_back({edge[0], edge[2]});
            }
        }

        vector<int> dist(n, INT_MAX);

        // {dist, node}
        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> minHeap;
        minHeap.push({0, src});
        dist[src] = 0;

        while (!minHeap.empty()) {
            auto current = minHeap.top();
            minHeap.pop();

            for (auto adj : adjList[current.second]) {
                if (dist[current.second] + adj.second < dist[adj.first]) {
                    dist[adj.first] = dist[current.second] + adj.second;
                    minHeap.push({dist[adj.first], adj.first});
                }
            }
        }

        return dist;
    }
};