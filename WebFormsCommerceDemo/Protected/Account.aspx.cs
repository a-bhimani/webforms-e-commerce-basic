using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo.Protected
{
	public partial class Account : System.Web.UI.Page
	{
		SrvContext dbCtx;
		private Customer updCustomer = null;

		protected void Page_Init(object sender, EventArgs e)
		{

		}

		protected void Page_InitComplete(object sender, EventArgs e)
		{
			Guid testId;
			string UserUUID = Generics.IfNullString(Session["UniqueKey"]);
			if (Guid.TryParse(UserUUID, out testId))
			{
				dbCtx = new SrvContext();
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
				txtMEmailAddress.Text = updCustomer.Username;
				txtMPhone.Text = updCustomer.Phone.ToString("0");
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

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			bool t = false;
			if (updCustomer != null)
			{
				updCustomer.FirstName = txtMFirstName.Text;
				updCustomer.LastName = txtMLastName.Text;
				updCustomer.BillingAddress = txtMBillingAddress.Text;
				updCustomer.BillingCity = txtMBillingCity.Text;
				updCustomer.BillingState = txtMBillingState.Text;
				if (Generics.IfNullString(txtMBillingZip.Text).Length == 5)
					updCustomer.BillingZip = int.Parse(txtMBillingZip.Text);

				if (chkMShippingIsSame.Checked)
				{
					updCustomer.ShippingAddress = updCustomer.BillingAddress;
					updCustomer.ShippingCity = updCustomer.BillingCity;
					updCustomer.ShippingState = updCustomer.BillingState;
					updCustomer.ShippingZip = updCustomer.BillingZip;
				}
				else
				{
					updCustomer.ShippingAddress = txtMShippingAddress.Text;
					updCustomer.ShippingCity = txtMShippingCity.Text;
					updCustomer.ShippingState = txtMShippingState.Text;
					if (Generics.IfNullString(txtMShippingZip.Text).Length == 5)
						updCustomer.ShippingZip = int.Parse(txtMShippingZip.Text);
				}

				if (Validator.TryValidateObject(updCustomer,
																					new ValidationContext(updCustomer, serviceProvider: null, items: null),
																					new List<ValidationResult>(),
																					true))
				{
					try
					{
						//SrvContext dbCtx = new SrvContext();
						if (dbCtx.SaveChanges() > 0)
						{
							lblUpdateSummary.Text = "Your details have successfully been updated in the system.";
							lblUpdateSummary.CssClass = lblUpdateSummary.CssClass.Replace("warning", "success");
							lblUpdateSummary.CssClass = lblUpdateSummary.CssClass.Replace("red", "green");
							lblUpdateSummary.Visible = true;
							t = true;
						}
					}
					catch
					{
						lblUpdateSummary.Text = "There was an error updating your information in the system.";
					}
				}
			}
			if (!t)
			{
				lblUpdateSummary.Visible = true;
			}
		}
	}
}

