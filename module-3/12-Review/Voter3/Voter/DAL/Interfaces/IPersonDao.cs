using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voter.Models;

namespace Voter.DAL.Interfaces
{
    public interface IPersonDao
    {
        List<Person> GetPersons();
    }
}
