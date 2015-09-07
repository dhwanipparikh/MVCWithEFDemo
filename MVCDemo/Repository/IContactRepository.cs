using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCDemo.Domain;

namespace MVCDemo.Repository
{
    public interface IContactRepository
    {
        void Save(Contact contact);
    }
}
