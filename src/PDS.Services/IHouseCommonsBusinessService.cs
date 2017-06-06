using System;
using System.Collections.Generic;
using PDS.Domain;


namespace PDS.Services
{
    public interface IHouseCommonsBusinessService
    {
        IEnumerable<BusinessItem> GetBusinessCalendarByDate(DateTime startDate, DateTime endDate);

        IEnumerable<CalendarEvent> GetCalendarEvent(DateTime startDate, DateTime endDate);

        Member GetMember(int id);

    }
}
