using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.MusicApi;
using Newtonsoft.Json;
using RestSharp;

namespace MusicPlayer.Utils
{
    public class RequestUtils
    {
        public static async Task<string> GetResponse(ZingMp3Api api, string path, Dictionary<string, string> qs)
        {
            var client = new RestClient(api.Url);
            var request = new RestRequest(path);

            // Add headers
            var cookie = await GetCookie(api);
            request.AddHeader("Cookie", cookie);

            // Add parameters
            request.AddParameter("ctime", api.Ctime);
            request.AddParameter("version", api.Version);
            request.AddParameter("apiKey", api.ApiKey);

            if (qs != null)
                foreach (var key in qs.Keys)
                    request.AddParameter(key, qs[key]);

            // Execute the request
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // json parse
                dynamic json = JsonConvert.DeserializeObject(response.Content);
                if (json.err == 0) return json.data.ToString();

                Console.WriteLine(json.msg);
                var tryAgain = await GetResponse(api, path, qs);
                return tryAgain;
            }

            if (ReloadConnection())
            {
                var tryAgain = await GetResponse(api, path, qs);
                return tryAgain;
            }

            throw new Exception(response.ErrorMessage);
        }

        public static async Task<string> GetCookie(ZingMp3Api api)
        {
            var client = new RestClient(api.Url);
            var request = new RestRequest(api.Url);

            // Execute the request
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // Get the Set-Cookie header
                var setCookieHeader = from x in response.Headers
                    where x.Name.ToLower().Equals("set-cookie")
                    select x.Value;

                return setCookieHeader.ToList()[1].ToString();
            }

            if (ReloadConnection())
            {
                var tryAgain = await GetCookie(api);
                return tryAgain;
            }

            throw new Exception(response.ErrorMessage);
        }

        private static bool ReloadConnection()
        {
            var dialogResult = MessageBox.Show("Connection lost. Try again?", "Connection lost",
                MessageBoxButtons.OK);
            return dialogResult == DialogResult.OK;
        }
    }
}