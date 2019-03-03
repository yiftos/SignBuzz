using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;


namespace SignBuzz
{
    public class User
    {
        string id;
        string userId;
        string name;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "userId")]
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Version]
        public string Version { get; set; }
    }
}
