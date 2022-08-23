#include <array>
#include <cstring>
#include <iostream>
#include <queue>

using namespace std;

class BellmanFordAlgorithm {
   public:
    vector<int> findShortestPath(vector<array<int, 3>> edges, int n, int source) {
        vector<int> distance(n, INT_MAX);

        distance[source] = 0;

        for (int i = 0; i < n; i++)  // Do the relaxation up to n  times.
        {
            for (array<int, 3> edge : edges) {
                int u = edge[0];
                int du = distance[u];

                int v = edge[1];
                int dv = distance[v];

                int cuv = edge[2];

                if (du != INT_MAX && du + cuv < dv) {
                    distance[v] = du + cuv;
                }
            }
        }

        // One more relaxation for the checking the negative cycle.
        for (array<int, 3> edge : edges) {
            int u = edge[0];
            int du = distance[u];

            int v = edge[1];
            int dv = distance[v];

            int cuv = edge[2];

            if (du != INT_MAX && du + cuv < dv) {
                cout << "Negative cycle detected." << endl;
                return vector<int>{};
            }
        }

        return distance;
    }
};