using System.Data.Entity;

namespace WebFormsCommerceDemo.Models
{
	public class SrvContext : DbContext
	{
		public SrvContext()
			: base("ConnHddShoppePrimary")
		{
			//Database.SetInitializer<SrvContext>(null);
		}

		public virtual DbSet<Category> Categories { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<Customer> Customers { get; set; }

		public virtual DbSet<CartItem> CartItems { get; set; }

		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region Categories
			modelBuilder.Entity<Category>()
						.HasMany(el => el.Products)
						.WithRequired(el => el.Category)
						.HasForeignKey(el => el.CategoryID)
						.WillCascadeOnDelete(false);

			modelBuilder.Entity<Category>()
					.Property(el => el.Description)
					.IsUnicode(false);
			#endregion

			#region Products
			modelBuilder.Entity<Product>()
					.Property(el => el.Description)
					.IsUnicode(false);
			#endregion

			#region Customers
			modelBuilder.Entity<Customer>()
				.HasMany(el => el.CartItems)
				.WithRequired(el => el.Customer)
				.HasForeignKey(el => el.CustomerID)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Customer>()
				.HasMany(el => el.Orders)
				.WithRequired(el => el.Customer)
				.HasForeignKey(el => el.CustomerID)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Customer>()
					.Property(el => el.FirstName)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.LastName)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.Username)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.Phone)
					.HasPrecision(10, 0);

			modelBuilder.Entity<Customer>()
					.Property(el => el.BillingAddress)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.BillingCity)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.BillingState)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.ShippingAddress)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.ShippingCity)
					.IsUnicode(false);

			modelBuilder.Entity<Customer>()
					.Property(el => el.ShippingState)
					.IsUnicode(false);
			#endregion

			#region CartItems

			#endregion

			#region Orders
			modelBuilder.Entity<Order>()
				.HasMany(el => el.CartItems);

			modelBuilder.Entity<Order>()
					.Property(el => el.FirstName)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.LastName)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.BillingAddress)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.BillingCity)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.BillingState)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.ShippingAddress)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.ShippingCity)
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.Property(el => el.ShippingState)
					.IsUnicode(false);
			#endregion
		}
	}
}
