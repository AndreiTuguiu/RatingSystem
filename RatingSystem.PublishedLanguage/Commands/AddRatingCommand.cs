using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class AddRatingCommand : IRequest
    {
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public int StatusId { get; set; }
        public decimal Rating { get; set; }
    }
}
