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
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.FindAsync(request.Id);
                if(activities == null)
                    throw new Exception("Cannot find activity.");

                _context.Remove(activities);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;

                throw new Exception("Problem saving changes.");            }
        }
    }
}