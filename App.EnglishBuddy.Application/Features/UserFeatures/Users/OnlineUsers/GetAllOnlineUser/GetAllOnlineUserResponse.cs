namespace App.EnglishBuddy.Application.Features.UserFeatures.GetAllOnlineUser;

public sealed record GetAllOnlineResponse
{

    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public string? FcmToken { get; set; }
    public string? Image { get; set; }

    public Guid UserId { get; set; }
    public int Minutes { get; set; }

}