using Microsoft.EntityFrameworkCore;
using ProductStore.Entities;
using ProductStore.Entities.EntitiesConfiguration;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ProductStore.Data;

public class ProductStoreDbContext : AbpDbContext<ProductStoreDbContext>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.ApplyConfigurationsFromAssembly(typeof(ProductStoreDbContext).Assembly); 

        //builder.ApplyConfiguration(new ProductConfiguration());
        //builder.ApplyConfiguration(new CategoryConfiguration());
        //builder.ApplyConfiguration(new OrderConfiguration());
        //builder.ApplyConfiguration(new OrderDetailsConfiguration());
    }
}
