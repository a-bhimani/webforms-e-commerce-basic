using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormsCommerceDemo
{
	public class MyHttpHandler : IHttpHandler, IRequiresSessionState
	{
		internal readonly IHttpHandler OriginalHandler;

		public MyHttpHandler(IHttpHandler originalHandler)
		{
			OriginalHandler = originalHandler;
		}

		public void ProcessRequest(HttpContext context)
		{
			// do not worry, ProcessRequest() will not be called, but let's be safe
			throw new InvalidOperationException("MyHttpHandler cannot process requests.");
		}

		public bool IsReusable
		{
			// IsReusable must be set to false since class has a member!
			get { return false; }
		}
	}

	public class RequestAuth : IHttpModule
	{
		private HttpContext Ctx;

		/// <summary>
		/// You will need to configure this module in the Web.config file of your
		/// web and register it with IIS before being able to use it. For more information
		/// see the following link: http://go.microsoft.com/?linkid=8101007
		/// </summary>
		#region IHttpModule Members

		public void Dispose()
		{
			//clean-up code here.
		}

		public void Init(HttpApplication context)
		{

			context.PostAcquireRequestState += new EventHandler(Application_PostAcquireRequestState);
			context.PostMapRequestHandler += new EventHandler(Application_PostMapRequestHandler);

			context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
			context.EndRequest += (new EventHandler(this.Application_EndRequest));

			// Below is an example of how you can handle LogRequest event and provide 
			// custom logging implementation for it
			context.LogRequest += new EventHandler(OnLogRequest);
		}

		#endregion

		void Application_PostAcquireRequestState(object source, EventArgs e)
		{
			HttpApplication app = (HttpApplication)source;

			MyHttpHandler resourceHttpHandler = HttpContext.Current.Handler as MyHttpHandler;

			if (resourceHttpHandler != null)
			{
				// set the original handler back
				HttpContext.Current.Handler = resourceHttpHandler.OriginalHandler;
			}

			// -> at this point session state should be available

			//Debug.Assert(app.Session != null, "it did not work :(");
		}

		void Application_PostMapRequestHandler(object source, EventArgs e)
		{
			HttpApplication app = (HttpApplication)source;

			if (app.Context.Handler is IReadOnlySessionState || app.Context.Handler is IRequiresSessionState)
			{
				// no need to replace the current handler
				return;
			}

			// swap the current handler
			app.Context.Handler = new MyHttpHandler(app.Context.Handler);
		}

		public void OnLogRequest(Object source, EventArgs e)
		{
			//custom logging logic can go here
		}

		private void Application_BeginRequest(Object source, EventArgs e)
		{
			Guid testId;
			Ctx = ((HttpApplication)source).Context;
			bool ShouldProtect = false;
			try
			{
				ShouldProtect = string.Equals(Generics.IfNullString(Ctx.Request.Url.Segments[1]), "Protected/", StringComparison.InvariantCultureIgnoreCase);
			}
			catch
			{
				ShouldProtect = false;
			}

			if (ShouldProtect)
			{
				string SessionKey = string.Empty;
				try
				{
					SessionKey = Generics.IfNullString(Ctx.Session["UniqueKey"]);
				}
				catch
				{
					;
				}

				if (Guid.TryParse(Generics.IfNullString(SessionKey), out testId))
				{
					;
				}
				else
				{
					Ctx.Response.Redirect(FormsAuthentication.LoginUrl);
				}
			}
		}

		private void Application_EndRequest(Object source, EventArgs e)
		{
			return;
		}
	}
}
