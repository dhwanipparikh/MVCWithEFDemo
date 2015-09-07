using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Repository;

namespace MVCDemo.Service
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected IUnitOfWork TheUnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

    }
}