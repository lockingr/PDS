using System;
using System.Collections.Generic;
using System.Text;
using PDS.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace PDS.Services
{
    public class HouseCommonsBusinessService : IHouseCommonsBusinessService
    {
        public IEnumerable<BusinessItem> GetBusinessCalendarByDate(DateTime startDate, DateTime endDate)
        {
            // Get Calendar Event for that date range supplied

            // Get members attending (if any)

            // Build BusinessItem object with calendar event and 

            // Add to BusinessItem collection

            //send back top client json
            throw new NotImplementedException();

        }

        private IEnumerable<CalendarEvent> GetCalendarEvent(DateTime startDate, DateTime endDate)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49387");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/customerservice").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Collection<CalendarEvent> data = JsonConvert.DeserializeObject<Collection<CalendarEvent>>(stringData);
                return data;
            }
        }

        IEnumerable<CalendarEvent> IHouseCommonsBusinessService.GetCalendarEvent(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        private Member GetMember(int id)
        {
            throw new NotImplementedException();
        }

        Member IHouseCommonsBusinessService.GetMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}
