using System.Linq.Expressions;
using api.Models;
using api.Models.Base;
using api.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Database;

public class SimpleDBContext : IdentityDbContext<User, Role, string>
{
	public DbSet<User> users { get; set; }
	public DbSet<Category> categories { get; set; }
	public DbSet<Product> products { get; set; }

	public SimpleDBContext()
	{
	}

	public SimpleDBContext(DbContextOptions<SimpleDBContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		IsDeleteFilter(builder);
	}

	private void IsDeleteFilter(ModelBuilder builder)
	{
		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			if (typeof(IBaseEntity).IsAssignableFrom(entityType.ClrType) && entityType.BaseType == null)
			{
				var parameter = Expression.Parameter(entityType.ClrType);
				var propertyMethodInfo = typeof(EF).GetMethod("Property")?.MakeGenericMethod(typeof(Object));
				var isDeletedProperty =
					Expression.Call(propertyMethodInfo, parameter, Expression.Constant("DeletedAt"));
				var constant = Expression.Constant(null);
				var equalExpression = Expression.Equal(isDeletedProperty, constant);
				var lambda = Expression.Lambda(equalExpression, parameter);
				builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
			}
		}
	}

	public override int SaveChanges()
	{
		var entries = ChangeTracker.Entries().Where(e =>
			e.Entity is IBaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

		foreach (var entityEntry in entries)
		{
			((IBaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

			if (entityEntry.State == EntityState.Added)
			{
				((IBaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
			}
		}

		return base.SaveChanges();
	}
}
