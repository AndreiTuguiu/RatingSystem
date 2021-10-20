using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class AddRating : IRequestHandler<AddRatingCommand>
    {
        private readonly IMediator _mediator;
        private readonly RatingDbContext _dbContext;

        public AddRating(IMediator mediator, RatingDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public Task<Unit> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            var conferenceXAttendee = new ConferenceXAttendee
            {
                AttendeeEmail = request.AttendeeEmail,
                ConferenceId = request.ConferenceId,
                StatusId = request.StatusId,
                Rating = request.Rating
            };
            _dbContext.ConferenceXattendees.Add(conferenceXAttendee);
            _dbContext.SaveChanges();
            return Unit.Task;
        }
    }
}


