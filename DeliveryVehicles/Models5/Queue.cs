using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

[Table("queues")]
public partial class Queue
{
    [Key]
    [Column("queue_id")]
    public int QueueId { get; set; }

    [Column("line_id")]
    public int LineId { get; set; }

    [Column("seats_needed")]
    public int SeatsNeeded { get; set; }

    [Column("seats_collected")]
    public int? SeatsCollected { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("LineId")]
    [InverseProperty("Queues")]
    public virtual Line Line { get; set; } = null!;

    [InverseProperty("Queue")]
    public virtual ICollection<QueueItem> QueueItems { get; set; } = new List<QueueItem>();

    [ForeignKey("StatusId")]
    [InverseProperty("Queues")]
    public virtual Code Status { get; set; } = null!;

    [InverseProperty("Queue")]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
