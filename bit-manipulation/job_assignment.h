#include <cstring>
#include <iostream>
#include <vector>

using namespace std;

// Example of bit masking dynamic programming

// Problem Statement

// Let there be N workers and N jobs. Any worker can be assigned to perform any job, incurring some cost that
// may vary depending on the work-job assignment. It is required to perform all jobs by assigning exactly one worker to each job and
// exactly one job to each agent in such a way that the total cost of the assignment is minimized.

// Input Format
// Number of workers and job: N
// Cost matrix C with dimension N*N where C(i,j) is the cost incurred on assigning ith Person to jth Job.

// Sample Input
// 4

// [
// 9 2 7 8
// 6 4 3 7
// 5 8 1 8
// 7 6 9 4
// ]

// Sample Output
// 13

// Constraints
// N <= 20

class JobAssignment {
   private:
    int n = 0;
    int memo[21][(1 << 21)];

   public:
    int findMinCost(vector<vector<int>>& cost) {
        this->n = cost.size();
        memset(memo, -1, sizeof(memo));
        return dp(cost, 0, 0);
    }

   private:
    int dp(vector<vector<int>>& cost, int index, int mask) {
        if (index == n) {
            return 0;
        }

        if (memo[index][mask] != -1) {
            return memo[index][mask];
        }

        // Try out all available jobs for the current person
        int minCost = INT_MAX;
        for (int j = 0; j < n; j++) {
            if ((mask & (1 << j)) == 0) {
                int current = cost[index][j] + dp(cost, index + 1, mask ^ (1 << j));
                minCost = min(minCost, current);
            }
        }

        return memo[index][mask] = minCost;
    }
};

// Time Complexity: O(N^2)
// Space Complexity: O(N.2^N)
