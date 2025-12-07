using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("queue_items")]
public partial class QueueItem
{
    [Key]
    [Column("queue_item_id")]
    public int QueueItemId { get; set; }

    [Column("queue_id")]
    public int QueueId { get; set; }

    [Column("request_id")]
    public int RequestId { get; set; }

    [Column("added_at", TypeName = "datetime")]
    public DateTime? AddedAt { get; set; }

    [ForeignKey("QueueId")]
    [InverseProperty("QueueItems")]
    public virtual Queue Queue { get; set; } = null!;

    [ForeignKey("RequestId")]
    [InverseProperty("QueueItems")]
    public virtual PassengerRequest Request { get; set; } = null!;
}
