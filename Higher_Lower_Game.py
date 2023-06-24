# Dakota McCord
# 4.3 Assignment - Pseudocode Revisited
# Lab 9.1.1 - Higher/Lower Game
# Play higher/lower game with user

import random   # import random for RNG

print('Welcome to the higher/lower game, Bella!')   # greet user
while True:   # do forever
    lower_bound = int(input('Enter the lower bound: '))   # Get lower bound in prompt
    upper_bound = int(input('Enter the upper bound: '))   # Get higher bound in prompt
    if lower_bound < upper_bound:   # check lower  bound is less than upper
        break   # exit While loop on true
    else:   # otherwise print error message
        print('The lower bound must be less than the upper bound.\n')
random_num = random.randint(lower_bound, upper_bound)
# ^^^ create and set a number between lower and true upper values
user_guess = int(input(f'\nGreat, now guess a number between {lower_bound} and {upper_bound}: '))
# ^^^ Get user guess in prompt
while True:   # do forever
    if user_guess == random_num:   # check user guess equivalent to random number
        print('You got it!')   # print win message
        exit()   # exit script
    if user_guess < random_num:   # check user guess less than random number
        print('Nope, too low.\n')   # print low message
    elif user_guess > random_num:   # check user guess greater than random number
        print('Nope, too high.\n')   # print high message
    user_guess = user_guess = int(input('Guess another number: '))  # get user guess in prompt

# edited version for Lab 9.1.1 - Higher/Lower Game
# import random  # import random for RNG

# seedVal = int(input("What seed should be used? "))
# random.seed(seedVal)

# # Dakota McCord
# # 4.3 Assignment - Pseudocode Revisited
# # Lab 9.1.1 - Higher/Lower Game
# # Play higher/lower game with user

# # print('Welcome to the higher/lower game, Bella!')   # greet user
# while True:  # do forever
    #     lower_bound = int(input('What is the lower bound?'))  # Get lower bound in prompt
    #     upper_bound = int(input('What is the upper bound?'))  # Get higher bound in prompt
    #     if lower_bound < upper_bound:  # check lower  bound is less than upper
    #         break  # exit While loop on true
    #     else:  # otherwise print error message
#         print('Lower bound must be less than upper bound.')
# random_num = random.randint(lower_bound, upper_bound)
# # ^^^ create and set a number between lower and true upper values
# user_guess = int(input('What is your guess? '))
# # ^^^ Get user guess in prompt
# while True:  # do forever
    #     if user_guess == random_num:  # check user guess equivalent to random number
    #         print('You got it!')  # print win message
    #         exit()  # exit script
    #     if user_guess < random_num:  # check user guess less than random number
    #         print('Nope, too low.\n')  # print low message
    #     elif user_guess > random_num:  # check user guess greater than random number
    #         print('Nope, too high.\n')  # print high message
#     user_guess = user_guess = int(input('What is your guess? '))  # get user guess in prompt

