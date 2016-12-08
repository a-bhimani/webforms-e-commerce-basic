using System;
using System.Linq;
using WebFormsCommerceDemo.Models;
using static WebFormsCommerceDemo.Properties.Settings;

namespace WebFormsCommerceDemo.Protected
{
	public partial class Order_History : System.Web.UI.Page
	{
		private Guid testId;
		private SrvContext dbCtx;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Guid.TryParse(Generics.IfNullString(Default.AppUserUniqueKey), out testId))
			{
				dbCtx = new SrvContext();
				this.FetchOrderHistory();
			}
		}

		public IQueryable<Order> FetchOrderHistory()
		{
			return dbCtx.Orders
										.Where(el => (el.Customer.UniqueKey == testId)
																		&&
																	el.IsOrdered);
		}
	}
}
