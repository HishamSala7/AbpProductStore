using NpgsqlTypes;
using ProductStore.Data;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;
using Volo.Abp.Data;

namespace ProductStore;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var loggerConfiguration = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithProcessId()      // Adds process ID
            .Enrich.WithThreadId()       // Adds thread ID
            .Enrich.WithMachineName()    // Adds machine name
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .WriteTo.Async(c => c.PostgreSQL(
                connectionString: "Host=your_postgres_host;Database=your_database;Username=your_username;Password=your_password;",
                tableName: "logging",
                needAutoCreateTable: true,
                columnOptions: new Dictionary<string, ColumnWriterBase>
                {
                    { "message", new RenderedMessageColumnWriter() },
                    { "message_template", new MessageTemplateColumnWriter() },
                    { "level", new LevelColumnWriter(true, NpgsqlDbType.Text) },
                    { "time_stamp", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
                    { "exception", new ExceptionColumnWriter() },
                    { "process_id", new SinglePropertyColumnWriter("ProcessId", PropertyWriteMethod.Raw) },
                    { "thread_id", new SinglePropertyColumnWriter("ThreadId", PropertyWriteMethod.Raw) },
                    { "machine_name", new SinglePropertyColumnWriter("MachineName",  PropertyWriteMethod.Raw) }
                }));

        //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
        //.Enrich.FromLogContext()
        //.Enrich.WithProcessId()      // Add Process ID
        //.Enrich.WithMachineName()    // Add Machine Name
        //.Enrich.WithThreadId()
        //.WriteTo.Async(c => c.File("Logs/logs.txt"))
        //.WriteTo.Async(c => c.Console());


        if (IsMigrateDatabase(args))
        {
            loggerConfiguration.MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning);
            loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
        }

        Log.Logger = loggerConfiguration.CreateLogger();


        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            if (IsMigrateDatabase(args))
            {
                builder.Services.AddDataMigrationEnvironment();
            }
            await builder.AddApplicationAsync<ProductStoreModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();

            if (IsMigrateDatabase(args))
            {
                await app.Services.GetRequiredService<ProductStoreDbMigrationService>().MigrateAsync();
                return 0;
            }

            Log.Information("Starting ProductStore.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "ProductStore terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}
