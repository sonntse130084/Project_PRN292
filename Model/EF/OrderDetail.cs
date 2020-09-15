namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string phoneID { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public double discount { get; set; }

        public virtual Phone Phone { get; set; }

        public virtual Order Order { get; set; }
    }
}
