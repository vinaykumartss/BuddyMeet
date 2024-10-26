using MediatR;

namespace App.EnglishBuddy.Application.Features.UserFeatures.OnlineUsers
{
    public class OnlineUserStatusRequest : IRequest<OnlineUserStatusResponse>
    {
       
        public Guid? Id { get; set; }

        public bool? IsOnline { get; set; }
    }
}