using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.DAL;

namespace MVCDemo.Repository
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(DemoContext _context)
            : base(_context)
        {
        }
        public void Save(Contact contact)
        {
            if (contact.ContactID == 0)
            {
                TheDemoDBContext.Contacts.Add(contact);
            }
            else
            {
                TheDemoDBContext.Contacts.Attach(contact);
                TheDemoDBContext.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}