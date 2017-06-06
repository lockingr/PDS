using System;
using System.Collections.Generic;
using System.Text;
using PDS.Domain;

namespace PDS.Services
{
    class HouseCommonsBusinessServiceMock : IHouseCommonsBusinessService
    {
        public IEnumerable<BusinessItem> GetBusinessCalendarByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CalendarEvent> GetCalendarEvent(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}
