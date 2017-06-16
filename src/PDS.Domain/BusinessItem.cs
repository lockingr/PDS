using System;
using System.Collections.ObjectModel;

namespace PDS.Domain
{
    /// <summary>
    /// Domain class that holds details of the order of business item and relevant members
    /// </summary>
    public class BusinessItem
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
        
        public BusinessItem()
        {
            Members = new Collection<Member>();
        }
    }
}
