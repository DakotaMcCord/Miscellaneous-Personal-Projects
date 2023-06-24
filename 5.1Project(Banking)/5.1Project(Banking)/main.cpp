#include <iostream>
#include <string>
#include <iomanip> 
#include <vector>
#include <numeric>
using namespace std;

// Dakota McCord
// Project 5.1 - Banking
// get input from user -> display balance and enterest at end of year across a number of years

// get ballance func.
double GetBallance(double initDeposit, double anualInterest, int timeInYears, double monthlyDeposit) {
	// this function does the math for total end of year ballance -> returns total

	double newTotal = initDeposit;
	for (int i = 0; i < (timeInYears * 12); ++i) {
		newTotal = (newTotal + monthlyDeposit) + (((newTotal + monthlyDeposit) * (anualInterest / 100)) / 12);
	}
	return newTotal;
}

// get input func.
void GetInput(double& initialDeposit, double& monthlyDeposit, double& annualInterest, int& numberOfYears) {
	// prompt and get initial deposite
	cout << "Initial Investment: ";
	cin >> initialDeposit;

	// prompt and get monthy deposite
	cout << "Monthly Deposite: ";
	cin >> monthlyDeposit;

	// prompt and get annual interest
	cout << "Annual Interest (as percent): ";
	cin >> annualInterest;

	// prompt and get span of years
	cout << "Number of years: ";
	cin >> numberOfYears;

	// prompt enter for contunue
	cout << "Press <ENTER> to continue." << endl;
	cin.ignore();
	cin.get();
}

// print func.
void PrintLedger(double initialDeposit, double monthlyDeposit, double annualInterest, int numberOfYears) {
	double
		accruedInterest = 0, // cal. total accrued interest
		accruedTotal = 0; // calc. total ballance

	cout << "Year | Balance | Interest | Total" << endl; // sheet header
	for (int i = 0; i < numberOfYears; ++i) {
		// for each year:
		accruedTotal = GetBallance(initialDeposit, annualInterest, i + 1, monthlyDeposit); // calc. ballance
		accruedInterest = accruedTotal * (annualInterest / 100); // calc. interest

		cout << fixed << setprecision(2); // formatting
		cout << i + 1 << " | " << accruedTotal << " | " << accruedInterest << endl; // print each line of sheet
	}
	cout << endl;
}

int main() {
	// program var.
	double
		initialDeposit,
		monthlyDeposit,
		annualInterest;
	int numberOfYears;

	bool running = true; // check if app running

	while (running) { // while running
		GetInput(initialDeposit, monthlyDeposit, annualInterest, numberOfYears); // get input rom user

		// display Table (No monthy deposite)
		cout << "Balance and Interest (No Deposites)" << endl;
		PrintLedger(initialDeposit, 0, annualInterest, numberOfYears);

		// display table (with monthly deposite)
		cout << "Balance and Interest (With Deposites)" << endl;
		PrintLedger(initialDeposit, monthlyDeposit, annualInterest, numberOfYears);

		// chec exit
		string input = ""; // set input to empty
		while (running) {
			// prompt user
			cout << endl << "Would you like to exit? (Y/N)" << endl;
			if (input == "y" || input == "Y") { // f yes -> set running false -> exit
				running = false;
				break;
			}
			else if (input == "n" || input == "N") { // if no -> clear tables -> break check
				system("CLS");
				break;
			}
			// else -> get more input for valid answer
			getline(cin, input);
		}
	}

	return 0;
}