using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFormsCommerceDemo.Models
{
	public class Order
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Order()
		{
			CartItems = new HashSet<CartItem>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderID { get; set; }

		[Required]
		public Guid UniqueOrderNumber { get; set; }

		[Required]
		public DateTime OrderDate { get; set; }

		//BILLING
		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[StringLength(180)]
		[DataType(DataType.MultilineText)]
		public string BillingAddress { get; set; }

		[Required]
		[StringLength(60)]
		public string BillingCity { get; set; }

		[Required]
		[StringLength(60)]
		public string BillingState { get; set; }

		[Required]
		[Range(10000, 99999)]
		public int BillingZip { get; set; }

		//SHIPPING
		[Required]
		[StringLength(180)]
		[DataType(DataType.MultilineText)]
		public string ShippingAddress { get; set; }

		[Required]
		[StringLength(60)]
		public string ShippingCity { get; set; }

		[Required]
		[StringLength(60)]
		public string ShippingState { get; set; }

		[Required]
		[Range(10000, 99999)]
		public int ShippingZip { get; set; }

		public double TaxSum { get; set; } //@ 10%

		[DataType(DataType.Currency)]
		public double TotalSum { get; set; }

		[Required]
		public bool IsOrdered { get; set; }

		public string Notes { get; set; }

		[ForeignKey("Customer")]
		public int CustomerID { get; set; }

		public virtual Customer Customer { get; set; }

		public virtual ICollection<CartItem> CartItems { get; set; }
	}
}
