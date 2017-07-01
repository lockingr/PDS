using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PDS.UI.Web.Controllers.Resources;
using PDS.Domain;

namespace PDS.UI.Web.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            // Domain to API resource
            CreateMap<BusinessItem, BusinessItemResource>()
                .ForMember(br => br.Members,
                opt => opt.MapFrom(b => b.Members.Select(bm => new Member
                {
                    FullTitle = bm.FullTitle,
                    Party =  new Party { text = bm.Party.text},
                    MemberFrom = bm.MemberFrom
                })));

        }

    }
}
