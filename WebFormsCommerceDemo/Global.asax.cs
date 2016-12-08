using System;
using System.Data.Entity;
using System.Web;
using System.Web.Routing;
using WebFormsCommerceDemo.Models;

namespace WebFormsCommerceDemo
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			Database.SetInitializer(new DbInitializer());

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
