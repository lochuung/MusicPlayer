using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlayer.MusicApi;
using Newtonsoft.Json;
using RestSharp;

namespace MusicPlayer.Utils
{
    public class RequestUtils
    {
        public static async Task<string> GetResponse(ZingMp3Api api, string path, Dictionary<string, string> qs)
        {
            // var baseUrl = api.Url;
            // var url = baseUrl + path;
            // // add query params
            // url += "?";
            // if (qs != null)
            //     foreach (var key in qs.Keys)
            //         url += key + "=" + qs[key] + "&";
            // url += $"ctime={api.Ctime}&version={api.Version}&apiKey={api.ApiKey}";
            //
            //
            // var client = new RestClient();
            // var request = new RestRequest(url);
            //
            // // add headers
            // // request.AddHeader("Content-Type", "application/json");
            // request.AddHeader("Accept", "*/*");
            // request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            // string cookie = await GetCookie(api);
            // request.AddHeader("Cookie", cookie);
            //
            //
            // var response = await client.ExecuteAsync(request);
            // return response.Content;
            
            var client = new RestClient(api.Url);
            var request = new RestRequest(path, Method.Get);

            // Add headers
            string cookie = await GetCookie(api);
            request.AddHeader("Cookie", cookie);

            // Add parameters
            request.AddParameter("ctime", api.Ctime);
            request.AddParameter("version", api.Version);
            request.AddParameter("apiKey", api.ApiKey);
            
            if (qs != null)
            {
                foreach (var key in qs.Keys)
                {
                    request.AddParameter(key, qs[key]);
                }
            }

            // Execute the request
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // json parse
                dynamic json = JsonConvert.DeserializeObject(response.Content);
                if (json.err == 0)
                {
                    return json.data;
                }
                else
                {
                    Console.WriteLine(json.msg);
                    string tryAgain = await GetResponse(api, path, qs);
                    return tryAgain;
                }
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        public static async Task<string> GetCookie(ZingMp3Api api)
        {
            var client = new RestClient(api.Url);
            var request = new RestRequest(api.Url, Method.Get);

            // Execute the request
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // Get the Set-Cookie header
                var setCookieHeader = response.Headers.FirstOrDefault(h => h.Name == "Set-Cookie");

                if (setCookieHeader != null)
                {
                    // Split the Set-Cookie header into individual cookies
                    var cookies = setCookieHeader.Value.ToString().Split(',');

                    // Return the second cookie, if it exists
                    if (cookies.Length > 1)
                    {
                        return cookies[1];
                    }
                }

                throw new Exception("No Set-Cookie header found in the response.");
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }
    }
}