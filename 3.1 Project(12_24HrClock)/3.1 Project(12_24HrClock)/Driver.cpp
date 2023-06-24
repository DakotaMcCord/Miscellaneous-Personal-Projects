#include <iostream>
#include <iomanip>
#include <string>
#include <thread>
using namespace std;

// Dakota McCord
// 3.1 Project - 12 and 24 hr clock
// Output clock -> tick clock forward -. get input from user to edit clock

// constants
const int
	MAXHOUR12 = 12,
	MAXHOUR24 = 23,
	MAXMINSEC = 59,
	RESET0 = 0,
	RESET1 = 1;
const string 
	HOURCLOCK_12 = "12-Hour Clock",
	HOURCLOCK_24 = "24-Hour Clock",
	CLOCKFACE_12 = "HH:MM:SS MER",
	CLOCKFACE_24 = "HH:MM:SS";
string userInput = ""; // user input
bool AmPm = true; // Meridiam
// Clock variables
int 
	Hours_12 = 12, 
	Hours_24 = 0, 
	Minutes = 59, 
	Seconds = 59;

// Function for Clear the Screen
void ClearScreen() {
	system ("CLS");
}
// Function for Loop Number
int LoopNum(int num, int MaxNum, int ResetToNum) {
	// num is the one to be looped
	// MaxNum is the largest number before loop
	// ResetToNum is the num to set to after loop
	if (num > MaxNum) {
		num = ResetToNum;
	}
	return num;
}
// add an Hour to the Clock

void AddHour() {
	// if next hour is 12 -> invert Meridiam
	if (Hours_12 == 11) {
		AmPm = !AmPm;
	}

	Hours_12 += 1; // add hour
	Hours_12 = LoopNum(Hours_12, MAXHOUR12, RESET1); // loop to 1 if over 12

	Hours_24 += 1; // add hour
	Hours_24 = LoopNum(Hours_24, MAXHOUR24, RESET0); // loop to 0 if over 23
}
// add min to clock
void AddMinute() {
	if (Minutes == 59) {
		AddHour(); // add hour
	}

	Minutes += 1; // add minute
	Minutes = LoopNum(Minutes, MAXMINSEC, RESET0); // loop to 0 if over 59
}
// add seconds to clock
void AddSecond() {
	if (Seconds == 59) {
		AddMinute();  // add min
	}

	Seconds += 1; // add second
	Seconds = LoopNum(Seconds, MAXMINSEC, RESET0); // loop to 0 if over 59
}

// Function for Get Input
void GetUserInput(string input) {
	// output based on user input
	if (input == "1") {
		AddHour();
	} else if (input == "2") {
		AddMinute();
	} else if (input == "3") {
		AddSecond();
	}
}

// Function for Convert num double digit
string ConvertTwoDigit(int num) {
	string output = to_string(num); // sout output to num
	if (num < 10) {
		output = "0" + to_string(num); // if num is greater than 10 -> set ouput to 0 + N 
																								//Ex: 01, 02, 03...
	}
	return output;
}
// Function for print clock
void PrintClock() {
	int LineLength = 29;
	int Buffer = 0;
	string ClockFace = "";
	string Meridiem;

	if (AmPm) {
		Meridiem = "A M";
	} else {
		Meridiem = "P M";
	}

	// first line
	cout << setw(LineLength) << setfill('*') << ""; // Linebreak (Top of 12hr clock)
	cout << setw(5) << setfill(' ') << ""; // midline buffer
	cout << setw(LineLength) << setfill('*') << ""; // Linebreak (Top of 24hr clock)
	cout << endl; // break to next line

	// second line
			// 12hr clock
	Buffer = (LineLength - HOURCLOCK_12.length()) / 2; // format buffer for 12hr clock
	cout << "*"; // start clock line
	cout << right << setw(LineLength - Buffer - 1) << setfill(' '); // fill left side with buffer
	cout << HOURCLOCK_12;  // print clock header
	cout << right << setw(Buffer) << setfill(' '); // fill right side with buffer
	cout << "*"; // end clock line

	cout << setw(5) << setfill(' ') << ""; // midline buffer
	
				// 24hr clock
	Buffer = (LineLength - HOURCLOCK_24.length()) / 2; // format buffer for 12hr clock
	cout << "*"; // start clock line
	cout << right << setw(LineLength - Buffer - 1) << setfill(' '); // fill left side with buffer
	cout << HOURCLOCK_24;  // print clock header
	cout << right << setw(Buffer) << setfill(' '); // fill right side with buffer
	cout << "*"; // end clock line
	cout << endl; // break to next line

	// third line
			// 12hr clock
	// Set ClockFace
	ClockFace = CLOCKFACE_12;		// Set ClockFace to const for alteration
	ClockFace.replace(
		ClockFace.find("HH"),				// find index of HH
		2,												// length of HH is 2
		ConvertTwoDigit(Hours_12));  // replace HH with Hours Rounded
	ClockFace.replace(
		ClockFace.find("MM"),				// find index of MM
		2,												// length of HH is 2
		ConvertTwoDigit(Minutes));  // replace HH with Minutes Rounded
	ClockFace.replace(
		ClockFace.find("SS"),				// find index of SS
		2,												// length of HH is 2
		ConvertTwoDigit(Seconds));  // replace HH with Seconds Rounded
	ClockFace.replace(
		ClockFace.find("MER"),			// find index of MER
		3,												// length of MER is 3
		Meridiem);								// replace MER with Meridiam

	// print ClockFace
	Buffer = (LineLength - ClockFace.length()) / 2; // format buffer for 12hr clock
	cout << "*"; // start clock line
	cout << right << setw(LineLength - Buffer - 1) << setfill(' '); // fill left side with buffer
	cout << ClockFace;  // print clock header
	cout << right << setw(Buffer) << setfill(' '); // fill right side with buffer
	cout << "*"; // end clock line

	cout << setw(5) << setfill(' ') << ""; // midline buffer

	// 24hr clock
		// Set ClockFace
	ClockFace = CLOCKFACE_24;		// Set ClockFace to const for alteration
	ClockFace.replace(
		ClockFace.find("HH"),				// find index of HH
		2,												// length of HH is 2
		ConvertTwoDigit(Hours_24));  // replace HH with Hours Rounded
	ClockFace.replace(
		ClockFace.find("MM"),				// find index of MM
		2,												// length of HH is 2
		ConvertTwoDigit(Minutes));  // replace HH with Minutes Rounded
	ClockFace.replace(
		ClockFace.find("SS"),				// find index of SS
		2,												// length of HH is 2
		ConvertTwoDigit(Seconds));  // replace HH with Seconds Rounded

	// print ClockFace
	Buffer = (LineLength - ClockFace.length()) / 2; // format buffer for 12hr clock
	cout << "*"; // start clock line
	cout << right << setw(LineLength - Buffer - 1) << setfill(' '); // fill left side with buffer
	cout << ClockFace;  // print clock header
	cout << right << setw(Buffer) << setfill(' '); // fill right side with buffer
	cout << "*"; // end clock line
	cout << endl; // break to next line

	// fourth line
	cout << setw(LineLength) << setfill('*') << ""; // Linebreak (bottom of 12hr clock)
	cout << setw(5) << setfill(' ') << ""; // midline buffer
	cout << setw(LineLength) << setfill('*') << ""; // Linebreak (bottom of 24hr clock)
	cout << endl; // break to next line
}
// Function for print menu
void PrintMenu() {
	int LineLength = 29;
	int Buffer = 0;
	string PrintText = "";

	// first line
	cout << setw(LineLength) << setfill('*') << "" << endl; // Linebreak (Top menu)

	// second line
			// option 1
	PrintText = " 1 - Add One Hour";
	Buffer = (LineLength - PrintText.length()) / 2; // format buffer for option line
	cout << "*"; // start clock line
	cout << left << setw(LineLength - 2) << setfill(' '); // fill right side with buffer
	cout << PrintText;  // print clock header
	cout << "*"; // end clock line
	cout << endl; // break to next line

	// third line
			// option 2
	PrintText = " 2 - Add One Minute";
	Buffer = (LineLength - PrintText.length()) / 2; // format buffer for option line
	cout << "*"; // start clock line
	cout << left << setw(LineLength - 2) << setfill(' '); // fill right side with buffer
	cout << PrintText;  // print clock header
	cout << "*"; // end clock line
	cout << endl; // break to next line
	
	// fourth line
			// option 3
	PrintText = " 3 - Add One Second";
	Buffer = (LineLength - PrintText.length()) / 2; // format buffer for option line
	cout << "*"; // start clock line
	cout << left << setw(LineLength - 2) << setfill(' '); // fill right side with buffer
	cout << PrintText;  // print clock header
	cout << "*"; // end clock line
	cout << endl; // break to next line
	
	// fifth line
			// option 4
	PrintText = " 4 - Exit Program";
	Buffer = (LineLength - PrintText.length()) / 2; // format buffer for option line
	cout << "*"; // start clock line
	cout << left << setw(LineLength - 2) << setfill(' '); // fill right side with buffer
	cout << PrintText;  // print clock header
	cout << "*"; // end clock line
	cout << endl; // break to next line

	// sixth line
	cout << setw(LineLength) << setfill('*') << "" << endl; // Linebreak (bottom menu)
}
bool KeepTicking = true; // keep thread going until false
void TickClock() {
	while (KeepTicking) {
		AddSecond(); // add a second

		std::this_thread::sleep_for(std::chrono::seconds(1)); // wait a second

		ClearScreen();  // Clear screen
		PrintClock(); // print clock
		PrintMenu(); // print menu
	}
}
// driver Main()
int main() {
	Hours_12 = 12; // Not sure how to import current hour
	Minutes = (time(0) / 60) % 60; // set minutes
	Seconds = (time(0)) % 60; // set Seconds
	AmPm = true; // edit meridiam based on time

	thread clock(TickClock); // Tick every Second

	while (true) {
		ClearScreen();  // Clear screen
		PrintClock(); // print clock
		PrintMenu(); // print menu

		cin >> userInput; // recieve input from user
		if (userInput == "4") {
			break; // exit app
		}
		
		GetUserInput(userInput); // do actions based on input
	}

	// end clock
	KeepTicking = false;
	clock.join();
}