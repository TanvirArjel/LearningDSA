#include <iostream>
#include <queue>
#include <vector>

using namespace std;

class PrimsAlgorithm {
   public:
    int getMinCost(vector<vector<int>>& edges, int n) {
        vector<vector<pair<int, int>>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back({edge[1], edge[2]});
        }

        // Min weight from its parent
        vector<int> weights(n, INT_MAX);
        vector<bool> mst(n, false);
        vector<int> parent(n, -1);

        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> minHeap;
        minHeap.push({0, 0});
        weights[0] = 0;

        int minCost = 0;

        while (n) {
            // Find the min weight node that are not part of the mst
            auto minPair = minHeap.top();
            minHeap.pop();

            int minNode = minPair.second;
            if (mst[minNode]) {
                continue;
            }

            n--;

            mst[minNode] = true;
            minCost += minPair.first;

            // Explore all the adjacent of the current node
            for (pair<int, int> adjPair : adjList[minNode]) {
                int adj = adjPair.first;
                int weight = adjPair.second;
                if (mst[adj] == false && weights[adj] > weight) {
                    parent[adj] = minNode;
                    weights[adj] = weight;
                    minHeap.push({weights[adj], adj});
                }
            }
        }

        return minCost;
    }
};