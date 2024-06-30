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

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<Cpu> Cpus { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<Gpu> Gpus { get; set; }

    public virtual DbSet<Hdd> Hdds { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<ManifestTable> ManifestTables { get; set; }

    public virtual DbSet<Motherboard> Motherboards { get; set; }

    public virtual DbSet<Qcresult> Qcresults { get; set; }

    public virtual DbSet<Ramsize> Ramsizes { get; set; }

    public virtual DbSet<ReplacedPart> ReplacedParts { get; set; }

    public virtual DbSet<ReturnsInfo> ReturnsInfos { get; set; }

    public virtual DbSet<ServiceTag> ServiceTags { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<Skuview> Skuviews { get; set; }

    public virtual DbSet<Ssd> Ssds { get; set; }

    public virtual DbSet<StaffTable> StaffTables { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<Window> Windows { get; set; }

    public virtual DbSet<WindowsKeyDatum> WindowsKeyData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FDI3A84;Initial Catalog=xumlocal;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=True;");
        //=> optionsBuilder.UseSqlServer("Data Source=WIN-K1TRUVHT0PC\\XUMGPC;Initial Catalog=xumlocal;Persist Security Info=True;User ID=XumAdmin;Password=Lolipopchainsaw3;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27E1D2AD5B");

            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC07F5038045");

            entity.Property(e => e.AssignedNumber).HasDefaultValue("Unknown");
            entity.Property(e => e.Channel).IsFixedLength();
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Orderid).IsFixedLength();
            entity.Property(e => e.PackedBy).HasDefaultValue("Unknown");
            entity.Property(e => e.Qty).IsFixedLength();
            entity.Property(e => e.TestStatus)
                .HasDefaultValue("Unknown")
                .IsFixedLength();
            entity.Property(e => e.TestedBy)
                .HasDefaultValue("Not Tested")
                .IsFixedLength();
        });

        modelBuilder.Entity<ManifestTable>(entity =>
        {
            entity.Property(e => e.PackedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Qcresult>(entity =>
        {
            entity.HasKey(e => e.QcresultId).HasName("PK__QCResult__5ED0A44F957CCB4C");

            entity.Property(e => e.DbId).IsFixedLength();
            entity.Property(e => e.PixelTest).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.QctestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WifiTest).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<ReplacedPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Replaced__7C3F0D50DBC6DDCC");

            entity.HasOne(d => d.Return).WithMany(p => p.ReplacedParts).HasConstraintName("FK__ReplacedP__Retur__4F47C5E3");
        });

        modelBuilder.Entity<ReturnsInfo>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__ReturnsI__F445E9A890990FE8");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.OrderId).IsFixedLength();
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.Property(e => e.Case).IsFixedLength();
            entity.Property(e => e.Cpu).IsFixedLength();
            entity.Property(e => e.Gpu).IsFixedLength();
            entity.Property(e => e.Hdd).IsFixedLength();
            entity.Property(e => e.Mobo).IsFixedLength();
            entity.Property(e => e.Ram).IsFixedLength();
            entity.Property(e => e.Ssd).IsFixedLength();
            entity.Property(e => e.Windows)
                .HasDefaultValue("Windows 11 Home")
                .IsFixedLength();
        });

        modelBuilder.Entity<Skuview>(entity =>
        {
            entity.ToView("SKUview");

            entity.Property(e => e.Case).IsFixedLength();
            entity.Property(e => e.Cpu).IsFixedLength();
            entity.Property(e => e.Gpu).IsFixedLength();
            entity.Property(e => e.Hdd).IsFixedLength();
            entity.Property(e => e.Mobo).IsFixedLength();
            entity.Property(e => e.Ram).IsFixedLength();
            entity.Property(e => e.Ssd).IsFixedLength();
        });

        modelBuilder.Entity<StaffTable>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.TestResultId).HasName("PK__TestResu__E24635876C73A7A8");

            entity.Property(e => e.BatteryLife).IsFixedLength();
            entity.Property(e => e.DbId).IsFixedLength();
        });

        modelBuilder.Entity<WindowsKeyDatum>(entity =>
        {
            entity.HasKey(e => e.ServiceTag).HasName("PK__WindowsK__71080053B0244076");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
