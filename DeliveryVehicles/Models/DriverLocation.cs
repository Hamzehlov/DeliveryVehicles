using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("driver_locations")]
public partial class DriverLocation
{
    [Key]
    [Column("location_id")]
    public long LocationId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("lat", TypeName = "decimal(10, 7)")]
    public decimal Lat { get; set; }

    [Column("lng", TypeName = "decimal(10, 7)")]
    public decimal Lng { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("DriverLocations")]
    public virtual DriverDetail Driver { get; set; } = null!;
}
