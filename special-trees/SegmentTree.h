#include <vector>

using namespace std;

class SegmentTree {
   private:
    vector<int> segmentArray;
    vector<int> nums;
    int n = 0;

   public:
    SegmentTree(vector<int>& input) {
        n = input.size();
        this->nums = input;
        segmentArray.resize(4 * n, 0);
        buildTree(0, 0, n - 1);
    }

    // Build the segment tree using divide and conquer and merging
   private:
    void buildTree(int sIndex, int left, int right) {
        if (left == right) {
            segmentArray[sIndex] = nums[left];
            return;
        }

        int mid = (left + right) / 2;
        buildTree(2 * sIndex + 1, left, mid);
        buildTree(2 * sIndex + 2, mid + 1, right);

        // Sum of the left and right as we have find range sum
        // If we had to find min or max then we have store min or max between left and right
        segmentArray[sIndex] = segmentArray[2 * sIndex + 1] + segmentArray[2 * sIndex + 2];
    }

   public:
    void update(int index, int val) {
        int add = val - nums[index];
        nums[index] = val;
        update(0, 0, n - 1, index, add);
    }

   private:
    void update(int sIndex, int left, int right, int index, int add) {
        if (index < left || index > right) {
            return;
        }

        segmentArray[sIndex] += add;

        if (left != right) {
            int mid = (left + right) / 2;
            update(2 * sIndex + 1, left, mid, index, add);
            update(2 * sIndex + 2, mid + 1, right, index, add);
        }
    }

   public:
    int getRangeSum(int left, int right) {
        return getRangeSum(0, 0, n - 1, left, right);
    }

   private:
    int getRangeSum(int sIndex, int left, int right, int qLeft, int qRight) {
        // check if segment range lies in the query range
        if (left >= qLeft && right <= qRight) {
            return segmentArray[sIndex];
        }

        // Check if segment range is out of the query range
        if (right < qLeft || left > qRight) {
            return 0;
        }

        int mid = (left + right) / 2;

        // If segment range is partially overlap the query range
        int leftSum = getRangeSum(2 * sIndex + 1, left, mid, qLeft, qRight);
        int rightSum = getRangeSum(2 * sIndex + 2, mid + 1, right, qLeft, qRight);

        return leftSum + rightSum;
    }
};

// Time Complexity: update--> O(logN) and sumRange(logN)
// Space Complexity: O(4N) = O(N) + call stack: O(H)