using NUnit.Framework;
using RestSharp;

namespace TestAPI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostOrderTestCase(string body)
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

        [Test]
        public void GetOrderByIdTestCase(string id)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            return response;

        }

        [Test]
        public void GetAllOrderTestCase()
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            return response;
        }

        [Test]
        public void PutOrderTestCase(string id, string body)
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.PUT);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Execute task
            IRestResponse response = client.Execute(request);
            return response;

        }

        [Test]
        public void DeleteOrderByIdTestCase(string id)
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
