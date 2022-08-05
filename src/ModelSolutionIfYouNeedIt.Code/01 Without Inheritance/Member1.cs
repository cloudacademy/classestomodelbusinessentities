//using System;
//using System.Collections.Generic;

//namespace LendingLibrary
//{
//    public class Member
//    {
//        public string Name { get; }
//        public int MembershipNumber { get; }
//        public int Age { get; }

//        public string Street { get; set; }
//        public string City { get; set; }
//        // if outstanding fines is -'ve account is in credit
//        // if outstanding fines is +'ve there are still fines that need paying
//        public decimal OutstandingFines { get; private set; }

//        public static decimal ChildOutstandingFineLimit { get; private set; } = 15.00M;

//        public Member(string name, int age, int membershipNumber)
//        {
//            this.Name = name;
//            this.Age = age;
//            this.MembershipNumber = membershipNumber;
//        }

//        public string Borrow(Book book)
//        {
//            if (Age < 16 && book.Category == BookCategory.Adult)
//            {
//                return $"{book.Title} is unsuitable for children. The request to borrow it has been rejected";
//            }
//            else
//            {
//                //Code that updates database with details that member has borrowed book would go here
//                return $"{book.Title} successfully borrowed by {this.Name}";
//            }
//        }

//        public void PayFine(decimal fine)
//        {
//            if (Age < 16)
//            {
//                if (fine > ChildOutstandingFineLimit)
//                    fine = ChildOutstandingFineLimit;
//            }
//            //No FineLimit for adults
//            OutstandingFines -= fine;

//        }

//        public void NewFine(decimal fine) // Fine needs to be added to any existing fines
//        {
//            if (Age < 16) //Maximum outstanding fine for children  which they should not exceed
//            {
//                if (ChildOutstandingFineLimit <= (fine + OutstandingFines))
//                {
//                    OutstandingFines = ChildOutstandingFineLimit;
//                    return;
//                }
//            }

//            OutstandingFines += fine;
//        }
//    }
//}