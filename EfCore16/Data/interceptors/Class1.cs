using EfCore16.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore16.Data.interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return result;

            foreach (var Entry in eventData.Context.ChangeTracker.Entries())
            {
                if (
                    Entry is null 
                    ||Entry.State != EntityState.Deleted 
                    || !(Entry.Entity is ISoftDeletable entity))
                    continue;

                Entry.State=EntityState.Modified;
                entity.Delete();

            }
            return result;
        }
    }
}
