using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutostoreProject.DBEntities;

public partial class AScaDbContext : DbContext
{
    private IConfiguration _configuration;
    public AScaDbContext(IConfiguration configuration)
    :base()
    {
        _configuration = configuration;
    }

    public AScaDbContext(DbContextOptions<AScaDbContext> options,IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    public virtual DbSet<ADepartment> ADepartments { get; set; }

    public virtual DbSet<ADepartmentDetail> ADepartmentDetails { get; set; }

    public virtual DbSet<APage> APages { get; set; }

    public virtual DbSet<APagePermission> APagePermissions { get; set; }

    public virtual DbSet<ARole> ARoles { get; set; }

    public virtual DbSet<AShift> AShifts { get; set; }

    public virtual DbSet<AShiftDetail> AShiftDetails { get; set; }

    public virtual DbSet<AUrlaub> AUrlaubs { get; set; }

    public virtual DbSet<AUrlaubDetail> AUrlaubDetails { get; set; }

    public virtual DbSet<AUser> AUsers { get; set; }

    public virtual DbSet<AUserPassword> AUserPasswords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ADepartment>(entity =>
        {
            entity.ToTable("A_Department");

            entity.Property(e => e.CreatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ADepartmentDetail>(entity =>
        {
            entity.ToTable("A_DepartmentDetail");

            entity.Property(e => e.PersonalNr).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.WorkStation).HasMaxLength(50);
        });

        modelBuilder.Entity<APage>(entity =>
        {
            entity.ToTable("A_Page");

            entity.Property(e => e.PageName).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<APagePermission>(entity =>
        {
            entity.ToTable("A_PagePermission");
        });

        modelBuilder.Entity<ARole>(entity =>
        {
            entity.ToTable("A_Role");

            entity.Property(e => e.CreatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AShift>(entity =>
        {
            entity.ToTable("A_Shift");

            entity.Property(e => e.AssignedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AuthorizedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AuthorizedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AShiftDetail>(entity =>
        {
            entity.ToTable("A_ShiftDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDateTime).HasColumnType("datetime");
            entity.Property(e => e.ToDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AUrlaub>(entity =>
        {
            entity.ToTable("A_Urlaub");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.PersonalNr).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<AUrlaubDetail>(entity =>
        {
            entity.ToTable("A_UrlaubDetail");

            entity.Property(e => e.ApprovedBy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AUser>(entity =>
        {
            entity.ToTable("A_User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Islinked)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<AUserPassword>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("A_UserPassword");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
