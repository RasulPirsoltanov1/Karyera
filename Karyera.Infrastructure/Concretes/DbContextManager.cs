using Karyera.Application.Abstractions;
using Karyera.Domain.BaseEntities;
using Karyera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Infrastructure.Concretes
{
    public class DbContextManager<T> : IDbContextManager<T> where T : BaseEntity
    {
        AppDbContext _appDbContext;

        public DbContextManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<T> Table => _appDbContext.Set<T>();

        public int SaveChanges()
        {
          return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
