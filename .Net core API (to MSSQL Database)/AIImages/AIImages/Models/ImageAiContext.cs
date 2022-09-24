using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AIImages.Models;

public partial class ImageAiContext : DbContext
{
    public ImageAiContext()
    {
    }

    public ImageAiContext(DbContextOptions<ImageAiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiimageDetail> AiimageDetails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-J25OHBDE;Database=ImageAI;Trusted_Connection=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiimageDetail>(entity =>
        {
            entity.ToTable("AIimageDetails");

            entity.Property(e => e.Id)
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.Classes)
                .HasColumnOrder(4)
                .HasColumnType("text")
                .HasColumnName("classes");
            entity.Property(e => e.ConfidenceLevel)
                .HasColumnOrder(3)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("confidence_level");
            entity.Property(e => e.Date)
                .HasColumnOrder(1)
                .HasColumnName("date");
            entity.Property(e => e.Image).HasColumnOrder(2);
            entity.Property(e => e.ProcessingTime)
                .HasMaxLength(10)
                .HasColumnOrder(5)
                .IsFixedLength()
                .HasColumnName("processing_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
