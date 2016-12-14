namespace AutoServis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        public int id { get; set; }

        [StringLength(10)]
        public string email { get; set; }

        [StringLength(10)]
        public string ime { get; set; }

        [StringLength(30)]
        public string prezime { get; set; }

        [Required]
        [StringLength(30)]
        public string lozinka { get; set; }

        [StringLength(20)]
        public string brTel { get; set; }
    }
}
