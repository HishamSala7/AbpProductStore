using ProductStore.Localization;
using Volo.Abp.Application.Services;

namespace ProductStore.Services;

/* Inherit your application services from this class. */
public abstract class ProductStoreAppService : ApplicationService
{
    protected ProductStoreAppService()
    {
        LocalizationResource = typeof(ProductStoreResource);
    }
}