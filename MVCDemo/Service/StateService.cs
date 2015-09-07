using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Domain;
using MVCDemo.Repository;

namespace MVCDemo.Service
{
    public class StateService :BaseService
    {
       
        public StateService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public virtual List<State> GetStateList()
        {
            return TheUnitOfWork.StateRepository.GetAllState();
        }

    }
}