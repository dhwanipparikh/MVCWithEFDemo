using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.Common;
namespace MVCDemo.DAL
{
    public static class SeedData
    {

        public static List<Member> GetMemberList()
        {
            List<Member> members = new List<Member>();


            members.Add(new Member
            {
                FirstName = "John",
                LastName = "Doe",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "123 Main Road", AddressLine2 = "Apt 100", City = "Madison", StateID = "WI", ZipCode = "53717", Email = "john.doe@gmail.com" } }
            });
            members.Add(new Member
            {
                FirstName = "James",
                LastName = "Smith",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "1243 Mineral Point Road", AddressLine2 = "", City = "Madison", StateID = "WI", ZipCode = "53713", Email = "james.smith@yahoo.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Mary",
                LastName = "Harris",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "555 State Street", AddressLine2 = "Suite 203", City = "Madison", StateID = "WI", ZipCode = "51117", Email = "mary.harris@gmail.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Linda",
                LastName = "Lee",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "1 Rosa Road", AddressLine2 = "Apt 22", City = "Madison", StateID = "WI", ZipCode = "54784", Email = "linda.lee@yahoo.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Jennifer",
                LastName = "Young",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "57 E Washington Ave.", AddressLine2 = "", City = "Chicago", StateID = "IL", ZipCode = "68717", Email = "jennifer.young@hotmail.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Lisa",
                LastName = "Taylor",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "214 W Washington Ave.", AddressLine2 = "Suite 12", City = "Chicago", StateID = "IL", ZipCode = "75474", Email = "lisa.taylor@aol.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Nancy",
                LastName = "Clark",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "1 S Butler Street", AddressLine2 = "", City = "Madison", StateID = "WI", ZipCode = "59712", Email = "nancy.clark@gmail.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Robert",
                LastName = "Johnson",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "PO BOX 545", AddressLine2 = "", City = "Chicago", StateID = "IL", ZipCode = "67717", Email = "robert.johnson@hotmail.com" } }
            });
            members.Add(new Member
            {
                FirstName = "Michael",
                LastName = "Miller",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "154 S Webstar Street", AddressLine2 = "Suite 500", City = "Madison", StateID = "WI", ZipCode = "53874", Email = "michael.miller@aol.com" } }
            });
            members.Add(new Member
            {
                FirstName = "David",
                LastName = "Anderson",
                Contacts = new List<Contact> { new Contact { AddressLine1 = "1 S Gammon Road", AddressLine2 = "Apt 71", City = "Madison", StateID = "WI", ZipCode = "54817", Email = "david.anderson@gmail.com" } }
            });

            foreach (Member member in members)
            {
                member.Contacts.ToList().ForEach(c =>
                {
                    c.Country = AppConstant.COUNTRY;
                    c.ContactType = AppConstant.CONTACT_TYPE;
                });
            }

            return members;
        }
        public static List<State> GetStateList()
        {
            List<State> states = new List<State>();
            states.Add(new State { StateID = "AL", StateName = "Alabama" });
            states.Add(new State { StateID = "AK", StateName = "Alaska" });
            states.Add(new State { StateID = "AZ", StateName = "Arizona" });
            states.Add(new State { StateID = "AR", StateName = "Arkansas" });
            states.Add(new State { StateID = "CA", StateName = "California" });
            states.Add(new State { StateID = "CO", StateName = "Colorado" });
            states.Add(new State { StateID = "CT", StateName = "Connecticut" });
            states.Add(new State { StateID = "DE", StateName = "Delaware" });
            states.Add(new State { StateID = "FL", StateName = "Florida" });
            states.Add(new State { StateID = "GA", StateName = "Georgia" });
            states.Add(new State { StateID = "HI", StateName = "Hawaii" });
            states.Add(new State { StateID = "ID", StateName = "Idaho" });
            states.Add(new State { StateID = "IL", StateName = "Illinois" });
            states.Add(new State { StateID = "IN", StateName = "Indiana" });
            states.Add(new State { StateID = "IA", StateName = "Iowa" });
            states.Add(new State { StateID = "KS", StateName = "Kansas" });
            states.Add(new State { StateID = "KY", StateName = "Kentucky" });
            states.Add(new State { StateID = "LA", StateName = "Louisiana" });
            states.Add(new State { StateID = "ME", StateName = "Maine" });
            states.Add(new State { StateID = "MD", StateName = "Maryland" });
            states.Add(new State { StateID = "MA", StateName = "Massachusetts" });
            states.Add(new State { StateID = "MI", StateName = "Michigan" });
            states.Add(new State { StateID = "MN", StateName = "Minnesota" });
            states.Add(new State { StateID = "MS", StateName = "Mississippi" });
            states.Add(new State { StateID = "MO", StateName = "Missouri" });
            states.Add(new State { StateID = "MT", StateName = "Montana" });
            states.Add(new State { StateID = "NE", StateName = "Nebraska" });
            states.Add(new State { StateID = "NV", StateName = "Nevada" });
            states.Add(new State { StateID = "NH", StateName = "New Hampshire" });
            states.Add(new State { StateID = "NJ", StateName = "New Jersey" });
            states.Add(new State { StateID = "NM", StateName = "New Mexico" });
            states.Add(new State { StateID = "NY", StateName = "New York" });
            states.Add(new State { StateID = "NC", StateName = "North Carolina" });
            states.Add(new State { StateID = "ND", StateName = "North Dakota" });
            states.Add(new State { StateID = "OH", StateName = "Ohio" });
            states.Add(new State { StateID = "OK", StateName = "Oklahoma" });
            states.Add(new State { StateID = "OR", StateName = "Oregon" });
            states.Add(new State { StateID = "PA", StateName = "Pennsylvania" });
            states.Add(new State { StateID = "RI", StateName = "Rhode Island" });
            states.Add(new State { StateID = "SC", StateName = "South Carolina" });
            states.Add(new State { StateID = "SD", StateName = "South Dakota" });
            states.Add(new State { StateID = "TN", StateName = "Tennessee" });
            states.Add(new State { StateID = "TX", StateName = "Texas" });
            states.Add(new State { StateID = "UT", StateName = "Utah" });
            states.Add(new State { StateID = "VT", StateName = "Vermont" });
            states.Add(new State { StateID = "VA", StateName = "Virginia" });
            states.Add(new State { StateID = "WA", StateName = "Washington" });
            states.Add(new State { StateID = "WV", StateName = "West Virginia" });
            states.Add(new State { StateID = "WI", StateName = "Wisconsin" });
            states.Add(new State { StateID = "WY", StateName = "Wyoming" });

            return states;
        }
    }
}