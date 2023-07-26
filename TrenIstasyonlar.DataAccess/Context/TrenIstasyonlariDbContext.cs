using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrenIstasyonlar.DataAccess.Entities;

namespace TrenIstasyonlar.DataAccess.Context
{
    public partial class TrenIstasyonlariDbContext:DbContext
    {
        
        public TrenIstasyonlariDbContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<Istasyon> Istasyons { get; set; }

        public virtual DbSet<Kullanici> Kullanicis { get; set; }

        public virtual DbSet<Sefer> Sefers { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Istasyon>(entity =>
            {
                entity.ToTable("Istasyon");

                entity.Property(e => e.IstasyonId).HasColumnName("IstasyonID");
                entity.Property(e => e.IstasyonAdi).HasMaxLength(100);
                entity.Property(e => e.IstasyonAdres)
                    .HasMaxLength(200)
                    .IsFixedLength();
                entity.Property(e => e.IstasyonKonum)
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici");

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
                entity.Property(e => e.KullaniciAdi).HasMaxLength(100);
                entity.Property(e => e.Sifre).HasMaxLength(200);
            });

            modelBuilder.Entity<Sefer>(entity =>
            {
                entity.ToTable("Sefer");

                entity.Property(e => e.SeferId).HasColumnName("SeferID");
                entity.Property(e => e.KalkisIstasyonId).HasColumnName("KalkisIstasyonID");
                entity.Property(e => e.VarisIstasyonId).HasColumnName("VarisIstasyonID");

                entity.HasOne(d => d.KalkisIstasyon).WithMany(p => p.SeferKalkisIstasyons)
                    .HasForeignKey(d => d.KalkisIstasyonId)
                    .HasConstraintName("FK_Sefer_Istasyon");

                entity.HasOne(d => d.VarisIstasyon).WithMany(p => p.SeferVarisIstasyons)
                    .HasForeignKey(d => d.VarisIstasyonId)
                    .HasConstraintName("FK_Sefer_Istasyon1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
