using System.Collections.Generic;

namespace MetadataServerMockProject
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // json2csharp.com/
    public class MetadataServerMockResponse
    {
        public string subject;
        public Url url;
        public Name name;
        public Ticker tiker;
        public Decimals decimals;
        public Logo logo;
        public Description description;
        public Root root;
    }

    public class Signature
    {
        public string signature { get; set; }
        public string publicKey { get; set; }
    }

    public class Url
    {
        public int sequenceNumber { get; set; }
        public string value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Name
    {
        public int sequenceNumber { get; set; }
        public string value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Ticker
    {
        public int sequenceNumber { get; set; }
        public string value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Decimals
    {
        public int sequenceNumber { get; set; }
        public int value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Logo
    {
        public int sequenceNumber { get; set; }
        public string value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Description
    {
        public int sequenceNumber { get; set; }
        public string value { get; set; }
        public List<Signature> signatures { get; set; }
    }

    public class Root
    {
        public string subject { get; set; }
        public Url url { get; set; }
        public Name name { get; set; }
        public Ticker ticker { get; set; }
        public Decimals decimals { get; set; }
        public string policy { get; set; }
        public Logo logo { get; set; }
        public Description description { get; set; }
    }

}
