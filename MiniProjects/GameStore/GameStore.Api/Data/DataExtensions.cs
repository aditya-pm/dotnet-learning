using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<GameStoreContext>();

        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        // reads from appsettings.json
        var connString = builder.Configuration.GetConnectionString("GameStore");

        // AddSqlite also registers dependency (GameStoreContext) with a scoped service
        // lifetime, similar to AddScope below
        // builder.Services.AddScoped<GameStoreContext>();
        //
        // DbContext has a scoped service lifetime because:
        // 1. It ensures that a new instance of DbContext is created per request
        // 2. DB connections are a limited and expensive resource
        // 3. DbContext is not thread-safe. Scoped avoids concurrency issues
        // 4. Makes it easier to manage transactions and ensure data consistency
        // 5. Reusing a DbContext instance can lead to increased memory usage

        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: options =>
            {
                options.UseSeeding(
                    (context, _) =>
                    {
                        if (!context.Set<Genre>().Any())
                        {
                            context.Set<Genre>().AddRange(
                                new Genre { Name = "Fighting" },
                                new Genre { Name = "RPG"}, 
                                new Genre { Name = "Platformer" },
                                new Genre { Name = "Racing" },
                                new Genre { Name = "Sports" }
                            );

                            context.SaveChanges();
                        }
                    }
                );
            }          
        );


        // ALTERNATE SYNTAX

        /*

        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: someFunc
        );

        void someFunc(DbContextOptionsBuilder options)
        {
            options.UseSeeding(seedFunc);
        }

        // Signature simplified for explanation.
        // Actual second parameter type depends on UseSeeding overload.
        void seedFunc(DbContext context, SomeType _)
        {
            if (!context.Set<Genre>().Any())
            {
                context.Set<Genre>().AddRange(
                    new Genre { Name = "Fighting" },
                    new Genre { Name = "RPG"}, 
                    new Genre { Name = "Platformer" },
                    new Genre { Name = "Racing" },
                    new Genre { Name = "Sports" }
                );

                context.SaveChanges();
            }
        }

        */

        /* 
           NOTE:
            - optionsAction is an Action<DbContextOptionsBuilder>?.
            
               Action<T> means:
               - returns void
               - accepts a T parameter
            
               Therefore optionsAction expects a function with signature:
              
               void SomeFunc(DbContextOptionsBuilder options)

            - We use DbContextOptionsBuilder.UseSeeding() to pass in a function that does 
              initial database setup. UseSeeding expects a callback function.
              EF Core will invoke this callback during database creation/migration.

            - The callback must take 2 parameters: 1st param is of type DbContext (required
              by us to perform SQL operations), 2nd param depends on overload.
        */
    }
}
