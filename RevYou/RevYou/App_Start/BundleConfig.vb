Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))

        'Tried to bundle some admin mart index styles
        bundles.Add(New StyleBundle("~/Template/defaultStyle").Include(
                    "~/Content/Template/assets/extra-libs/c3/c3.min.css",
                    "~/Content/Template/assets/libs/chartist/dist/chartist.min.css",
                    "~/Content/Template/assets/extra-libs/jvector/jquery-jvectormap-2.0.2.css",
                    "~/Content/Template/dist/css/style.min.css"
                    ))



    End Sub
End Module

