using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("driver_attachments")]
public partial class DriverAttachment
{
    [Key]
    [Column("attachment_id")]
    public int AttachmentId { get; set; }

    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("type_code_id")]
    public int TypeCodeId { get; set; }

    [Column("file_url")]
    public string FileUrl { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("DriverAttachments")]
    public virtual DriverDetail Driver { get; set; } = null!;

    [ForeignKey("TypeCodeId")]
    [InverseProperty("DriverAttachments")]
    public virtual Code TypeCode { get; set; } = null!;
}
