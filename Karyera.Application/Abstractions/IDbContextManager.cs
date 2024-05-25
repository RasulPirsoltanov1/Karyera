using Karyera.Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Abstractions
{
    public interface IDbContextManager<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
