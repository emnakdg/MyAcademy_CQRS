using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.ContactResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetContactByIdQueryResult> Handle(int id)
        {
            var value = await _context.Contacts.FindAsync(id);
            return _mapper.Map<GetContactByIdQueryResult>(value);
        }
    }
}
