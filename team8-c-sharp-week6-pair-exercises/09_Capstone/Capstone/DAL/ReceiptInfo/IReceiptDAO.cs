using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.ReceiptInfo
{
    public interface IReceiptDAO
    {
        Receipt ReceiptWriter(int spaceID, int groupSize, DateTime arrivalDate, DateTime leaveDate, string familyName);
    }
}
