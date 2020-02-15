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

        'JQuery DataTables
        bundles.Add(New ScriptBundle("~/bundles/script/jquery-datatables").Include(
                        "~/Content/Template/plugins/jquery-datatable/jquery.dataTables.js",
                        "~/Content/Template/plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/buttons.flash.min.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/jszip.min.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/pdfmake.min.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/vfs_fonts.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/buttons.html5.min.js",
                        "~/Content/Template/plugins/jquery-datatable/extensions/export/buttons.print.min.js"
                    ))
    End Sub
End Module

