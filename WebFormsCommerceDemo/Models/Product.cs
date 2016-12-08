using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebFormsCommerceDemo.Models
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductID { get; set; }

		[Required]
		[StringLength(155)]
		public string Name { get; set; }

		[StringLength(2000)]
		public string Description { get; set; }

		public string ImagePath { get; set; }

		[DataType(DataType.Currency)]
		public double? UnitPrice { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsFeatured { get; set; }

		[ForeignKey("Category")]
		public int CategoryID { get; set; }

		public virtual Category Category { get; set; }
	}
}
