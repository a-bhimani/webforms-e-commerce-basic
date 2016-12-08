using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo.Protected
{
	public partial class Cart : System.Web.UI.Page
	{
		protected double TotalAmount = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.FetchCartItems();
		}

		public IQueryable<CartItem> FetchCartItems()
		{
			Guid testId;
			Guid.TryParse(Generics.IfNullString(Session["UniqueKey"]), out testId);
			SrvContext dbCtx = new SrvContext();
			IQueryable<CartItem> lstCartItems = dbCtx.CartItems
																								.Where(el => (el.Customer.UniqueKey == testId)
																																&&
																															el.IsActive);
			if (lstCartItems.Count() > 0)
			{
				vwNoItems.Visible = false;
				thCheckout.Visible = true;
				lvwCheckout.Visible = true;
				tfCheckout.Visible = true;
				TotalAmount = lstCartItems.Select(el => el.ItemPrice)
																		.Sum();
			}
			return lstCartItems;
		}

		protected void lvwCheckout_RowBound(object sender, ListViewItemEventArgs e)
		{
			if (e.Item.ItemType == ListViewItemType.DataItem)
			{
				DropDownList ddlQuantity = (DropDownList)e.Item.FindControl("ddlQuantity");
				for (int ix = 1; ix <= 9; ix++)
				{
					ddlQuantity.Items.Add(new ListItem(ix.ToString(), ix.ToString()));
				}
				ddlQuantity.SelectedValue = ((CartItem)e.Item.DataItem).Quantity.ToString();
			}
		}

		protected void btnUpdateItem_Click(object sender, CommandEventArgs e)
		{
			try
			{
				byte quantity = 1;
				quantity = byte.Parse(Generics.IfNullString(((DropDownList)((LinkButton)sender).NamingContainer.FindControl("ddlQuantity")).SelectedValue));
				Mediator.doUpdateCartItemQuantity(int.Parse(Generics.IfNullString(e.CommandArgument)), quantity);
				Response.Redirect(Request.RawUrl);
			}
			catch
			{
				;
			}
		}

		protected void btnRemoveItem_Click(object sender, CommandEventArgs e)
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
