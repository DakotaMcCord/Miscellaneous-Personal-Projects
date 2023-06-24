import re
import string

list_of_items = {} # dict. for items -> Item : Frequency

# LoadList Func. -> populate dict. from File
def LoadList():
    with open("CS210_Project_Three_Input_File.txt") as file: # open file -> close file whan finished
         for line in file.readlines(): # read each line in file
             line = line.strip("\n") # remove newline from read line
             
             if line not in list_of_items: # item not in dict
                 list_of_items[line] = 1 # add item to dict. -> initialize frequency to 1
             else: # item already in dict.
                list_of_items[line] += 1 # add 1 to frequency

# PrintList Func. -> dsplay items to user
def PrintList():
    LoadList(); #load list func. Call -> load list from file
    print("Items in purchase history:\n") # display to user

    for item in list_of_items: # get each item from dict.
        print(item + ": " + str(list_of_items.get(item))) # ouptu "Item: Frequency" to iser
    print("\n") # format newline

# lookup Frequency func. -> get frequency of specified item
def LookupFrequency(lookup):
    LoadList(); #load list func. Call -> load list from file
    output = 0 # initialize ouptu to 0

    for item in list_of_items: # get each item from dict.
        if item.lower() == lookup.lower(): # check if item found in dict. -> lowercase to prevent syntax error: A != a
            output = list_of_items.get(item) # item found -> set outpur
    return output # return frequency of item

# create file func. -> creat ot update frequency file
def CreateFrequencyFile():
    LoadList() #load list func. Call -> load list from file
    newFile = open("frequency.dat", "w") #Create or open file

    for item in list_of_items: # get each item from dict.
        newFile.write("{} {}\n".format(item, list_of_items.get(item))) # write "Item: Frequency" to file

    newFile.close(); # close file