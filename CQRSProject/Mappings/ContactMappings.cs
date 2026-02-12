using AutoMapper;
using CQRSProject.CQRSPattern.Results.ContactResults;
using CQRSProject.Entities;

namespace CQRSProject.Mappings
{
    public class ContactMappings : Profile
    {
        public ContactMappings()
        {
            CreateMap<Contact, GetContactQueryResult>();
            CreateMap<Contact, GetContactByIdQueryResult>();
        }
    }
}
