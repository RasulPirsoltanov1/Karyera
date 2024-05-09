using Karyera.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Queries.GetAll
{
    public class CategoryGetAllQueryRequest:IRequest<List<Category>>
    {
       
    }
}
