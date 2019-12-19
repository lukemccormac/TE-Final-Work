﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.SpaceInVenue
{
    public interface ISpaceDAO
    {
        IList<Space> GetAllSpaces(int input);
    }
}
