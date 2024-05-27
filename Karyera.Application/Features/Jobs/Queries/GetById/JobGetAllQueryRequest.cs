using Karyera.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Jobs.Queries
{
    // Modified JobGetAllQueryRequest to include pagination parameters
    public class JobGetByIdQueryRequest : IRequest<Job>
    {
        public int JobId { get; set; }
    }
}
