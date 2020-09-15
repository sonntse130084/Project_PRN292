namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [Required]
        [StringLength(8)]
        public string roleID { get; set; }

        [Required]
        [StringLength(300)]
        public string avatar { get; set; }

        public bool status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Role Role { get; set; }
    }
}
