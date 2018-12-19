namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuocGoi")]
    public partial class CuocGoi
    {
        [Key]
        public int MaCuocGoi { get; set; }

        public int MaSim { get; set; }

        public DateTime TG_BatDau { get; set; }

        public DateTime TG_KetThuc { get; set; }

        public double SoPhutSD { get; set; }

        public decimal? ThanhTien { get; set; }

        public virtual Sim Sim { get; set; }
    }
}
