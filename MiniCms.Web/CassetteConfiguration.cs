using Cassette.Configuration;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace MiniCms.Web
{
    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {
            // TODO: Configure your bundles here...
            // Please read http://getcassette.net/documentation/configuration

            // This default configuration treats each file as a separate 'bundle'.
            // In production the content will be minified, but the files are not combined.
            // So you probably want to tweak these defaults!
            //bundles.AddPerIndividualFile<StylesheetBundle>("Content");
            bundles.AddPerIndividualFile<ScriptBundle>("Scripts");
            bundles.AddPerSubDirectory<ScriptBundle>("Areas/Admin/Content");
            bundles.AddPerSubDirectory<ScriptBundle>("Areas/Admin/Scripts");

            bundles.Add<StylesheetBundle>("Content/bootstrap.css");
            bundles.Add<StylesheetBundle>("Content/bootstrap-responsive.css");
            bundles.Add<StylesheetBundle>("Content/css/jquery-autocomplete.css");

            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/bootstrap.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/combine_fonts.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/plugins/datepicker/css/datepicker.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/plugins/colorpicker/css/colorpicker.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/plugins/wysiwyg/bootstrap-wysihtml5.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/plugins/plupload/js/jquery.plupload.queue/css/jquery.plupload.queue.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/buttons.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/style.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/dark.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/cms.css");
            bundles.Add<StylesheetBundle>("Areas/Admin/Content/css/bootstrap-responsive.css");

            // To combine files, try something like this instead:
            //   bundles.Add<StylesheetBundle>("Content");
            // In production mode, all of ~/Content will be combined into a single bundle.
            
            // If you want a bundle per folder, try this:
            //   bundles.AddPerSubDirectory<ScriptBundle>("Scripts");
            // Each immediate sub-directory of ~/Scripts will be combined into its own bundle.
            // This is useful when there are lots of scripts for different areas of the website.

            // *** TOP TIP: Delete all ".min.js" files now ***
            // Cassette minifies scripts for you. So those files are never used.
        }
    }
}