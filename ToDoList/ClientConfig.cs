using RestSharp;

namespace ToDoList {
    public static class ClientConfig<T> {
        const string url = "https://localhost:44354/api/values";
        private static RestClient restClient;
        public static IRestResponse Get(string endpoint, T toPassParameter) {
            var client = CreateRestClient();
            var request = new RestRequest(endpoint, Method.GET);
            string endpointParam = endpoint.Split('{', '}')[1];
            request.AddUrlSegment(endpointParam, toPassParameter);
            var response = client.Execute(request);
            return response;
        }

        public static IRestResponse Post(string endpoint, T body, string toPassParameter = null) {
            var client = CreateRestClient();
            var request = new RestRequest(endpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            if (!string.IsNullOrEmpty(toPassParameter)) {
                string endpointParam = endpoint.Split('{', '}')[1];
                request.AddUrlSegment(endpointParam, toPassParameter);
            }
            request.AddBody(body);
            var response = client.Execute(request);
            return response;
        }
        private static RestClient CreateRestClient() {
            if (restClient == null) {
                restClient = new RestClient(url);
            }
            return restClient;
        }
    }
}
