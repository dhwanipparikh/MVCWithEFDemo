using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Repository;
using MVCDemo.Models;
using MVCDemo.Common;

namespace MVCDemo.Service
{
    public class DemographicService : BaseService
    {

        public DemographicService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           
        }
        public virtual List<Demographic> GetAll()
        {
            
            return TheUnitOfWork.MemberRepository.GetAll();
            
        }

        public virtual void Save(Demographic viewModel)
        {
            viewModel.HomeContact.Country = AppConstant.COUNTRY;
            viewModel.HomeContact.ContactType = AppConstant.CONTACT_TYPE;
            viewModel.HomeContact.MemberID = viewModel.Member.MemberID;
            TheUnitOfWork.MemberRepository.Save(viewModel.Member);
            TheUnitOfWork.ContactRepository.Save(viewModel.HomeContact);
            TheUnitOfWork.Save();
           
        }

        public virtual Demographic GetByID(int id)
        {

            return TheUnitOfWork.MemberRepository.GetByID(id);
        }
    }
}