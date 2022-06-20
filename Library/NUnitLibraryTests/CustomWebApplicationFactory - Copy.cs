using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using NUnitLibraryTests.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitLibraryTests
{
	public class CustomWebApplicationFactory<TStartup>
			: WebApplicationFactory<TStartup> where TStartup : class
	{
		private static DbContextOptions<LibraryContext> dbContextOptions = new DbContextOptionsBuilder<LibraryContext>()
			.UseInMemoryDatabase(databaseName:"testDB").Options;
		private LibraryContext libraryContext;

		public CustomWebApplicationFactory()
		{
			libraryContext = new LibraryContext(dbContextOptions);
		}

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType ==
																	typeof(DbContextOptions<LibraryContext>));
				services.Remove(serviceDescriptor);

				// Create a new service provider.
				var serviceProvider = new ServiceCollection()
					
					.BuildServiceProvider();

				services.AddDbContext<LibraryContext>(options =>
				{
					options.UseInMemoryDatabase(databaseName: "testDB");
				}, ServiceLifetime.Scoped);

				// Build the service provider.
				var sp = services.BuildServiceProvider();

				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;

					var db = scopedServices.GetRequiredService<LibraryContext>();

					db.Database.EnsureDeleted();

					// Ensure the database is created.
					db.Database.EnsureCreated();

					// Seed the database with test data.
					Utilities.InitializeDbForTests(db);
				}
			});
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}

