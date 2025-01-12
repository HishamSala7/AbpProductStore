using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace ProductStore.Data;

public class ProductStoreEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public ProductStoreEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ProductStoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProductStoreDbContext>()
            .Database
            .MigrateAsync();
    }
}
