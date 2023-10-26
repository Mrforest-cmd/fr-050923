#include <iostream>
#include <Windows.h>
//#include <cstring>

using namespace std;

string question[9] = { "1. Найбільша країна за площею в світі.",
                       "2. Країна, відома своєю кухнею з макаронів та піцци.",
                       "3. Країна, яка є рідиною кенгуру та коята.",
                       "4. Країна, де розташована піраміда Хеопса.",
                       "5. Країна, яка здобула свою незалежність від Великої Британії у 1776 році.",
                       "6. Країна, в якій розташоване Тадж-Махал.",
                       "7. Найбільша країна Південної Америки.",
                       "8. Країна, де знаходиться Колізей.",
                       "9. Країна, яка має найбільше островів у світі." };
string answer[9] = { "росія", "італія", "австралія", "єгипет", "сша", "індія", "бразилія", "італія", "індонезія" };

/*char tolower_win1251(char ch) {
    if (ch >= 192 && ch <= 223) {
        return ch + 32;
    }
    return ch;
}*/

string stringtolower1251(string text) {
    string result;
    for (int i = 0; i < text.length(); i++) {
        if (text[i] >= 192 && text[i] <= 223) {
            result += text[i] + 32;
        }
        else {
            result += text[i];
        }
    }
    return result;
}



class Tables {
private:
    string question[9];
    string answer[9];
    bool finish = false;

public:
    //--------------------------------------------------------------------------
    void createGraphicsTable(string answer[]) {
        int spaceCout = 0;
        int findingChar = 0;
        int check = 0;

        for (int i = 0; i < answer[0].length(); i++) {
            for (int j = 0; j < answer[1].length(); j++) {
                if (answer[0][i] == answer[1][j]) {
                    spaceCout = i;
                    findingChar = j;
                    for (int k = j+1; k != 0; k--) {
                        for (int q = 0; q < spaceCout; q++) {
                            cout << "   ";
                        }
                        if (this->answer[i] == "") {
                            cout << '|' << this->answer[1][check] << '|' << endl;
                            check++;
                        }
                        else {
                            cout << '|' << ' ' << '|' << endl; check++;
                        }
                    }
                    break;
                }
            }
        }
        for (int i = 0; i < answer[check].length(); i++) {
            cout << '|' << this->answer[1][i] << '|';
        }
        cout << endl;
        for (int i = answer[1].length(); i > findingChar; i--) {
            for (int q = 0; q < spaceCout; q++) {
                cout << "   ";
            }
            cout << "| |" << endl;
        }        
        /*//--------------------------------------------------------------------------
        for (int i = 0; i < answer[1].length(); i++) {
            for (int j = 0; j < answer[2].length(); j++) {
                if (answer[1][i] == answer[2][j]) {
                    spaceCout = i;
                    findingChar = j;
                    for (int k = j; k != 0; k--) {
                        for (int q = 0; q < spaceCout; q++) {
                            cout << "   ";
                        }
                        if (this->answer[i] == "") {
                            cout << '|' << this->answer[2][check] << '|' << endl;
                            check++;
                        }
                        else {
                            cout << '|' << ' ' << '|' << endl; check++;
                        }
                    }
                    break;
                }
            }
        }
        for (int i = 0; i < answer[check].length(); i++) {
            cout << '|' << this->answer[2][check] << '|';
        }
        *///--------------------------------------------------------------------------
    }
    Tables(string question[], string answer[]) {
        for (int i = 0; i < 9; i++) {
            this->question[i] = question[i];
            this->answer[i] = answer[i];
        }
        this->finish = Start();
        while (!this->finish) {
            createGraphicsTable(answer);
            this->getQuestion();
            this->numberOfQuestion();
            this->finish = this->Start();
            system("cls");
        }

    }
    bool Start() {
        for (int i = 0; i < 9; i++) {
            if (this->question[i] != "") {
                return false;
            }
        }
        return true;
    }
    void getQuestion() {
        for (int i = 0; i < 9; i++) {
            cout << this->question[i] << endl;
        }
    }
    void numberOfQuestion() {
        int numberQ;
        cout << "Enter question number: ";
        cin >> numberQ;
        if (numberQ > 0 && numberQ < 10) {
            cout << endl << this->question[numberQ - 1] << endl;
        }
        cout << "Enter your answer: ";
        string answerr;
        cin >> answerr;
        //answerr = stringtolower1251(answerr);
        if (answerr == this->answer[numberQ - 1]) {
            cout << answerr << " - well done.\n";
            setQuestionOfNumber(numberQ - 1);
        }
        else {
            cout << answerr << " - Wrong answer" << endl;
        }

    }
    void setQuestionOfNumber(int number) {
        this->question[number] = "";
    }

};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
        Tables game{ question,answer };
        cout << "\n\n\n";
        game.numberOfQuestion();

}