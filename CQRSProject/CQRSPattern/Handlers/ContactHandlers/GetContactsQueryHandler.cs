using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.ContactResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.ContactHandlers
{
    public class GetContactsQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetContactsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _context.Contacts.OrderByDescending(x => x.Id).ToListAsync();
            return _mapper.Map<List<GetContactQueryResult>>(values);
        }
    }
}
