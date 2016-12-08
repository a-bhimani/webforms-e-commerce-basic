using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFormsCommerceDemo.Models
{
	public class Category
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Category()
		{
			Products = new HashSet<Product>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryID { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
