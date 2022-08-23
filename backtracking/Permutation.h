#include <unordered_map>
#include <unordered_set>
#include <vector>

using namespace std;

class Permutation {
   public:
    vector<vector<int>> find(vector<int>& nums) {
        vector<vector<int>> result;
        unordered_set<int> taken;
        vector<int> current;
        permute(nums, current, result, taken);
        return result;
    }

   private:
    void permute(vector<int>& nums, vector<int>& perm,
                 vector<vector<int>>& result, unordered_set<int>& taken) {
        if (perm.size() == nums.size()) {
            result.push_back(perm);
        }

        // for each position, we will loop through all elements and taken the elements that are not being taken already.
        for (int i = 0; i < nums.size(); i++) {
            if (!taken.count(i)) {
                perm.push_back(nums[i]);
                taken.insert(i);

                permute(nums, perm, result, taken);

                // Backtrack to the previous state.
                perm.pop_back();
                taken.erase(taken.find(i));
            }
        }
    }

    void permuteSwap(vector<int>& nums, int start, vector<vector<int>>& result) {
        if (start == nums.size()) {
            result.push_back(nums);
            return;
        }

        for (int index = start; index < nums.size(); index++) {
            swap(nums[start], nums[index]);
            permuteSwap(nums, start + 1, result);
            swap(nums[start], nums[index]);
        }
    }
};