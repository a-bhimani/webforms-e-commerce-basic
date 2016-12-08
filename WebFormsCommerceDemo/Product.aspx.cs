using System;
using System.Linq;
using WebFormsCommerceDemo.Models;
using static WebFormsCommerceDemo.Properties.Settings;

namespace WebFormsCommerceDemo.Protected
{
	public partial class Product : System.Web.UI.Page
	{
		int product_id = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["product_id"], out product_id);
			SrvContext dbCtx = new SrvContext();
			if ((product_id > 0) && (dbCtx.Products
																			.Where(el => (el.ProductID == product_id))
																			.Count() == 1))
			{
				WebFormsCommerceDemo.Models.Product currProduct = dbCtx.Products
																																.Where(el => el.ProductID == product_id)
																																.First();
				ltlProductName.Text = currProduct.Name;
				ltlPrice.Text = string.Format("{0:C}", currProduct.UnitPrice);
				ltlDescription.Text = currProduct.Description;
				imgProduct.ImageUrl = currProduct.ImagePath;
				if (!currProduct.IsAvailable)
				{
					lblStock.CssClass = lblStock.CssClass.Replace("label-success", "label-danger");
					lblStock.Text = "Unavailable";
					btnAddToCart.Disabled = true;
				}
				lnkCategory.PostBackUrl = ("/?category_id=" + currProduct.CategoryID);
				lnkCategory.Text = currProduct.Category.Name;
			}
			else
			{
				plhBreadCrumbs.Visible = false;
				plhProductDetails.Visible = false;
				plhProductDescription.Visible = false;
				plhNoContent.Visible = true;
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (!(IsPostBack) && (Generics.IfNullString(Request.QueryString["cart_added"]) == "true"))
			{
				SrvContext dbCtx = new SrvContext();
				vwAddedCart.InnerText = vwAddedCart.InnerText.Replace("{{Product}}", dbCtx.Products.Where(el => (el.ProductID == product_id)).Single().Name);
				vwAddedCart.Visible = true;
			}
		}

		protected void btnAddToCart_Click(object sender, EventArgs e)
		{
			Guid testId;
			if (Guid.TryParse(Generics.IfNullString(Default.AppUserUniqueKey), out testId))
			{
				if (Mediator.doAddCartItem(product_id))
				{
					Response.Redirect(Request.Path + "/?product_id=" + product_id + "&cart_added=true");
				}
				else
				{
					vwAddedCart.InnerText = "There was an error adding the product to your cart.";
					vwAddedCart.Attributes["class"] = vwAddedCart.Attributes["class"].Replace("-success", "-danger");
					vwAddedCart.Visible = true;
				}
			}
			else
			{
				Response.Redirect("/Login/?logon=enabled");
			}
		}
	}
}
