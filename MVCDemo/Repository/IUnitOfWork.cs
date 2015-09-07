using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo.Repository
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        IContactRepository ContactRepository { get; }
        IStateRepository StateRepository { get; }
        void Save();
    }
}
