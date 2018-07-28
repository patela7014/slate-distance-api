using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DAL.Helpers
{
    public class GoogleDistanceMatrixApi
    {
        public class Data
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        public class Row
        {
            public Element[] Elements { get; set; }
        }

        public class Element
        {
            public string Status { get; set; }
            public string OriginAddress { get; set; }
            public string DestinationAddress { get; set; }
            public Data Duration { get; set; }
            public Data Distance { get; set; }
        }

        public class Response
        {
            public string Status { get; set; }

            [JsonProperty(PropertyName = "origin_addresses")]
            public string[] OriginAddresses { get; set; }

            [JsonProperty(PropertyName = "destination_addresses")]
            public string[] DestinationAddresses { get; set; }

            public Row[] Rows { get; set; }

        }

        public class BestOfficeData
        {
            public string Office { get; set; }
            public Element DistanceData { get; set; }
        }


        private string Key { get; set; }
        private string Url { get; set; }

        private string[] OriginAddresses { get; set; }
        private string[] DestinationAddresses { get; set; }

        public GoogleDistanceMatrixApi(string _Url, string _Key, string[] originAddresses, string[] destinationAddresses)
        {
            Key = _Key;
            Url = _Url;
            OriginAddresses = originAddresses;
            DestinationAddresses = destinationAddresses;

            if (string.IsNullOrEmpty(Url))
            {
                throw new Exception("GoogleDistanceMatrixApiUrl is not set in AppSettings.");
            }

            if (string.IsNullOrEmpty(Key))
            {
                throw new Exception("GoogleDistanceMatrixApiKey is not set in AppSettings.");
            }
        }

        public async Task<Response> GetResponse()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(GetRequestUrl());

                HttpResponseMessage response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("GoogleDistanceMatrixApi failed with status code: " + response.StatusCode);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Response>(content);
                }
            }
        }

        private string GetRequestUrl()
        {
            OriginAddresses = OriginAddresses.Select(HttpUtility.UrlEncode).ToArray();
            var origins = string.Join("|", OriginAddresses);
            DestinationAddresses = DestinationAddresses.Select(HttpUtility.UrlEncode).ToArray();
            var destinations = string.Join("|", DestinationAddresses);
            return $"{Url}&origins={origins}&destinations={destinations}&key={Key}";
        }
    }
}
