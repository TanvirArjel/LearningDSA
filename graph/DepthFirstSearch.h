#include <stack>
#include <vector>

using namespace std;

class DepthFirstSearch {
   public:
    vector<int> usingRecursion(vector<vector<int>>& edges, int n, bool isDirected = true) {
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            if (isDirected == false) {
                adjList[edge[1]].push_back(edge[0]);
            }
        }

        vector<int> result;
        vector<int> visited(n, 0);

        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                dfs(adjList, i, visited, result);
            }
        }

        return result;
    }

   private:
    void dfs(vector<vector<int>>& adjList, int node, vector<int>& visited, vector<int>& result) {
        visited[node] = 1;
        result.push_back(node);

        for (int adj : adjList[node]) {
            if (visited[adj] == 0) {
                dfs(adjList, adj, visited, result);
            }
        }
    }

   public:
    vector<int> usingIterative(vector<vector<int>>& edges, int n, bool isDirected = true) {
        vector<vector<int>> adjList(n);

        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            if (isDirected == false) {
                adjList[edge[1]].push_back(edge[0]);
            }
        }

        vector<int> result;
        vector<int> visited(n, 0);
        stack<int> stack;

        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                stack.push(i);

                while (!stack.empty()) {
                    int current = stack.top();
                    stack.pop();

                    if (visited[current] == 1) {
                        continue;
                    }

                    visited[current] = 1;

                    result.push_back(current);

                    for (int adj : adjList[current]) {
                        if (visited[adj] == 0) {
                            stack.push(adj);
                        }
                    }
                }
            }
        }

        return result;
    }
};
