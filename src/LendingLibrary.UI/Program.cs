using LendingLibrary;
using System;

namespace LendingLibraryUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library;
            Member greta;
            Member donald;

            library = new Library();
            greta = library.Add(name: "Greta Thunberg", age: 15);
            greta.Street = "Queen Street";
            greta.City = "Stockholm";
            greta.NewFine(6M);
            donald = library.Add(name: "Donald Trump", age: 73);
            donald.Street = "White House";
            donald.City = "Washington";
            donald.NewFine(30M);

            Console.WriteLine($"library contains {library.NumberOfMembers} members");
            Console.WriteLine($"{greta.Name}'s membership number is {greta.MembershipNumber}");
            Console.WriteLine($"{donald.Name}'s membership number is {donald.MembershipNumber}");

            //Book Code 100: "Walls have ears", BookCategory.Adult
            //Book Code 101: "Noddy goes to Toytown", BookCategory.Children
            Book adultBook = library.GetBook(100);
            Book childBook = library.GetBook(101);

            // a junior member (under 16) can borrow only child category books
            string confirmMessage = greta.Borrow(childBook);
            Console.WriteLine(confirmMessage);

            // a junior member (under 16) can borrow only child category books
            confirmMessage = greta.Borrow(adultBook);
            Console.WriteLine(confirmMessage);

            // an adult member (>= 16) can borrow only child category books
            confirmMessage = donald.Borrow(childBook);
            Console.WriteLine(confirmMessage);
            confirmMessage = donald.Borrow(adultBook);
            Console.WriteLine(confirmMessage);

            // Child_Pays_Fine_From_Cash_Fund
            decimal payment = 7M;
            decimal expectedBalance = greta.OutstandingFines - payment;
            Console.WriteLine($"{greta.Name} currently owes {greta.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            greta.PayFine(payment);
            Console.WriteLine($"After paying in {payment:C}, {greta.Name} now owes {greta.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Child_Incurs_Fine_That_Exceeds_limit
            //Note: FineLimit is a static readonly property set to a default value of 15.00
            decimal fine = 17M;
            expectedBalance = Member.ChildOutstandingFineLimit; //Note: OutstandingFineLimit is a static readonly property set to a default value of 15.00

            Console.WriteLine($"{greta.Name} currently owes {greta.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            greta.NewFine(fine); //child fine's are capped so only £15 needs to be paid
            Console.WriteLine($"After incurring a {fine:C} fine, {greta.Name} now owes {greta.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Adult_Pays_Fine
            //Note: There is no fine limit for adults
            payment = 17M;
            expectedBalance = donald.OutstandingFines - payment;
            Console.WriteLine($"{donald.Name} currently owes {donald.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            donald.PayFine(payment);
            Console.WriteLine($"After paying in {payment:C}, {donald.Name} now owes {donald.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Adult_Incurs_Fine_That_Exceeds_limit
            //Note: There is no fine limit for adults
            fine = 17M;
            expectedBalance = donald.OutstandingFines + fine;
            Console.WriteLine($"{donald.Name} currently owes {donald.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            donald.NewFine(fine);
            Console.WriteLine($"After incurring a {fine:C} fine, {donald.Name} now owes {donald.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
        }
    }
}
