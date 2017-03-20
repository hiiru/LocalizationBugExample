using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace LocalizationExample.MvcLocalization
{
    public class MyHtmlLocalizer : HtmlLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public MyHtmlLocalizer(IStringLocalizer localizer) : base(localizer)
        {
            _localizer = localizer;
        }

        public override IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            return new MyHtmlLocalizer(_localizer.WithCulture(culture));
        }

        protected override LocalizedHtmlString ToHtmlString(LocalizedString result)
        {
            return new MyLocalizedHtmlString(result.Name, result.Value, result.ResourceNotFound);
        }
    }
}