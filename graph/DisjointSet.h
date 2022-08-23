#include <vector>

using namespace std;

class DisjointSet {
    vector<int> rootArray;
    vector<int> rankArray;

   public:
    DisjointSet(int n) {
        rootArray.resize(n);
        rankArray.resize(n);
        for (int i = 0; i < n; i++) {
            rootArray[i] = i;
            rankArray[i] = 0;
        }
    }

    int findRoot(int node) {
        if (node == rootArray[node]) {
            return node;
        }

        return rootArray[node] = findRoot(rootArray[node]);
    }

    bool doUnion(int node1, int node2) {
        int root1 = findRoot(node1);
        int root2 = findRoot(node2);

        if (root1 == root2) {
            return false;
        }

        if (rankArray[root1] >= rankArray[root2]) {
            rootArray[root2] = root1;
            rankArray[root1]++;
        } else {
            rootArray[root1] = root2;
            rankArray[root2]++;
        }

        return true;
    }
};