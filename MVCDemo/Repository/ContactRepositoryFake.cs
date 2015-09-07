using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.DAL;

namespace MVCDemo.Repository
{
    public class ContactRepositoryFake :IContactRepository
    {

        List<Contact> Contacts;
        public ContactRepositoryFake()
        {
            Contacts = new List<Contact>();
        }
        public void Save(Contact contact)
        {
                Contacts.Add(contact); 
        }
        
    }
}