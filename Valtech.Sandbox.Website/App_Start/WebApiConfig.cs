using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Valtech.Sandbox.Website
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// initialize and map all attribute routed Web API controllers (note: this does not enable MVC attribute routing)
			config.MapHttpAttributeRoutes();
            
			config.Formatters.Clear();
			config.Formatters.Add(new JsonMediaTypeFormatter());
			config.Formatters.Add(new XmlMediaTypeFormatter());
		}
	}
}