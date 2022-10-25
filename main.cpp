#include <algorithm>
#include <iostream>
#include <queue>
#include <stack>
#include <unordered_set>
#include <vector>

#include "bit-manipulation/implement-set.h"
#include "graph/KosarajusAlgorithm.h"

using namespace std;

int main() {
    BitMaskSet* bitSet = new BitMaskSet();
    bitSet->add(5);
    bitSet->add(7);
    bitSet->add(3);

    bitSet->display();

    cout << "Removed" << endl;

    bitSet->remove(3);
    bitSet->display();

    return 1;
}