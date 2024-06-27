using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UploadToSheets.DTOS;

namespace UploadToSheets.DBContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    private readonly string connectionString = "Data Source=WIN-K1TRUVHT0PC\\XUMGPC;Initial Catalog=xumlocal;User ID=XumAdmin;Password=Lolipopchainsaw3; TrustServerCertificate=True;";
    //private readonly string connectionString = "Data Source=DESKTOP-V7HB0MU\\MSSQLSERVER01;Initial Catalog=xumlocal;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=True;";
    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<ManifestTable> ManifestTables { get; set; }

    public virtual DbSet<Qcresult> Qcresults { get; set; }

    public virtual DbSet<ReplacedPart> ReplacedParts { get; set; }

    public virtual DbSet<ReturnsInfo> ReturnsInfos { get; set; }

    public virtual DbSet<ServiceTag> ServiceTags { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<Skuview> Skuviews { get; set; }

    public virtual DbSet<StaffTable> StaffTables { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27E1D2AD5B");

            entity.ToTable("CustomerInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChannelReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderId)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("OrderID");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC07F5038045");

            entity.ToTable("History");

            entity.Property(e => e.AssignedNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("Unknown");
            entity.Property(e => e.Channel)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Orderid)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PackedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("Unknown");
            entity.Property(e => e.PackedDate).HasColumnType("datetime");
            entity.Property(e => e.Qty)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("QTY");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.TestStatus)
                .HasMaxLength(25)
                .HasDefaultValue("Unknown")
                .IsFixedLength();
            entity.Property(e => e.TestedBy)
                .HasMaxLength(25)
                .HasDefaultValue("Not Tested")
                .IsFixedLength();
        });

        modelBuilder.Entity<ManifestTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ManifestTable");

            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.OrderSku)
                .HasMaxLength(250)
                .HasColumnName("OrderSKU");
            entity.Property(e => e.PackedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Prebuild).HasMaxLength(50);
            entity.Property(e => e.PrebuildSku)
                .HasMaxLength(250)
                .HasColumnName("PrebuildSKU");
        });

        modelBuilder.Entity<Qcresult>(entity =>
        {
            entity.HasKey(e => e.QcresultId).HasName("PK__QCResult__5ED0A44F957CCB4C");

            entity.ToTable("QCResults");

            entity.Property(e => e.QcresultId).HasColumnName("QCResultId");
            entity.Property(e => e.DbId)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.IotestPassed).HasColumnName("IOTestPassed");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PixelTest).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.QctestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("QCTestDate");
            entity.Property(e => e.WifiTest).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<ReplacedPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Replaced__7C3F0D50DBC6DDCC");

            entity.Property(e => e.PartName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PartSku)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PartSKU");

            entity.HasOne(d => d.Return).WithMany(p => p.ReplacedParts)
                .HasForeignKey(d => d.ReturnId)
                .HasConstraintName("FK__ReplacedP__Retur__4F47C5E3");
        });

        modelBuilder.Entity<ReturnsInfo>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__ReturnsI__F445E9A890990FE8");

            entity.ToTable("ReturnsInfo");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.AdditionalRepairInfo).HasColumnType("text");
            entity.Property(e => e.AdditionalReturnInfo).HasColumnType("text");
            entity.Property(e => e.Diagnosis).HasColumnType("text");
            entity.Property(e => e.OrderId)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("OrderID");
            entity.Property(e => e.ReasonForReturn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceTag>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ServiceKey)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.ToTable("SKUS");

            entity.Property(e => e.Case)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CASE");
            entity.Property(e => e.Cpu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CPU");
            entity.Property(e => e.Gpu)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("GPU");
            entity.Property(e => e.Hdd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("HDD");
            entity.Property(e => e.Mobo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MOBO");
            entity.Property(e => e.Ram)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("RAM");
            entity.Property(e => e.Sku1)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.Ssd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSD");
            entity.Property(e => e.Windows)
                .HasMaxLength(25)
                .HasDefaultValue("Windows 11 Home")
                .IsFixedLength();
        });

        modelBuilder.Entity<Skuview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SKUview");

            entity.Property(e => e.Case)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CASE");
            entity.Property(e => e.Cpu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CPU");
            entity.Property(e => e.Gpu)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("GPU");
            entity.Property(e => e.Hdd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("HDD");
            entity.Property(e => e.Mobo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MOBO");
            entity.Property(e => e.Ram)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("RAM");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.Ssd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSD");
        });

        modelBuilder.Entity<StaffTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StaffTable");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.TestResultId).HasName("PK__TestResu__E24635876C73A7A8");

            entity.Property(e => e.BatteryLife)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CpumaxTemp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CPUMaxTemp");
            entity.Property(e => e.DbId)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.GpumaxTemp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("GPUMaxTemp");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
