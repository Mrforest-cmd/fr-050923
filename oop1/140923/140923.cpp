#include <iostream>
#include <stdlib.h>
#include <string>

using namespace std;

class Image {
private:
	unsigned short int width;
	unsigned short int height;
	string name;
	string extension;
	unsigned short int imageWeightInByte;

public:
	string format;
	string comment;
	string tags[100];
	unsigned short int rating;

	Image(unsigned short int inputWidth = 1000, unsigned short int inputHeight = 1000) {
		width = inputWidth;
		height = inputHeight;
		format = "";
		comment = "";
		tags;
		extension = ".jpg";
		name = "Image_01" + extension;
		rating = 0;
		imageWeightInByte = width * height * 3;
	}
	//GETTER
	unsigned short int getWidth() { return width; }

	string getImageWeightInByte() {
		float number = imageWeightInByte;
		int stage = 0;
		if (number > 1000 && number < 1000000 && number < 1000000000) {
			stage = 1;
			number = number / 1000;
		}
		else if (number > 1000000 && number < 1000000000) {
			stage = 2;
			number = number / 1000000;
		}
		else if (number > 1000000000) {
			stage = 3;
			number = number / 1000000000;
		}

		string new_weight = to_string(number);
		switch (stage) {
		case 1:
			new_weight += "KB";
		case 2:
			new_weight += "MB";
		case 3:
			new_weight += "GB";
		}
		return new_weight;
	}
	string getName() { return name; }
	//SETTER
	void setWidth(unsigned short int inputWidth) { if (inputWidth > 500 && inputWidth < 10000) { width = inputWidth; } }
	void setName(string line) {
		bool digitinside = false;
		for (int i = 0; i < line.length(); i++) {
			if (isdigit(name[i])) {
				digitinside = true;
				break;
			}
		}
		if (not digitinside) {
			name = line;
		}
	}
	void setExtansion(string ext) {
		bool extensioncheck = false;
		string extensions[3] = {".png", ".jpg", ".tiff"};
		for (int i = 0; i < 3; i++) {
			if (ext == extensions[i]) {
				for (int b = 0; b < extensions[i].length(); b++) {
					if (isupper(extensions[i][b])) {
						char upper = extensions[i][b];
						extensions[i][b] = upper + 32;
					}
				}
				extension = ext;
			}
		}
		
	}



};



int main()
{
	Image first{ 640, 1280 };
	string weight = first.getImageWeightInByte();
	cout << weight;
	
}