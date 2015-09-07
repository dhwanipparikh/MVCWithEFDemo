using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCDemo.Domain;
using MVCDemo.Models;
namespace MVCDemo.Repository
{
    public interface IMemberRepository
    {
        void Save(Member member);
        Demographic GetByID(int id);
        List<Demographic> GetAll();
    }
}
