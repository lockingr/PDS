using System;
using System.Collections.Generic;
using System.Text;

namespace PDS.Domain
{
    public class ServiceConfig
    {
        public string CalendarURI { get { return _calendarURI; }  }

        public string MembersNameURI { get { return _membersNameURI; }  }

        public string CalendarEndPoint { get { return _calendarEndPoint; }  }

        public string MemberNamesEndPoint { get { return _memberNamesEndPoint; } }

        private readonly string _calendarURI;

        private readonly string _membersNameURI;

        private readonly string _calendarEndPoint;

        private readonly string _memberNamesEndPoint;

        public ServiceConfig(string calendarURI, 
                             string membersNameURI, 
                             string CalendarEndPoint,
                             string MemberNamesEndPoint)
        {

            _calendarURI = calendarURI;

            _membersNameURI = membersNameURI;

            _calendarEndPoint = CalendarEndPoint;

            _memberNamesEndPoint = MemberNamesEndPoint;

        }
    }
}
