using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("driver_details")]
public partial class DriverDetail
{
    [Key]
    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("vehicle_type")]
    [StringLength(100)]
    public string? VehicleType { get; set; }

    [Column("plate_number")]
    [StringLength(50)]
    public string? PlateNumber { get; set; }

    [Column("photo_url")]
    [StringLength(300)]
    public string? PhotoUrl { get; set; }

    [Column("id_image_url")]
    [StringLength(300)]
    public string? IdImageUrl { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("current_line_id")]
    public int? CurrentLineId { get; set; }

    [Column("is_available")]
    public bool? IsAvailable { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("CurrentLineId")]
    [InverseProperty("DriverDetails")]
    public virtual Line? CurrentLine { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<DriverLocation> DriverLocations { get; set; } = new List<DriverLocation>();

    [InverseProperty("Driver")]
    public virtual ICollection<DriverPosition> DriverPositions { get; set; } = new List<DriverPosition>();

    [InverseProperty("Driver")]
    public virtual ICollection<DriverSubscription> DriverSubscriptions { get; set; } = new List<DriverSubscription>();

    [InverseProperty("Driver")]
    public virtual DriverWallet? DriverWallet { get; set; }

    [InverseProperty("Driver")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    [ForeignKey("StatusId")]
    [InverseProperty("DriverDetails")]
    public virtual Code Status { get; set; } = null!;

    [InverseProperty("Driver")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("Driver")]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    [ForeignKey("UserId")]
    [InverseProperty("DriverDetails")]
    public virtual AspNetUser User { get; set; } = null!;
}
