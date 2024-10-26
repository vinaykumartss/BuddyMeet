using App.EnglishBuddy.Application.Repositories;
using App.EnglishBuddy.Domain.Entities;
using App.EnglishBuddy.Infrastructure.Context;

namespace App.EnglishBuddy.Infrastructure.Repositories;

public class MeetingsRepository : BaseRepository<Meetings>, IMeetingsRepository
{
    public EnglishBuddyDbContext _context;
    public MeetingsRepository(EnglishBuddyDbContext context) : base(context)
    {
        _context = context;
    }

  
}