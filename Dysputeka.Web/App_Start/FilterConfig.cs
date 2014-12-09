﻿using System.Web;
using System.Web.Mvc;
using PortalKol.Web.Infrastructure;

namespace PortalKol.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionScopeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}