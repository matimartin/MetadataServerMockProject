//using RestSharp;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace MetadataServerMockProject
//{
//    public class EndpointBase
//    {
//        private string url;
//        private RestClient restClient;
//        private RestRequest restRequest;

//        private ConcurrentDictionary<string, string> testSettings;

//        private IRestResponse restResponse;

//        public EndpointBase()
//        {
//            url = GetURL();
//        }

//        private string GetURL()
//        {
//            // Deserializes the Test Config file - Usually testconfig.local.json
//            testSettings = Helper.ParseJsonFile<ConcurrentDictionary<string, string>>(SettingsObjects.TestConfigJson);

//            // Obtain the AppUrl property from the Test Config file
//            url = testSettings["AppUrl"];

//            if (url.Length == 0)
//                throw new Exception($"Unable to find AppUrl in config file");

//            return url;
//        }

//        public async Task<IRestResponse> PostRequest(string endPoint, Object body)
//        {
//            // Build the client object
//            restClient = new RestClient(url);

//            // Build the request object
//            restRequest = new RestRequest(endPoint, Method.POST);
//            restRequest.AddHeader("Accept", "*/*");
//            restRequest.RequestFormat = DataFormat.Json;
//            restRequest.AddJsonBody(body);

//            restResponse = await restClient.ExecuteAsync(restRequest);

//            // Execute the API request and receive the response
//            return restResponse;
//        }

//        /// <summary>
//        /// Sends an API POST request
//        /// </summary>
//        /// <param name="endPoint">End point of the API request</param>
//        /// <param name="loginresponse">Response object from Login request</param>
//        /// <param name="body">Body of the request</param>
//        /// <returns>Response received from API request</returns>
//        //public async Task<IRestResponse> PostRequest(string endPoint, LoginResponse loginresponse, Object body)
//        public async Task<IRestResponse> PostRequest(string endPoint, IList<RestResponseCookie> cookies, Object body)
//        {
//            string cookieName = "JSESSIONID";

//            // Search the Cookies by name and return Cookie value
//            var cookie = cookies.Where(myCookie => myCookie.HttpCookie.Name == cookieName);

//            var cookieValue = cookie.FirstOrDefault().Value;

//            // Build the client object
//            restClient = new RestClient(url);

//            // Build the request object
//            restRequest = new RestRequest(endPoint, Method.POST);
//            restRequest.AddHeader("content-type", "application/json");
//            restRequest.RequestFormat = DataFormat.Json;
//            restRequest.AddCookie(cookieName, cookieValue);
//            restRequest.AddJsonBody(body);

//            restResponse = await restClient.ExecuteAsync(restRequest);
//            Console.WriteLine("Request Body: " + restResponse.Request.Body.Value);
//            Console.WriteLine("Response Content: " + restResponse.Content);

//            // Execute the API request and receive the response
//            return restResponse;
//        }

//        public void VerifyPositiveTestResults()
//        {
//            if (restResponse == null)
//                throw new Exception($"Response is null.  Did you run an End Point Test first?");

//            // Verify the request completed successfully
//            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);

//            // Verify the Return Code property is empty
//            var returnCode = Helper.ParseJsonObject<ReturnCode>(restResponse.Content);
//            returnCode.RTRNCD.Should().BeEmpty();
//        }

//        public class ReturnCode
//        {
//            public string RTRNCD { get; set; }
//        }
//    }
//}
