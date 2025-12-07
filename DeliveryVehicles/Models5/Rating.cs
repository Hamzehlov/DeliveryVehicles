using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("ratings")]
public partial class Rating
{
    [Key]
    [Column("rating_id")]
    public int RatingId { get; set; }

    [Column("trip_id")]
    public int TripId { get; set; }

    [Column("passenger_id")]
    public int PassengerId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("rating")]
    public byte Rating1 { get; set; }

    [Column("comment")]
    [StringLength(500)]
    public string? Comment { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("Ratings")]
    public virtual DriverDetail Driver { get; set; } = null!;

    [ForeignKey("PassengerId")]
    [InverseProperty("Ratings")]
    public virtual PassengerDetail Passenger { get; set; } = null!;

    [ForeignKey("TripId")]
    [InverseProperty("Ratings")]
    public virtual Trip Trip { get; set; } = null!;
}
