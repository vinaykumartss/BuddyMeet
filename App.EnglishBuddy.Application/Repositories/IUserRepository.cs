
using App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;
using App.EnglishBuddy.Domain.Entities;

namespace App.EnglishBuddy.Application.Repositories;

public interface IUserRepository : IBaseRepository<Users>
{
    Task<Users> GetByEmail(string email, CancellationToken cancellationToken);
   

    Task<List<GetAllOnlineResponse>> GetAllOnlineUsers(GetAllOnlineRequest request, CancellationToken cancellationToken);
}
