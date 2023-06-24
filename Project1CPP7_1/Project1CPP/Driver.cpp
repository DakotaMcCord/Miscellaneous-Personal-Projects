#include <Python.h>
#include <iostream>
#include <fstream>
#include <Windows.h>
#include <cmath>
#include <string>
#include <iomanip>

using namespace std;

// Dakota McCord
// 7.1 Project
// get option from user -> use python to perform action

// CallProcedure Func. provided
/*
Description: - To call this function, simply pass the function name in Python that you wish to call.
Example: - callProcedure("printsomething");
Output: - Python will print on the screen: Hello from python!
Return: - None
*/
void CallProcedure(string pName) {
	char* procname = new char[pName.length() + 1];
	std::strcpy(procname, pName.c_str());

	Py_Initialize();
	PyObject* my_module = PyImport_ImportModule("PythonCode");
	PyErr_Print();
	PyObject* my_function = PyObject_GetAttrString(my_module, procname);
	PyObject* my_result = PyObject_CallObject(my_function, NULL);
	Py_Finalize();

	delete[] procname;
}

// callIntFunc Func. provided
/*
Description: - To call this function, pass the name of the Python functino you wish to call and the string parameter you want to send
Example: - int x = callIntFunc("PrintMe","Test");
Output: - Python will print on the screen: - You sent me: Test
Return: - 100 is returned to the C++
*/
int callIntFunc(string proc, string param) {
	char* procname = new char[proc.length() + 1];
	std::strcpy(procname, proc.c_str());

	char* paramval = new char[param.length() + 1];
	std::strcpy(paramval, param.c_str());


	PyObject* pName, * pModule, * pDict, * pFunc, * pValue = nullptr, * presult = nullptr;

	// Initialize the Python Interpreter
	Py_Initialize();

	// Build the name object
	pName = PyUnicode_FromString((char*) "PythonCode");

	// Load the module object
	pModule = PyImport_Import(pName);

	// pDict is a borrowed reference 
	pDict = PyModule_GetDict(pModule);

	// pFunc is also a borrowed reference 
	pFunc = PyDict_GetItemString(pDict, procname);
	if (PyCallable_Check(pFunc)) {
		pValue = Py_BuildValue("(z)", paramval);
		PyErr_Print();
		presult = PyObject_CallObject(pFunc, pValue);
		PyErr_Print();
	} else {
		PyErr_Print();
	}

	//printf("Result is %d\n", _PyLong_AsInt(presult));
	Py_DECREF(pValue);

	// Clean up
	Py_DECREF(pModule);
	Py_DECREF(pName);

	// Finish the Python Interpreter
	Py_Finalize();

	// clean 
	delete[] procname;
	delete[] paramval;


	return _PyLong_AsInt(presult);
}

// callIntFunc Func. provided
/*
Description: - To call this function, pass the name of the Python functino you wish to call and the string parameter you want to send
Example: - int x = callIntFunc("doublevalue",5);
Return: - 25 is returned to the C++
*/
int callIntFunc(string proc, int param) {
	char* procname = new char[proc.length() + 1];
	std::strcpy(procname, proc.c_str());

	PyObject* pName, * pModule, * pDict, * pFunc, * pValue = nullptr, * presult = nullptr;

	// Initialize the Python Interpreter
	Py_Initialize();

	// Build the name object
	pName = PyUnicode_FromString((char*) "PythonCode");

	// Load the module object
	pModule = PyImport_Import(pName);

	// pDict is a borrowed reference 
	pDict = PyModule_GetDict(pModule);

	// pFunc is also a borrowed reference 
	pFunc = PyDict_GetItemString(pDict, procname);
	if (PyCallable_Check(pFunc)) {
		pValue = Py_BuildValue("(i)", param);
		PyErr_Print();
		presult = PyObject_CallObject(pFunc, pValue);
		PyErr_Print();
	} else {
		PyErr_Print();
	}

	//printf("Result is %d\n", _PyLong_AsInt(presult));
	Py_DECREF(pValue);

	// Clean up
	Py_DECREF(pModule);
	Py_DECREF(pName);

	// Finish the Python Interpreter
	Py_Finalize();

	// clean 
	delete[] procname;

	return _PyLong_AsInt(presult);
}

// Display Func. -> show menu -> prompt input
void DisplayMainMenu() {
	cout << "1: List of purchases." << endl;
	cout << "2: Get frequency of an item." << endl;
	cout << "3: Create \"frequency.dat\" file and display histogram." << endl;
	cout << "4: Exit" << endl;
	cout << "Enter your selection as a number 1, 2, 3, or 4." << endl;
}

// Break Func. -> have user "enter" to continue
void BreakPointConfirm() {
	cout << "Press <ENTER> to Continue." << endl; // prompt
	cin.ignore(); // clear buff
	cin.get(); // get enter key
}

// print list Func. -> display items
void PrintList() {
	system("CLS"); // clear screen

	CallProcedure("PrintList"); // python Func. Call

	BreakPointConfirm(); // break point confirm
}
// GetFrequency Func. -> return Number of time an item is found
void GetFrequencyOfItem(string& userInput) {
	system("CLS"); // clear screen

	cout << "Enter an item for lookup: "; // prompt item for lookup
	cin >> userInput; // recieve item from user

	int Frequency = callIntFunc("LookupFrequency", userInput); // set frequency -> python func. call

	if (Frequency > 0) { // >0 -> item was found at least once
		cout << endl << "\"" << userInput << "\"" << " found in purchase history." << endl; // notifify user -> lookup found
		cout << "Frequency of " << "\"" << userInput << "\"" << " is: " << Frequency << endl << endl; // display frequency
	} else { // <0 -> item was not found
		cout << endl << "\"" << userInput << "\"" << " not found in purchase history." << endl << endl; // notify user -> lookup not found
	}

	userInput = ""; // reset input to null
	BreakPointConfirm(); // break point confirm
}
// CreatFile Func -> display histogram
void CreatAndDisplayHist(string& userInput) {
	system("CLS"); // clear screen
	CallProcedure("CreateFrequencyFile"); // call python func.

	cout << "Histogram read from \"frequency.dat\":" << endl << endl; // notify user

	ifstream inFile; // in-file sream var -> reads file
	inFile.open("frequency.dat"); // open file for reading
	while (!inFile.eof()) { // while not end of file
		getline(inFile, userInput); // get read line as input
		int Index = userInput.find(" "); // find first " " for spliting at index
			// ^^ returns -1 if " " not found

		if (Index >= 0) { // " " was found for split
			cout << left << setfill(' ') << setw(15); // format ledt align -> 15 char limit -> fill with " "
			cout << userInput.substr(0, Index + 1); // output item -> up to split(index)
			userInput = userInput.replace(0, Index + 1, ""); // remove substr from input -> leaves frequency as input

			Index = stoi(userInput); // set index to frequency of item as int
			// print * "frequency" number of times
			for (int i = 0; i < Index; ++i) {
				cout << "*";
			}
			cout << endl; // endline format
		}
	}

	inFile.close(); // close file

	userInput = ""; // set input to null
	cout << endl; // endline format
	BreakPointConfirm();  // break point confirm 
}

// Driver
void main() {
	bool Running = true;  // set true -> while running -> continue program
	string userInput = ""; // declar and initialize input as empty

	// while running
	do {
		system("CLS"); // clear screen
		DisplayMainMenu(); // display menu

		cout << "Input: "; // prompt input
		cin >> userInput; // get input

		// check input is "1"
		if (userInput == "1") {
			PrintList(); // print list func. Call
		}
		// check input is "2"
		else if (userInput == "2") {
			GetFrequencyOfItem(userInput); // Get Frequenct Func. Call -> pass input
		}
		// check input is "3"
		else if (userInput == "3") {
			CreatAndDisplayHist(userInput); // Creat File Func Call. -> pass input
		}
		// check input is "4"
		else if (userInput == "4") {
			cout << endl << "Exiting Application." << endl; // notify user of exit
			Running = false; // set running to false
			BreakPointConfirm(); // call break point confirm
		}
		// if not selected above
		else {
			cout << endl << "Entry must be one of the above values. (1, 2, 3,  or 4)" << endl; // dislay error
			BreakPointConfirm(); // break point confirm
		}
	} while (Running); // continue while true
}