using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Security;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo
{
	public partial class Login : System.Web.UI.Page
	{
		private SrvContext dbCtx;

		protected void Page_InitComplete(object sender, EventArgs e)
		{
			bool b = false;
			vwLogoutMessage.Visible = (bool.TryParse(Generics.IfNullString(Request.QueryString["logout"]), out b) && b);
			vwLoginMessage.Visible = (Generics.IfNullString(Request.QueryString["logon"]) == "enabled");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dbCtx = new SrvContext();
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//Session.Abandon();
				txtUsername.Text = string.Empty;
				txtPassword.Text = string.Empty;
				txtRegisterFirstName.Text = string.Empty;
				txtRegisterLastName.Text = string.Empty;
				txtRegisterUsername.Text = string.Empty;
				txtRegisterPhone.Text = string.Empty;
				txtRegisterPassword.Text = string.Empty;
				txtRegisterConfirmPassword.Text = string.Empty;
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			bool t = false;
			byte[] PasswordBin = Generics.MakeHash(txtPassword.Text);
			IQueryable<Customer> customer = dbCtx.Customers
																						.Where(el => ((el.Username == txtUsername.Text)
																														&&
																													el.IsActive));
			if (customer.Count() == 1)
			{
				Customer runCustomer = customer.Single();
				if (Generics.CompareBinaries(runCustomer.PasswordBin, Generics.MakeHash(txtPassword.Text)))
				{
					//Session["UniqueKey"] = runCustomer.UniqueKey;
					//Session["Username"] = runCustomer.Username;
					//FormsAuthentication.RedirectFromLoginPage(runCustomer.Username, true);
					t = true;
				}
			}
			if (t)
			{
				Response.Redirect(FormsAuthentication.DefaultUrl);
			}
			else
			{
				lblLoginError.Visible = true;
			}
		}

		protected void btnRegister_Click(object sender, EventArgs e)
		{
			bool t = false;
			Customer newCustomer = new Customer();
			newCustomer.FirstName = txtRegisterFirstName.Text;
			newCustomer.LastName = txtRegisterLastName.Text;
			newCustomer.Username = txtRegisterUsername.Text;
			newCustomer.Phone = decimal.Parse(txtRegisterPhone.Text);
			newCustomer.PasswordBin = Generics.MakeHash(txtRegisterPassword.Text);
			if (Validator.TryValidateObject(newCustomer,
																				new ValidationContext(newCustomer, serviceProvider: null, items: null),
																				new List<ValidationResult>(),
																				true))
			{
				dbCtx.Customers.Add(newCustomer);
				try
				{
					if (dbCtx.SaveChanges() > 0)
					{
						lblRegistrationSummary.Text = "You have been successfully registered into the system.";
						lblRegistrationSummary.CssClass = lblRegistrationSummary.CssClass.Replace("warning", "success");
						lblRegistrationSummary.CssClass = lblRegistrationSummary.CssClass.Replace("red", "green");
						lblRegistrationSummary.Visible = true;
						t = true;
					}
				}
				catch
				{
					lblRegistrationSummary.Text = "A user with the Email Address or Phone Number already exists in the system.";
				}
			}

			if (!t)
			{
				lblRegistrationSummary.Visible = true;
			}
		}
	}
}
