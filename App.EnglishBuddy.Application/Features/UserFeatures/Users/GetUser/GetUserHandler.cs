﻿using App.EnglishBuddy.Application.Common.Exceptions;
using App.EnglishBuddy.Application.Repositories;
using App.EnglishBuddy.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace App.EnglishBuddy.Application.Features.UserFeatures.GetUser;

public sealed class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUserHandler> _logger;
    private readonly IMediator _mediator;
    private readonly IUsersImagesRepository _iUsersImagesRepository;
    private readonly IMeetingsUsersRepository _iMeetingsUserRepository;
    private readonly IMeetingsRepository _iMeetingsRepository;

    
    public GetUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository,
        IMapper mapper, ILogger<GetUserHandler> logger, IMediator mediator, IUsersImagesRepository iUsersImagesRepository, IMeetingsUsersRepository iMeetingsUserRepository, IMeetingsRepository iMeetingsRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
        _iUsersImagesRepository = iUsersImagesRepository;
        _iMeetingsUserRepository = iMeetingsUserRepository;
        _iMeetingsRepository = iMeetingsRepository;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        GetUserResponse response = new GetUserResponse();
        try
        {
            Users user = await _userRepository.GetById(request.Id, cancellationToken);
            _logger.LogInformation("user" + JsonConvert.SerializeObject(user));
            if (user != null)
            {
                response = _mapper.Map<GetUserResponse>(user);
                Domain.Entities.UsersImages userImage = await _iUsersImagesRepository.FindByUserId(x => x.UserId == user.Id, cancellationToken);
                _logger.LogInformation("userImage" + JsonConvert.SerializeObject(userImage));
                if (userImage != null)
                {
                    response.ImagePath = $"https://insightxdev.com:801/{userImage.ImagePath}";
                }
                var meetingUser = _iMeetingsUserRepository.FindByListSync(x => x.UserId == user.Id && x.IsmeetingAdmin == false);
                if (meetingUser != null)
                {
                    response.MeetingJoined = meetingUser.Count;
                }
               
                var meetingCreatedBy= _iMeetingsRepository.FindByListSync(x => x.UserId == user.Id);
                if (meetingCreatedBy != null)
                {
                    response.MeetingCreated = meetingCreatedBy.Count;
                }
            } else
            {
                throw new NotFoundException("No Record Found");
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}