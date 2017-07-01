using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PDS.UI.Web.Controllers.Resources
{
    public class BusinessItemResource
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string DayOfWeek()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        public string Description { get; set; }
        public Collection<Member> Members { get; set; }

        public BusinessItemResource()
        {
            Members = new Collection<Member>();
        }
    }
}
