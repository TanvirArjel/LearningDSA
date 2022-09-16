#include <vector>

using namespace std;

class BinaryIndexTree {
   private:
    int size = 0;
    vector<int> treeArray;
    vector<int> nums;

   public:
    BinaryIndexTree(vector<int>& input) {
        int n = input.size();
        this->size = n + 1;  // Binary index tree will be 1-indexed based.
        treeArray.resize(size);
        nums.resize(n, 0);

        // Build the binary index tree
        for (int index = 0; index < n; index++) {
            update(index, input[index]);
        }
    }

   public:
    void update(int index, int value) {
        int add = value - nums[index];
        nums[index] = value;

        index = index + 1;  // Binary indexed tree is 1-indexed based.

        while (index < size) {
            treeArray[index] += add;
            index = index + (index & (-index));
        }
    }

    int getSum(int index) {
        index = index + 1;  // Binary indexed tree is 1-indexed based.

        int sum = 0;
        while (index > 0) {
            sum += treeArray[index];
            index = index - (index & (-index));
        }

        return sum;
    }

    int getRangeSum(int left, int right) {
        int leftSum = getSum(left - 1);
        int rightSum = getSum(right);
        return rightSum - leftSum;
    }
};

// Using Binary Index Tree/ Fenwick Tree
// Time Complexity: O(logN)
// Space Complexity: O(N)