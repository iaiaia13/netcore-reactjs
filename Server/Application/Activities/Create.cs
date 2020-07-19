using System.Collections.Generic;
using System.Threading;
using MediatR;
using Persistence;
using Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string Category { get; set; }

            public string City { get; set; }

            public string Venue { get; set; }

            public DateTime Date { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var activities = new Activity
                {
                    Id = new Guid(),
                    Title = command.Title,
                    Description = command.Description,
                    Category = command.Category,
                    Date = new DateTime(),
                    City = command.City,
                    Venue = command.Venue
                };

                _context.Activities.Add(activities);

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;

                throw new Exception("Problem saving changes.");
            }
        }
    }
}