using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("driver_positions")]
public partial class DriverPosition
{
    [Key]
    [Column("pos_id")]
    public int PosId { get; set; }

    [Column("line_id")]
    public int LineId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("position_index")]
    public int PositionIndex { get; set; }

    [Column("skip_count")]
    public int? SkipCount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("DriverPositions")]
    public virtual DriverDetail Driver { get; set; } = null!;

    [ForeignKey("LineId")]
    [InverseProperty("DriverPositions")]
    public virtual Line Line { get; set; } = null!;
}
