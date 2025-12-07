using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("passenger_requests")]
public partial class PassengerRequest
{
    [Key]
    [Column("request_id")]
    public int RequestId { get; set; }

    [Column("passenger_id")]
    public int PassengerId { get; set; }

    [Column("line_id")]
    public int LineId { get; set; }

    [Column("pickup_lat", TypeName = "decimal(10, 7)")]
    public decimal? PickupLat { get; set; }

    [Column("pickup_lng", TypeName = "decimal(10, 7)")]
    public decimal? PickupLng { get; set; }

    [Column("pickup_address")]
    [StringLength(300)]
    public string? PickupAddress { get; set; }

    [Column("dropoff_lat", TypeName = "decimal(10, 7)")]
    public decimal? DropoffLat { get; set; }

    [Column("dropoff_lng", TypeName = "decimal(10, 7)")]
    public decimal? DropoffLng { get; set; }

    [Column("dropoff_address")]
    [StringLength(300)]
    public string? DropoffAddress { get; set; }

    [Column("seats_requested")]
    public int? SeatsRequested { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("LineId")]
    [InverseProperty("PassengerRequests")]
    public virtual Line Line { get; set; } = null!;

    [ForeignKey("PassengerId")]
    [InverseProperty("PassengerRequests")]
    public virtual PassengerDetail Passenger { get; set; } = null!;

    [InverseProperty("Request")]
    public virtual ICollection<QueueItem> QueueItems { get; set; } = new List<QueueItem>();

    [ForeignKey("StatusId")]
    [InverseProperty("PassengerRequests")]
    public virtual Code Status { get; set; } = null!;

    [InverseProperty("Request")]
    public virtual ICollection<TripPassenger> TripPassengers { get; set; } = new List<TripPassenger>();
}
