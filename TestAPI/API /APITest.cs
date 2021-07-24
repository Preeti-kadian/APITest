using System;
using System.Collections;
using System.IO;
using APITest.API.Model;
using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TestAPI.API;

namespace APITest
{
    public class Tests
    {
        BillingOrderAPI billingOrderAPI;



        [SetUp]
        public void Setup()
        {
            billingOrderAPI = new BillingOrderAPI();
        }

        [Test]
        public void TC_GetOrderById()
        {

            IRestResponse response = billingOrderAPI.GetOrderById("2");
            TestContext.WriteLine(response.Content);
        }

        [Test]
        public void TC_GetAllOrder()
        {

            IRestResponse response = billingOrderAPI.GetOrderAll();
            TestContext.WriteLine(response.Content);


        }


        [TestCaseSource(nameof(BillingOrderTestCaseData))]
        public void CreatOrderTestCase(BillingOrder expectedOrder, string status)
        {

            //Convert object to json
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);

            //Insert json body into post method
            IRestResponse response = billingOrderAPI.PostOrder(jsonBody);
            TestContext.WriteLine(response.Content); //in json format

            //Deserialize response
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            id = actualOrder.id + "";

            //Assertion
            expectedOrder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));

        }

        //Creating Test Case Data Object
        public static IEnumerable BillingOrderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new BillingOrder
                {
                    addressLine1 = "Test",
                    addressLine2 = "test1",
                    city = "QL",
                    comment = "hello",
                    email = "john@hotmail.com",
                    firstName = "John",
                    lastName = "Wojtowicz",
                    phone = "9876543221",
                    zipCode = "123456",
                    itemNumber = 1,
                    state = "AL"
                }, "valid").SetName("Create Billing Order Test Case");
                yield return new TestCaseData(new BillingOrder()).SetName("Default Test data");

                yield return new TestCaseData(new BillingOrder(email: "123"), "Invalid").SetName("Email validation");
            }
        }

        //Clean Up
        string id;
        [TearDown]
        public void CleanUp()
        {
            if (string.IsNullOrEmpty(id))
            {
                billingOrderAPI.DeleteOrderById(id);
            }
        }



        [Test]
        public void TC_PutOrderById()
        {
            //Input data into method
            //string body = "{\"addressLine1\": \"Strathfield\",\"addressLine2\": \"Street\", \"city\": \"Holroyd\", \"comment\": \"Newrecord\",\"email\": \"john_nel@gmail.com\",\"firstName\": \"John1\",\"id\": \"0\",\"itemNumber\": \"3\",\"lastName\": \"Nelson\",\"phone\": \"0987654432\",\"state\": \"AL\",\"zipCode\": \"879652\"}";

            var expectedOrder = new BillingOrder
            {
                addressLine1 = "Sydney",
                addressLine2 = "NSW",
                city = "Syd",
                comment = "hello",
                email = "Mike@hotmail.com",
                firstName = "Mike",
                lastName = "Wojtowicz",
                phone = "9876543221",
                zipCode = "123456",
                itemNumber = 1,
                state = "AL"
            };
            //Convert object to json
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);



            //Insert json body into post method
            IRestResponse response = billingOrderAPI.UpdateOrder("2", jsonBody);
            TestContext.WriteLine(response.Content);

            //Deserialize response
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            //Assertion
            Assert.AreEqual(expectedOrder.firstName, actualOrder.firstName);
        }



        [Test]
        public void TC_DeleteOrderById()
        {

            IRestResponse response = billingOrderAPI.GetOrderById("10");
            TestContext.WriteLine(response.Content);
        }

        [TestCaseSource(nameof(BillingOrderTestCaseCSV_Data))]
        public void CreateOrderCSVDataTestCase(BillingOrder expectedOrder, string status)
        {


            string jsonBody = JsonConvert.SerializeObject(expectedOrder);
            IRestResponse response = billingOrderAPI.PostOrder(jsonBody);
            TestContext.WriteLine(response.Content); 
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            id = actualOrder.id + "";

            //Assertion
            expectedOrder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));

        }

        //Creating Test Case Data Object
        public static IEnumerable BillingOrderTestCaseCSV_Data()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"TestData/billingOrderTestData.csv";
            using (var csv = new CsvReader(new StreamReader(Path.Combine(path), true)))
            {
                while (csv.ReadNextRecord())
                {
                    //test data
                    string description = csv[12];
                    BillingOrder order = new BillingOrder(
                        addressLine1: csv["addressline1"],
                        addressLine2: csv["addressline2"],
                       firstName: csv["firstname"],
                       email: csv["email"]
                      );
                    yield return new TestCaseData(order).SetName(description);


                }

            }
        }
    }
}










