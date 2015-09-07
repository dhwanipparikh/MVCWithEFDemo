using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.DAL;
using MVCDemo.Models;
using MVCDemo.Common;


namespace MVCDemo.Repository
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        internal MemberRepository(DemoContext _context)
            : base(_context)
        {
        }
        public void Save(Member member)
        {
            if (member.MemberID == 0)
            {
                TheDemoDBContext.Members.Add(member);
            }
            else
            {
                TheDemoDBContext.Members.Attach(member);
                TheDemoDBContext.Entry(member).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public Demographic GetByID(int id)
        {
            var result = TheDemoDBContext.Members
                .Include("Contact")
                .Where(m => m.MemberID == id)
                .Select(m => new Demographic()
                {
                    Member = m,
                    HomeContact = m.Contacts.Where(c => c.ContactType == AppConstant.CONTACT_TYPE).FirstOrDefault()

                });
            return result.Single();
        }

        public List<Demographic> GetAll()
        {
            //throw new NotImplementedException(); 
            var result = TheDemoDBContext.Members
                .Include("Contact")
                 .Select(m => new Demographic()
                 {
                     Member = m,
                     HomeContact = m.Contacts.FirstOrDefault()
                 });
            return result.ToList();
        }
    }
}