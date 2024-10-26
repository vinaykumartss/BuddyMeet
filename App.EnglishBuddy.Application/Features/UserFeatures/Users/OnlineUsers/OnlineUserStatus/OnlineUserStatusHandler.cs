using App.EnglishBuddy.Application.Common.Exceptions;
using App.EnglishBuddy.Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.EnglishBuddy.Application.Features.UserFeatures.OnlineUsers;

public sealed class OnlineUserStatusHandler : IRequestHandler<OnlineUserStatusRequest, OnlineUserStatusResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<OnlineUserStatusHandler> _logger;
    private readonly IMediator _mediator;
    public OnlineUserStatusHandler(IUnitOfWork unitOfWork, IUserRepository userRepository,
        IMapper mapper, ILogger<OnlineUserStatusHandler> logger, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<OnlineUserStatusResponse> Handle(OnlineUserStatusRequest request, CancellationToken cancellationToken)
    {
        OnlineUserStatusResponse response = new OnlineUserStatusResponse();
        try
        {
            Domain.Entities.Users users = await _userRepository.FindByUserId(x => x.Id == request.Id, cancellationToken);
            if (users != null)
            {
                users.isOnline = request.IsOnline;
                _userRepository.Update(users);
                await _unitOfWork.Save(cancellationToken);
                response.IsSuccess = true;
              


            }
            else
            {
                throw new BadRequestException("User does not exist, please try agin");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong, please try again");

        }
        return response;
    }
}