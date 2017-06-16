using System;
using PDS.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;

namespace PDS.Services
{
    public class HouseCommonsBusinessService 
    {
        private readonly string _calendarEndPoint;
        private readonly string _memberNamesEndPoint;
        private readonly string _calendarURI;
        private readonly string _membersNameURI;


        public HouseCommonsBusinessService(string calendarURI,
                                           string membersNameURI, 
                                           string calendarEndPoint, 
                                           string memberNamesEndPoint)
        {
            _calendarURI = calendarURI;

            _membersNameURI = membersNameURI;

            _calendarEndPoint = calendarEndPoint;

            _memberNamesEndPoint = memberNamesEndPoint;

        }

        /// <summary>
        /// Gets a collection of business items using start and end dates.
        /// </summary>

        public Collection<BusinessItem> GetCalendarOfEventsByDate(DateTime startDate, DateTime endDate)
        {
            Collection<BusinessItem> businessItems = new Collection<BusinessItem>();
            Collection<CalendarEvent> calendarEvents;

            calendarEvents = GetCalendarEvent(startDate, endDate);

            foreach (var calendarEvent in calendarEvents)
            {

                var businessItem = new BusinessItem
                {
                    Description = calendarEvent.Description,
                    StartDate = DateTime.Parse(calendarEvent.StartDate),
                    EndDate = DateTime.Parse(calendarEvent.EndDate)

                };

                if (calendarEvent.Members.Count > 0)
                {
                    var member = GetMemberById(calendarEvent.Members[0].Id);

                    businessItem.Members.Add(member);
                }

                businessItems.Add(businessItem);
            }

            return businessItems;
        }

        private Collection<CalendarEvent> GetCalendarEvent(DateTime startDate, DateTime endDate)
        {
            var endPoint = string.Format(_calendarEndPoint,
                                          startDate.Date.ToString("yyyy-MM-dd"),
                                          endDate.Date.ToString("yyyy-MM-dd"));

            var jsonCalendarEventData = ServiceHelper(_calendarURI, endPoint);

            Collection<CalendarEvent> calendarEvents = JsonConvert.DeserializeObject<Collection<CalendarEvent>>(jsonCalendarEventData);

            return calendarEvents;
        }

        private Member GetMemberById(int id)
        {
            var endPoint = string.Format(_memberNamesEndPoint, id.ToString());

            var jsonMemeberData = ServiceHelper(_membersNameURI, endPoint);

            var members = JsonConvert.DeserializeObject<Rootobject>(jsonMemeberData).Members.Member;

            return members;
        }

        private string ServiceHelper(string uri, string endPoint)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);

                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");

                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    HttpResponseMessage response = client.GetAsync(endPoint).Result;

                    if (response.StatusCode != HttpStatusCode.OK)
                        return response.StatusCode.ToString();

                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    
                    return jsonData;
                }

            }
            catch (Exception)
            {
                throw new Exception("Error contacting end point");
            }
                        
        }

    }
}
