using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("driver_wallets")]
public partial class DriverWallet
{
    [Key]
    [Column("driver_id")]
    public int DriverId { get; set; }

    [Column("balance", TypeName = "decimal(12, 2)")]
    public decimal? Balance { get; set; }

    [Column("reserved", TypeName = "decimal(12, 2)")]
    public decimal? Reserved { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("DriverWallet")]
    public virtual DriverDetail Driver { get; set; } = null!;
}
