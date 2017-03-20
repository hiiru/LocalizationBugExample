using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using System.IO;
using System.Text.Encodings.Web;

namespace LocalizationExample.MvcLocalization
{
    public class MyLocalizedHtmlString : LocalizedHtmlString, IHtmlContent
    {
        private bool _hasArguments;

        public MyLocalizedHtmlString(string name, string value) : base(name, value)
        {
        }

        public MyLocalizedHtmlString(string name, string value, bool isResourceNotFound) : base(name, value, isResourceNotFound)
        {
        }

        public MyLocalizedHtmlString(string name, string value, bool isResourceNotFound, object[] arguments) : base(name, value, isResourceNotFound, arguments)
        {
            _hasArguments = true;
        }

        void IHtmlContent.WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (_hasArguments)
            {
                base.WriteTo(writer, encoder);
            }
            else
            {
                writer.Write(Value);
            }
        }
    }
}