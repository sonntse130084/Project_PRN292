namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phone()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PhotoPhones = new HashSet<PhotoPhone>();
        }

        [StringLength(8)]
        public string phoneID { get; set; }

        [Required]
        [StringLength(50)]
        public string phoneName { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public double discount { get; set; }

        [Required]
        [StringLength(8)]
        public string supID { get; set; }

        public DateTime? insertDate { get; set; }

        public bool status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoPhone> PhotoPhones { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Phone phone &&
                   phoneID == phone.phoneID;
        }

        public override int GetHashCode()
        {
            return 110667698 + EqualityComparer<string>.Default.GetHashCode(phoneID);
        }
    }
}
