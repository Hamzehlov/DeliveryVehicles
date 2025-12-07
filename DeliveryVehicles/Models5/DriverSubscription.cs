using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("driver_subscriptions")]
public partial class DriverSubscription
{
    [Key]
    [Column("subscription_id")]
    public int SubscriptionId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string? Type { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("DriverSubscriptions")]
    public virtual DriverDetail Driver { get; set; } = null!;
}
