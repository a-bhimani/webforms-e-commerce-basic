using System;
using System.Linq;
using System.Web.UI;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo
{
	public partial class submap1 : MasterPage
	{
		private int category_id = 0;
		protected int getActiveCategoryID { get { return this.category_id; } }

		protected void Page_Init(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["category_id"], out this.category_id);
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public IQueryable<Category> FetchCategories()
		{
			return (new SrvContext()).Categories;
		}
	}
}
