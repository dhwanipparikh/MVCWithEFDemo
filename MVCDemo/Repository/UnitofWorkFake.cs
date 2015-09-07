using System;
using System.Collections.Generic;
using System.Linq;
using MVCDemo.DAL;

namespace MVCDemo.Repository
{
    public class UnitOfWorkFake :  IUnitOfWork
    {
        private IMemberRepository _memberRep;
        private IContactRepository _contactRep;
        private IStateRepository _stateRep;

        public UnitOfWorkFake()
        {
        }
        public IMemberRepository MemberRepository
        {
            get
            {
                if (_memberRep == null)
                    _memberRep = new MemberRepositoryFake();
                return _memberRep;
            }
        }
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRep == null)
                    _contactRep = new ContactRepositoryFake();
                return _contactRep;
            }
        }
        public IStateRepository StateRepository
        {
            get
            {
                if (_stateRep == null)
                    _stateRep = new StateRepositoryFake();
                return _stateRep;
            }
        }      

        public void Save()
        {
        }
    }
}