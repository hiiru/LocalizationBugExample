# Localization behavior
This repo demonstrates a behavior difference between Localization (`IStringLocalizer`) and MvcLocalization (`IViewLocalizer`).

`IViewLocalizer` assumes that every localized resource is a format string and needs to be passed to string.format().
`IStringLocalizer` assumes that only localized resources which are invoked with provided arguments are passed to string.format()

## Problem:
Any localized resource containing { } that aren't escaped will throw a FormatException when loaded from `IViewLocalizer`.

## Workarounds:

### Using .Value
`IViewLocalizer`'s Value property isn't affected because this prints a string instead of IHtmlContent, however then HTML isn't interpreted.
However it can be passed to Html.Raw to render it as HTML again.

```
<p>Localizer["NoArgumentsJson"].Value</p>
<p>@Html.Raw(Localizer["NoArgumentsJson"].Value)</p>
```

### Use a custom IHtmlLocalizerFactory and LocalizedHtmlString
The first part (`IHtmlLocalizerFactory`) can easily be replaced by DI.

For `LocalizedHtmlString` however it's necessary to use a C# trick to replace a non-virtual method (WriteTo).
This is possible because in rendering it is only used in form of IHtmlContent, so by adding a dedicated implmentation of WriteTo for the interface, it can be replaced.
A example of this is in this repo in the workaround branch.

Currently it works, but it could break at any time, depending on how the `LocalizedHtmlString` instance is used.

## Related discussions
Issue in Localization: https://github.com/aspnet/Localization/issues/346

PR in Mvc: https://github.com/aspnet/Mvc/pull/5962
