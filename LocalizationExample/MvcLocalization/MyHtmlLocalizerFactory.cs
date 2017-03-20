using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;

namespace LocalizationExample.MvcLocalization
{
    public class MyHtmlLocalizerFactory : IHtmlLocalizerFactory
    {
        private readonly IStringLocalizerFactory _factory;

        public MyHtmlLocalizerFactory(IStringLocalizerFactory localizerFactory)
        {
            _factory = localizerFactory ?? throw new ArgumentNullException(nameof(localizerFactory));
        }

        public IHtmlLocalizer Create(string baseName, string location)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            var localizer = _factory.Create(baseName, location);
            return new MyHtmlLocalizer(localizer);
        }

        public IHtmlLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
            {
                throw new ArgumentNullException(nameof(resourceSource));
            }

            var localizer = _factory.Create(resourceSource);
            return new MyHtmlLocalizer(localizer);
        }
    }
}