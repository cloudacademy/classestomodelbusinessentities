# Using Classes to Model Business Entities Coding Challenge
In this challenge, there is no step-by-step guide and no hints. However, if you get really stuck, the full solution is located in the ModelSolutionIfYouNeedIt.Code project. 

The challenge tasks you to restructure an existing application that is based around the members of a library. As it stands, the application caters for two kinds of library member, junior and adult. Junior members are under 16 years of age. Adult members are allowed to borrow any book from the library, whilst junior members can only borrow books from the Child category. In its current state, the LendingLibrary project has a single class called ‘Member’ that contains Borrow, PayFine, and NewFine methods, each of which contains logic that distinguishes between junior and adult members, wherever it is appropriate.

The Visual Studio solution has a console app project called ‘LendingLibraryUI’ and a unit test project called ‘LendingLibraryTests’. Both projects contain similar logic that tests the LendingLibrary project’s underlying functionality with two members called ‘greta’ (a junior member) and ‘donald’ (an adult member).

Your job is to reengineer the logic so that the Member class becomes an abstract base class where the Borrow, PayFine, and NewFine methods are declared as abstract; and create two specialised classes called ‘JuniorMember’ and ‘AdultMember’, that inherit from the Member class and implement all of the abstract methods.

If you do this correctly, almost no code will need to be altered in the LendingLibraryUI or LendingLibraryTests projects. Except for the following line which appears in both projects:

```
expectedBalance = Member.ChildOutstandingFineLimit;
```

It would make sense to put the ChildOutstandingBalance property in the specialised JuniorMember class, given only child members have an upper limit on any fines they may need to pay. It would also make sense to rename the property to be ‘OutstandingFineLimit’ (dropping the word ‘Child’).

# Tasks
1. Expand the LendingLibrary.Code project so you can see the folders and files within. 

2. Locate the 01 Without Inheritance folder and open the Member class (located in Member1.cs) in the editor.

3. Take a good look at the logic in this class because it’s this code that will need to be reengineered, especially the Borrow, PayFine, and NewFine methods because it’s the code in these that needs to be split into the JuniorMember and AdultMember classes.

4. Run the LendingLibraryUI and/or the LendingLibraryTests projects and ensure the logic works as expected.

5. Locate the 02 With Inheritance folder and note the three empty classes AdultMember, JuniorMember and Member (located in Member2.cs). All the class logic in Member2.cs has been commented out because you can’t have two classes called ‘Member’. At some point you are going to need to comment out all the code in Member1.cs and create an abstract, adapted version of the class in Member2.cs.

6. You now need to:

-  Copy all the code in the Member class of Member1.cs into Member2.cs, making sure the new version of the class is declared as abstract
-  Rework the logic so the Borrow, PayFine, and NewFine methods are declared as abstract
-  Comment out the code in Member1.cs
- Add code to the AdultMember and JuniorMember classes such that they inherit from Member and implement whatever is necessary
-  add appropriate code to the Borrow, PayFine, and NewFine methods in both the AdultMember and JuniorMember classes
-  Make sure the JuniorMember class has an OutstandingFineLimit property
-  Adjust the logic in the LendingLibraryUI and LendingLibraryTests projects so the following line:
```
expectedBalance = Member.ChildOutstandingFineLimit
```
Becomes:
```
expectedBalance = ChildMember.OutstandingFineLimit
```

7. Run the LendingLibraryUI and/or the LendingLibraryTests projects and ensure the logic works as before.



# To Run the Project
-  Select "Start Debugging" or "Run Without Debugging" from Visual Studio Code's "Run" menu or press F5 or Ctrl+F5
-  To interact with the console (and view the program's output) select the "Terminal" option from Visual Studio Code's View Menu (or press Ctrl+')  

# Execute Unit Tests
At any time you can invoke the unit tests that will be used to determine whether you have successfully completed the challenge by selecting the "Terminal" option from Visual Studio Code's View Menu (or pressing Ctrl+')) and running the following command:

```
dotnet test
```
If all the tests pass you will see a message (in green) that states <span style="color:green">"Passed!  - Failed:   0..."</span>. If any of the tests fail tou will see a message in red that states <span style="color:red">"Failed! - Failed:    n..."</span> where n indicates the number of tests that have failed.

__Note:__ Please recognise the tests are looking for precisely sequenced sets of text so if you think your code is producing the correct output but the associated test fails, then it’s quite likely there’s some kind of minor discrepancy such as an additional or missing space or piece of punctuation.

__Also Note:__ You are NOT (yet) expected to understand how to create your own unit tests nor to interpret the results beyond knowing whether the tests have passed or failed. You will be looking at unit testing as the final topic of this digital course.

# Model Solution (__but only if you need it__)
The code for a model solution can be found in the ```ModelSolutionIfYouNeedIt.Code``` project 