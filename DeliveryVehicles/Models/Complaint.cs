using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("complaints")]
public partial class Complaint
{
    [Key]
    [Column("complaint_id")]
    public int ComplaintId { get; set; }

    [Column("trip_id")]
    public int? TripId { get; set; }

    [Column("from_user_type")]
    [StringLength(50)]
    public string FromUserType { get; set; } = null!;

    [Column("from_user_id")]
    public int FromUserId { get; set; }

    [Column("to_user_type")]
    [StringLength(50)]
    public string? ToUserType { get; set; }

    [Column("to_user_id")]
    public int? ToUserId { get; set; }

    [Column("title")]
    [StringLength(200)]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Complaints")]
    public virtual Code Status { get; set; } = null!;

    [ForeignKey("TripId")]
    [InverseProperty("Complaints")]
    public virtual Trip? Trip { get; set; }
}
