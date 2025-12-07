using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("transactions")]
public partial class Transaction
{
    [Key]
    [Column("transaction_id")]
    public long TransactionId { get; set; }

    [Column("driver_id")]
    public int? DriverId { get; set; }

    [Column("passenger_id")]
    public int? PassengerId { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("amount", TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [Column("balance_after", TypeName = "decimal(10, 2)")]
    public decimal? BalanceAfter { get; set; }

    [Column("reference")]
    [StringLength(255)]
    public string? Reference { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("Transactions")]
    public virtual DriverDetail? Driver { get; set; }

    [ForeignKey("PassengerId")]
    [InverseProperty("Transactions")]
    public virtual PassengerDetail? Passenger { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("Transactions")]
    public virtual Code Type { get; set; } = null!;
}
