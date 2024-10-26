using App.EnglishBuddy.Application.Repositories;
using AutoMapper;
using MediatR;

namespace App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;

public sealed class GetAllOnlineHandler : IRequestHandler<GetAllOnlineRequest, List<GetAllOnlineResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetAllOnlineHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetAllOnlineResponse>> Handle(GetAllOnlineRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllOnlineUsers(request, cancellationToken);
        return users;
    }
}