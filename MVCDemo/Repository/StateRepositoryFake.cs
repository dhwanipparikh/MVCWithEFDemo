using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.DAL;
using MVCDemo.Domain;

namespace MVCDemo.Repository
{
    public class StateRepositoryFake : IStateRepository
    {
        List<State> States;
        internal StateRepositoryFake()
        {
            States = new List<State>();
            States.AddRange(SeedData.GetStateList());
        }
        public List<State> GetAllState()
        {
            var result = States.ToList();               
            return result;

        }
    }
}