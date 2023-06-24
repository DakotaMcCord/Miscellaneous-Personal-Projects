#include <Python.h>
#include <iostream>
#include <Windows.h>
#include <cmath>
#include <string>

using namespace std;

// Dakota McCord
// 6.3 Assignment - Integrating Languages
// prompt user for input -> multiply or double a number

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

// Break Func. -> have user "enter" to continue
void BreakPointConfirm() {
	cout << "Press <ENTER> to Continue." << endl; // prompt
	cin.ignore(); // clear buff
	cin.get(); // get enter key
}

// Display Func. -> show menu -> prompt input
void DisplayMainMenu() {
	cout << "1: Display a Multiplication Table" << endl;
	cout << "2: Double a Value" << endl;
	cout << "3: Exit" << endl;
	cout << "Enter your selection as a number 1, 2, or 3." << endl;
}
// check number func. -> check user input -> verify is number
void CheckIsNumber(string& userInput) {
	bool checking = true; // set true -> while true: verify input

	// verify input
	while (checking) {
		system("CLS"); // clear screen
		cout << "Enter a number." << endl; // prompt user

		cout << "Input: "; // prompt user
		cin >> userInput; // get user input

		// check each char in userInput
		for (int i = 0; i < userInput.size(); ++i) {
			// check if first char is '-' denoting negative number
				// otherwise if not a number -> return error
			if (!isdigit(userInput[i]) && (i != 0 && userInput[0] != '-')) {
				cout << endl << "ERR: Input must be a whole number." << endl; // print error msg
				BreakPointConfirm(); // call break point confirm
				break; // exit loop
			} else if (i == userInput.size() - 1) { // if end if input & no errors found -> exit checker
				checking = false;
			}
		}
	}
}
// multiplication Table Func. -> get number -> print table
void MultiplicationTable(string& userInput) {
	CheckIsNumber(userInput); // get input as number

	cout << endl << "Multiplying " << userInput << " up to 10: " << endl << endl; // display prompt
	callIntFunc("MultiplicationTable", stoi(userInput)); // call python func. -> print table
	cout << endl; // format

	BreakPointConfirm(); // call break point confirm

	userInput = ""; // reset input
}
// mdouble value func. -> get number -> print number doubled
void DoubleValue(string& userInput) {
	CheckIsNumber(userInput);  // get input as number

	cout << endl; // format
	callIntFunc("DoubleValue", stoi(userInput)); // call python func -> double value
	cout << endl; // format

	BreakPointConfirm();  // call break point confirm

	userInput = ""; // reset input
}

// Main Driver Func.
void main() {
	bool Running = true; // set true -> while running -> continue program
	string userInput = ""; // declar and initialize input as empty
	
	// while running
	do {
		system("CLS"); // clear screen
		DisplayMainMenu(); // display menu

		cout << "Input: "; // prompt input
		cin >> userInput; // get input

		// check input is "1"
		if (userInput == "1") {
			MultiplicationTable(userInput); // call Multipy func.
		}
		// check is "2"
		else if (userInput == "2") {
			DoubleValue(userInput); // call double func.
		}
		// check is "3"
		else if (userInput == "3") {
			cout << endl << "Exiting Application." << endl; // notify user of exit
			Running = false; // set running to false
			BreakPointConfirm(); // call break point confirm
		}
		// if not selected above
		else {
			cout << endl << "Entry must be one of the above values. (1, 2, or 3)" << endl; // dislay error
			BreakPointConfirm(); // break point confirm
		}

	} while (Running); // continue while true
}
