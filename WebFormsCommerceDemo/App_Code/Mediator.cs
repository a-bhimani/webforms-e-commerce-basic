using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo
{
	public static class Mediator
	{
		#region Cart
		public static bool doAddCartItem(int ProductID)
		{
			Guid testId;
			bool t = false;
			if ((Guid.TryParse(Generics.IfNullString(HttpContext.Current.Session["UniqueKey"]), out testId)) && (ProductID > 0))
			{
				SrvContext dbCtx = new SrvContext();
				Customer cx = dbCtx.Customers
															.Where(el => (el.UniqueKey == testId))
															.Single();
				CartItem ci;
				if (dbCtx.CartItems
									.Where(el => (el.CustomerID == cx.CustomerID)
																	&&
																el.IsActive
																	&&
																(el.ProductID == ProductID)).Count() == 1)
				{
					ci = dbCtx.CartItems
								.Where(el => (el.CustomerID == cx.CustomerID)
																&&
															el.IsActive
																&&
															(el.ProductID == ProductID))
								.Single();
					if (ci.Quantity < 10)
					{
						ci.Quantity += 1;
						ci.ItemPrice = double.Parse(Generics.IfNullString(dbCtx.Products
																																	.Where(el => (el.ProductID == ProductID))
																																	.Single()
																																		.UnitPrice)) * ci.Quantity;
					}
				}
				else
				{
					ci = new CartItem();
					ci.CustomerID = cx.CustomerID;
					ci.ProductID = ProductID;
					ci.Quantity = 1;
					ci.ItemPrice = double.Parse(Generics.IfNullString(dbCtx.Products
																																	.Where(el => (el.ProductID == ProductID))
																																	.Single()
																																		.UnitPrice));
					ci.IsActive = true;
					dbCtx.CartItems.Add(ci);
				}
				if (Validator.TryValidateObject(ci,
																				new ValidationContext(ci, serviceProvider: null, items: null),
																				new List<ValidationResult>(),
																				true))
				{
					try
					{
						t = (dbCtx.SaveChanges() > 0);
					}
					catch
					{
						;
					}
				}
			}
			return t;
		}

		public static bool doUpdateCartItemQuantity(int CartItemID, byte quantity)
		{
			Guid testId;
			bool t = false;
			if (Guid.TryParse(Generics.IfNullString(HttpContext.Current.Session["UniqueKey"]), out testId))
			{
				SrvContext dbCtx = new SrvContext();
				Customer cx = dbCtx.Customers
															.Where(el => (el.UniqueKey == testId))
															.Single();
				CartItem ci;
				if (dbCtx.CartItems
									.Where(el => (el.CustomerID == cx.CustomerID)
																	&&
																el.IsActive
																	&&
																(el.CartItemID == CartItemID)).Count() == 1)
				{
					ci = dbCtx.CartItems
								.Where(el => (el.CustomerID == cx.CustomerID)
																&&
															el.IsActive
																&&
															(el.CartItemID == CartItemID))
								.Single();
					if ((ci.Quantity > 0) && (ci.Quantity < 10))
					{
						ci.Quantity = quantity;
						ci.ItemPrice = double.Parse(Generics.IfNullString(dbCtx.Products
																																	.Where(el => (el.ProductID == ci.ProductID))
																																	.Single()
																																		.UnitPrice)) * ci.Quantity;
						if (Validator.TryValidateObject(ci,
																						new ValidationContext(ci, serviceProvider: null, items: null),
																						new List<ValidationResult>(),
																						true))
						{
							try
							{
								t = (dbCtx.SaveChanges() > 0);
							}
							catch
							{
								;
							}
						}
					}
				}
			}
			return t;
		}

		public static bool doRemoveCartItem(int CartItemID)
		{
			Guid testId;
			bool t = false;
			if ((Guid.TryParse(Generics.IfNullString(HttpContext.Current.Session["UniqueKey"]), out testId)) && (CartItemID > 0))
			{
				SrvContext dbCtx = new SrvContext();
				int CustomerID = dbCtx.Customers
															.Where(el => (el.UniqueKey == testId))
															.Single()
																.CustomerID;
				if (dbCtx.CartItems.Where(el => (el.CartItemID == CartItemID)
																					&&
																				(el.CustomerID == CustomerID)).Count() == 1)
				{
					CartItem ci = dbCtx.CartItems
															.Where(el => (el.CartItemID == CartItemID)
																							&&
																						(el.CustomerID == CustomerID))
																							.Single();
					dbCtx.CartItems.Remove(ci);
					try
					{
						t = (dbCtx.SaveChanges() > 0);
					}
					catch
					{
						;
					}
				}
			}
			return t;
		}
		#endregion

		#region Order
		public static bool doSetOrder()
		{
			//Guid testId;
			//bool t = false;
			//if ((Guid.TryParse(Generics.IfNullString(HttpContext.Current.Session["UniqueKey"]), out testId)) && (ProductID > 0))
			//{
			//	SrvContext dbCtx = new SrvContext();
			//	Customer cx = dbCtx.Customers
			//												.Where(el => (el.UniqueKey == testId))
			//												.Single();
			//	CartItem ci;
			//	if (dbCtx.CartItems
			//						.Where(el => (el.CustomerID == cx.CustomerID)
			//														&&
			//													el.IsActive
			//														&&
			//													(el.ProductID == ProductID)).Count() == 1)
			//	{
			//		ci = dbCtx.CartItems
			//					.Where(el => (el.CustomerID == cx.CustomerID)
			//													&&
			//												el.IsActive
			//													&&
			//												(el.ProductID == ProductID))
			//					.Single();
			//		if (ci.Quantity < 10)
			//		{
			//			ci.Quantity += 1;
			//			ci.ItemPrice = double.Parse(Generics.IfNullString(dbCtx.Products
			//																														.Where(el => (el.ProductID == ProductID))
			//																														.Single()
			//																															.UnitPrice)) * ci.Quantity;
			//		}
			//	}
			//	else
			//	{
			//		ci = new CartItem();
			//		ci.CustomerID = cx.CustomerID;
			//		ci.ProductID = ProductID;
			//		ci.Quantity = 1;
			//		ci.ItemPrice = double.Parse(Generics.IfNullString(dbCtx.Products
			//																														.Where(el => (el.ProductID == ProductID))
			//																														.Single()
			//																															.UnitPrice));
			//		ci.IsActive = true;
			//		dbCtx.CartItems.Add(ci);
			//	}
			//	if (Validator.TryValidateObject(ci,
			//																	new ValidationContext(ci, serviceProvider: null, items: null),
			//																	new List<ValidationResult>(),
			//																	true))
			//	{
			//		try
			//		{
			//			t = (dbCtx.SaveChanges() > 0);
			//		}
			//		catch
			//		{
			//			;
			//		}
			//	}
			//}
			//return t;
			return true;
		}
		#endregion
	}
}
