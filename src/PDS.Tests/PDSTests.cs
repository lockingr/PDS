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
        private ServiceConfig _serviceConfig;

        [TestInitialize]
        public void SetUp()
        {
            _serviceConfig = new ServiceConfig(
                    "http://service.calendar.parliament.uk/calendar/events/",
                    "http://data.parliament.uk/membersdataplatform/services/mnis/",
                    "list.json?startdate={0}&enddate={1}",
                    "members/query/id={0}/"
                );            
        }

        [TestMethod]
        public void BusinessService_WhenDateSupplied_ReturnsCalendarEventsWithoutMembers()
        {
            // Arrange
            DateTime startDate = DateTime.Parse("2017-06-05"); 
            DateTime endDate = DateTime.Parse("2017-06-19"); 
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_serviceConfig);

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
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_serviceConfig);

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
            HouseCommonsBusinessService service = new HouseCommonsBusinessService(_serviceConfig);

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
