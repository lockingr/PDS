using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PDS.Domain
{
    public class BusinessItem
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public IEnumerable<Member> Members { get; set; }

        public BusinessItem()
        {
            Members = new Collection<Member>();
        }

    }
}
