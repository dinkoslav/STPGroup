namespace STPGroup.Data.DataHandlers.Interfaces
{
    using STPGroup.Database;
    using System.Linq;

    public interface ICompaniesDataHandler
    {
        IQueryable<Companies> All();

        Companies GetById(int id);

        void Delete(int id);

        Companies Add(Companies company);

        Companies Update(Companies company);
    }
}
