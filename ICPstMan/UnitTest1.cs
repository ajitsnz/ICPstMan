using ICPstMan.Model;
using Microsoft.VisualStudio.Services.Account;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;

namespace ICPstMan
{
    public class Tests
    {
        public static string baseurl = "http://localhost:8080/BillingOrder";

        [Test]
        public void create()
        {

 //         string data = "{\r\n  \"addressLine1\": \"abcd\",\r\n  \"addressLine2\": \"efgh\",\r\n  \"city\": \"string\",\r\n  \"comment\": \"string\",\r\n  \"email\": \"derik@gmail.com\",\r\n  \"firstName\": \"derik\",\r\n  \"id\": 0,\r\n  \"itemNumber\": 0,\r\n  \"lastName\": \"string\",\r\n  \"phone\": \"34567891\",\r\n  \"state\": \"AL\",\r\n  \"zipCode\": \"123456\"\r\n}";
            
            BillingOrder Order = new BillingOrder();

         /*Order.id = 3;
            Order.firstName = "kjflskgjsdl";
            Order.lastName = "knvn";
            Order.email = "nnmmm@gmail.com";
            Order.phone = "2323242567";
            Order.city = "hhjg";
            Order.zipCode = "123456";
            Order.addressLine1 = "jjkklll";
            Order.addressLine2 = "mkklllll";
            Order.itemNumber = 32;
            Order.comment = "ffghhjjiu";
            Order.state = "AL";*/

            string jsonstring = JsonConvert.DeserializeObject(Order);
            dynamic expected = JsonConvert.DeserializeObject(jsonstring);
           IRestResponse response = Post(jsonstring);
           dynamic actual = JsonConvert.DeserializeObject(response.Content);
           Assert.AreEqual(actual.firstName, expected.firstName); 
           Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }


    public IRestResponse Post(String PostData)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json",PostData , ParameterType.RequestBody);
         // IRestResponse response = client.Execute(request);
            return client.Execute(request);
         // Console.WriteLine(response.Content);
         //    dynamic res = JsonConvert.DeserializeObject(response.Content);
         //    dynamic actual = JsonConvert.DeserializeObject(Details);
            
          //  TestContext.WriteLine("firstname is : "+ res.firstName);
          //   TestContext.WriteLine("Email is : " + res.email);
            // Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
           // Assert.AreEqual(actual.firstName, res.firstName);
        }
        [Test]
        public void Get()
        {
            var client = new RestClient($"{baseurl}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void GetbyID()
        {
            var client = new RestClient($"{baseurl}/1");

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void Replace()
        {
            var client = new RestClient($"{baseurl}/3");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \r\n        \"firstName\": \"ravinder\",\r\n        \"lastName\": \"singh\",\r\n        \"email\": \"ravvisig@gmail.com\",\r\n        \"phone\": \"5675656353\",\r\n        \"city\": \"tuyqtuqsg\",\r\n        \"zipCode\": \"343542\",\r\n        \"addressLine1\": \"kjhjkgjgg\",\r\n        \"addressLine2\": \"khkuguyyfuf\",\r\n        \"itemNumber\": 0,\r\n        \"comment\": \"string\",\r\n        \"state\": \"AL\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void delete()
        {
            var client = new RestClient($"{baseurl}/10");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}