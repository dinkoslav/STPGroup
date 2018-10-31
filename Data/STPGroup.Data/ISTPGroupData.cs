namespace STPGroup.Data
{
    using STPGroup.Data.Repositories;
    using STPGroup.Database;

    public interface ISTPGroupData
    {
        STPGroupDbContext Context { get; }

        IRepository<Companies> Companies { get; }

        IRepository<Employees> Employees { get; }

        int SaveChanges();
    }
}
