using System;
using RestSharp;

namespace TestAPI
{
    public class BillingOrderAPI
    {
        private readonly string baseUrl = "http://localhost:8080";

        public IRestResponse GetOrderById(string id)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetOrderAll()
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse PostOrder(string body)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Execute task
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse UpdateOrder(string id, string body)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.PUT);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Execute task
            IRestResponse response = client.Execute(request);
            return response;

        }

        public IRestResponse DeleteByOrder(string id)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);


            //Execute task
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
