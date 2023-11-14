#include <iostream>
#include <Windows.h>

using namespace std;

class alphabets {
protected:
    static bool is_ascii;

    char letters[33] = { 'А', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ю', 'Я' };
    string morse_analog[33] = { ".-", "-...",".--","....","--.","-..",".","..-..","...-","--..","-.--","..",".--.",".---","-.-",".-..","--","-.","---",".--.",".-.","...","-","..-","..-.","----","-.-.","---.","--.-","--.--","-..-","..--",".-.-" };
    char ascii_letters[33] = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    string ascii_morse_analog[33] = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
};

bool alphabets::is_ascii = false;

class Encoding : public alphabets {
public:
    Encoding() {
        
    }
    string encode(string message) {
        for (int i = 0; i < message.length(); i++) {
            //cout << (int)message[i];
            if ((int)message[i] >= 65 && (int)message[i] <= 122) {
                is_ascii = true;
            }
            else {
                is_ascii = false;
            }
        }

        string encoded_message = "";
        if (!is_ascii) {
            for (int i = 0; i < message.length(); i++) {
                for (int j = 0; j < 33; j++) {
                    if (message[i] == letters[j]) {
                        encoded_message += morse_analog[j];
                        encoded_message += ' ';
                    }
                }
            }
        }
        else {
            for (int i = 0; i < message.length(); i++) {
                for (int j = 0; j < 27; j++) {
                    if (message[i] == ascii_letters[j]) {
                        encoded_message += ascii_morse_analog[j];
                        encoded_message += ' ';
                    }
                }
            }
        }
        return encoded_message;
    }
};

class Decoding : public alphabets {
public:
    Decoding() {
        
    }
    string decode(string message) {
        string decoded_message;
        string morse_character; 

        for (int i = 0; i < message.length(); i++) {
            char ch = message[i]; //(int)message[i] < 101 && (int)message[i] < 132 ? (int)message[i]-40 : (int)message[i] < 192 && (int)message[i] > 223 ? (int)message[i]-32 : message[i];
            if (ch != ' ') {
                morse_character += ch;
            }
            else {
                if (!is_ascii) {
                    for (unsigned int i = 0; i < 33; ++i) {
                        if (morse_analog[i] == morse_character){
                            decoded_message += letters[i];
                        }
                    }
                }
                if (is_ascii) {
                    for (unsigned int i = 0; i < 27; ++i) {
                        if (ascii_morse_analog[i] == morse_character) {
                            decoded_message += ascii_letters[i];

                        }
                    }
                }
                morse_character.clear();
            }
        }
        if (!is_ascii) {
            for (unsigned int i = 0; i < 33; ++i) {
                if (morse_analog[i] == morse_character) {
                    decoded_message += letters[i];
                }
            }
        }
        else {
            for (unsigned int i = 0; i < 27; ++i) {
                if (ascii_morse_analog[i] == morse_character) {
                    decoded_message += ascii_letters[i];
                }
            }
        }

        return decoded_message;
    }
};


int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Encoding one;
    Decoding two;
    cout << one.encode("ITSTEP") << endl;
    cout << two.decode(one.encode("ITSTEP")) << endl;
}
