#include <algorithm>
#include <iostream>
#include <queue>
#include <stack>
#include <unordered_set>
#include <vector>

#include "bit-manipulation/job_assignment.h"
#include "graph/KosarajusAlgorithm.h"

using namespace std;

int main() {
    vector<vector<int>> cost = {{9, 2, 7, 8}, {6, 4, 3, 7}, {5, 8, 1, 8}, {7, 6, 9, 4}};
    JobAssignment* jobAssignment = new JobAssignment();
    int minCost = jobAssignment->findMinCost(cost);
    cout << minCost << endl;
    return 1;
}