using Karyera.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Jobs.Queries
{
    // Modified JobGetAllQueryRequest to include pagination parameters
    public class JobGetAllQueryRequest : IRequest<List<Job>>
    {
        public int PageNumber { get; set; } = 1; // Default to first page
        public int PageSize { get; set; } = 10; // Default to 10 items per page
    }
}
