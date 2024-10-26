using App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;
using App.EnglishBuddy.Application.Repositories;
using App.EnglishBuddy.Domain.Entities;
using App.EnglishBuddy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace App.EnglishBuddy.Infrastructure.Repositories;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    public EnglishBuddyDbContext _context;
    public UserRepository(EnglishBuddyDbContext context) : base(context)
    {
        _context = context;
    }

   


    public async Task<List<GetAllOnlineResponse>> GetAllOnlineUsers(GetAllOnlineRequest request, CancellationToken cancellationToken)
    {

        List<GetAllOnlineResponse> query = await (from u in _context.Users
                                                join p in _context.UsersImages on u.Id equals p.UserId into gj
                                                from x in gj.DefaultIfEmpty()
                                                where u.isOnline == request.IsOnline
                                                select new GetAllOnlineResponse
                                                {
                                                    Name = u.FirstName + " " + u.LastName,
                                                    Email = u.Email,
                                                    Address = u.CityName,
                                                    FcmToken = u.FcmToken,
                                                    Mobile = u.Mobile,
                                                    Image = !string.IsNullOrEmpty(x.ImagePath) ? $"https://insightxdev.com:801/{x.ImagePath}" : null,
                                                    UserId = u.Id,
                                                    Minutes = _context.RandomCallingTracking.Where(x => x.UserId == u.Id && x.CreatedDate == DateTime.Now.Date).Sum(x => x.Minutes)
                                                })
                                               
                                               .Skip((request.PageNumber - 1) * request.PageSize)
                                               .Take(request.PageSize).ToListAsync(cancellationToken);
        return query;
    }

    public Task<Users> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}