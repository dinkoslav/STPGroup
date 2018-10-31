namespace STPGroup.Data.DataHandlers
{
    using System;
    using STPGroup.Data.DataHandlers.Interfaces;
    using Database;

    public class EmployeesDataHandler : BaseDataHandler, IEmployeesDataHandler
    {
        public EmployeesDataHandler(ISTPGroupData data)
            : base(data)
        {
        }

        public Employees Add(Employees employee)
        {
            this.Data.Employees.Add(employee);
            this.Data.SaveChanges();

            return employee;
        }

        public void Delete(int id)
        {
            this.Data.Employees.Delete(id);
            this.Data.SaveChanges();
        }

        public Employees GetById(int id)
        {
            return this.Data.Employees.GetById(id);
        }

        public Employees Update(Employees employee)
        {
            this.Data.Employees.Update(employee);
            this.Data.SaveChanges();

            return employee;
        }
    }
}
