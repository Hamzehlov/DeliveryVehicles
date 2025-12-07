using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeliveryVehicles.Models5;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<DriverDetail> DriverDetails { get; set; }

    public virtual DbSet<DriverLocation> DriverLocations { get; set; }

    public virtual DbSet<DriverPosition> DriverPositions { get; set; }

    public virtual DbSet<DriverSubscription> DriverSubscriptions { get; set; }

    public virtual DbSet<DriverWallet> DriverWallets { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<PassengerDetail> PassengerDetails { get; set; }

    public virtual DbSet<PassengerRequest> PassengerRequests { get; set; }

    public virtual DbSet<Queue> Queues { get; set; }

    public virtual DbSet<QueueItem> QueueItems { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripPassenger> TripPassengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KDV3O5C;Database=DeliveryVehiclesDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.FirstName).HasDefaultValue("");
            entity.Property(e => e.LastName).HasDefaultValue("");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getutcdate())");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__codes__3213E83F56E2E59E");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("fk_codes_parent");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__complain__A771F61C8E3E3BC6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ToUserType).HasDefaultValue("system");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Status).WithMany(p => p.Complaints)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_compl_status");

            entity.HasOne(d => d.Trip).WithMany(p => p.Complaints).HasConstraintName("fk_compl_trip");
        });

        modelBuilder.Entity<DriverDetail>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__driver_d__A411C5BDF3116871");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CurrentLine).WithMany(p => p.DriverDetails).HasConstraintName("fk_driver_line");

            entity.HasOne(d => d.Status).WithMany(p => p.DriverDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_status");

            entity.HasOne(d => d.User).WithMany(p => p.DriverDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_user");
        });

        modelBuilder.Entity<DriverLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__driver_l__771831EA58D16CBC");

            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver_location");
        });

        modelBuilder.Entity<DriverPosition>(entity =>
        {
            entity.HasKey(e => e.PosId).HasName("PK__driver_p__D1A4EB12F2B1DFAE");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SkipCount).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pos_driver");

            entity.HasOne(d => d.Line).WithMany(p => p.DriverPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pos_line");
        });

        modelBuilder.Entity<DriverSubscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__driver_s__863A7EC1AD670945");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sub_driver");
        });

        modelBuilder.Entity<DriverWallet>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__driver_w__A411C5BD500874A0");

            entity.Property(e => e.DriverId).ValueGeneratedNever();
            entity.Property(e => e.Balance).HasDefaultValue(0.00m);
            entity.Property(e => e.Reserved).HasDefaultValue(0.00m);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithOne(p => p.DriverWallet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_wallet_driver");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("PK__lines__F5AE5F6252D86421");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DefaultPrice).HasDefaultValue(0.00m);
            entity.Property(e => e.SeatsPerVehicle).HasDefaultValue(4);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842FB645E06A");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsSent).HasDefaultValue(false);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__offers__03D37AC217DB3F7E");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DiscountPercentage).HasDefaultValue(0.00m);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<PassengerDetail>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__passenge__03764586CB22B915");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.PassengerDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_passenger_user");
        });

        modelBuilder.Entity<PassengerRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__passenge__18D3B90FAC4482C1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SeatsRequested).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Line).WithMany(p => p.PassengerRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_req_line");

            entity.HasOne(d => d.Passenger).WithMany(p => p.PassengerRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_req_passenger");

            entity.HasOne(d => d.Status).WithMany(p => p.PassengerRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_req_status");
        });

        modelBuilder.Entity<Queue>(entity =>
        {
            entity.HasKey(e => e.QueueId).HasName("PK__queues__2294FA6EA32892BB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SeatsCollected).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Line).WithMany(p => p.Queues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_queue_line");

            entity.HasOne(d => d.Status).WithMany(p => p.Queues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_queue_status");
        });

        modelBuilder.Entity<QueueItem>(entity =>
        {
            entity.HasKey(e => e.QueueItemId).HasName("PK__queue_it__D83F340E6C0E5538");

            entity.Property(e => e.AddedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Queue).WithMany(p => p.QueueItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qi_queue");

            entity.HasOne(d => d.Request).WithMany(p => p.QueueItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qi_request");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__ratings__D35B278BCEB8A91D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rating_driver");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rating_passenger");

            entity.HasOne(d => d.Trip).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rating_trip");
        });

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PK__system_s__256E1E32853CC4A5");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__transact__85C600AF0CCAD868");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.Transactions).HasConstraintName("fk_trans_driver");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Transactions).HasConstraintName("fk_trans_passenger");

            entity.HasOne(d => d.Type).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trans_type");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__trips__302A5D9E86CDE31B");

            entity.Property(e => e.CommissionAmount).HasDefaultValue(0.00m);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalFare).HasDefaultValue(0.00m);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trip_driver");

            entity.HasOne(d => d.Queue).WithMany(p => p.Trips).HasConstraintName("fk_trip_queue");

            entity.HasOne(d => d.Status).WithMany(p => p.Trips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trip_status");
        });

        modelBuilder.Entity<TripPassenger>(entity =>
        {
            entity.HasKey(e => e.TripPassengerId).HasName("PK__trip_pas__935225D1762F0825");

            entity.Property(e => e.AddedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SeatsAssigned).HasDefaultValue(1);

            entity.HasOne(d => d.Request).WithMany(p => p.TripPassengers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tp_request");

            entity.HasOne(d => d.Trip).WithMany(p => p.TripPassengers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tp_trip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
