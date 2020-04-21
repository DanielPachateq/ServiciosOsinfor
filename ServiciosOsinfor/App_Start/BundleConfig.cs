using System.Web;
using System.Web.Optimization;

namespace ServiciosNacionCrema
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {           

            bundles.Add(new StyleBundle("~/Bundles/css")
                             .Include("~/Content/css/bootstrap.min.css")
                             .Include("~/Content/css/bootstrap-select.css")
                             .Include("~/Content/css/bootstrap-datepicker3.min.css")
                             .Include("~/Content/font-awesome/css/font-awesome.min.css")
                             .Include("~/Content/css/icheck/blue.min.css")
                             .Include("~/Content/Site.css")
                             .Include("~/Content/css/ganamas.css")
                             .Include("~/Content/js/plugins/datatables/dataTables.bootstrap4.css")
                             .Include("~/Content/js/plugins/datatables/extensions/Buttons-1.5.1/css/buttons.bootstrap.min.css")
                             .Include("~/Content/js/plugins/datatables/extensions/Buttons-1.5.1/css/buttons.dataTables.min.css")
                             .Include("~/Content/js/plugins/datatables/extensions/checkboxes-1.2.11/css/dataTables.checkboxes.css")
                             );

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.es.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator/validator.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/custom.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js")
                .Include("~/Content/js/plugins/datatables/jquery.dataTables.min.js")
                .Include("~/Content/js/plugins/datatables/datatables.bootstrap4.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/pdfmake-0.1.32/pdfmake.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/pdfmake-0.1.32/vfs_fonts.js")
                .Include("~/Content/js/plugins/datatables/extensions/JSZip-2.5.0/jszip.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/JSZip-2.5.0/jszip.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/Buttons-1.5.1/js/dataTables.buttons.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/Buttons-1.5.1/js/buttons.print.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/Buttons-1.5.1/js/buttons.html5.min.js")
                .Include("~/Content/js/plugins/datatables/extensions/checkboxes-1.2.11/js/dataTables.checkboxes.js")
                );
        }
    }
}
