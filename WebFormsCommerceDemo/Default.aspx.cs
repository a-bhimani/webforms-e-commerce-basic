using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo
{
	public partial class _Default : Page
	{
		private int category_id = 0;

		protected void Page_PreLoad(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["category_id"], out this.category_id);
		}

		protected void btnAddToCart_Click(object sender, CommandEventArgs e)
		{
			Guid testId;
			int ProductId = 0;
			if (Guid.TryParse(Generics.IfNullString(Session["UniqueKey"]), out testId) && int.TryParse(Generics.IfNullString(e.CommandArgument), out ProductId))
			{
				if (Mediator.doAddCartItem(ProductId))
				{
					SrvContext dbCtx = new SrvContext();
					vwAddedCart.InnerText = vwAddedCart.InnerText.Replace("{{Product}}", dbCtx.Products.Where(el => (el.ProductID == ProductId)).Single().Name);
				}
				else
				{
					vwAddedCart.InnerText = "There was an error adding the product to your cart.";
					vwAddedCart.Attributes["class"] = vwAddedCart.Attributes["class"].Replace("-success", "-danger");
				}
				vwAddedCart.Visible = true;
			}
			else
			{
				Response.Redirect("/Login/?logon=enabled");
			}
		}

		public IQueryable<Product> FetchProducts()
		{
			SrvContext dbCtx = new SrvContext();
			if ((this.category_id > 0) && (dbCtx.Categories
																							.Where(el => el.CategoryID == category_id))
																							.Count() == 1)
			{
				ltlCategory.Text = dbCtx.Categories
																	.Where(el => el.CategoryID == category_id)
																	.Select(el => el.Name)
																	.First();
				return dbCtx.Products
											.Where(el => el.CategoryID == category_id)
											.OrderBy(el => el.Name);
			}
			else
			{
				if (!(string.IsNullOrEmpty(Request.QueryString["q"])))
				{
					string q = Request.QueryString["q"].ToString();
					ltlCategory.Text = ("Search : " + q);
					return dbCtx.Products
												.Where(el => el.Name.Contains(q) || el.Description.Contains(q))
												.OrderBy(el => el.Name);
				}
				else
				{
					return dbCtx.Products
												.Where(el => el.IsFeatured)
												.OrderByDescending(el => el.CategoryID);
				}
			}
		}
	}
}

