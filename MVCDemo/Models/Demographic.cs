using System.Web.Mvc;
using System.Collections.Generic;
using MVCDemo.Domain;

namespace MVCDemo.Models
{
    public class Demographic
    {
        public Member Member { get; set; }
        public Contact HomeContact { get; set; }

        public List<SelectListItem> StateList { get; set; }
        public Demographic()
        {
            Member = new Member();
            HomeContact = new Contact();

            StateList = new List<SelectListItem>();
            
        }
    }
}