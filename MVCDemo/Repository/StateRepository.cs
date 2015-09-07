using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.DAL;
using MVCDemo.Domain;

namespace MVCDemo.Repository
{
    public class StateRepository : BaseRepository, IStateRepository
    {
        internal StateRepository(DemoContext _context) : base(_context)
        {
          
        }
        public List<State> GetAllState()
        {

            var result = TheDemoDBContext.States.ToList();               

                return result;

        }
    }
}