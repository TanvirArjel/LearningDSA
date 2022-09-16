#include <algorithm>
#include <iostream>
#include <queue>
#include <stack>
#include <unordered_set>
#include <vector>

#include "graph/KosarajusAlgorithm.h"

using namespace std;

// Functional recursion with single parameter.
void reverse(vector<int>& nums, int i) {
    if (i >= nums.size() / 2) {
        return;
    }

    int j = nums.size() - 1 - i;
    swap(nums[i], nums[j]);

    reverse(nums, i + 1);
}

int main() {
    cout << "Hello Word" << endl;
    return 1;
}