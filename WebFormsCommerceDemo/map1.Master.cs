using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsCommerceDemo.Models;
using static WebFormsCommerceDemo.Properties.Settings;

namespace WebFormsCommerceDemo
{
	public partial class map1 : MasterPage
	{
		private Guid testId;
		protected string PrintUsername = string.Empty;
		protected int CartItemCount = 0;
		protected double CartItemTotal = 0;

		protected void Page_Init(object sender, EventArgs e)
		{
			txtSearch.Value = Request.QueryString["q"];
			if (Guid.TryParse(Generics.IfNullString(Default.AppUserUniqueKey), out testId))
			{
				//PrintUsername = Generics.IfNullString();
				PrintUsername = "abhimani@hawk.iit.edu";
				//vwCart.Visible = true;
				vwUser.Visible = true;
				vwLogin.Visible = false;
				vwFooterUser.Visible = true;
				vwFooterLogin.Visible = false;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.FetchCartItems();
		}

		public IQueryable<CartItem> FetchCartItems()
		{
			SrvContext dbCtx = new SrvContext();
			IQueryable<CartItem> lstCartItems = dbCtx.CartItems
																								.Where(el => (el.Customer.UniqueKey == testId)
																																&&
																															el.IsActive);
			CartItemCount = lstCartItems.Count();
			if (CartItemCount > 0)
			{
				CartItemTotal = lstCartItems.Select(el => el.ItemPrice).Sum();
				vwCheckout.Visible = true;
			}
			return lstCartItems;
		}

		public IQueryable<Category> FetchCategories()
		{
			SrvContext dbCtx = new SrvContext();
			return dbCtx.Categories;
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			Response.Redirect("/?q=" + txtSearch.Value);
		}

		protected void btnLogout_Click(object sender, EventArgs e)
		{
			//Session.Clear();
			//Session.Abandon();
			//FormsAuthentication.SignOut();
			Response.Redirect("/Login/?logout=true");
		}

		protected void btnRemoveCartItem_Click(object sender, CommandEventArgs e)
		{
			try
			{
				Mediator.doRemoveCartItem(int.Parse(Generics.IfNullString(e.CommandArgument)));
				Response.Redirect(Request.RawUrl);
			}
			catch
			{
				;
			}
		}
	}
}
