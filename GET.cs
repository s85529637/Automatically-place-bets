using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets
{
    public class GET
    {
        public async Task<string> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }

            return string.Empty;
        }

        public async Task<string> GetSendAsync(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "PostmanRuntime/7.36.3");
            var response = await client.SendAsync(request);
            
            response.EnsureSuccessStatusCode();
            if (response.Content != null)
            {
                var resurl = response.RequestMessage.RequestUri.ToString();
                return resurl;
            }
              return string.Empty;

        }
    }
}
