using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("lines")]
public partial class Line
{
    [Key]
    [Column("line_id")]
    public int LineId { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("from_area")]
    [StringLength(150)]
    public string? FromArea { get; set; }

    [Column("to_area")]
    [StringLength(150)]
    public string? ToArea { get; set; }

    [Column("seats_per_vehicle")]
    public int? SeatsPerVehicle { get; set; }

    [Column("default_price", TypeName = "decimal(10, 2)")]
    public decimal? DefaultPrice { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("estimated_duration_minutes")]
    public int? EstimatedDurationMinutes { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("CurrentLine")]
    public virtual ICollection<DriverDetail> DriverDetails { get; set; } = new List<DriverDetail>();

    [InverseProperty("Line")]
    public virtual ICollection<DriverPosition> DriverPositions { get; set; } = new List<DriverPosition>();

    [InverseProperty("Line")]
    public virtual ICollection<PassengerRequest> PassengerRequests { get; set; } = new List<PassengerRequest>();

    [InverseProperty("Line")]
    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();
}
