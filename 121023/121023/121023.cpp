#include <iostream>
#include <windows.h>

using namespace std;

class Figure {
public:
	char symbol;
	string type;
	Figure(string type, char symbol) {
		this->type = type;
		this->symbol = symbol;

	}
};

class Field {
public:
	char** board;
	Field() {
		board = new char* [10];
		for (int i = 0; i < 10; i++) {
			board[i] = new char[10];
		}
	}
	
	void fillfield() {
		for (int i = 0; i < 10; i++) {
			for (int y = 0; y < 10; y++) {
				board[i][y] = ' ';
			}
		}
	}
	
	void showField() {
		for (int i = 0; i < 30; i++) {
			cout << '-';
		}
		cout << endl;
		for (int i = 0; i < 10; i++) {
			for (int y = 0; y < 10; y++) {
				cout << '|' << board[i][y] << '|';
			}
			cout << endl;
		}
		for (int i = 0; i < 30; i++) {
			cout << '-';
		}
		cout << endl;
	}
	void addfigure(Figure figure) {
		int x,y; bool doesfit = true;

		do {
			x = rand() % 10;
			int y = rand() % 10;
		} while (board[x][y] != ' ');

		board[x][y] = figure.symbol;

		for (int i = 0; i < figure.type.length(); i++) {
			switch (figure.type[i]) {
			case '#':
				if (figure.type[i + 1] == '/') {
					x++;
					i++;
				}
				board[x][y] = figure.symbol;
				y++;
				break;
			case '/':
				x++;
				break;
			case ' ':
				y++;
				break;
			}
		}
	}




};

int main()
{
	srand((unsigned)time(NULL));
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Field game;

	Figure square{ "##/##", 'a' };
	Figure lightning{ "#/#/ #/ #", 'b' };
	Figure tank{ " #/###", 's' };
	Figure line{ "####", 'b' };
	Figure upsidedowng{ "#/#/##", 'g'};
	game.fillfield();
	game.addfigure(tank);
	game.addfigure(line);
	game.showField();
}