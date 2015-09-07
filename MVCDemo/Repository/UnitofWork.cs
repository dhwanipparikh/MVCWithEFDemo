using System;
using System.Collections.Generic;
using System.Linq;
using MVCDemo.DAL;

namespace MVCDemo.Repository
{
    public class UnitOfWork :IUnitOfWork , IDisposable
    {
        private IMemberRepository _memberRep;
        private IContactRepository _contactRep;
        private IStateRepository _stateRep;

        private DemoContext _context;
        private bool disposed = false;

        public UnitOfWork()
        {
            _context = new DemoContext();
            _context.User = new Common.User();
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                if (_memberRep == null)
                    _memberRep = new MemberRepository(_context);
                return _memberRep;
            }
        }

        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRep == null)
                    _contactRep = new ContactRepository(_context);
                return _contactRep;
            }
        }
        public IStateRepository StateRepository
        {
            get
            {
                if (_stateRep == null)
                    _stateRep = new StateRepository(_context);
                return _stateRep;
            }
        }      

        public void Save()
        {
            _context.Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}