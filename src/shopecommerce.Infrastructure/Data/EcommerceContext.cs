using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Infrastructure.Data.EntityConfigurations;
using System.Data;

namespace shopecommerce.Infrastructure.Data;

public class EcommerceContext : DbContext, IUnitOfWork
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    private bool _isDisposed;

    public EcommerceContext(DbContextOptions<EcommerceContext> options, IDbConnection dbConnection) : base(options)
    {
        _connection = dbConnection;
        if(_connection.State != ConnectionState.Open)
            _connection.Open();
        _transaction = dbConnection.BeginTransaction();
    }

    public async Task<bool> SaveEntitiesChangeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await base.SaveChangesAsync(cancellationToken);
        }
        catch(DbUpdateException ex)
        {
            _transaction.Rollback();
            throw ex;
        }
        finally
        {
            _transaction.Dispose();
            _connection.Close();
        }
        return true;
    }

    private void Dispose(bool disposing)
    {
        if(_isDisposed)
            return;

        if(disposing)
        {
            _transaction.Dispose();
            _connection.Dispose();
        }

        _isDisposed = true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Generated Configuration
        modelBuilder.ApplyConfiguration(new CategoriesMap());
        modelBuilder.ApplyConfiguration(new ContactsMap());
        modelBuilder.ApplyConfiguration(new NewsMap());
        modelBuilder.ApplyConfiguration(new OrderDetailsMap());
        modelBuilder.ApplyConfiguration(new OrdersMap());
        modelBuilder.ApplyConfiguration(new PaymentMethodsMap());
        modelBuilder.ApplyConfiguration(new PoliciesMap());
        modelBuilder.ApplyConfiguration(new ProductCategoriesMap());
        modelBuilder.ApplyConfiguration(new ProductsMap());
        modelBuilder.ApplyConfiguration(new ProductsPricesMap());
        modelBuilder.ApplyConfiguration(new PromotionsMap());
        modelBuilder.ApplyConfiguration(new RolesMap());
        modelBuilder.ApplyConfiguration(new SlidesMap());
        modelBuilder.ApplyConfiguration(new UsersMap());
        #endregion
    }

    #region Generated Properties
    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<Contacts> Contacts { get; set; }
    public virtual DbSet<News> News { get; set; }
    public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
    public virtual DbSet<Policies> Policies { get; set; }
    public virtual DbSet<ProductCategories> ProductCategories { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<ProductsPrices> ProductsPrices { get; set; }
    public virtual DbSet<Promotions> Promotions { get; set; }
    public virtual DbSet<Roles> Roles { get; set; }
    public virtual DbSet<Slides> Slides { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    #endregion
}