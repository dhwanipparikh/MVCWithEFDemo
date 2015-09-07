using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCDemo.Domain;


namespace MVCDemo.Repository
{
    public interface IStateRepository
    {
        List<State> GetAllState();
    }
}
