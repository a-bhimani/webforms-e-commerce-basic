using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFormsCommerceDemo.Models
{
	public class CartItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartItemID { get; set; }

		[Range(1, 9)]
		public byte Quantity { get; set; }

		[DataType(DataType.Currency)]
		public double ItemPrice { get; set; }

		public bool IsActive { get; set; }

		[ForeignKey("Customer")]
		public int CustomerID { get; set; }

		[ForeignKey("Product")]
		public int ProductID { get; set; }

		[ForeignKey("Order")]
		public int? OrderID { get; set; }

		public virtual Customer Customer { get; set; }

		public virtual Product Product { get; set; }

		public virtual Order Order { get; set; }
	}
}
