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
    public class Edit
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
                var activities = await _context.Activities.FindAsync(command.Id);

                if (activities == null)
                    throw new Exception("Error happen when edit.");

                activities.Title = command.Title ?? activities.Title;
                activities.Description = command.Description ?? activities.Description;
                activities.Category = command.Category ?? activities.Category;
                activities.City = command.Title ?? activities.City;

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;

                throw new Exception("Problem saving changes.");
            }
        }
    }
}