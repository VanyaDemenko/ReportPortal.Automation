using ReportPortal.Business.Extensions;
using RestSharp;

namespace ReportPortal.Business.Builders
{
    public class RequestBuilder
    {
        private static RestRequest _request;
        private static RestClient _client;
        private static Uri BaseServiceUri { get; set; }

        public RequestBuilder(string url, string authorizationToken)
        {
            _request = new RestRequest();
            BaseServiceUri = new Uri(url);
            WithHeader("Authorization", authorizationToken);
        }

        public RequestBuilder Uri(string url)
        {
            _client = new RestClient(BaseServiceUri.Append(url));
            return this;
        }

        public RequestBuilder Method(Method method)
        {
            _request.Method = method;
            return this;
        }

        public RequestBuilder WithHeader(string key, string value)
        {
            _request.AddHeader(key, value);
            return this;
        }

        public RequestBuilder WithBody(string requestBody)
        {
            _request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return this;
        }

        public ApiResponseExtensions Execute()
        {
            var response = _client.Execute(_request);
            return new ApiResponseExtensions(response);
        }
    }
}
