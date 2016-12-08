using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFormsCommerceDemo.Models
{
	public class Customer
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Customer()
		{
			CartItems = new HashSet<CartItem>();
			Orders = new HashSet<Order>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerID { get; set; }

		[Required]
		public Guid UniqueKey { get; set; }

		[Required]
		[StringLength(155)]
		[EmailAddress]
		[Index(IsUnique = true)]
		public string Username { get; set; }

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[Column(TypeName = "numeric")]
		[Range(1000000000, 9999999999)]
		public decimal Phone { get; set; }

		[Required]
		[MaxLength(32)]
		public byte[] PasswordBin { get; set; }

		[Required]
		public bool IsActive { get; set; }

		//BILLING
		[StringLength(180)]
		[DataType(DataType.MultilineText)]
		public string BillingAddress { get; set; }

		[StringLength(60)]
		public string BillingCity { get; set; }

		[StringLength(60)]
		public string BillingState { get; set; }

		[Range(10000, 99999)]
		public int? BillingZip { get; set; }

		//SHIPPING
		[StringLength(180)]
		[DataType(DataType.MultilineText)]
		public string ShippingAddress { get; set; }

		[StringLength(60)]
		public string ShippingCity { get; set; }

		[StringLength(60)]
		public string ShippingState { get; set; }

		[Range(10000, 99999)]
		public int? ShippingZip { get; set; }

		public virtual ICollection<CartItem> CartItems { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
