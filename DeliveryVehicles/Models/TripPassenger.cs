using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("trip_passengers")]
public partial class TripPassenger
{
    [Key]
    [Column("trip_passenger_id")]
    public int TripPassengerId { get; set; }

    [Column("trip_id")]
    public int TripId { get; set; }

    [Column("request_id")]
    public int RequestId { get; set; }

    [Column("seats_assigned")]
    public int? SeatsAssigned { get; set; }

    [Column("pickup_lat", TypeName = "decimal(10, 7)")]
    public decimal? PickupLat { get; set; }

    [Column("pickup_lng", TypeName = "decimal(10, 7)")]
    public decimal? PickupLng { get; set; }

    [Column("added_at", TypeName = "datetime")]
    public DateTime? AddedAt { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("TripPassengers")]
    public virtual PassengerRequest Request { get; set; } = null!;

    [ForeignKey("TripId")]
    [InverseProperty("TripPassengers")]
    public virtual Trip Trip { get; set; } = null!;
}
