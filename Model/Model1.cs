namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CuocGoi> CuocGoi { get; set; }
        public virtual DbSet<HoaDonDK> HoaDonDK { get; set; }
        public virtual DbSet<HoaDonThanhToan> HoaDonThanhToan { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiCuoc> LoaiCuoc { get; set; }
        public virtual DbSet<Sim> Sim { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuocGoi>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDonDK>()
                .Property(e => e.ChiPhi)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDonThanhToan>()
                .Property(e => e.CuocThueBao)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDonThanhToan>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDonDKs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDonThanhToans)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sim>()
                .HasMany(e => e.CuocGois)
                .WithRequired(e => e.Sim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sim>()
                .HasMany(e => e.HoaDonDKs)
                .WithRequired(e => e.Sim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sim>()
                .HasMany(e => e.HoaDonThanhToans)
                .WithRequired(e => e.Sim)
                .WillCascadeOnDelete(false);
        }
    }
}
