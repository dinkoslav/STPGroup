namespace STPGroup.Data.DataHandlers
{
    using System;
    using System.Linq;
    using STPGroup.Data.DataHandlers.Interfaces;
    using Database;

    public class CompaniesDataHandler : BaseDataHandler, ICompaniesDataHandler
    {
        public CompaniesDataHandler(ISTPGroupData data)
            : base(data)
        {
        }

        public Companies Add(Companies company)
        {
            this.Data.Companies.Add(company);
            this.Data.SaveChanges();

            return company;
        }

        public IQueryable<Companies> All()
        {
            return this.Data.Companies.All();
        }

        public void Delete(int id)
        {
            this.Data.Companies.Delete(id);
            this.Data.SaveChanges();
        }

        public Companies GetById(int id)
        {
            return this.Data.Companies.GetById(id);
        }

        public Companies Update(Companies company)
        {
            this.Data.Companies.Update(company);
            this.Data.SaveChanges();

            return company;
        }
    }
}
