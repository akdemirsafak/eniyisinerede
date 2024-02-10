﻿namespace Reservation.API.Entity;

public interface IAuditableEntity
{
    DateTime? CreatedAt { get; set; }
    Guid? CreatedById { get; set; }
    DateTime? UpdatedAt { get; set; }
    Guid? UpdatedById { get; set; }
}
