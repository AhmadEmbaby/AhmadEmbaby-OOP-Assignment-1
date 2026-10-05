Note: I found these problems by myself and asked ChatGPT to reWrit it and orgnize it as a report in english.

# Critique

## 1 Fixed limits

The system uses fixed limits for customers products orders and order lines

If the system reaches one of these limits it cannot add more data even if more space is needed

This makes the system hard to grow

## 2 Global variables

The customers products and orders are stored in global variables

Any function can access and change this data directly

This can cause unexpected changes and makes it harder to control the state of the system

## 3 Data is spread across many arrays

The data of customers products and orders is stored in many separate arrays

For example order information is split between different arrays for the customer date payment and order lines

If the way an order is stored changes many functions may also need to be changed

## 4 Order line data is split

The product and quantity of an order line are stored in different arrays

The code needs to use the same indexes to know which quantity belongs to which product

This makes the code harder to follow and a mistake with the indexes can connect the wrong data together

## 5 Manual IDs

The user enters the Customer ID Product ID and Order ID

This can cause duplicate or invalid IDs and the system has to check them

The system should be responsible for generating the IDs

## 6 IDs and indexes are mixed

The system uses IDs to identify customers products and orders but uses indexes to access their data in the arrays

This adds extra steps and makes the code harder to understand

## 7 Menu choices use magic numbers

The menu uses numbers directly to represent different actions

For example the code checks values like 6 or 7

If the menu changes these numbers can become harder to understand and easier to use incorrectly

## 8 Business logic depends on the global storage

Many functions directly depend on the global arrays

If the storage structure changes many functions will need to be changed

This makes the code harder to maintain

## 9 Business rules are spread across functions

Rules such as checking stock checking payment and calculating the VIP discount are handled in different functions

When a business rule changes the developer may need to find and change it in several places

## 10 No real objects for the domain

Customer Product Order and OrderLine are not represented as real objects

Their data is separated between arrays and their behavior is handled by functions

This makes it harder to keep each object's data and behavior together

## 11 Shared data makes testing harder

The functions depend on the same global data

This makes it harder to test one part of the system without depending on the state created by other parts

## Main problem

The main problem is that the data and business logic are spread across the whole program

Because many functions depend directly on the same global arrays a change in the data structure can require changes in many different places

The system should use real Customer Product Order and OrderLine objects so each object can keep its own data and behavior together