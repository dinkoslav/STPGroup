namespace STPGroup.Data
{
    using STPGroup.Data.Repositories;
    using STPGroup.Database;
    using System;
    using System.Collections.Generic;

    public class STPGroupData : ISTPGroupData
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        //private STPGroupDbContext context;

        public STPGroupData(STPGroupDbContext context)
        {
            this.Context = context;
        }

        public STPGroupDbContext Context { get; private set; }

        public IRepository<Companies> Companies => this.GetRepository<Companies>();

        public IRepository<Employees> Employees => this.GetRepository<Employees>();

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            Type type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                Type repositoryType = typeof(GenericRepository<T>);
                object instance = Activator.CreateInstance(repositoryType, this.Context);
                this.repositories.Add(type, instance);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
