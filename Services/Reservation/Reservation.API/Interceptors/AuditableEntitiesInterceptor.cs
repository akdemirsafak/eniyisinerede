﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Reservation.API.Entity;

namespace Reservation.API.Interceptors;

public class AuditableEntitiesInterceptor : SaveChangesInterceptor
{
    //private readonly IHttpContextAccessor _httpContextAccessor;

    //public AuditableEntitiesInterceptor(IHttpContextAccessor httpContextAccessor)
    //{
    //    _httpContextAccessor = httpContextAccessor;
    //}
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        Microsoft.EntityFrameworkCore.DbContext? dbContext = eventData.Context;
        if (dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        IEnumerable<EntityEntry<IAuditableEntity>> entries =
            dbContext
            .ChangeTracker
                .Entries<IAuditableEntity>();


        foreach (EntityEntry<IAuditableEntity> entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                //entry.Property(x => x.CreatedBy).CurrentValue = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                //entry.Property(x => x.UpdatedBy).CurrentValue = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
