namespace STPGroup.Data.DataHandlers
{
    public abstract class BaseDataHandler
    {
        protected BaseDataHandler(ISTPGroupData data)
        {
            this.Data = data;
        }

        protected ISTPGroupData Data { get; private set; }
    }
}
