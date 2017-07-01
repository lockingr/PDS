using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDS.UI.Web.Controllers.Resources;
using PDS.Services;
using PDS.Domain;
using System.Collections.ObjectModel;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDS.UI.Web.Controllers
{
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly ServiceConfig _serviceConfig;

        private readonly IMapper mapper;

        public CalendarController(IMapper mapper)
        {
            this.mapper = mapper;

            _serviceConfig = new ServiceConfig(
                   "http://service.calendar.parliament.uk/calendar/events/",
                   "http://data.parliament.uk/membersdataplatform/services/mnis/",
                   "list.json?startdate={0}&enddate={1}",
                   "members/query/id={0}/"
               );
        }


        [HttpGet("{startDate}/{endDate}")]
        public IEnumerable<BusinessItemResource> GetCalendarEvents(string startDate, 
                                                                   string endDate)
        {

            HouseCommonsBusinessService service = 
                        new HouseCommonsBusinessService(_serviceConfig);


            var businessItems = service.GetCalendarOfEventsByDate(
                                        DateTime.Parse(startDate), 
                                        DateTime.Parse(endDate));


            return mapper.Map<IEnumerable<BusinessItem>, IEnumerable<BusinessItemResource>>(businessItems);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
