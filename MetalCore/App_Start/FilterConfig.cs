﻿using System.Web;
using System.Web.Mvc;

namespace SB_Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerificarSession());

        }
    }
}
