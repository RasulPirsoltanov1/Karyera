using Karyera.Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karyera.Infrastructure.Interceptors
{
    public class DbContextInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var entities = eventData.Context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added && x.Entity is BaseEntity);

            foreach (var entity in entities)
            {
                ((BaseEntity)entity.Entity).CreateDate = DateTimeOffset.Now;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
