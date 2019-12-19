using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.CategoryInfo
{
    public interface ICategoryDAO
    {
        IList<Category> GetAllCategories(int ID);

    }
}
