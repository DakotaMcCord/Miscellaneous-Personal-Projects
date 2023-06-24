#ifndef ITEM_TO_PURCHASE_H
#define ITEM_TO_PURCHASE_H

#include <string>
using namespace std;

// ItemToPurchase Class Definition

class ItemToPurchase {
    public:
        ItemToPurchase();                    // Default Constructor
        
        void SetName(string name);      // SET Func. for itemName
        string GetName();                     // GET Func. for itemName
        
        void SetPrice(int price);           // SET Func. for itemPrice
        int GetPrice();                          // GET Func. for itemPrice
        
        void SetQuantity(int quantity); // SET Func. for itemQuantity
        int GetQuantity();                    // GET Func. for itemQuantity

    private:
            string itemName;   // Initialized in default constructor to "none"
            int itemPrice;        // Initialized in default constructor to 0
            int itemQuantity;  // Initialized in default constructor to 0
};

#endif