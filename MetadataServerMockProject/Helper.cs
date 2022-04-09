using System.Collections.Generic;

namespace MetadataServerMockProject
{
    public class Helper
    {
        // Get the array list of the json file for the subjects element in the body of the POST to then deserialized
        public class JsonBodyList
        {
            public List<string> subjects { get; set; }
        }

        // Create a list of the elements inside the Root get it from responsePost.Content to then send it to deserialized
        public class Response1
        {
            public List<Root> subjects { get; set; }
        }
    }
}
