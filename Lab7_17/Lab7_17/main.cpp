#include <iostream>
using namespace std;

#include "ItemToPurchase.h"

// Dakota McCord
// LAB: 7.17.1 - Warm up, Online shopping cart (Part 1)
// get items from user -> output cost totals


// Prompt for First Item Func.
void PromptFirstItem(ItemToPurchase& item, string userInputStr, int userInputInt) {
	// Get firstItem form user
	cout << "Item 1" << endl;   // print section form firstItem

	cout << "Enter the items name: ";	 // prompt user for itemName
	getline(cin, userInputStr);			 // get firstItem name from user
	item.SetName(userInputStr);         // set firstItem Name as user specified

	cout << "Enter the items price: ";     // promt user for itemPrice
	cin >> userInputInt;						 // get firstItem price from user
	item.SetPrice(userInputInt);          // set firstItem price as user specified

	cout << "Enter the items quantity: ";// promt user for itemQuantity
	cin >> userInputInt;						 // get firstItem quantity from user
	item.SetQuantity(userInputInt);    // set firstItem quantity as user specified

	cin.ignore();
}
// Prompt for Second Item Func.
void PromptSecondItem(ItemToPurchase& item, string userInputStr, int userInputInt) {
	// Get firstItem form user
	cout << "Item 2" << endl;   // print section form firstItem

	cout << "Enter the items name: ";	 // prompt user for itemName
	getline(cin, userInputStr);			 // get secondItem name from user
	item.SetName(userInputStr);         // set secondItem Name as user specified

	cout << "Enter the items price: ";     // promt user for itemPrice
	cin >> userInputInt;						 // get secondItem price from user
	item.SetPrice(userInputInt);          // set secondItem price as user specified

	cout << "Enter the items quantity: ";// promt user for itemQuantity
	cin >> userInputInt;						 // get secondItem quantity from user
	item.SetQuantity(userInputInt);    // set secondItem quantity as user specified
}
// print totals Func.
void PrintTotal(ItemToPurchase firstItem, ItemToPurchase secondItem) {
	int
		firstTotal = 0,    // holder for firstTotal math
		secondTotal = 0; // holder for secondTotal math

	//print cost to user
	cout << "TOTAL COST" << endl;  // print cost Section to user

	firstTotal = firstItem.GetQuantity() * firstItem.GetPrice(); // do math for firstItem
	cout << firstItem.GetName() << ": " << firstItem.GetQuantity() << " @ $" << firstItem.GetPrice() << " = $";   // print formula
	cout << firstTotal << endl;   // print total for firstItem

	secondTotal = secondItem.GetQuantity() * secondItem.GetPrice(); // do math for secondItem
	cout << secondItem.GetName() << ": " << secondItem.GetQuantity() << " @ $" << secondItem.GetPrice() << " = $";   // print formula
	cout << secondTotal << endl;   // print total for secondItem
	cout << endl; // break Line

	cout << "Total: $" << firstTotal + secondTotal << endl; // print total for both items
}

// Program Driver
int main() {
	ItemToPurchase
		firstItem,		 // first item to be promted for
		secondItem;	 // second item to be promted for
	
	string userInputStr = "<N/A>";  // holder for user input (string)
	int userInputInt = -1;       // holder for user input (int)

	PromptFirstItem(firstItem, userInputStr, userInputInt);  // prompt and get firstItem from User
	cout << endl; // break line
	
	PromptSecondItem(secondItem, userInputStr, userInputInt);  // prompt and get secondItem from User
	cout << endl; // break line

	PrintTotal(firstItem, secondItem); // print totals for items 1 and 2
	cout << endl; // break line

	return 0;
}