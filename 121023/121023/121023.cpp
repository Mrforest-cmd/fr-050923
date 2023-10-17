#include <iostream>

using namespace std;

class Figure {
protected:
	char* line;
	char** arr;
public:
	string type;
	char symbol;
	Figure(string type, char symbol) {
		this->symbol = symbol;
		if (type == "line") {
			this->type = type;
			this->line = new char[4];
			for (int i = 0; i < 4; i++) {
				this->line[i] = this->symbol;
			}
			delete[] arr;
		}
		// -------------------------------------------------------------------------------
		else if (type == "box") {
			this->type = type;
			this->arr = new char* [2];
			for (int i = 0; i < 2; i++) {
				this->arr[i] = new char[2];
				for (int j = 0; j < 2; j++) {
					this->arr[i][j] = symbol;
				}
			}
			delete[] line;
		}
		// -------------------------------------------------------------------------------
		else if (type == "tank") {
			this->type = type;
			this->arr = new char* [3];
			for (int i = 0; i < 3; i++) {
				this->arr[i] = new char[3];
				for (int j = 0; j < 3; j++) {
					this->arr[i][j] = ' ';
				}
			}
			this->arr[0][1] = this->symbol;
			this->arr[1][0] = this->symbol;
			this->arr[1][1] = this->symbol;
			this->arr[1][2] = this->symbol;
			this->arr[2][1] = this->symbol;
			delete[] line;
		}
		// -------------------------------------------------------------------------------
		else if (type == "udg") {
			this->type = type;
			this->arr = new char* [4];
			for (int i = 0; i < 4; i++) {
				this->arr[i] = new char[2];
				for (int j = 0; j < 2; j++) {
					this->arr[i][j] = ' ';
				}
			}

			this->arr[0][0] = this->symbol;
			this->arr[1][0] = this->symbol;
			this->arr[2][0] = this->symbol;
			this->arr[3][0] = this->symbol;
			this->arr[3][1] = this->symbol;
			delete[] line;
		}
		// -------------------------------------------------------------------------------
		else if (type == "lightning") {
			this->type = type;
			this->arr = new char* [3];
			for (int i = 0; i < 3; i++) {
				this->arr[i] = new char[2];
				for (int j = 0; j < 2; j++) {
					this->arr[i][j] = ' '; 
				}
			}
			this->arr[0][0] = this->symbol;
			this->arr[1][0] = this->symbol;
			this->arr[1][1] = this->symbol;
			this->arr[2][1] = this->symbol;
			delete[] line;
		}
		// -------------------------------------------------------------------------------

		else { this->type = "error"; }
	}
};
class Field {
public:
	char** array = new char* [10];
	Field() {
		for (int i = 0; i < 10; i++) {
			this->array[i] = new char[10];
			for (int j = 0; j < 10; j++) {
				this->array[i][j] = ' ';
			}
		}
	}
	void addFigure(Figure figure) {
		while (true) {
			int x = rand() % 10,
				y = rand() % 10;
			cout << endl << x << " " << y << endl;
			bool write = false;
			if (this->array[x][y] == ' ') {
				// -------------------------------------------------------------------------------
				if (figure.type == "udg") {
					if (x < 9 && y < 8) {
						for (int i = y; i < y + 3; i++) {
							if (this->array[i][x] == ' ' && this->array[y+2][x + 1] == ' ') {
								write = true;
							}
							else {
								write = false;
								break;
							}
						}
						if (write == true) {
							for (int i = y; i < y + 3; i++) {
								this->array[i][x] = figure.symbol;
							}
							this->array[y + 2][x + 1] = figure.symbol;
							break;
						}
						continue;
					}
				}
				// -------------------------------------------------------------------------------
				if (figure.type == "tank") {
					if (x < 9 && y < 9 && y >= 1) {
						for (int i = x; i < x + 3; i++) {
							if (this->array[y][i] == ' ' && this->array[y-1][x+1] == ' ') {
								write = true;
							}
							else {
								write = false;
								break;
							}
						}

						if (write == true) {
							for (int i = x; i < x + 3; i++) {
								this->array[y][i] = figure.symbol;
							}
							this->array[y - 1][x + 1] = figure.symbol;
							break;
						}
						continue;

					}
				}
				// -------------------------------------------------------------------------------
				if (figure.type == "box") {
					if (x < 9 && y < 9) {
						for (int j = x; j < x + 2; j++) {
							for (int i = x; i < x + 2; i++) {
								if (this->array[j][i] == ' ') {
									write = true;
								}
								else {
									write = false;
									break;
								}
							}
						}
						if (write == true) {
							for (int j = x; j < x + 2; j++) {
								for (int i = x; i < x + 2; i++) {
									this->array[j][i] = figure.symbol;
								}
							}
							break;
						}
						continue;
						
					}
				}
				// -------------------------------------------------------------------------------
				if (figure.type == "lightning") {
					if (x < 9 && y < 8) {
						for (int i = y; i < y + 3; i++) {
							if (this->array[i][x] == ' ' && this->array[y+1][x + 1] == ' ' && this->array[y + 2][x + 1] == ' ') {
								write = true;
							}
							else {
								write = false;
								break;
							}
						}
						if (write == true) {
							for (int i = y; i < y + 2; i++) {
								this->array[i][x] = figure.symbol;
							}
							this->array[y + 1][x + 1] = figure.symbol;
							this->array[y + 2][x + 1] = figure.symbol;
							break;
						}
						continue;
					}
				}
				// -------------------------------------------------------------------------------
				if (figure.type == "line") {
					if (x < 7) {
						for (int i = x; i < x + 4; i++) {
							if (this->array[y][i] == ' ') {
								write = true;
							}
							else {
								write = false;
								break;
							}
						}
						if (write == true) {
							for (int i = x; i < x + 4; i++) {
								this->array[y][i] = figure.symbol;
							}
							break;
						}
						continue;
					}
				}
				// -------------------------------------------------------------------------------
			}
		} 
	}
	void showField() {
		for (int i = 0; i < 30; i++) {
			cout << '-';
		}
		cout << endl;
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				cout << '|' << array[i][j] << '|';
			}
			cout << endl;
		}
		for (int i = 0; i < 30; i++) {
			cout << '-';
		}
	}
	void addChar(char symbol = '-', int x = 0, int y = 0, int iterator = 4, int start = 3) {
		for (int i = start; i < iterator + start; i++) {
			this->array[y][i] = symbol;
		}
	}
};

int main()
{
	srand(time(NULL));
	Field game;
	Figure first{ "lightning",'c' };
	game.showField();
	game.addFigure(first);
	cout << endl;
	game.showField();
}
