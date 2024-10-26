using MediatR;

namespace App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;

public sealed record GetAllOnlineRequest : IRequest<List<GetAllOnlineResponse>>
{
    public Boolean IsOnline { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}


