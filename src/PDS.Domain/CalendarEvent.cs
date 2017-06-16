using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PDS.Domain
{

    public class MemberInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Committee
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<object> Inquiries { get; set; }
    }

    /// <summary>
    /// Domain class for calendar event
    /// </summary>
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public object Notes { get; set; }
        public int SortOrder { get; set; }
        public string Type { get; set; }
        public string House { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public object LocationMetadata { get; set; }
        public bool HasSpeakers { get; set; }
        public Committee Committee { get; set; }
        public List<object> Tags { get; set; }
        public Collection<MemberInfo> Members { get; set; }
        public List<object> Metadata { get; set; }
        public string SummarisedDetails { get; set; }
        
    }
}
