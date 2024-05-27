using Karyera.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Companies.Queries.GetAll
{
    public class CompanyGetAllQueryRequest : IRequest<List<Company>>
    {

    }

}
