Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)

        'Default ROUTE CONFIG
        'routes.IgnoreRoute("{resource}.axd/{*pathInfo}")


        'routes.MapRoute(
        '    name:="Default",
        '    url:="{controller}/{action}/{id}",
        '    defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        ')
        'END OF DEFAULT ROUTE CONFIG

        'MY ROUTE CONFIG
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")


        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
           name:="UserRoute",
           url:="{controller}/{action}/{id}",
           defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
       )
        'END OF MY ROUTE CONFIG



    End Sub
End Module