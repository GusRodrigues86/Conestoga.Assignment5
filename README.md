# PROG1781.Assignment5
## Goal
Create a C# console application that creates and records information about a book.

## Menu Display
1. Create a new book:
    - Provide the title of the book:
	- Provide the author of the book:
	- Provide the copyright year of the book:
	- Provide the number of pages of the book:
1. Display the details of an existing book:
	- Provide a book title to search:
	- Provide an author to search:
1. Edit an existing book:
	- Provide a book title to search:
	- Provide an author to search:
1. Exit the program:

### Validation
* All inputs must be validated.
    * In case of an invalid input, the user is prompted to re-enter the value until a valid value has been entered.
* "A" New book creation rules
	* Search if the book already exists in the record.
		* If a book has previously been created, the program displays "Book record already exists"
	* Store book in the library.
* "B" Book lookup rules
	* Search if the book already exists in the record.
		* No book found: "No book record exists".
		* Book found: Displays the book details.
* "C" Book lookup rules
	* Search if the book already exists in the record.
		* No book found: "No book record exists".
		* Book found: 
			* Displays the book details.
			* Prompt the user to enter new values for each field. 

## Book Class Requirements
Create a class that represents the Book using appropriate fields and methods.

* [x] Be defined in a separate file
* [x] Not have any public fields
* [x] Contain, at a minimum, two public methods with the following names:
    * [x] Display
    * [ ] Edit
* [x] Contain a non-default constructor that is used to initialize the book record information
* [x] Contain a default constructor (even if it is not used by your program)

## The Book Fields
1.	Title - required, non-empty string
1.	Author - required, non-empty string
1.	Copyright Year - required, integer between 1924 and 2019, inclusive
1.	Number of pages - required, positive integer

