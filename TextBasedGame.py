# Dakota McCord
# 7.3 Project Two Submission
# get user input -> move between rooms and get items in a game

# The dictionary links a room to other rooms.
rooms = {
        'Red Gem Room': {'South': 'Blue Gem Room', 'item': 'Red Gem'},
        'Orange Gem Room': {'West': 'Indigo Gem Room', 'item': 'Orange Gem'},
        'Yellow Gem Room': {'North': 'Violet Gem Room', 'South': 'Tumble Room', 'item': 'Yellow Gem'},
        'Green Gem Room': {'West': 'Violet Gem Room', 'item': 'Green Gem'},
        'Blue Gem Room': {'North': 'Red Gem Room', 'West': 'Tumble Room', 'item': 'Blue Gem'},
        'Indigo Gem Room': {'East': 'Orange Gem Room', 'North': 'Tumble Room', 'item': 'Indigo Gem'},
        'Violet Gem Room': {'South': 'Yellow Gem Room', 'East': 'Green Gem Room', 'item': 'Violet Gem'},
        'Tumble Room': {'North': 'Yellow Gem Room', 'East': 'Blue Gem Room',
                        'South': 'Indigo Gem Room', 'West': 'Pedestal Room'},
        'Pedestal Room': {'East': 'Tumble Room'}
    }

# instance values
current_room = 'Tumble Room'
user_inventory = []

# prompts for user
key_exit = 'exit'
key_goto_location = 'go'
key_take_item = 'take'
key_item = 'item'
break_bar = '-' * 50
valid_inputs = \
    '  "GO {direction}": moves location\n' \
    '  "TAKE {item}": takes an item from room'


def display_location():   # Display location, directions and inventory
    room_directions = ''
    room_item = ''
    if key_item in rooms[current_room].keys():
        room_item = f'\nYou See a {rooms[current_room][key_item]}'
    for direction in rooms[current_room].keys():
        if direction != key_item:
            room_directions += f'{direction}, '
    return f'Inventory: {user_inventory}\n' \
           f'You are in the {current_room}\n' \
           f'You can go: {room_directions}'.strip(f', ') + \
           f'{room_item}'


def invalid_input(input_str):   # invalid input message
    return f'{input_str} is not a valid action\n' \
           f'\nValid Actions:\n' \
           f'{valid_inputs}'

# main functions Below


def move_rooms(direction):   # move rooms
    output = ''   # temp string for printing
    # pull globals for alteration
    global current_room

    # Check direction is valid -> change rooms
        # Check if room is boss room
            # execute win or lose conditions depending on inventory
    # Check direction is exit -> close game
    # else display invalid direction
    if direction in rooms[current_room]:
        current_room = rooms[current_room][direction]
        output = f'\nYou head {direction}'
        # print win or lose if in pedestal room
        if current_room == 'Pedestal Room':
            output += f'\nYou enter the {current_room} and...'
            if len(user_inventory) > 6:
                print(f'{output}\n\n'
                      f'The shadows are kept at bay while you exit!\n'
                      f'You Win!!')
            else:
                print(f'{output}\n\n'
                      f'You are Consumed by shadows!!\n'
                      f'You Lose.')
            # wai for user to acknowledge win/loss -> exit
            input('\npress <enter> to continue')
            exit()
    else:
        output = f'\nYou can not go {direction} from here.'
    return output


def take_item(item):   # take item from room
    # import globals for alteration
    global user_inventory
    global rooms
    # remove item from room -> add to player inventory
    # print item taken or not taken to user
    if key_item in rooms[current_room] and \
            item.lower() == rooms[current_room][key_item].lower():
        user_inventory.append(item)
        rooms[current_room].pop(key_item)
        output = f'You take the {item}'
    else:
        output = f'You do not see a {item} here.'
    return output


# display valid inputs and format
print(valid_inputs)
print(break_bar)
while True:   # This is The Main Game Loop
    # Display Location
    print(display_location())
    # get input from user -> split input into 2 parts and format
        # get string up to first space
        # set new input to be list[string to first space, everything after first space]
        # format list[0] to lowercase
        # format list[1] to titled
    user_input = input()
    new_input = user_input.find(' ')
    new_input = [user_input[0:new_input].lower(), user_input[new_input + 1:].title()]

    # Check input has keyword 'GO' ->  Call move_rooms
    # Check input has keyword 'TAKE' -> Call take_item
    # else print invalid input message
    if new_input[0] == key_goto_location or user_input.lower() == key_exit:
        print(move_rooms(new_input[1]))
    elif new_input[0] == key_take_item:
        print(take_item(new_input[1]))
    else:
        # print invalid input message
        print(invalid_input(user_input))
    # format w/ break line
    print(break_bar)
