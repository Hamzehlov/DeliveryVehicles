using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("trips")]
public partial class Trip
{
    [Key]
    [Column("trip_id")]
    public int TripId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("queue_id")]
    public int? QueueId { get; set; }

    [Column("start_time", TypeName = "datetime")]
    public DateTime? StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime? EndTime { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("total_fare", TypeName = "decimal(10, 2)")]
    public decimal? TotalFare { get; set; }

    [Column("commission_amount", TypeName = "decimal(10, 2)")]
    public decimal? CommissionAmount { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Trip")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    [ForeignKey("DriverId")]
    [InverseProperty("Trips")]
    public virtual DriverDetail Driver { get; set; } = null!;

    [ForeignKey("QueueId")]
    [InverseProperty("Trips")]
    public virtual Queue? Queue { get; set; }

    [InverseProperty("Trip")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    [ForeignKey("StatusId")]
    [InverseProperty("Trips")]
    public virtual Code Status { get; set; } = null!;

    [InverseProperty("Trip")]
    public virtual ICollection<TripPassenger> TripPassengers { get; set; } = new List<TripPassenger>();
}
