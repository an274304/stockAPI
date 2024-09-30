
using DomainLayer.V1.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=103.117.212.130;Database=stockApi;User Id=stockApi;password=Committed@1234;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
    }

    public virtual DbSet<BranchMaster> BranchMaster { get; set; }

    public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }

    public virtual DbSet<CurrencyMaster> CurrencyMaster { get; set; }

    public virtual DbSet<CurrencyMasterLog> CurrencyMasterLog { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMaster { get; set; }

    public virtual DbSet<ProductMaster> ProductMaster { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItem { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }

    public virtual DbSet<StockItemMaster> StockItemMaster { get; set; }

    public virtual DbSet<UserMaster> UserMaster { get; set; }

    public virtual DbSet<UserTypeMaster> UserTypeMaster { get; set; }

    public virtual DbSet<VendorMaster> VendorMaster { get; set; }
}
