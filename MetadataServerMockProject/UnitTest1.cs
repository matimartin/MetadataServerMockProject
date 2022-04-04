using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MetadataServerMockProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var client = new RestClient("http://metadata-server-mock.herokuapp.com/metadata/");
            
            var request = new RestRequest("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e", Method.Get);
            var response = await client.ExecuteAsync(request);

            var apiResponse = JsonConvert.DeserializeObject<MetadataServerMockResponse>(response.Content);

            Console.WriteLine(response.Content);
            Console.WriteLine(apiResponse.url.signatures);
            Console.WriteLine(response.StatusCode);


            Assert.IsTrue(apiResponse.subject.Contains("2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e"));
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
