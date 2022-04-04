using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetadataServerMockProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethodAmazingAsync()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");
            
            var requestAmazingCoin = new RestRequest("metadata/2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e", Method.Get);
            var responseAmazingCoin = await client.ExecuteAsync(requestAmazingCoin);

            var apiResponseAmazinCoing = JsonConvert.DeserializeObject<MetadataServerMockResponse>(responseAmazingCoin.Content);

            //Get status code: 200 OK
            Assert.AreEqual(responseAmazingCoin.StatusCode, System.Net.HttpStatusCode.OK);

            // Get Properties
            Assert.IsTrue(apiResponseAmazinCoing.subject.Contains("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e"));
            Assert.IsTrue(apiResponseAmazinCoing.name.value.Contains("Amazing Coin"));
            Assert.IsTrue(apiResponseAmazinCoing.url.signatures[0].publicKey.Contains("9b3c4095df24e08599115c750988b0a105043cd15b6521a123f21d7b92369a73"));
            Assert.IsTrue(apiResponseAmazinCoing.url.signatures[0].signature.Contains("1eefd452faba1b2ea3a897534c325ab9e5e546029d26377cf379d126f94ff8df8ecea6227da271e53feb61f993625bb6d57f967267a366b94c73ef535b698105"));
            
        }

        [TestMethod]
        public async Task TestMethodHappyAsync()
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

        [TestMethod]
        public async Task TestMethodPostAsync()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/");

            var requestPost = new RestRequest("metadata/query", Method.Post);

            requestPost.RequestFormat = DataFormat.Json;

            List<string> test = new List<string>(new string[] { "919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e",
        "789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f1" });

            requestPost.AddJsonBody(new MetadataServerMockRequestPOST() { subjects = "919e8a1922aaa764b1d66407c6f62244e77081215f385b60a62091494861707079436f696e"});

            var fullUrl = client.BuildUri(requestPost);

            var responsePost = await client.ExecuteAsync(requestPost);

            var apiResponsePost = JsonConvert.DeserializeObject<MetadataServerMockResponse>(responsePost.Content);

        }
    }
}
