#include <iostream>
#include <queue>
#include <stack>
#include <vector>

using namespace std;

// Cycle detection for Undirected Graph
class CycleDetectionInUDG {
    // Using Breadth first search algorithm.
   public:
    bool usingBFS(vector<vector<int>>& edges, int n) {
        // Build the adjacency list
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            adjList[edge[1]].push_back(edge[0]);
        }

        vector<int> visited(n, 0);
        queue<pair<int, int>> queue;

        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                queue.push({0, -1});
                visited[0] = 1;

                while (!queue.empty()) {
                    auto current = queue.front();
                    queue.pop();

                    for (int adj : adjList[current.first]) {
                        if (visited[adj] == 0) {
                            visited[adj] = 1;
                            queue.push({adj, current.first});
                        } else {
                            if (adj != current.second) {
                                cout << "Cycle detected at " << adj << endl;
                                return true;
                            }
                        }
                    }
                }
            }
        }

        cout << "No cycle detected" << endl;
        return false;
    }

    // Using Depth First Search Algorithm
   public:
    bool usingDFS(vector<vector<int>>& edges, int n) {
        // Build the adjacency list
        vector<vector<int>> adjList(n);
        for (vector<int> edge : edges) {
            adjList[edge[0]].push_back(edge[1]);
            adjList[edge[1]].push_back(edge[0]);
        }

        vector<int> visited(n, 0);
        stack<pair<int, int>> stack;

        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                stack.push({i, -1});

                while (!stack.empty()) {
                    auto current = stack.top();
                    stack.pop();

                    if (visited[current.first] == 1) {
                        continue;
                    }

                    visited[current.first] = 1;

                    for (int adj : adjList[current.first]) {
                        if (visited[adj] == 0) {
                            stack.push({adj, current.first});
                        } else {
                            if (adj != current.second) {
                                cout << "Cycle detected at " << adj << endl;
                                return true;
                            }
                        }
                    }
                }
            }
        }

        cout << "No cycle detected" << endl;
        return false;
    }
};