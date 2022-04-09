using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using static MetadataServerMockProject.Helper;

namespace MetadataServerMockProject
{
    [TestClass]
    public class Tests
    {
        // GET
        [TestMethod]
        [Description("Get the whole Metadata")]
        public async Task TestMethodAmazing()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");

            var requestAmazingCoin = new RestRequest("metadata/2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e", Method.Get);
            var responseAmazingCoin = await client.ExecuteAsync(requestAmazingCoin);

            var apiResponseAmazinCoing = JsonConvert.DeserializeObject<MetadataServerMockResponse>(responseAmazingCoin.Content);

            // Get status code: 200 OK
            Assert.AreEqual(responseAmazingCoin.StatusCode, System.Net.HttpStatusCode.OK);

            // Validate the data is not null
            Assert.IsNotNull(responseAmazingCoin.Content);

            // Get Properties
            Assert.IsTrue(apiResponseAmazinCoing.subject.Contains("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e"));
            Assert.IsTrue(apiResponseAmazinCoing.name.value.Contains("Amazing Coin"));
        }

        // GET
        [TestMethod]
        [Description("Get Property")]
        public async Task TestMethodHappy()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");

            var requestHappyCoin = new RestRequest("metadata/919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e", Method.Get);
            var responseHappyCoin = await client.ExecuteAsync(requestHappyCoin);

            var apiResponseHappyCoin = JsonConvert.DeserializeObject<MetadataServerMockResponse>(responseHappyCoin.Content);

            //Get status code: 200 OK
            Assert.AreEqual(responseHappyCoin.StatusCode, System.Net.HttpStatusCode.OK);
            
            // Get Properties
            Assert.IsTrue(apiResponseHappyCoin.subject.Contains("919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e"));
            Assert.IsTrue(apiResponseHappyCoin.name.value.Contains("HappyCoin"));
            Assert.IsTrue(apiResponseHappyCoin.url.signatures[0].publicKey.Contains("db2c42a7c5b70d7e635b95c5864439f22ccd6639cc7bc128a88a804f149a4448"));
            Assert.IsTrue(apiResponseHappyCoin.url.signatures[0].signature.Contains("f18ddccdbf34ed909f36ca753ceecb2f5a1958cf49212e83ffbe6630228dc6d9818c36cb345156efddd3af6383edd4755bd827a3dc90a70476ac15bf5bdd7f06"));
        }

        // POST
        [TestMethod]
        [Description("Post Query (1st Curl)")]
        public async Task TestMethodPostCurl1()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");

            var resource = new RestRequest("metadata/query", Method.Post);

            resource.RequestFormat = DataFormat.Json;

            string values = "{subjects: ['919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e', '2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e']}";

            // Create the full url adding the json body get it from the class in the helper
            var fullUrl = resource.AddJsonBody(JsonConvert.DeserializeObject<JsonBodyList>(values));

            // excecute the full url to send the request to get the response
            var responsePost = await client.ExecuteAsync(fullUrl);

            // Verify the status code received is 200 OK
            Assert.AreEqual(responsePost.StatusCode, System.Net.HttpStatusCode.OK);

            // Deserialize the full reponse
            var apiResponsePost = JsonConvert.DeserializeObject<Response1>(responsePost.Content);

            // Verify data
            apiResponsePost.subjects[0].subject.Should().Contain("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e");
            apiResponsePost.subjects[1].name.signatures[0].signature.Contains("10c0761f6992768208644451cfd8bf77c1a09f8346a2381c22d87107aef107dee3db29d826b7332f0181546d30ad49c6d3338c70ce7aa082ae2dd54e78e9cf01");


            // Asserts
            Assert.AreEqual(apiResponsePost.subjects[0].name.value, "Amazing Coin", "Wrong name for this coin. should be:" + apiResponsePost.subjects[0].name.value);
            Assert.AreEqual(apiResponsePost.subjects[1].name.value, "HappyCoin", "Wrong name for this coin. Should be:" + apiResponsePost.subjects[1].name.value);
        }

        // POST
        [TestMethod]
        [Description("Post Query (1st Curl)")]
        public async Task TestMethodPostCurl2()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");

            var resource = new RestRequest("metadata/query", Method.Post);

            resource.RequestFormat = DataFormat.Json;

            string values = "{subjects: ['919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e', " +
                "'2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e', " +
                "'2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e']" +
                ", properties: ['HappyCoin', '13da4cffbbe65c5f6c867362cc4d6e0c3a3f2897ed5bc0ff3446ec588a68925dd82e02f11b3ff60e297f43ed7546fe58622dd845393aefaa6f577c93d0889200', 'https://happy.io']}";

            // Create the full url adding the json body get it from the class in the helper
            var fullUrl = resource.AddJsonBody(JsonConvert.DeserializeObject<JsonBodyList>(values));

            // excecute the full url to send the request to get the response
            var responsePost = await client.ExecuteAsync(fullUrl);

            // Verify the status code received is 200 OK
            Assert.AreEqual(responsePost.StatusCode, System.Net.HttpStatusCode.OK);

            // Deserialize the full reponse
            var apiResponsePost = JsonConvert.DeserializeObject<Response1>(responsePost.Content);

            // Verify data
            apiResponsePost.subjects[0].subject.Should().Contain("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e");
            apiResponsePost.subjects[1].policy.Should().Contain("82008201818200581c69303ce3536df260efddbc", "Polici # should be: " + apiResponsePost.subjects[1].policy);

            // Asserts
            Assert.AreEqual(apiResponsePost.subjects[1].decimals.value, 6, "Decimal value number should be: " + apiResponsePost.subjects[1].decimals.value);
            Assert.AreEqual(apiResponsePost.subjects[0].decimals.sequenceNumber, 1, "sequence Number should be: " + apiResponsePost.subjects[0].decimals.sequenceNumber);
        }
    }
}
