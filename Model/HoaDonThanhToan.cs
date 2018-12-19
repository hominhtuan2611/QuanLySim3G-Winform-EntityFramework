namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonThanhToan")]
    public partial class HoaDonThanhToan
    {
        [Key]
        public int MaHD { get; set; }

        public int MaKH { get; set; }

        public int MaSim { get; set; }

        public decimal CuocThueBao { get; set; }

        public DateTime NgayHD { get; set; }

        public bool ThanhToan { get; set; }

        public decimal ThanhTien { get; set; }

        public bool Status { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Sim Sim { get; set; }
    }
}
