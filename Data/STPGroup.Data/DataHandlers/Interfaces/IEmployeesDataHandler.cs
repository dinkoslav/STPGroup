using STPGroup.Database;

namespace STPGroup.Data.DataHandlers.Interfaces
{
    public interface IEmployeesDataHandler
    {
        Employees Update(Employees employee);

        Employees GetById(int id);

        void Delete(int id);

        Employees Add(Employees employee);
    }
}
