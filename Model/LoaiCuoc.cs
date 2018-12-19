namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCuoc")]
    public partial class LoaiCuoc
    {
        [Key]
        public int IdCuoc { get; set; }

        public TimeSpan TG_BatDau { get; set; }

        public TimeSpan TG_KetThuc { get; set; }

        public int GiaCuoc { get; set; }

        public bool Status { get; set; }
    }
}
