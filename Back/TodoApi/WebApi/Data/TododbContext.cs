using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public partial class TododbContext : DbContext
{
    public TododbContext()
    {
    }

    public TododbContext(DbContextOptions<TododbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesInfo> RolesInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=postgres;Database=tododb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("role_id");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");

            entity.HasOne(d => d.RoleNavigation).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_role");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<RolesInfo>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pk");

            entity.ToTable("roles_info");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.HashPass)
                .HasColumnType("character varying")
                .HasColumnName("hash_pass");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
