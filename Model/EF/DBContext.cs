namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhotoPhone> PhotoPhones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.phoneID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.addressShip)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.receiver)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phone>()
                .Property(e => e.phoneID)
                .IsUnicode(false);

            modelBuilder.Entity<Phone>()
                .Property(e => e.phoneName)
                .IsUnicode(false);

            modelBuilder.Entity<Phone>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Phone>()
                .Property(e => e.supID)
                .IsUnicode(false);

            modelBuilder.Entity<Phone>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Phone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phone>()
                .HasMany(e => e.PhotoPhones)
                .WithRequired(e => e.Phone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoPhone>()
                .Property(e => e.urlPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<PhotoPhone>()
                .Property(e => e.phoneID)
                .IsUnicode(false);

            modelBuilder.Entity<PhotoPhone>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supID)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.roleID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
