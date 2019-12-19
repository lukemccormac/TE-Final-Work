using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.StateInfo
{
    public interface IStateDAO
    {
        State GetLocation(int ID);
    }
}
