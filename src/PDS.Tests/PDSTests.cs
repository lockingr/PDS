using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.Services;
using System.Globalization;
using PDS.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PDS.Tests
{
    [TestClass]
    public class PDSTests
    {
        private string _calendarUri;
        private string _memberNamesUri;
        private string _calendarEndPoint;
        private string _memberNamesEndPoint;

        [TestInitialize]
        public void SetUp()
        {
            _calendarUri = "http://service.calendar.parliament.uk/calendar/events/";
            _memberNamesUri = "http://data.parliament.uk/membersdataplatform/services/mnis/";
            _calendarEndPoint = "list.json?startdate={0}&enddate={1}";
            _memberNamesEndPoint = "members/query/id={0}/";
        }

        [TestMethod]
        public void BusinessService_WhenDateSupplied_ReturnsCalendarEventsWithoutMembers()
        {
            // Arrange
            DateTime startDate = DateTime.Parse("2017-06-05"); 
            DateTime endDate = DateTime.Parse("2017-06-19"); 
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_calendarUri,
                                                                                  _memberNamesUri,
                                                                                  _calendarEndPoint,
                                                                                  _memberNamesEndPoint);

            // Act
            var items =  service.GetCalendarOfEventsByDate(startDate, endDate);

            // Assert
            Assert.IsNotNull(items);

        }

        [TestMethod]
        public void BusinessService_WhenDateSupplied_ReturnsCalendarEvents()
        {
            // Arrange
            DateTime startDate = DateTime.Parse("2017-04-01");
            DateTime endDate = DateTime.Parse("2017-04-30");
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_calendarUri,
                                                                                  _memberNamesUri,
                                                                                  _calendarEndPoint,
                                                                                  _memberNamesEndPoint);

            // Act
            var items = service.GetCalendarOfEventsByDate(startDate, endDate);

            // Assert
            Assert.IsNotNull(items.Count > 0 );

        }

        [TestMethod]
        public void BusinessService_WhenNonSittingDateRange_ReturnsZeroEvents()
        {
            // Arrange
            DateTime startDate = DateTime.Parse("2017-06-05");
            DateTime endDate = DateTime.Parse("2017-06-11");
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_calendarUri,
                                                                                  _memberNamesUri,
                                                                                  _calendarEndPoint,
                                                                                  _memberNamesEndPoint);

            // Act
            var items = service.GetCalendarOfEventsByDate(startDate, endDate);

            // Assert
            Assert.IsTrue(items.Count == 0);
        }

        private DateTime GetStartOfWeek()
        {
            return DateTime.Now.AddDays( 
                  (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek 
                - (int)DateTime.Today.DayOfWeek);
        }

        private DateTime GetEndOfWeek()
        {
            return DateTime.Today;
        }


    }
}
