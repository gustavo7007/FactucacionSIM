using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FacturacionSIM.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/login/login.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/blckUI.js",
                "~/Scripts/CasasFuncionesMenus.js",
                "~/Scripts/CasasFuncionesGlobales.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/bower_components/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/plugins/input-mask/jquery.inputmask.js",
                        "~/plugins/input-mask/jquery.inputmask.date.extensions.js",
                        "~/plugins/input-mask/jquery.inputmask.extensions.js",
                        "~/bower_components/moment/min/moment.min.js",
                        "~/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                        "~/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                        "~/plugins/timepicker/bootstrap-timepicker.min.js",
                        "~/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/plugins/iCheck/icheck.min.js",
                        "~/bower_components/datatables.net/1.10.18/js/jquery.dataTables.min.js",
                        "~/bower_components/datatables.net/buttons/1.5.4/js/dataTables.buttons.min.js",
                        "~/bower_components/datatables.net/buttons/1.5.4/js/buttons.flash.min.js",
                        "~/bower_components/datatables.net/jszip/2.5.0/jszip.min.js",
                        "~/bower_components/datatables.net/pdfmake/0.1.36/pdfmake.min.js",
                        "~/bower_components/datatables.net/pdfmake/0.1.36/vfs_fonts.js",
                        "~/bower_components/datatables.net/buttons/1.5.4/js/buttons.html5.min.js",
                        "~/bower_components/datatables.net/buttons/1.5.4/js/buttons.print.min.js",
                        "~/bower_components/fastclick/lib/fastclick.js",
                        "~/dist/js/adminlte.min.js",
                        "~/bower_components/ckeditor/ckeditor.js",
                        "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/respond.min.js",
                        "~/bower_components/ag-grid-enterprise-master/dist/ag-grid-enterprise.js",
                        "~/bower_components/lobibox-master/js/Lobibox.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/blckUI.js",
                        "~/plugins/alertify/alertify.min.js",
                        "~/Scripts/mensajes.js",
                        "~/Scripts/FuncionesGlobalAg-grid.js",
                        "~/bower_components/chart.js/Chart.js",
                        "~/Scripts/date.format.js"
                        ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                "~/bower_components/ag-grid-enterprise-master/dist/styles/ag-theme-bootstrap.css",
                "~/bower_components/font-awesome/css/font-awesome.min.css",
                "~/bower_components/Ionicons/css/ionicons.min.css",
                "~/bower_components/lobibox-master/dist/css/Lobibox.min.css",
                "~/bower_components/datatables.net/1.10.18/css/jquery.dataTables.min.css",
                "~/bower_components/datatables.net/buttons/1.5.4/css/buttons.dataTables.min.css",
                "~/dist/css/AdminLTE.min.css",
                "~/dist/css/skins/_all-skins.min.css",
                "~/plugins/timepicker/bootstrap-timepicker.min.css",
                "~/bower_components/ag-grid-enterprise-master/dist/styles/ag-theme-balham.css",
                "~/plugins/alertify/alertify.core.css",
                "~/plugins/alertify/alertify.default.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
        }
    }
}