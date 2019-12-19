﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDao
    {
        IList<Survey> GetTopSurveys();

        bool SaveNewSurvey(Survey post);

      IDictionary<string, string> GetParkNames();
    }
}
