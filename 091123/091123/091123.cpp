#include <iostream>

using namespace std;

class Sorting {
private:
    int n;
    string* array;
public:
    Sorting(string arr[], int length) {
        n = length;
        array = new string[n];
        for (int i = 0; i < n; i++) {
            array[i] = arr[i];
        }
    }

    string* reverse() {
        string* reversedarray = new string[n];
        int secondposition = n - 1;
        for (int i = 0; i < n; i++) {
            reversedarray[i] = array[secondposition];
            secondposition--;
        }

        return reversedarray;
    }

    string* sortbylength() {
        string* sortedarray = new string[n];
        for (int i = 0; i < n; i++) {
            sortedarray[i] = array[i];
        }

        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (sortedarray[j].length() < sortedarray[i].length()) {
                    string temp = sortedarray[i];
                    sortedarray[i] = sortedarray[j];
                    sortedarray[j] = temp;
                }
            }
        }

        return sortedarray;
    }

    string* sortbyalphabet() {
        string* sortedarray = new string[n];
        for (int i = 0; i < n; i++) {
            if (array[i][0] >= 49 && array[i][0] <= 90) {
                sortedarray[i] = tolower(array[i][0]);
            }
            sortedarray[i] = array[i];
        }

        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (sortedarray[j][0] > sortedarray[j + 1][0]) {
                    string temp = sortedarray[j];
                    sortedarray[j] = sortedarray[j+1];
                    sortedarray[j+1] = temp;
                }
            }
        }

        return sortedarray;
    }

    void showempty() {
        unsigned int amount_of_empty = 0;
        unsigned int temp = 0;
        for (int i = 0; i < n; i++) {
            if (array[i].length() == 0) {
                amount_of_empty++;
                continue;
            }
            for (int j = 0; j < array[i].length(); j++) {
                if (array[i][j] == ' ') {
                    temp++;
                }
            }
            if (temp == array[i].length()) {
                amount_of_empty++;
            }
            temp = 0;
        }
        cout << amount_of_empty << endl;
    }
};

int main() {
    string arr[5] = { "Baka", "meow", "  ", "", "123abc" };
    /*
    for (int i = 0; i < 5; i++) {
        cout << arr[i] << endl;
    }

    Sorting one(arr, 5);

    cout << "\n\n\n\n\n";

    string* reversedarr = one.reverse();

    for (int i = 0; i < 5; i++) {
        cout << reversedarr[i] << endl;
    }

    cout << "\n\n\n\n\n";

    string* lengtharr = one.sortbylength();

    for (int i = 0; i < 5; i++) {
        cout << lengtharr[i] << endl;
    }

    cout << "\n\n\n\n\n";

    string* alphabettharr = one.sortbyalphabet();

    for (int i = 0; i < 5; i++) {
        cout << alphabettharr[i] << endl;
    }
    */
    Sorting one{arr,5};

    one.showempty();
}
