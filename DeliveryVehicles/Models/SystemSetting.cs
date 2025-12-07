using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("system_settings")]
[Index("KeyName", Name = "UQ__system_s__846621D30F8973A1", IsUnique = true)]
public partial class SystemSetting
{
    [Key]
    [Column("setting_id")]
    public int SettingId { get; set; }

    [Column("key_name")]
    [StringLength(100)]
    public string KeyName { get; set; } = null!;

    [Column("value")]
    [StringLength(255)]
    public string Value { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
