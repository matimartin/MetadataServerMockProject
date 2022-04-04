using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace MetadataServerMockProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string html;
            string url = "http://metadata-server-mock.herokuapp.com/metadata/2048c7e09308f9138cef8f1a81733b72e601d016eea5eef759ff2933416d617a696e67436f696e";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<Signature>(html);


            Assert.IsTrue(apiResponse.publicKey.Contains("9b3c4095df24e08599115c750988b0a105043cd15b6521a123f21d7b92369a73"));
            Assert.IsTrue(apiResponse.signature.Contains("2bf86524f8cb8dff2d06ea291cccb6bd69cd31499d64eac5d661245d6c68ebe047515f0e119ddf08848d20e7b898dda59b1369bcb1dc59210049c76d00db9f04"));
        }
    }
}
