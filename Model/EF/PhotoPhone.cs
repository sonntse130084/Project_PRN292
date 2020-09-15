namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoPhone")]
    public partial class PhotoPhone
    {
        [Key]
        public int photoID { get; set; }

        [Required]
        [StringLength(300)]
        public string urlPhoto { get; set; }

        [Required]
        [StringLength(8)]
        public string phoneID { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public virtual Phone Phone { get; set; }
    }
}
