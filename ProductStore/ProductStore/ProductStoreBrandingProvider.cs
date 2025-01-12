using Microsoft.Extensions.Localization;
using ProductStore.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProductStore;

[Dependency(ReplaceServices = true)]
public class ProductStoreBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProductStoreResource> _localizer;

    public ProductStoreBrandingProvider(IStringLocalizer<ProductStoreResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
