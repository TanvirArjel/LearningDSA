#include <queue>
#include <vector>

using namespace std;

class BreadthFirstSearch {
    vector<int> find(vector<vector<int>>& edges, int n, bool isDirected = true) {
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            if (isDirected == false) {
                adjList[edge[1]].push_back(edge[0]);
            }
        }

        vector<int> result;

        queue<int> queue;
        vector<int> visited(n, 0);

        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                queue.push(i);
                visited[i] = 1;

                while (!queue.empty()) {
                    int current = queue.front();
                    queue.pop();

                    result.push_back(current);

                    for (int adj : adjList[current]) {
                        if (visited[adj] == 0) {
                            queue.push(adj);
                            visited[adj] = 1;
                        }
                    }
                }
            }
        }

        return result;
    }
};