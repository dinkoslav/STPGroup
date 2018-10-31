namespace STPGroup.WebServices.Interfaces
{
    public interface IHttpRequestService
    {
        T Get<T>(string serviceUrl, string mediaType = "application/json");

        T Post<T>(string serviceUrl, object data, string auth, string mediaType = "application/json");
    }
}
