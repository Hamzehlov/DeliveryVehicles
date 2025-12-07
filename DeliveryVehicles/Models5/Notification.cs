using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("notifications")]
public partial class Notification
{
    [Key]
    [Column("notification_id")]
    public long NotificationId { get; set; }

    [Column("user_type")]
    [StringLength(50)]
    public string UserType { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("title")]
    [StringLength(200)]
    public string? Title { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("is_sent")]
    public bool? IsSent { get; set; }

    [Column("sent_at", TypeName = "datetime")]
    public DateTime? SentAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
