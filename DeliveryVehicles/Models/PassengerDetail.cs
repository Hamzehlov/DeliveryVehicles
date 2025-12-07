using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("passenger_details")]
public partial class PassengerDetail
{
    [Key]
    [Column("passenger_id")]
    public int PassengerId { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Passenger")]
    public virtual ICollection<PassengerRequest> PassengerRequests { get; set; } = new List<PassengerRequest>();

    [InverseProperty("Passenger")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    [InverseProperty("Passenger")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("UserId")]
    [InverseProperty("PassengerDetails")]
    public virtual ApplicationUser User { get; set; } = null!;
}
