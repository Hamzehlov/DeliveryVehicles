using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models;

[Table("codes")]
public partial class Code
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code_name_ar")]
    [StringLength(100)]
    public string CodeNameAr { get; set; } = null!;

    [Column("code_name_en")]
    [StringLength(100)]
    public string CodeNameEn { get; set; } = null!;

    [Column("code_value")]
    [StringLength(50)]
    public string CodeValue { get; set; } = null!;

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("category")]
    [StringLength(50)]
    public string Category { get; set; } = null!;

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    [InverseProperty("Status")]
    public virtual ICollection<DriverDetail> DriverDetails { get; set; } = new List<DriverDetail>();

    [InverseProperty("Parent")]
    public virtual ICollection<Code> InverseParent { get; set; } = new List<Code>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Code? Parent { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<PassengerRequest> PassengerRequests { get; set; } = new List<PassengerRequest>();

    [InverseProperty("Status")]
    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();

    [InverseProperty("Type")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("Status")]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
