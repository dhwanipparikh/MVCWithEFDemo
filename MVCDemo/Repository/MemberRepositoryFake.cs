using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.Models;
using MVCDemo.DAL;
using MVCDemo.Common;


namespace MVCDemo.Repository
{
    public class MemberRepositoryFake :IMemberRepository
    {
        List<Member> Members;
        public MemberRepositoryFake()
        {
            Members = new List<Member>();
            Members.AddRange(SeedData.GetMemberList());
            int memberId = 1;
            int contactId = 1;
            foreach (var member in Members)
            {
                member.MemberID = memberId;
                
                foreach (var contact in member.Contacts)
                {
                    contact.ContactID = contactId;
                    contact.Member = member;
                    contact.MemberID = member.MemberID;
                    contact.State = SeedData.GetStateList().Where(s => s.StateID == contact.StateID).Single();
                    contactId++;
                }

                memberId++;
            }
        }
        public void Save(Member member)
        {
            if(member.MemberID!=0)
                Members.Remove(Members.Where(m => m.MemberID == member.MemberID).Single());
            
            Members.Add(member);  
        }

        public Demographic GetByID(int id)
        {

            var result = Members
                .Where(m => m.MemberID == id)
                .Select(m => new Demographic() {
                    Member = m,
                    HomeContact = m.Contacts.Where(c => c.ContactType == AppConstant.CONTACT_TYPE).FirstOrDefault()
                
                });

            return result.Single();

        }

        public List<Demographic> GetAll()
        {

            var result = Members
                 .Select(m => new Demographic() { 
                  Member=m,
                  HomeContact=m.Contacts.FirstOrDefault()
                 });                

                return result.ToList();

        }
    }
}