﻿namespace STPGroup.WebServices
{
    using Newtonsoft.Json;
    using STPGroup.WebServices.Interfaces;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpRequestService : IHttpRequestService
    {
        private HttpClient client;

        public HttpRequestService()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            this.client = new HttpClient(handler);
        }

        public T Get<T>(string serviceUrl, string mediaType = "application/json")
        {
            HttpRequestMessage request = this.BuildRequest(serviceUrl, mediaType, HttpMethod.Get);
            this.SetServerCertificateValidationCallback();

            return this.GetResponseResult<T>(this.client.SendAsync(request), true);
        }

        public T Post<T>(string serviceUrl, object data, string auth, string mediaType = "application/json")
        {
            HttpRequestMessage request = this.BuildRequest(serviceUrl, auth, mediaType, HttpMethod.Post, this.GetHttpStringContent(data, mediaType));
            this.SetServerCertificateValidationCallback();

            return this.GetResponseResult<T>(this.client.SendAsync(request), true);
        }

        private T GetResponseResult<T>(Task<HttpResponseMessage> sendTask, bool ensureSuccessStatusCode = false)
        {
            T result = default(T);
            try
            {
                HttpResponseMessage response = sendTask.Result;
                if (ensureSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                }

                string responseContent = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (TaskCanceledException ex)
            {
                this.ProcessTaskCanceledException(ex);
            }

            return result;
        }

        private HttpRequestMessage BuildRequest(string serviceUrl, string mediaType, HttpMethod method, HttpContent content = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Headers.Authorization = null;
            if (content != null)
            {
                request.Content = content;
            }

            return request;
        }

        private void SetServerCertificateValidationCallback()
        {
            // Ignore SSL/TLS certificate errors
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        private void ProcessTaskCanceledException(TaskCanceledException ex)
        {
            if (ex.CancellationToken != null && !ex.CancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("A task was canceled because of timeout expiration.", ex);
            }

            throw ex;
        }

        private StringContent GetHttpStringContent(object data, string mediaType)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, mediaType);
        }

        private HttpRequestMessage BuildRequest(string serviceUrl, string auth, string mediaType, HttpMethod method, HttpContent content = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Headers.Authorization = !string.IsNullOrWhiteSpace(auth) ? new AuthenticationHeaderValue("Auth", auth) : null;
            if (content != null)
            {
                request.Content = content;
            }

            return request;
        }
    }
}
