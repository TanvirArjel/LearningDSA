#include <algorithm>
#include <vector>

#include "graph/DisjointSet.h"

using namespace std;

// Kruskal's algorithm
class KruskalsAlgorithm {
   public:
    // {node1, node2, weight}
    int kruskalAlgorithm(vector<vector<int>>& edges, int n) {
        auto comp = [](vector<int>& a, vector<int>& b) {
            return a[2] < b[2];
        };

        // Sort the node by weight in ascending order.
        sort(edges.begin(), edges.end(), comp);  // O(E.log(E))

        DisjointSet* disjointSet = new DisjointSet(n);

        int minCost = 0;
        for (vector<int> edge : edges) {
            if (disjointSet->doUnion(edge[0], edge[1])) {
                minCost += edge[2];
            }
        }

        return minCost;
    }
};