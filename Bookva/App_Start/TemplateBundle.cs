using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace Bookva.Web.App_Start
{
    public class TemplateBundle : Bundle
    {
        public TemplateBundle(string virtualPath)
            : base(virtualPath, new TemplatesTransform())
        { }
    }
    class TemplatesTransform : IBundleTransform
    {
        private const string AngularModuleName = "BookvaApp";

        public void Process(BundleContext context, BundleResponse response)
        {
            var bundleResponse = new StringBuilder();

            bundleResponse.AppendFormat(@"angular.module('{0}').run(['$templateCache',function(t){{",
                AngularModuleName);

            foreach (var file in response.Files)
            {
                var templateText = HttpUtility.JavaScriptStringEncode(file.ApplyTransforms());
                bundleResponse.AppendFormat(@"t.put('{0}','{1}');", file.VirtualFile.VirtualPath, templateText);
            }
            bundleResponse.Append(@"}]);");

            response.Files = new BundleFile[] { };
            response.Content = bundleResponse.ToString();
            response.ContentType = "text/javascript";
        }
    }
}