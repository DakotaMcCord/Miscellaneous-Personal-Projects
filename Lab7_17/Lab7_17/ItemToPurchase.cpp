#include <iostream>
using namespace std;

#include "ItemToPurchase.h"

// ItemToPurchase Func. Definitions.

ItemToPurchase::ItemToPurchase() {
    itemName = "none";
    itemPrice = 0;
    itemQuantity = 0;
}

// GET & SET Name Func.
void ItemToPurchase::SetName(string name) {
    this->itemName = name;
}
string ItemToPurchase::GetName() {
    return this->itemName;
}

// GET & SET Price Func.
void ItemToPurchase::SetPrice(int price) {
    this->itemPrice = price;
}
int ItemToPurchase::GetPrice() {
    return this->itemPrice;
}

// GET & SET Quantity Func.
void ItemToPurchase::SetQuantity(int quantity) {
    this->itemQuantity = quantity;
}
int ItemToPurchase::GetQuantity() {
    return this->itemQuantity;
}