# JSON Parser Solution
### JSON Parser Project
This project was created with the intent of completing a coding assessment for Opentext/Webroot.

This solution requires Visual Studio 2019 (Community edition is available from the MSDN website free of charge)

### JSON Parser Unit Test
This project has unit tests to test the JSON Parser project

### BlackBoxTesting
This is a project in the solution to represent how we could implement black box testing (not knowing anything about the inner workings of the code to test).

I don't actually implement the logic to parse the file itself and calculate what I think it should be as I already have in the JSON Parser Project.  I just hard coded the expected values for my two test files.  In a real life scenario I would actually implement said logic since I will most likely not be the developer of the code in test.

___

## **The Problem:**
Given a set of JSON objects (in a file is fine), for each unique ID field show the unique IPs associated with it and the number of times that IP appeared.  Also, sum the score for that ID.  Make no assumptions about the incoming JSON.

### **Example input:**

{"id":"test","score":12,"ip":"1.2.3.4","message":"Hi"}
{"id":"test","score":5,"ip":"1.2.3.5"}
{"id":"test","score":17,"ip":"1.2.3.4"}
{"id":"test2","score":9,"ip":"1.2.3.4"}

### **Example output:**

### test:
    1.2.3.5: 1
    1.2.3.4: 2
    score: 34

### test2:
    1.2.3.4: 1
    score: 9


## A few questions as I get started:
* Will the IP and score be provided in base 10 numbers [0-9]? (no hex, binary, etc.)
* Can score be any integer? Does it has a max/min?
* What IP format will be used for the input IPV4? Or can it be IPV6? Both? Are there other types of formats I need to be aware of?
* Should the application be able to handle invalid scores? Say if a string is passed in or non-numeric value?
* Invalid IP addresses? 
* I would probably throw an exception or log such a case as an error.  Will that suffice?
* Invalid JSON?
* Same as above, throw exception/log error
* Can I assume English will only be used in the JSON?

##Assumptions/Requirements
* Assuming 1 entry per line of source file: no more, no less

## Instructions:
* VS will be requried in order to open and run this solution correctly
* Once upon, you can set JSON Parser as your start up project and press F5 to start the console application
 * enter location of source JSON file (must be in format listed above)
