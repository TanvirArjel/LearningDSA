#include <iostream>

using namespace std;

class BitMaskSet {
   private:
    int mask = 0;

   public:
    void add(int item) {
        mask = mask | (1 << item);
    }

    void remove(int item) {
        mask = mask ^ (1 << item);
    }

    void display() {
        for (int i = 0; i <= 31; i++) {
            int bit = (mask >> i) & 1;
            if (bit == 1) {
                cout << i << endl;
            }
        }
    }
};