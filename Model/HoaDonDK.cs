namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonDK")]
    public partial class HoaDonDK
    {
        [Key]
        public int MaHD { get; set; }

        public int MaSim { get; set; }

        public DateTime NgayDK { get; set; }

        public decimal ChiPhi { get; set; }

        public int MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Sim Sim { get; set; }
    }
}
