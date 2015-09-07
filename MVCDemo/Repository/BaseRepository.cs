using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.DAL;

namespace MVCDemo.Repository
{
    public abstract class BaseRepository
    {
        private readonly DemoContext _context;
        public BaseRepository(DemoContext context)
        {
            _context = context;
        }
        public DemoContext TheDemoDBContext
        {
            get
            {
                return _context;
            }
        }
    }
}