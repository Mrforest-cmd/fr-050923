#include <iostream>
#include <math.h>

using namespace std;
// 1 1 2 5 8 13 21 ... 
// ТЗ: числа від 0
// => first , second
class Progression {
private:
	double dfirst;
	double dsecond;
	int ifirst;
	int isecond;
	bool isDouble;
public:
	Progression(double first, double second) {
		this->dfirst = first;
		this->dsecond = second;
		this->isDouble = true;
		delete& this->ifirst, & this->isecond;
	}
	Progression(int first, int second) {
		this->ifirst = first;
		this->isecond = second;
		this->isDouble = false;
		delete& this->dfirst, & this->dsecond;
	}
	unsigned long getNumberByOrdinal(unsigned int ordinal = 1) {
		if (this->isDouble) {
			double lfirst = dfirst;
			double lsecond = dsecond;
			if (ordinal == 1)
				return lfirst;
			if (ordinal == 2)
				return lsecond;
			for (int i = 3; i <= ordinal; i++) {
				double temp = lfirst + lsecond;
				lfirst = lsecond;
				lsecond = temp;
			}
			return lsecond;
		}
		else if (!isDouble) {
			int lfirst = ifirst;
			int lsecond = isecond;
			if (ordinal == 1)
				return lfirst;
			if (ordinal == 2)
				return lsecond;
			for (int i = 3; i <= ordinal; i++) {
				int temp = lfirst + lsecond;
				lfirst = lsecond;
				lsecond = temp;
			}
			return lsecond;
		}
			
	}
	
	
	
};

int main()
{
	Progression progression1 = { 1,1 };
	cout << progression1.getNumberByOrdinal(1) << endl;
	cout << progression1.getNumberByOrdinal(2) << endl;
	cout << progression1.getNumberByOrdinal(3) << endl;
	cout << progression1.getNumberByOrdinal(4) << endl;

}