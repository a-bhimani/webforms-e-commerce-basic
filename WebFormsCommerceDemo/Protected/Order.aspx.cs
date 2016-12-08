using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Security;
using WebFormsCommerceDemo.Models;
using static WebFormsCommerceDemo.Properties.Settings;

namespace WebFormsCommerceDemo.Protected
{
	public partial class OrderWf : System.Web.UI.Page
	{
		private Guid testId;
		SrvContext dbCtx;
		private Customer updCustomer = null;
		protected int TotalCount = 0;
		protected double TotalAmount = 0;
		protected double TotalTax = 0;
		protected double TotalOrderAmount = 0;

		public IQueryable<CartItem> FetchCartItems()
		{
			IQueryable<CartItem> lstCartItems = dbCtx.CartItems
																								.Where(el => (el.Customer.UniqueKey == testId)
																																&&
																															el.IsActive);
			TotalCount = lstCartItems.Count();
			if (TotalCount > 0)
			{
				TotalAmount = lstCartItems.Select(el => el.ItemPrice)
																		.Sum();
				TotalTax = (TotalAmount * .1);
				TotalOrderAmount = (TotalAmount + TotalTax);
			}
			else
				Response.Redirect(FormsAuthentication.DefaultUrl);
			return lstCartItems;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Guid.TryParse(Generics.IfNullString(Default.AppUserUniqueKey), out testId))
			{
				dbCtx = new SrvContext();
				this.FetchCartItems();
				updCustomer = dbCtx.Customers.Where(el => (el.UniqueKey == testId))
																			.Single();
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (updCustomer != null)
			{
				txtMFirstName.Text = updCustomer.FirstName;
				txtMLastName.Text = updCustomer.LastName;
				txtMBillingAddress.Text = updCustomer.BillingAddress;
				txtMBillingCity.Text = updCustomer.BillingCity;
				txtMBillingState.Text = updCustomer.BillingState;
				txtMBillingZip.Text = updCustomer.BillingZip.ToString();
				txtMShippingAddress.Text = updCustomer.ShippingAddress;
				txtMShippingCity.Text = updCustomer.ShippingCity;
				txtMShippingState.Text = updCustomer.ShippingState;
				txtMShippingZip.Text = updCustomer.ShippingZip.ToString();
			}
		}

		protected void btnOrder_Click(object sender, EventArgs e)
		{
			Order o = new Order();
			bool t = false;
			o.CustomerID = dbCtx.Customers
														.Where(el => (el.UniqueKey == testId))
														.Single()
															.CustomerID;
			o.UniqueOrderNumber = Guid.NewGuid();
			o.OrderDate = DateTime.Now;
			o.FirstName = txtMFirstName.Text;
			o.LastName = txtMLastName.Text;
			o.BillingAddress = txtMBillingAddress.Text;
			o.BillingCity = txtMBillingCity.Text;
			o.BillingState = txtMBillingCity.Text;
			o.BillingZip = int.Parse(txtMBillingZip.Text);
			if (chkMShippingIsSame.Checked)
			{
				o.ShippingAddress = o.BillingAddress;
				o.ShippingCity = o.BillingCity;
				o.ShippingState = o.BillingState;
				o.ShippingZip = o.BillingZip;
			}
			else
			{
				o.ShippingAddress = txtMShippingAddress.Text;
				o.ShippingCity = txtMShippingCity.Text;
				o.ShippingState = txtMShippingCity.Text;
				o.ShippingZip = int.Parse(txtMShippingZip.Text);
			}
			o.TaxSum = TotalTax;
			o.TotalSum = TotalOrderAmount;
			o.Notes = txtNotes.Text;
			o.IsOrdered = true;
			if (Validator.TryValidateObject(o,
																				new ValidationContext(o, serviceProvider: null, items: null),
																				new List<ValidationResult>(),
																				true))
			{
				dbCtx.Orders.Add(o);
				try
				{
					int OrderId = dbCtx.SaveChanges();
					if (OrderId > 0)
					{
						foreach (CartItem ci in dbCtx.CartItems
																					.Where(el => (el.CustomerID == o.CustomerID)
																													&&
																												el.IsActive))
						{
							ci.OrderID = OrderId;
							ci.IsActive = false;
						}
						dbCtx.SaveChanges();
						lblOrderSummary.Text = ("Your order was successfully placed. Please note that your Order# is " + o.UniqueOrderNumber + ".");
						lblOrderSummary.CssClass = lblOrderSummary.CssClass.Replace("warning", "success");
						lblOrderSummary.CssClass = lblOrderSummary.CssClass.Replace("red", "green");
						pnlOrder.Visible = false;
						lblOrderSummary.Visible = true;
						t = true;
					}
				}
				catch
				{
					lblOrderSummary.Text = "There was an error placing your order.";
				}
			}

			if (!t)
			{
				lblOrderSummary.Visible = true;
			}
		}
	}
}
