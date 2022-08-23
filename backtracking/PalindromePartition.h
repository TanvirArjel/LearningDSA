#include <string>
#include <vector>

using namespace std;

class PalindromePartition {
   public:
    vector<vector<string>> find(string& s) {
        vector<vector<string>> result;
        vector<string> current;
        find(s, 0, current, result);
        return result;
    }

   private:
    void find(string& s, int start, vector<string>& current, vector<vector<string>>& result) {
        if (start == s.length()) {
            result.push_back(current);
            return;
        }

        for (int index = start; index < s.length(); index++) {
            bool palindrome = isPalindrome(s, start, index);
            if (palindrome) {
                string substring = s.substr(start, index - start + 1);
                current.push_back(substring);
                find(s, index + 1, current, result);
                current.pop_back();
            }
        }
    }

    bool isPalindrome(string& s, int i, int j) {
        while (i < j) {
            if (s[i] != s[j]) {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
};